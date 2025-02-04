using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KPA_BUDU_rework
{
    internal static class XML_reader
    {
        public delegate void PRINT_Handler(string str);
        public static event PRINT_Handler PrintHandler;

        public static List<users_class_for_xml.USER_struct> STRUCT_ANSWER = new List<users_class_for_xml.USER_struct>();
        public static List<users_class_for_xml.USER_struct> STRUCT_COMMAND = new List<users_class_for_xml.USER_struct>();
        public static List<users_class_for_xml.USER_struct_telemetry> STRUCT_TELEMETRY = new List<users_class_for_xml.USER_struct_telemetry>();

        public static void XML_STRUCT_COMMAND_READ(string FILE)
        {
            // ..................................................................Создание списка кнопок , основанных на раннее объявленном методе


            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(FILE);
            }
            catch (Exception t)
            {
                PrintHandler(t.Message);
            }
         
                XmlElement element = xml.DocumentElement;


            // int i = 0, j = 0, k = 0;
            if (element!= null)
            {
                //.......................................................................Считывание документа XML
                foreach (XmlNode xnode in element)
                {
                    users_class_for_xml.USER_struct user_struct = new users_class_for_xml.USER_struct();
                    string name = xnode.Attributes.GetNamedItem("name").Value;
                    user_struct.name = name;

                    if (xnode.Attributes.GetNamedItem("crc").Value == "y")
                        user_struct.crc = true;
                    else
                        user_struct.crc = false;

                    user_struct.type = xnode.Attributes.GetNamedItem("type").Value;

                    if (xnode.Attributes.GetNamedItem("count").Value == "y")
                        user_struct.count = true;
                    else
                        user_struct.count = false;


                    if (xnode.ChildNodes.Count == 0)
                    {
                        if ((xnode.Attributes.GetNamedItem("var").Value != "command") & (xnode.Attributes.GetNamedItem("var").Value != "iterable") & (xnode.Attributes.GetNamedItem("var").Value != "КС"))
                        {
                            user_struct.var = Convert.ToByte(xnode.Attributes.GetNamedItem("var").Value, 16);
                        }
                        else
                        {
                            user_struct.var_string = xnode.Attributes.GetNamedItem("var").Value;
                        }
                    }
                    else
                    {
                        byte temp_var = 0;
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "bit")
                            {
                                if (childnode.Attributes.GetNamedItem("var").Value == "1")
                                    temp_var |= (byte)(1 << int.Parse(childnode.Attributes.GetNamedItem("index").Value));
                            }
                        }
                        user_struct.var = temp_var;
                    }
                    STRUCT_COMMAND.Add(user_struct);
                }
            }

        }

        public static void XML_STRUCT_ANSWER_READ(string FILE)
        {
            // ..................................................................Создание списка кнопок , основанных на раннее объявленном методе

            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(FILE);
            }
            catch (Exception t)
            {
                PrintHandler(t.Message);
            }

            XmlElement element = xml.DocumentElement;


            // int i = 0, j = 0, k = 0;
            if (element!= null)
            {
                //.......................................................................Считывание документа XML
                foreach (XmlNode xnode in element)
                {
                    switch (xnode.Name)
                    {
                        case "answer":
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                users_class_for_xml.USER_struct user_struct = new users_class_for_xml.USER_struct();
                                string name = childnode.Attributes.GetNamedItem("name").Value;
                                user_struct.name = name;

                                if (childnode.Attributes.GetNamedItem("crc").Value == "y")
                                    user_struct.crc = true;
                                else
                                    user_struct.crc = false;

                                user_struct.type = childnode.Attributes.GetNamedItem("type").Value;

                                if (childnode.Attributes.GetNamedItem("count").Value == "y")
                                    user_struct.count = true;
                                else
                                    user_struct.count = false;


                                if (childnode.ChildNodes.Count == 0)
                                {
                                    if ((childnode.Attributes.GetNamedItem("var").Value != "command") & (childnode.Attributes.GetNamedItem("var").Value != "iterable") & (childnode.Attributes.GetNamedItem("var").Value != "КС"))
                                    {
                                        user_struct.var = Convert.ToByte(childnode.Attributes.GetNamedItem("var").Value, 16);
                                    }
                                    else
                                    {
                                        user_struct.var_string = childnode.Attributes.GetNamedItem("var").Value;
                                    }
                                }
                                else
                                {
                                    byte temp_var = 0;
                                    foreach (XmlNode node in childnode.ChildNodes)
                                    {
                                        if (node.Name == "bit")
                                        {
                                            if (node.Attributes.GetNamedItem("var").Value == "1")
                                                temp_var |= (byte)(1 << int.Parse(node.Attributes.GetNamedItem("index").Value));
                                        }
                                    }
                                    user_struct.var = temp_var;
                                }
                                STRUCT_ANSWER.Add(user_struct);
                            }
                            break;
                        case "telemetry":
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                users_class_for_xml.USER_struct_telemetry user_struct = new users_class_for_xml.USER_struct_telemetry();
                                string name = childnode.Attributes.GetNamedItem("name").Value;
                                user_struct.name = name;

                                if (childnode.Attributes.GetNamedItem("crc").Value == "y")
                                    user_struct.crc = true;
                                else
                                    user_struct.crc = false;

                                if (childnode.Attributes.GetNamedItem("type") != null)
                                    user_struct.type = childnode.Attributes.GetNamedItem("type").Value;

                                if (childnode.Attributes.GetNamedItem("count").Value == "y")
                                    user_struct.count = true;
                                else
                                    user_struct.count = false;


                                if (childnode.ChildNodes.Count == 0)
                                {
                                    if ((childnode.Attributes.GetNamedItem("var").Value != "command") & (childnode.Attributes.GetNamedItem("var").Value != "iterable") & (childnode.Attributes.GetNamedItem("var").Value != "КС"))
                                    {
                                        user_struct.var = Convert.ToByte(childnode.Attributes.GetNamedItem("var").Value, 16);
                                    }
                                    else
                                    {
                                        user_struct.var_string = childnode.Attributes.GetNamedItem("var").Value;
                                    }
                                }
                                else
                                {
                                    byte temp_var = 0;
                                    foreach (XmlNode node in childnode.ChildNodes)
                                    {
                                        users_class_for_xml.USER_tlm_data user_tlm = new users_class_for_xml.USER_tlm_data();
                                        if (node.Name == "byte")
                                        {
                                            foreach (XmlNode nd in node.ChildNodes)
                                            {

                                                if ((nd.Name == "bit") & (nd.Attributes.GetNamedItem("type") != null))
                                                {
                                                    users_class_for_xml.USER_Bool_tlm_data user_bool = new users_class_for_xml.USER_Bool_tlm_data();

                                                    if (nd.Attributes.GetNamedItem("name") != null)
                                                        user_bool.name = nd.Attributes.GetNamedItem("name").Value;

                                                    if (nd.Attributes.GetNamedItem("index") != null)
                                                        user_bool.index = int.Parse(nd.Attributes.GetNamedItem("index").Value);

                                                    if (nd.Attributes.GetNamedItem("index_flag") != null)
                                                        user_bool.index_flag = int.Parse(nd.Attributes.GetNamedItem("index_flag").Value);

                                                    user_tlm.user_bool_tlm_data.Add(user_bool);

                                                }
                                            }
                                        }
                                        else
                                                if ((node.Name == "data") & (node.Attributes.GetNamedItem("type") != null))
                                        {
                                            users_class_for_xml.USER_uint_tlm_data user_uint_tlm = new users_class_for_xml.USER_uint_tlm_data();
                                            // USER_Bool_tlm_data user_bool = new USER_Bool_tlm_data();

                                            if (node.Attributes.GetNamedItem("name") != null)
                                                user_tlm.name = node.Attributes.GetNamedItem("name").Value;

                                            if (node.Attributes.GetNamedItem("min_val") != null)
                                            {
                                                string temp = node.Attributes.GetNamedItem("min_val").Value;
                                                user_uint_tlm.min_var = users_class_for_xml.convert_str_int(temp);
                                            }

                                            if (node.Attributes.GetNamedItem("max_val") != null)
                                            {
                                                string temp = node.Attributes.GetNamedItem("max_val").Value;
                                                user_uint_tlm.max_var = users_class_for_xml.convert_str_int(temp);
                                            }

                                            if (node.Attributes.GetNamedItem("type").Value == "uint8")
                                                user_tlm.size = 1;
                                            else
                                            if (node.Attributes.GetNamedItem("type").Value == "uint16")
                                                user_tlm.size = 2;

                                            if (node.Attributes.GetNamedItem("index_graph") != null)
                                                user_tlm.index_graph = int.Parse(node.Attributes.GetNamedItem("index_graph").Value);

                                            if (node.Attributes.GetNamedItem("division") != null)
                                                user_tlm.division = int.Parse(node.Attributes.GetNamedItem("division").Value);

                                            if (node.Attributes.GetNamedItem("mult") != null)
                                                user_tlm.mult = int.Parse(node.Attributes.GetNamedItem("mult").Value);

                                            user_tlm.user_uint_tlm_data.Add(user_uint_tlm);
                                            //user_tlm.user_bool_tlm_data.Add(user_bool);

                                        }
                                        else

                                                    if (node.Name == "temp")
                                        {
                                            users_class_for_xml.USER_temp_tlm_data user_temp_tlm = new users_class_for_xml.USER_temp_tlm_data();
                                            // USER_Bool_tlm_data user_bool = new USER_Bool_tlm_data();

                                            if (node.Attributes.GetNamedItem("name") != null)
                                                user_tlm.name = node.Attributes.GetNamedItem("name").Value;

                                            if (node.Attributes.GetNamedItem("min_plus_val") != null)
                                            {
                                                string temp = node.Attributes.GetNamedItem("min_plus_val").Value;
                                                user_temp_tlm.min_plus_var = users_class_for_xml.convert_str_int(temp);
                                            }

                                            if (node.Attributes.GetNamedItem("max_plus_val") != null)
                                            {
                                                string temp = node.Attributes.GetNamedItem("max_plus_val").Value;
                                                user_temp_tlm.max_plus_var = users_class_for_xml.convert_str_int(temp);
                                            }

                                            if (node.Attributes.GetNamedItem("min_minus_val") != null)
                                            {
                                                string temp = node.Attributes.GetNamedItem("min_minus_val").Value;
                                                user_temp_tlm.min_minus_var = users_class_for_xml.convert_str_int(temp);
                                            }

                                            if (node.Attributes.GetNamedItem("max_minus_val") != null)
                                            {
                                                string temp = node.Attributes.GetNamedItem("max_minus_val").Value;
                                                user_temp_tlm.max_minus_var = users_class_for_xml.convert_str_int(temp);
                                            }
                                            user_tlm.user_temp_tlm_data.Add(user_temp_tlm);

                                            if (node.Attributes.GetNamedItem("type").Value == "int8")
                                                user_tlm.size = 1;
                                            else
                                            if (node.Attributes.GetNamedItem("type").Value == "int16")
                                                user_tlm.size = 2;

                                            if (node.Attributes.GetNamedItem("index_graph") != null)
                                                user_tlm.index_graph = int.Parse(node.Attributes.GetNamedItem("index_graph").Value);

                                            if (node.Attributes.GetNamedItem("division") != null)
                                                user_tlm.division = int.Parse(node.Attributes.GetNamedItem("division").Value);

                                            if (node.Attributes.GetNamedItem("mult") != null)
                                                user_tlm.mult = int.Parse(node.Attributes.GetNamedItem("mult").Value);
                                        }
                                        user_struct.user_tlm_data.Add(user_tlm);
                                        //if (node.Attributes.GetNamedItem("var").Value == "1")
                                        //    temp_var |= (byte)(1 << int.Parse(node.Attributes.GetNamedItem("index").Value));
                                    }
                                }
                                STRUCT_TELEMETRY.Add(user_struct);
                            }
                            break;
                    }
                }

            }

        }
    }
}
