using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_BUDU_rework
{
    internal static class user_Time
    {
        public static string get_time_string()
        {
            string str = "";

            if (DateTime.Now.Hour < 10)
                str += "0" + DateTime.Now.Hour.ToString();
            else
                str += DateTime.Now.Hour.ToString();

            str += ":";

            if (DateTime.Now.Minute < 10)
                str += "0" + DateTime.Now.Minute.ToString();
            else
                str += DateTime.Now.Minute.ToString();

            str += ":";

            if (DateTime.Now.Second < 10)
                str += "0" + DateTime.Now.Second.ToString();
            else
                str += DateTime.Now.Second.ToString();

            return str;
        }
    }
}
