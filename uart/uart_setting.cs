using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_BUDU_rework
{
    public partial class uart_setting : UserControl
    {
        public delegate void PRINT_Handler(string str);
        public event PRINT_Handler PrintHandler;
        public delegate void TELEMETRY_Handler(List<byte> data);
        public event TELEMETRY_Handler TelemetryHandler;
        public delegate void ASK_TELEMETRY_Handler();
        public event ASK_TELEMETRY_Handler AskTelemetry;
        private class Uart_setting_class
            {
                public string port_name;
                public int baudrate;
                public Parity parity;
                public int data_bits;
                public StopBits stop_bits;

                public Uart_setting_class()
                {
                    this.port_name = null;
                    this.baudrate = 115200;
                    this.parity = Parity.Even;
                    this.stop_bits = StopBits.One;
                    this.data_bits = 8;
                }
            }
            public SerialPort serial_port = new SerialPort();
            private Uart_setting_class uart_setting_class = new Uart_setting_class();

            public uart_setting()
            {
                InitializeComponent();

            //serial_port.Disposed
                serial_port.DataReceived += DataRecievedHandler;

                uart_baudrate_combobox.SelectedIndexChanged +=Uart_baudrate_combobox_SelectedIndexChanged;
                uart_parity_combobox.SelectedIndexChanged +=Uart_parity_combobox_SelectedIndexChanged;
                uart_data_bits_combobox.SelectedIndexChanged +=Uart_data_bits_combobox_SelectedIndexChanged;
                uart_stop_combobox.SelectedIndexChanged +=Uart_stop_combobox_SelectedIndexChanged;
                uart_port_combobox.SelectedIndexChanged +=Uart_port_combobox_SelectedIndexChanged;
                uart_port_combobox.Click += Uart_port_combobox_click_Hanlder;
                uart_open_close.Click += Uart_open_close_Click;

                uart_baudrate_combobox.Text = uart_setting_class.baudrate.ToString();
                uart_parity_combobox.Text = uart_setting_class.parity.ToString();
                uart_data_bits_combobox.Text = uart_setting_class.data_bits.ToString();
                uart_stop_combobox.Text = uart_setting_class.stop_bits.ToString();

            //uart_baudrate_combobox.Items.AddRange(new object[] {
            //"110",
            //"300",
            //"1200",
            //"2400",
            //"4800",
            //"9600",
            //"19200",
            //"38400",
            //"57600",
            //"115200",
            //"921600"});

            //    uart_parity_combobox.Items.AddRange(new object[] {
            //"Even",
            //"Odd",
            //"Mark",
            //"None"});

            //    uart_data_bits_combobox.Items.AddRange(new object[] {
            //"5",
            //"6",
            //"7",
            //"8"});

            //    uart_stop_combobox.Items.AddRange(new object[] {
            //"1",
            //"2"});
        }

        
        private void Uart_port_combobox_click_Hanlder(object sender, EventArgs e)
            {
                System.Windows.Forms.ComboBox box = (sender as System.Windows.Forms.ComboBox);
                string[] ports = SerialPort.GetPortNames();

                box.Items.Clear();
                box.Items.AddRange(ports);
            }
            private void Uart_port_combobox_SelectedIndexChanged(object sender, EventArgs e)
            {
                System.Windows.Forms.ComboBox box = (sender as System.Windows.Forms.ComboBox);
                box.Text = box.SelectedItem.ToString();

                if (box.SelectedItem != null)
                    this.uart_setting_class.port_name = box.SelectedItem.ToString().Split(' ')[0];
            }

            private void Uart_baudrate_combobox_SelectedIndexChanged(object sender, EventArgs e)
            {
                System.Windows.Forms.ComboBox box = (sender as System.Windows.Forms.ComboBox);
                switch (box.SelectedItem.ToString())
                {
                    case "110":
                        uart_setting_class.baudrate = 110;
                        break;
                    case "300":
                        uart_setting_class.baudrate = 300;
                        break;
                    case "1200":
                        uart_setting_class.baudrate = 1200;
                        break;
                    case "2400":
                        uart_setting_class.baudrate = 2400;
                        break;
                    case "4800":
                        uart_setting_class.baudrate = 4800;
                        break;
                    case "9600":
                        uart_setting_class.baudrate = 9600;
                        break;
                    case "19200":
                        uart_setting_class.baudrate = 19200;
                        break;
                    case "38400":
                        uart_setting_class.baudrate = 38400;
                        break;
                    case "57600":
                        uart_setting_class.baudrate = 576000;
                        break;
                    case "115200":
                        uart_setting_class.baudrate = 115200;
                        break;
                    case "921600":
                        uart_setting_class.baudrate = 921600;
                        break;
                    default:
                        uart_setting_class.baudrate = 115200;
                        break;
                }
            }

            private void Uart_data_bits_combobox_SelectedIndexChanged(object sender, EventArgs e)
            {
                System.Windows.Forms.ComboBox box = (sender as System.Windows.Forms.ComboBox);
                switch (box.SelectedItem.ToString())
                {
                    case "5":
                        uart_setting_class.data_bits = 5;
                        break;
                    case "6":
                        uart_setting_class.data_bits = 6;
                        break;
                    case "7":
                        uart_setting_class.data_bits = 7;
                        break;
                    case "8":
                        uart_setting_class.data_bits = 8;
                        break;
                    default:
                        uart_setting_class.data_bits = 8;
                        break;
                }
            }

        private void Uart_parity_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox box = (sender as System.Windows.Forms.ComboBox);
            switch (box.SelectedItem.ToString())
            {
                case "Even":
                    uart_setting_class.parity = Parity.Even;
                    break;
                case "None":
                    uart_setting_class.parity = Parity.None;
                    break;
                case "Odd":
                    uart_setting_class.parity = Parity.Odd;
                    break;
                case "Mark":
                    uart_setting_class.parity = Parity.Mark;
                    break;
                default:
                    uart_setting_class.parity = Parity.Even;
                    break;
            }
        }
        private void Uart_stop_combobox_SelectedIndexChanged(object sender, EventArgs e)
            {
                System.Windows.Forms.ComboBox box = (sender as System.Windows.Forms.ComboBox);
                switch (box.SelectedItem.ToString())
                {
                    case "1":
                        uart_setting_class.stop_bits = StopBits.One;
                        break;
                    case "2":
                        uart_setting_class.stop_bits = StopBits.Two;
                        break;
                    default:
                        uart_setting_class.stop_bits = StopBits.One;
                        break;
                }
            }

            private void Uart_open_close_Click(object sender, EventArgs e)
            {
                System.Windows.Forms.Button but = (sender as System.Windows.Forms.Button);

            if (serial_port.IsOpen)
            {
                serial_port.Close();
                but.Text = "Запустить";
                but.ForeColor = Color.ForestGreen;
                uart_check_timer.Enabled = false;
            }
            else
            {

                if (uart_setting_class.port_name == null)
                {
                    PrintHandler("Необходимо выбрать порт" + Environment.NewLine);

                }
                else
                {
                    serial_port.PortName = uart_setting_class.port_name;
                    serial_port.BaudRate = uart_setting_class.baudrate;
                    serial_port.StopBits = uart_setting_class.stop_bits;
                    serial_port.DataBits = uart_setting_class.data_bits;
                    serial_port.Parity = uart_setting_class.parity;

                    try
                    {
                        //but.Text = "Закрыть";
                        //but.ForeColor = Color.DarkRed;
                        serial_port.WriteTimeout = 500;
                        serial_port.Open();
                        PrintHandler("Порт " + serial_port.PortName + " открыт" + Environment.NewLine);
                        but.Text = "Закрыть";
                        but.ForeColor = Color.DarkRed;
                        uart_check_timer.Enabled = true;
                    }
                    catch (Exception t)
                    {
                        PrintHandler("Ошибка с :" + serial_port.PortName + ": " + t.Message + Environment.NewLine);
                    }
                }
            }
            }

        public void UART_WRITE(byte[] data)
        {
            try
            {
                serial_port.Write(data.ToArray(), 0, data.Count());
            }
            catch (Exception e)
            { 
                 PrintHandler(e.ToString() + Environment.NewLine);
            }
        }
        private void DataRecievedHandler(object sender , SerialDataReceivedEventArgs e)
        { 
            byte[] buffer = new byte[40];
            int len;
            try
            {
                len = (sender as SerialPort).BytesToRead;

                if (len < buffer.Length)
                {
                    (sender as SerialPort).Read(buffer, 0, len);
                    Queue<byte> RS485_data = new Queue<byte>();

                    for(int i = 0 ; i < len; i++)
                        RS485_data.Enqueue(buffer[i]);

                    USER_uart_struct uart_struct = new USER_uart_struct();
                    uart_struct.PrintHandler += Uart_struct_PrintHandler;
                    uart_struct.TelemetryHandler += Uart_struct_TelemetryHandler;
                    uart_struct.read_answer(RS485_data);
                }
                else
                    (sender as SerialPort).DiscardInBuffer();
            }
            catch (Exception t) {
                PrintHandler(t.Message + Environment.NewLine);
            }
        }

        private void Uart_struct_TelemetryHandler(List<byte> data)
        {
            TelemetryHandler(data);
        }
        private void Uart_struct_PrintHandler(string str)
        {
            PrintHandler(str + Environment.NewLine);
        }

        private void uart_check_timer_Tick(object sender, EventArgs e)
        {
            if (!serial_port.IsOpen)
            {
                uart_open_close.Text = "Запустить";
                uart_open_close.ForeColor = Color.ForestGreen;
                uart_check_timer.Enabled = false;
            }
        }

        private void uart_start_tlm_but_Click(object sender, EventArgs e)
        {
            Telemetry_request_timer.Enabled = true;
        }

        private void Telemetry_request_timer_Tick(object sender, EventArgs e)
        {
            AskTelemetry();
        }

        private void uart_stop_tlm_but_Click(object sender, EventArgs e)
        {
            Telemetry_request_timer.Enabled = false;
            saver.deinit_saver();
        }
    }
    }
