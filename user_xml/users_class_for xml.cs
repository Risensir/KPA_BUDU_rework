using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_BUDU_rework
{
    internal static class users_class_for_xml
    {
        public class USER_struct
        {
            public string name;
            public byte var;
            public bool count;
            public bool crc;
            public string type;
            public string var_string;
        }
        public class USER_temp_tlm_data
        {
            public int min_plus_var;
            public int max_plus_var;
            public int min_minus_var;
            public int max_minus_var;
        }

        public class USER_uint_tlm_data
        {
            public int max_var;
            public int min_var;
        }

        public class USER_Bool_tlm_data
        {
            public string name;
            public int index;
            public int index_flag = -1;
        }
        public class USER_struct_telemetry
        {
            public string name;
            public byte var;
            public bool count;
            public bool crc;
            public string type;
            public string var_string;
            public List<USER_tlm_data> user_tlm_data = new List<USER_tlm_data>();
        }

        public class USER_tlm_data
        {
            public string name;

            public int size;
            public int index_graph;
            public int division;
            public int mult;
            public List<USER_temp_tlm_data> user_temp_tlm_data = new List<USER_temp_tlm_data>();
            public List<USER_Bool_tlm_data> user_bool_tlm_data = new List<USER_Bool_tlm_data>();
            public List<USER_uint_tlm_data> user_uint_tlm_data = new List<USER_uint_tlm_data>();
        }
        public static int convert_str_int(string str)
        {
            if (str.Length % 2 != 0)
                str = "0" + str;

            int temp = 0;

            for (int len = str.Length - 1; len > 0; len -= 2)
            {
                string st2 = new string(new char[] { str[len - 1], str[len] });
                temp |= Convert.ToByte(st2, 16) << ((str.Length - len - 1) * 4);
            }
            return temp;
        }
    }
}
