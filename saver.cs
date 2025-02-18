using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_BUDU_rework
{
    static class saver
    {
        public delegate void PRINT_Handler(string str);
        public static event PRINT_Handler PrintHandler;

        public static StreamWriter log_file;
        public static bool isInit = false;
        static saver()
        {  
        }

        public static void init_saver(List<user_tlm.param_val> list_tlm)
        {
            int i = 0;
            string path_log_file = "LOGS/GRAPH_LOGS/" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString();
            while (File.Exists(path_log_file + "_" + i.ToString() + ".txt"))
                i++;

            path_log_file += "_" + i.ToString() + ".txt";
            log_file = new StreamWriter(path_log_file);

            string label = "Время";
            foreach (user_tlm.param_val param in list_tlm)
                label +=  "\t" + param.name;

            log_file.WriteLine(label);
            isInit = true;
        }

        public static void deinit_saver()
        {
            log_file.Close();
            isInit = false;
        }
        //delegate Task SaveTelemetry_delegate(List<user_tlm.param_val> list_tlm, float time);
        public static void SaveTelemetry(List<user_tlm.param_val> list_tlm)
        {
            string _string_ = "";

            foreach (user_tlm.param_val param in list_tlm)
            {
               if (param.name != "reserved")
                _string_ += "\t" + param.val;
            }

            string time_string = "";

            if (DateTime.Now.Hour < 10)
                time_string += "0" + DateTime.Now.Hour.ToString();
            else
                time_string += DateTime.Now.Hour.ToString();

            time_string += ":";

            if (DateTime.Now.Minute < 10)
                time_string += "0" + DateTime.Now.Minute.ToString();
            else
                time_string += DateTime.Now.Minute.ToString();

            time_string += ":";

            if (DateTime.Now.Second < 10)
                time_string += "0" + DateTime.Now.Second.ToString();
            else
                time_string += DateTime.Now.Second.ToString();

            time_string += ":";
            time_string += DateTime.Now.Millisecond.ToString();

            try
            {
                log_file.WriteLineAsync(time_string + _string_);
            }
            catch(Exception e) 
            {
                PrintHandler(e.Message + Environment.NewLine);
            }
        }
    }
}
