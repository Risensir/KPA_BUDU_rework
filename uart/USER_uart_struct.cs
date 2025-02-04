using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KPA_BUDU_rework.USER_uart_struct;

namespace KPA_BUDU_rework
{
    internal class USER_uart_struct
    {
        public delegate void PRINT_Handler(string str);
        public event PRINT_Handler PrintHandler;

        public delegate void TELEMETRY_Handler(List<byte> data);
        public event TELEMETRY_Handler TelemetryHandler;


        public byte ADDRESS_BUDU = 0x03;
        public byte ADDRESS_BKU = 0x01;
        public class uart_protocol
        {
            public readonly byte header = 0xAA;
            public flags flag = new flags();
            public byte flag_val = 0xFF;
            public byte address_abonent;
            public byte reserved = 0x00;
            public byte length_data;
            public List<byte> data = new List<byte>();
            public byte crc;

            public class flags
            {
                public bool obmen_3_lvl = false;
                public bool obmen_2_lvl = false;
                public bool obmen_1_lvl = true;
                public bool neispravn_abonent = false;
                public bool abonent_zanyat = false;
                public bool error_in_msg = false;
                public bool write_read;
                public bool take_get;
                public byte get_byte()
                {
                    byte data = 0;
                    data |= Convert.ToByte(obmen_3_lvl);
                    data |= (byte)(Convert.ToByte(obmen_2_lvl) << 1);
                    data |= (byte)(Convert.ToByte(obmen_1_lvl) << 2);
                    data |= (byte)(Convert.ToByte(neispravn_abonent) << 3);
                    data |= (byte)(Convert.ToByte(abonent_zanyat) << 4);
                    data |= (byte)(Convert.ToByte(error_in_msg) << 5);
                    data |= (byte)(Convert.ToByte(write_read) << 6);
                    data |= (byte)(Convert.ToByte(take_get) << 7);
                    return data;
                }
                private void clean_fields()
                {
                    neispravn_abonent = false;
                    abonent_zanyat = false;
                    error_in_msg = false;
                    write_read = false;
                    take_get = false;
                }

                public byte get_command_write()
                {
                    clean_fields();
                    write_read = true;
                    take_get = true;
                    return get_byte();//0xc4
                }

                public byte get_command_read()
                {
                    clean_fields();
                    take_get = true;
                    return get_byte();
                }

                public byte get_answer_complete()
                {
                    clean_fields();
                    write_read = true;
                    return get_byte();
                }

                public byte get_answer_tlm()
                {
                    clean_fields();
                    return get_byte();
                }
            };
            public void set_flag(byte data)
            {
                if ((data & 1) == 1)
                    flag.obmen_3_lvl = true;
                else
                    flag.obmen_3_lvl = false;

                if ((data & (1<<1)) == (1<<1))
                    flag.obmen_2_lvl = true;
                else
                    flag.obmen_2_lvl = false;

                if ((data & (1<<2)) == (1<<2))
                    flag.obmen_1_lvl = true;
                else
                    flag.obmen_1_lvl = false;

                if ((data & (1<<3)) == (1<<3))
                    flag.neispravn_abonent = true;
                else
                    flag.neispravn_abonent = false;

                if ((data & (1<<4)) == (1<<4))
                    flag.abonent_zanyat = true;
                else
                    flag.abonent_zanyat = false;

                if ((data & (1<<5)) == (1<<5))
                    flag.error_in_msg = true;
                else
                    flag.error_in_msg = false;

                if ((data & (1<<6)) == (1<<6))
                    flag.write_read = true;
                else
                    flag.write_read = false;

                if ((data & (1<<7)) == (1<<7))
                    flag.take_get = true;
                else
                    flag.take_get = false;
            }
        }

        private byte get_crc_uart(uart_protocol msg)
        {
            List<byte> crc_val = new List<byte>();
            crc_val.Add(msg.header);
            crc_val.Add(msg.flag.get_byte());
            crc_val.Add(msg.address_abonent);
            crc_val.Add(msg.reserved);
            crc_val.Add(msg.length_data);
            crc_val.AddRange(msg.data);
            return crc.crc_out(crc_val.ToArray());
        }

        public List<byte> construct_command(List<byte> data)
        {
            uart_protocol msg = new uart_protocol();
            List<byte> out_msg = new List<byte>();

            msg.length_data = (byte)data.Count();
            msg.address_abonent = ADDRESS_BUDU;
            msg.data = data;
           
            out_msg.Add(msg.header);
            out_msg.Add(msg.flag.get_command_write());
            out_msg.Add(msg.address_abonent);
            out_msg.Add(msg.reserved);
            out_msg.Add(msg.length_data);
            out_msg.AddRange(msg.data);
            out_msg.Add(get_crc_uart(msg));
            return out_msg;
        }

        public async Task read_answer(Queue<byte> q_data)
        {
            uart_protocol msg = new uart_protocol();
            List<byte> arr_crc = new List<byte>();

            while (q_data.Dequeue() != msg.header);
            try
            {
                msg.flag_val = q_data.Dequeue();
                msg.set_flag(msg.flag_val);
                msg.address_abonent = q_data.Dequeue();
                msg.reserved = q_data.Dequeue();
                msg.length_data = q_data.Dequeue();
                int i = 0;
                while ((i < msg.length_data) && ((q_data.Count() > 0)))
                {
                    msg.data.Add(q_data.Dequeue());
                    i++;
                }
                byte crc_temp = q_data.Dequeue();
                if (crc_temp == get_crc_uart(msg))
                {
                    if (msg.address_abonent != ADDRESS_BKU)
                    {
                        PrintHandler("Получен некорректный адрес: " + BitConverter.ToString(new byte[] {msg.address_abonent}));
                    }

                    if (msg.flag_val == msg.flag.get_answer_complete())
                    {
                        PrintHandler("Команда " + BitConverter.ToString(msg.data.ToArray()) + " выполнена" + Environment.NewLine);
                    }
                    else 
                    {
                        if (msg.flag_val == msg.flag.get_answer_tlm())
                        {
                            TelemetryHandler(msg.data);
                            PrintHandler("Получена телеметрия" + Environment.NewLine);
                        }
                        else
                        {
                            if ((msg.flag_val & (1<<3)) == (1 << 3))
                                PrintHandler("Неисправность абонента" + Environment.NewLine);
                            if ((msg.flag_val & (1<<4)) == (1 << 4))
                                PrintHandler("Абонент занят" + Environment.NewLine);
                            if ((msg.flag_val & (1<<4)) == (1 << 4))
                                PrintHandler("Ошибка в сообщении" + Environment.NewLine);
                        }
                    }
                }
                else
                {
                    PrintHandler(" CRC не совпал" +  "должно: " + BitConverter.ToString(new byte [] { get_crc_uart(msg) }) +  " пришло: " + BitConverter.ToString(new byte[] { crc_temp })  + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                PrintHandler(e.Message + Environment.NewLine);
            }
        }
    }
}
