using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace KPA_BUDU_rework
{
    public partial class Graph_write : Form
    {
        List<TextBox> list_textBox = new List<TextBox>();
        List<CheckBox> list_checkBox = new List<CheckBox>();
        List<user_scottplot> User_Formsplot = new List<user_scottplot>();
        user_scottplot_bar plot_bar;

        public Graph_write(List<user_tlm.param_val> list_tlm)
        {
            InitializeComponent();
            foreach (user_tlm.param_val param in list_tlm)
            {
                if (param.type != "bool")
                { 
                    user_scottplot temp_scottplot = new user_scottplot(param);
                    temp_scottplot.Dock = DockStyle.Fill;
                    table_logger.Controls.Add(temp_scottplot);
                    User_Formsplot.Add(temp_scottplot);
                }
            }
            plot_bar = new user_scottplot_bar(list_tlm);
            plot_bar.Dock= DockStyle.Fill;
            split_plot.Panel1.Controls.Add(plot_bar);
            
            construct_check_box(list_tlm);
            contruct_numeric_tlm(list_tlm);
        }

        //private class user_CheckBox: CheckBox
        //{
        //    public user_CheckBox(user_tlm.param_val list_tlm)
        //    {
        //        this.Text = list_tlm.name;
        //        this.Name = list_tlm.name;
        //        this.Checked = false;
        //    }
        //}

        private void construct_check_box(List<user_tlm.param_val> list_tlm)
        {
            foreach (user_tlm.param_val tlm in list_tlm)
            {
                table_check_box.RowStyles.Clear();
                if (tlm.type == "bool")
                {
                    CheckBox checkBox= new CheckBox();
                    checkBox.Text = tlm.name;
                    checkBox.Checked = false;
                    checkBox.Dock = DockStyle.Fill;
                    table_check_box.RowCount++;
                    table_check_box.Controls.Add(checkBox);
                    list_checkBox.Add(checkBox);
                }
                    
            }
        }

        private void contruct_numeric_tlm(List<user_tlm.param_val> list_tlm)
        {
            foreach (user_tlm.param_val tlm in list_tlm)
            {
                if (tlm.type != "bool")
                {
                    TableLayoutPanel table_label_textBox = new TableLayoutPanel();
                    table_label_textBox.ColumnCount = 2;
                    table_label_textBox.Dock = DockStyle.Fill;
                    table_label_textBox.AutoSize = true;

                    Label label = new Label();
                    label.Text = tlm.name;
                    label.Dock = DockStyle.Fill;

                    TextBox textBox = new TextBox();
                    textBox.Text = tlm.val.ToString();
                    textBox.Dock = DockStyle.Fill;
                    table_check_box.RowCount++;

                    table_label_textBox.Controls.Add(label);
                    table_label_textBox.Controls.Add(textBox);

                    table_check_box.Controls.Add(table_label_textBox);
                    
                    list_textBox.Add(textBox);
                }

            }
        }
        public delegate void text_Box_refresh_flag();
        public void listBox_refresh(List<user_tlm.param_val> list_tlm)
        {
            int j = 0;
            while (j<list_tlm.Count && list_tlm[j].type == "bool")
            {
                j++;
            }
            for (int i = j; i < list_tlm.Count; i++)
            {
                if (list_tlm[i].type != "bool")
                {
                   if (list_textBox[i-j].InvokeRequired)
                   {
                       text_Box_refresh_flag d = new text_Box_refresh_flag(() => list_textBox[i-j].Text = list_tlm[i].val.ToString());
                     list_textBox[i-j].Invoke(d);
                   }
                   else
                     list_tlm[i].val.ToString();
                }
            }
        }

        public delegate void Refresh_flag(List<user_tlm.param_val> list_tlm);

        public delegate void check_Box_refresh_flag();
        public void refresh_flag(List<user_tlm.param_val>list_tlm)
        {
            for (int i = 0; i < list_tlm.Count; i++)
            {
                if (list_tlm[i].type == "bool")
                {
                    if (list_tlm[i].val == 1)
                    {
                        if (list_checkBox[i].InvokeRequired)
                        {
                            check_Box_refresh_flag d = new check_Box_refresh_flag(() => list_checkBox[i].Checked = true);
                            list_checkBox[i].Invoke(d);
                        }
                        else
                            list_checkBox[i].Checked = true;
                    }
                    else
                    {
                        if (list_checkBox[i].InvokeRequired)
                        {
                            check_Box_refresh_flag d = new check_Box_refresh_flag(() => list_checkBox[i].Checked = false);
                            list_checkBox[i].Invoke(d);
                        }
                        else
                            list_checkBox[i].Checked = false;
                    }
                }
            }
            int j = 0;
            while (list_tlm[j].type == "bool")
                j++;
            for(int i = j; i-j < User_Formsplot.Count; i ++)
                User_Formsplot[i-j].Refresh_chart(list_tlm[i]);

            listBox_refresh(list_tlm);
            plot_bar.refresh_bar(list_tlm);
            
            //if (check_box_flag.InvokeRequired)
            //{
            //    Refresh_flag d = new Refresh_flag(refresh_flag);
            //    this.Invoke(d, new object[] { list_tlm });
            //}
            //else
            //{
            //    for (int i = 0; i < list_tlm.Count; i++)
            //    {
            //        if (list_tlm[i].type == "bool")
            //            if (list_tlm[i].val == 1)
            //                ((CheckBox)check_box_flag.Items[i]).Checked = true;
            //            else
            //                ((CheckBox)check_box_flag.Items[i]).Checked = false;
            //    }
            //}
        }

        private void but_clean_Click(object sender, EventArgs e)
        {
            foreach (user_scottplot plot in User_Formsplot)
                plot.Clear_data();
        }

        private void but_ViewFull_Click(object sender, EventArgs e)
        {
            foreach (user_scottplot plot in User_Formsplot)
                plot.FULL_Click();
            plot_bar.switch_STATE(0);
        }

        private void but_ViewSlide_Click(object sender, EventArgs e)
        {
            foreach (user_scottplot plot in User_Formsplot)
                plot.SLIDE_Click();
            plot_bar.switch_STATE(1);
        }

        private void but_ViewJump_Click(object sender, EventArgs e)
        {
            foreach (user_scottplot plot in User_Formsplot)
                plot.JUMP_Click();
            plot_bar.switch_STATE(2);
        }
    }
}
