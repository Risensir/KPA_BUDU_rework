using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_BUDU_rework
{
    public class user_tlm
    {
        public delegate void SHOW_TELEMETRY_Handler(List<param_val> tlm);
        public event SHOW_TELEMETRY_Handler ShowTelemetryHandler;
        public class param_val
        {
            public string name;
            public string short_name;
            public string type;
            public double crit_var;
            public double max;
            public double min;
            public double delta;
            public double val = 0;
            public param_val(string name ,string type,double crit_var, double max, double min , double delta)
            {
                this.name = name;
                this.type = type;
                this.crit_var= crit_var;
                this.max=max;
                this.min=min;
                this.delta = delta;
            }
            public param_val(string name, string type, string short_name)
            {
                this.name = name;
                this.type = type;
                this.short_name= short_name;
            }
        }

        public List<param_val> list_tlm = new List<param_val>();
        public user_tlm() 
        {
            list_tlm.Add(new param_val("Готовность БУДУ", "bool", "ГБУДУ"));
            list_tlm.Add(new param_val("Работа клапанов МГР", "bool", "КУ МГР"));
            list_tlm.Add(new param_val("Работа клапанов БПК", "bool", "КУ БПК"));
            list_tlm.Add(new param_val("Работа поджигного электрода", "bool","ЭП"));
            list_tlm.Add(new param_val("Подача питания на анод СПД", "bool" ,"АД" ));
            list_tlm.Add(new param_val("Работа двигателя СПД", "bool", "СПД"));
            list_tlm.Add(new param_val("Работа нак.и рег. расх. МГР", "bool","К"));
            list_tlm.Add(new param_val("Срабатывание токовой защиты", "bool", "СТЗА"));
            list_tlm.Add(new param_val("Работа в режиме регул.", "bool", "РРД"));
            list_tlm.Add(new param_val("Работа осн. БПК", "bool", "БПК"));
            list_tlm.Add(new param_val("Подпитка магнитн. катушек", "bool","МК"));
            list_tlm.Add(new param_val("Открытие вых. БПК", "bool","КУВЫХ"));
            list_tlm.Add(new param_val("Работа нагревателя 1", "bool", "НАГ1"));
            list_tlm.Add(new param_val("Работа нагревателя 2", "bool", "НАГ2"));
            list_tlm.Add(new param_val("Ток анода", "float", 1, 1.5, 0 ,0.01));
            list_tlm.Add(new param_val("Напряжение анода", "float", 300, 350,0, 1));
            list_tlm.Add(new param_val("СКО тока анода", "float", 0, 1, 0, 0.01));
            list_tlm.Add(new param_val("Ток рег. расх", "float", 1.4, 5, 0, 0.01));
            list_tlm.Add(new param_val("Ток магнита", "float", 2.4, 3, 0, 0.01));
            list_tlm.Add(new param_val("Ток накала", "float", 11.4, 12, 0, 0.1));
            list_tlm.Add(new param_val("Темп. Накала", "float", 0, 100, -40, 1));
            list_tlm.Add(new param_val("Темп. Анода", "float", 0, 100, -40, 1));
            list_tlm.Add(new param_val("Темп. Рег. расхода", "float", 0, 100, -40, 1));
        }
        public void construct_telemetry_list(List<byte> data)
        {
            BitArray bitarray = new BitArray(new byte [] {data[0] , data[1]});
            for (int i = 0; i < bitarray.Length; i++)
            {
                if (bitarray[i] == true)
                    list_tlm[i].val = 1;
                else
                    list_tlm[i].val = 0;
            }
            list_tlm[14].val = data[2];                 //ТАД
            list_tlm[15].val = data[3] << 8 | data[4];  //НАД
            list_tlm[16].val = data[5];                 //КТАД
            list_tlm[17].val = data[6]<<8 | data[7];    //ТТРД
            list_tlm[18].val = data[8]<<8 | data[9];    //ТКМД
            list_tlm[19].val = data[10];                 //ТНД

            if ((data[11] & 0x8) != 0)                  //ТЕМП НМ
            {
                list_tlm[20].val = (data[11] & 0x7F) * -1;
            }else
                list_tlm[20].val = data[11];

            if ((data[12] & 0x8) != 0)                  //ТЕМП АП
            {
                list_tlm[21].val = (data[12] & 0x7F) * -1;
            }
            else
                list_tlm[21].val = data[12];

            if ((data[13] & 0x8) != 0)                  //ТЕМП РР
            {
                list_tlm[22].val = (data[13] & 0x7F) * -1;
            }
            else
                list_tlm[22].val = data[13];

            for (int i = 14; i < list_tlm.Count; i++)
                list_tlm[i].val *= list_tlm[i].delta; 
        }
    }
}
