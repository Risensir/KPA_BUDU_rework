using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static KPA_BUDU_rework.XML_button;
//using static KPA_BUDU_rework.XML_reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace KPA_BUDU_rework
{
    public partial class XML_button : UserControl
    { 

        public delegate void PRINT_Handler(string str);
        public event PRINT_Handler PrintHandler;

        public delegate void TABLE_Handler(TableLayoutPanel table);
        public event TABLE_Handler TableHandler;

        public delegate void SEND_byte_Handler(byte[] msg);
        public event SEND_byte_Handler SendByteHandler;

        private string filePath_XML = @"C:\Users\NewArm\Desktop\NETWORK\БУДУ\СТИЛСОФТ\KPA_BUDU_programm-master\XML_struct\Commands_with_struct.xml";

        public TableLayoutPanel table_main = new TableLayoutPanel();
        private TableLayoutPanel table_but = new TableLayoutPanel();
        private TableLayoutPanel table_slider = new TableLayoutPanel();

        class Button_user : System.Windows.Forms.Button
        {
            public string name;
            public byte var;
            public byte[] vars;
            public List<CheckedListBox> checkBox = new List<CheckedListBox>();
            public List<NumericUpDown> uint8 = new List<NumericUpDown>();
            public List<NumericUpDown> int32 = new List<NumericUpDown>();
            public List<string> str_type = new List<string>();
            public bool press_flag;

            //protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            //{
            //    GraphicsPath p = new GraphicsPath();
            //    p.AddEllipse(1, 1, base.Width - 4, base.Height - 4);
            //    base.Region = new Region(p);
            //}
        }

        class Slider_user : System.Windows.Forms.TrackBar
        {
            public string name;
            public byte[] var;
            public byte indent_var;
            public byte header;
            public byte bytescol;
            public bool bytescol_flag;
            public byte control_sum;
            public bool control_sum_flag;
            public int Slider_val;

            public System.Windows.Forms.TextBox slider_val_text;
            public int var_a;
            public int var_b;
            public Button_user button_user;
        }
        Button_user BUT_TELEMETRY;
        public XML_button()
        {

            InitializeComponent();

            XML_load_but.Click += XML_load_but_Click;
            XML_choose_but.Click += XML_choose_but_Click;

            table_but.Dock = DockStyle.Fill;
            table_but.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            table_but.AutoSize = true;

            table_slider.Dock = DockStyle.Fill;
            table_slider.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            table_slider.AutoSize = true;

            table_main.Dock = DockStyle.Fill;
            table_main.AutoScroll = true;
            table_main.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            table_main.ColumnCount = 2;
            table_main.RowCount = 1;

            table_main.Controls.Add(table_but);
            table_main.Controls.Add(table_slider);

            try
            {
                XML_filepath_box.Text = filePath_XML;
              //  XML_load_but_Click(XML_load_but, new EventArgs());
            }
            catch (Exception e)
            {
                //PrintHandler(e.Message + Environment.NewLine);
            }
        }
        private void XML_load_but_Click(object sender, EventArgs e)
        {
            if (filePath_XML == null)
                PrintHandler("Необходимо выбрать файл структуры команд" + Environment.NewLine);
            else
                XML_COMMAND_READ();
        }
        private void XML_choose_but_Click(object sender, EventArgs e)
        {
            Choose_xml();
            XML_filepath_box.Text = filePath_XML;
        }

        public void xml_load()
        {
            XML_COMMAND_READ();
        }

        private void Choose_xml()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "..\\",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath_XML = @openFileDialog.FileName;
            }
        }
        private void XML_COMMAND_READ()
        {
            // ..................................................................Создание списка кнопок , основанных на раннее объявленном методе
            table_main.Visible = false;
            table_but.Controls.Clear();
            table_slider.Controls.Clear();
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath_XML);
            XmlElement element = xml.DocumentElement;

            // ........................................................................Очистка стилей колонок и строк таблицы
            table_but.ColumnStyles.Clear();
            table_but.RowStyles.Clear();

            table_slider.ColumnStyles.Clear();
            table_slider.RowStyles.Clear();

            //........................................................................ Создание новых стилей колонок и таблицы
            //tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 50));
            //tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50));

            //tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 50));
            //tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50));


            int i = 0, j = 0, k = 0;
            table_but.ColumnCount = element.Attributes.Count;
            table_but.RowCount = element.ChildNodes.Count;
            //.......................................................................Считывание документа XML
            foreach (XmlNode xnode in element)
            {
                //...............................................................Добавление новой колонки

                //tableLayoutPanel3.ColumnCount += 1;
                //..............................................................Считывание дочерних элементов
                foreach (XmlNode childnode in xnode.ChildNodes)
                {

                    //tableLayoutPanel3.RowCount += 1;
                    //--------------------------------------------------------------------------- VAR
                    switch (childnode.Name)
                    {
                        case "send_const":
                            {
                                //.............................................................Добавление в список новых экземпляров ранее созданного метода
                                Button_user but = new Button_user();

                                //.............................................................Заполнение атрибутов созданных кнопок
                                but.Text = childnode.Attributes.GetNamedItem("name").Value;
                                if (but.Text == "TELEMETRY")
                                    BUT_TELEMETRY = but;
                                string temp_string_var = childnode.Attributes.GetNamedItem("var").Value;
                                if (!((temp_string_var == "") | (temp_string_var == null)))
                                    but.var = Convert.ToByte(temp_string_var, 16);

                                int count_add = -1;




                                TableLayoutPanel table_second = new TableLayoutPanel();
                                table_second.Dock = DockStyle.Fill;
                                table_second.ColumnCount = 2;
                                //table_second.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                                table_second.ColumnStyles.Add(new ColumnStyle());
                                table_second.ColumnStyles.Add(new ColumnStyle());

                                table_second.ColumnStyles[0].SizeType = SizeType.Percent;
                                table_second.ColumnStyles[0].Width = 60;

                                table_second.ColumnStyles[1].SizeType = SizeType.Percent;
                                table_second.ColumnStyles[1].Width = 40;
                                table_second.AutoSize = true;

                                if (childnode.Attributes.GetNamedItem("count_add") != null)
                                {
                                    count_add = int.Parse(childnode.Attributes.GetNamedItem("count_add").Value);
                                    TableLayoutPanel table_third = new TableLayoutPanel();
                                    table_third.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
                                    table_third.Dock = DockStyle.Top;
                                    table_third.AutoSize = true;
                                    table_third.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;



                                    for (int index = 0; index <= count_add; index++)
                                    {
                                        Label label = new Label();
                                        if (childnode.Attributes.GetNamedItem("name_var_" + index.ToString()) != null)
                                        {
                                            label.Dock = DockStyle.Fill;
                                            label.Text = childnode.Attributes.GetNamedItem("name_var_" + index.ToString()).Value;
                                            //label.Font = new Font(label.Font);


                                            table_third.Controls.Add(label);

                                            if (childnode.Attributes.GetNamedItem("type_var_" + index.ToString()) != null)
                                            {
                                                string type_temp = childnode.Attributes.GetNamedItem("type_var_" + index.ToString()).Value;
                                                switch (type_temp)
                                                {
                                                    case "bool":
                                                        CheckedListBox checkBox = new CheckedListBox();
                                                        for (int sub_index = 0; sub_index < 2; sub_index++)
                                                        {
                                                            string temp_str = "name_var_" + index.ToString() + "_" + sub_index.ToString();
                                                            if (childnode.Attributes.GetNamedItem(temp_str) != null)
                                                            {
                                                                string temp_sub_string = childnode.Attributes.GetNamedItem(temp_str).Value;

                                                                checkBox.Items.AddRange(new object[] { temp_sub_string });

                                                                if (sub_index == 0)
                                                                    checkBox.SetItemCheckState(sub_index, CheckState.Checked);
                                                            }
                                                        }
                                                        checkBox.Dock = DockStyle.Fill;
                                                        checkBox.SetBounds(0, 0, 10, 40);
                                                        checkBox.ItemCheck += new ItemCheckEventHandler(this.CheckBox_Handler);
                                                        table_third.Controls.Add(checkBox);

                                                        but.checkBox.Add(checkBox);
                                                        but.str_type.Add("bool");
                                                        break;

                                                    case "uint8":
                                                        string temp_min_str = "min_var_" + index.ToString();
                                                        string temp_max_str = "max_var_" + index.ToString();
                                                        string temp_basic_str = "basic_var_" + index.ToString();

                                                        if ((childnode.Attributes.GetNamedItem(temp_min_str) != null) & (childnode.Attributes.GetNamedItem(temp_max_str) != null) & (childnode.Attributes.GetNamedItem(temp_basic_str) != null))
                                                        {
                                                            int min = users_class_for_xml.convert_str_int(childnode.Attributes.GetNamedItem(temp_min_str).Value);
                                                            int max = users_class_for_xml.convert_str_int(childnode.Attributes.GetNamedItem(temp_max_str).Value);
                                                            int basic = users_class_for_xml.convert_str_int(childnode.Attributes.GetNamedItem(temp_basic_str).Value);

                                                            NumericUpDown value = new NumericUpDown();

                                                            if (basic < min)
                                                                min = basic;

                                                            if (basic > max)
                                                                max = basic;

                                                            value.Minimum = min;
                                                            value.Maximum = max;
                                                            value.Value = basic;

                                                            value.Dock = DockStyle.Fill;
                                                            table_third.Controls.Add(value);

                                                            but.uint8.Add(value);
                                                            but.str_type.Add("uint8");
                                                        }
                                                        break;
                                                    case "int":
                                                        string temp_min_str_int = "min_var_" + index.ToString();
                                                        string temp_max_str_int = "max_var_" + index.ToString();
                                                        string temp_basic_str_int = "basic_var_" + index.ToString();
                                                        if ((childnode.Attributes.GetNamedItem(temp_min_str_int) != null) & (childnode.Attributes.GetNamedItem(temp_max_str_int) != null) & (childnode.Attributes.GetNamedItem(temp_basic_str_int) != null))
                                                        {

                                                            string min_str = childnode.Attributes.GetNamedItem(temp_min_str_int).Value;
                                                            string max_str = childnode.Attributes.GetNamedItem(temp_max_str_int).Value;
                                                            string basic_str = childnode.Attributes.GetNamedItem(temp_basic_str_int).Value;

                                                            if (min_str.Length % 2 != 0)
                                                                min_str = "0" + min_str;

                                                            if (max_str.Length % 2 != 0)
                                                                max_str = "0" + max_str;

                                                            if (basic_str.Length % 2 != 0)
                                                                basic_str = "0" + basic_str;

                                                            int temp_max = 0;
                                                            int temp_min = 0;
                                                            int temp_basic = 0;
                                                            NumericUpDown value = new NumericUpDown();
                                                            temp_min = users_class_for_xml.convert_str_int(min_str);
                                                            temp_max = users_class_for_xml.convert_str_int(max_str);
                                                            temp_basic = users_class_for_xml.convert_str_int(basic_str);

                                                            if (temp_basic < temp_min)
                                                                temp_min = temp_basic;

                                                            if (temp_basic > temp_max)
                                                                temp_max = temp_basic;

                                                            value.Minimum = temp_min;
                                                            value.Maximum = temp_max;
                                                            value.Value = temp_basic;


                                                            value.Dock = DockStyle.Fill;
                                                            table_third.Controls.Add(value);

                                                            but.int32.Add(value);
                                                            but.str_type.Add("int");
                                                        }
                                                        break;

                                                }
                                            }
                                        }
                                    }
                                    table_second.Controls.Add(table_third, 1, 0);
                                }
                                else
                                {
                                    if (childnode.Attributes.GetNamedItem("TEMP_NAME") != null)
                                    {
                                        Label label = new Label();
                                        label.Text = childnode.Attributes.GetNamedItem("TEMP_NAME").Value.ToString();
                                        label.Dock = DockStyle.Fill;
                                        table_second.Controls.Add(label, 1, 0);
                                    }
                                }
                                but.press_flag = false;
                                // but[but.Count - 1].Dock = DockStyle.Fill;
                                but.AutoSize = false;
                                but.Width = 150;
                                but.Height = 30;
                                but.ForeColor = Color.Black;

                                //if (but.Text == "TELEMETRY")
                                //    but_telemetry = but;

                                //if (but[but.Count - 1].Text == "TIME_CYCL")
                                //    time_cycl = but[but.Count - 1];

                                // ..............................................................Создание нового события при нажатии кнопки
                                but.Click += new System.EventHandler(this.button_user_Click);

                                //..............................................................Добавление в таблицу созданной кнопки
                                table_second.Controls.Add(but, 0, 0);

                                table_but.Controls.Add(table_second, j, i);
                                break;
                            }
                        case "send_var":
                            {
                                
                                //.............................................................Добавление в список новых экземпляров ранее созданного метода
                                Slider_user slider = new Slider_user();

                                //.............................................................Заполнение атрибутов созданных кнопок
                                slider.name = childnode.Attributes.GetNamedItem("name").Value;

                                string temp_string_header = childnode.Attributes.GetNamedItem("header").Value;

                                //--------------------------------------------------------------------------- HEADER
                                if (!((temp_string_header == "") | (temp_string_header == null)))
                                    slider.header = Convert.ToByte(temp_string_header, 16);

                                //--------------------------------------------------------------------------- BYTESCOL
                                if (childnode.Attributes.GetNamedItem("bytescol").Value == "y")
                                {
                                    slider.bytescol_flag = true;
                                    slider.bytescol = 6;
                                }
                                else
                                    slider.bytescol_flag = false;

                                string temp_string_var = childnode.Attributes.GetNamedItem("var_a").Value;
                                if (!((temp_string_var == "") | (temp_string_var == null)))
                                    slider.var_a = Convert.ToInt32(temp_string_var);
                                //   slider[slider.Count - 1].var_a = Convert.ToByte(temp_string_var, 16);

                                temp_string_var = childnode.Attributes.GetNamedItem("var_b").Value;
                                if (!((temp_string_var == "") | (temp_string_var == null)))
                                    slider.var_b = Convert.ToInt32(temp_string_var);
                                //  slider[slider.Count - 1].var_b = Convert.ToByte(temp_string_var, 16);

                                temp_string_var = childnode.Attributes.GetNamedItem("var").Value;
                                if (!((temp_string_var == "") | (temp_string_var == null)))
                                    slider.indent_var = Convert.ToByte(temp_string_var, 16);
                                //slider[slider.Count - 1].indent_var = Convert.ToInt32(temp_string_var);


                                if (childnode.Attributes.GetNamedItem("control_sum").Value == "y")
                                {
                                    slider.control_sum_flag = true;
                                }
                                else
                                    slider.control_sum_flag = false;

                                slider.Orientation = System.Windows.Forms.Orientation.Vertical;
                                //slider[slider.Count - 1].Maximum = slider[slider.Count - 1].var_b * 10;
                                //slider[slider.Count - 1].Minimum = slider[slider.Count - 1].var_a;

                                slider.Maximum = slider.var_b;
                                slider.Minimum = slider.var_a;

                                slider.Height = 500;
                                slider.Width = 50;

                                System.Windows.Forms.TextBox label_slider = new System.Windows.Forms.TextBox();
                                System.Windows.Forms.TextBox max_slider = new System.Windows.Forms.TextBox();
                                System.Windows.Forms.TextBox min_slider = new System.Windows.Forms.TextBox();
                                Button_user take_current = new Button_user();
                                System.Windows.Forms.TextBox Value_slider = new System.Windows.Forms.TextBox();

                                take_current.Text = "Отправить";
                                //take_current.header = default_header;
                                //take_current.bytescol = 6;

                                take_current.Click += new System.EventHandler(button_take_current_Click);

                                label_slider.Text = slider.name;
                                label_slider.BorderStyle = BorderStyle.None;

                                max_slider.Text = slider.var_b.ToString();
                                max_slider.BorderStyle = BorderStyle.None;

                                min_slider.Text = slider.var_a.ToString();
                                min_slider.BorderStyle = BorderStyle.None;

                                Value_slider.BorderStyle = BorderStyle.None;

                                Value_slider.Text = "0";

                                slider.slider_val_text = Value_slider;
                                slider.button_user = take_current;
                                //Slider_val = (byte)slider[slider.Count - 1].Value;

                                //table_slider.RowCount += 3;
                                
                                //table_slider.ColumnCount += 1;

                                table_slider.Controls.Add(max_slider, k, 0);
                                table_slider.Controls.Add(slider, k, 1);
                                table_slider.Controls.Add(min_slider, k, 2);
                                table_slider.Controls.Add(label_slider, k, 3);
                                table_slider.Controls.Add(Value_slider, k, 4);
                                table_slider.Controls.Add(take_current, k, 5);

                                k++;

                                slider.Scroll += new System.EventHandler(slider_handler);
                                slider.Slider_val = 0;
                                slider.button_user.vars = new byte[] { 0 };
                                break;
                            }
                        default:
                            {
                                //but.var = (byte)0x00;
                                break;
                            }
                    }

                    i++;
                }
                i = 0;
                j++;
            }
            table_main.Visible = true;
            TableHandler(table_main);
        }
        private void CheckBox_Handler(object sender, EventArgs e)
        {
            if (sender != null)
            {
                CheckedListBox checkBox = sender as CheckedListBox;
                try
                {
                    int index = checkBox.SelectedIndex;
                    checkBox.ItemCheck -= new ItemCheckEventHandler(this.CheckBox_Handler);
                    for (int i = 0; i < checkBox.Items.Count; i++)
                    {
                        if (i != index)
                        {
                            checkBox.SetItemCheckState(i, CheckState.Unchecked);
                            //checkBox.Se = checkBox.Items[i];
                        }
                    }
                    checkBox.ItemCheck += new ItemCheckEventHandler(this.CheckBox_Handler);
                }
                catch { }
            }
        }
        private async void button_take_current_Click(object sender, EventArgs e)
        {
            PrintHandler("Отправлено: " + BitConverter.ToString((sender as Button_user).vars) + Environment.NewLine);
            try
            {
                USER_uart_struct user_uart = new USER_uart_struct();
                (sender as Button_user).vars = user_uart.construct_command((sender as Button_user).vars.ToList<byte>()).ToArray();
            }
            catch (Exception t)
            {
                PrintHandler(t.Message + Environment.NewLine);
            }
            SendByteHandler((sender as Button_user).vars);  
        }
        private async void button_user_Click(object sender, EventArgs e)
        {
            Button_user but = (Button_user)sender;
                try
                {
                    List<byte> data = new List<byte>();
                        int ind_bool = 0;
                        int ind_uint8 = 0;
                        int ind_int = 0;
                        data.Add(but.var);
                        Dictionary<string, int> dict = new Dictionary<string, int>()
                        {
                            ["bool"] = 0,
                            ["uint8"] = 0,
                            ["int"] = 0
                        };
                        foreach (string str in but.str_type)
                        {
                            if (str == "bool")
                            {
                                int index = 0;
                                dict.TryGetValue("bool", out index);

                                if (but.checkBox[index].GetItemChecked(0))
                                    data.Add(0);

                                if (but.checkBox[index].GetItemChecked(1))
                                    data.Add(1);
                                ind_bool++;
                                dict["bool"] = ind_bool;
                            }

                            if (str == "uint8")
                            {
                                int index = 0;
                                dict.TryGetValue("uint8", out index);

                                byte[] new_ar = BitConverter.GetBytes((int)but.uint8[index].Value);
                                List<byte> new_ar_list = new_ar.ToList();

                                byte temp_byte = 0;
                                int ind = new_ar_list.Count - 1;
                                do
                                {
                                    temp_byte = new_ar_list[ind];

                                    if (new_ar_list[ind] == 0)
                                        new_ar_list.RemoveAt(ind);

                                    ind--;

                                } while ((temp_byte == 0) & (ind > 0));

                                new_ar_list.Reverse();
                                data.AddRange(new_ar_list);

                                ind_uint8++;
                                dict["uint8"] = ind_uint8;
                            }

                            if (str == "int")
                            {
                                int index = 0;
                                dict.TryGetValue("int", out index);

                                byte[] new_ar = BitConverter.GetBytes((int)but.int32[index].Value);
                                List<byte> new_ar_list = new_ar.ToList();

                                byte temp_byte = 0;
                      
                                new_ar_list.Reverse();
                                data.AddRange(new_ar_list);

                                ind_int++;
                                dict["int"] = ind_int;
                            }
                        }
                      

                //----------------------------------------- STRUCTURE SEND END


                USER_uart_struct user_uart = new USER_uart_struct();
                SendByteHandler(user_uart.construct_command(data).ToArray());
                        //SetLog("Отправлено: " + but.Text + ": " + BitConverter.ToString(out_word.ToArray()).Replace("-", " ") + Environment.NewLine, log_file);
                        //SetText_COM("Отправлено: ");
                        //foreach (string str in NAME)
                        //{
                        //    SetText_COM(str + " | ");
                        //}
                        //SetText_COM(Environment.NewLine);
                    
                    if (!((sender as Button_user).press_flag))
                    {
                        (sender as Button_user).ForeColor = Color.Red;
                        (sender as Button_user).press_flag = true;
                    }
                    else
                    {
                        (sender as Button_user).ForeColor = Color.Black;
                        (sender as Button_user).press_flag = false;
                    }
                }
                catch (Exception t)
                {
                    PrintHandler(t.Message + Environment.NewLine);
                    //button1_Click(button1, new EventArgs());
                    //Task.Delay(1000);
                    //button1_Click(button1, new EventArgs());
                    //Task.Delay(1000);
                }

            }
        private void slider_handler(object sender, EventArgs e)
        {
            // PrintHandler("Отправлено: " + (sender as Slider_user).var + Environment.NewLine);
            (sender as Slider_user).Slider_val = (int)((float)(sender as System.Windows.Forms.TrackBar).Value);
            (sender as Slider_user).slider_val_text.Text = ((sender as Slider_user).Slider_val).ToString();
            (sender as Slider_user).button_user.vars = new byte[] { (sender as Slider_user).indent_var, (byte)((sender as Slider_user).Slider_val >> 8), (byte)(sender as Slider_user).Slider_val };  
        }

        private delegate void but_user_click(object sender, EventArgs e);
        public void Telemetry_request()
        {
            if (BUT_TELEMETRY != null)
            {
                if (BUT_TELEMETRY.InvokeRequired)
                {
                    but_user_click d = new but_user_click(button_user_Click);
                    BUT_TELEMETRY.Invoke(d);
                }
                else
                    button_user_Click(BUT_TELEMETRY, new EventArgs());
            }
        }
    } 
}
    
