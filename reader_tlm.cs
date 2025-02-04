using ScottPlot.Plottable;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KPA_BUDU_rework;

namespace KPA_BUDU_rework
{
    public partial class reader_tlm : Form
    {
        List<user_scottplot> list_plot = new List<user_scottplot>();
        user_scottplot_bar plot_bar;
        List<System.Windows.Forms.CheckBox> list_box = new List<System.Windows.Forms.CheckBox>();

        List<List<float>> data_Y = new List<List<float>>();
        List<int> data_X = new List<int>();
        public class user_chBox : System.Windows.Forms.CheckBox
        {
            public user_scottplot plot;
            public DataLogger logger;
            public Color color;
        }
        StreamReader file_reader;
        public user_scottplot full_plot = new user_scottplot("Телеметрия");
        public List<DataLogger> dataLoggers = new List<DataLogger>();
        private List<Color> colors = new List<Color>() {Color.Red ,Color.Green , Color.Black , Color.Blue ,
                                                        Color.Brown, Color.Azure, Color.Orchid, Color.Lime,
                                                        Color.Orange,Color.Purple,Color.Pink,Color.Violet,Color.Gold,
                                                        Color.Yellow,Color.Tomato};
        public reader_tlm()
        {
            InitializeComponent();
            table_check_box.RowStyles.Clear();
            table_plot.RowStyles.Clear();
            full_plot.Dock = DockStyle.Fill;
            full_plot.MAIN_formsplot.Plot.AxisAuto();
            full_plot.MAIN_formsplot.Dock = DockStyle.Fill;
            full_plot.MAIN_formsplot.MouseMove += new System.Windows.Forms.MouseEventHandler(plot_MouseMove_full_plot);
            
        }
        public void read_file(string file)
        {
            if ((file != null) & (file != ""))
            {
                try
                {
                    file_reader = new StreamReader(file);
                    string str = file_reader.ReadLine();
                    string[] str_arr = str.Split('\t');
                    //TableLayoutPanel table_checkBox = new TableLayoutPanel();
                    //table_checkBox.RowCount = str_arr.Length;
                    //table_checkBox.Dock = DockStyle.Fill;
                    //table_checkBox.AutoScroll = false;

                    table_check_box.Dock = DockStyle.Fill;
                    table_check_box.AutoScroll = true;
                    table_check_box.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

                    split_play_plots.Panel2.Controls.Add(table_check_box);

                    int index = 0;
                    int index_value = 0;
                    foreach (string temp_string in str_arr)
                    {
                        if (temp_string != "" && temp_string!= "Время")
                        {
                            if (index_value > 13)
                            {
                                dataLoggers.Add(full_plot.MAIN_formsplot.Plot.AddDataLogger());
                                dataLoggers[dataLoggers.Count - 1].ManageAxisLimits = false;
                                dataLoggers[dataLoggers.Count - 1].MarkerSize = 4;
                                dataLoggers[dataLoggers.Count - 1].Color = colors[index];
                                dataLoggers[dataLoggers.Count - 1].Label = temp_string;

                                user_chBox checkBox = new user_chBox();
                                checkBox.Name = temp_string;
                                checkBox.Text = temp_string;
                                checkBox.Checked = true;
                                checkBox.Dock = DockStyle.Fill;
                                checkBox.color = colors[index];

                                table_check_box.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                                table_check_box.RowCount++;
                                table_check_box.Controls.Add(checkBox);
                                list_box.Add(checkBox);

                                checkBox.CheckedChanged += CheckBox_CheckedChanged;

                                user_scottplot plot = new user_scottplot(temp_string);
                                plot.MAIN_formsplot.Plot.YAxis.SetBoundary();
                                plot.MAIN_formsplot.Plot.XAxis.SetBoundary();


                                plot.MAIN_formsplot.Plot.Title(temp_string);
                                plot.logger = plot.MAIN_formsplot.Plot.AddDataLogger();

                                plot.logger.MarkerSize = 4;
                                plot.logger.Color = Color.Blue;
                                plot.index = index;

                                list_plot.Add(plot);

                                checkBox.plot = plot;
                                checkBox.logger = dataLoggers[dataLoggers.Count - 1];
                                plot.Dock = DockStyle.Fill;
                                plot.MAIN_formsplot.Dock = DockStyle.Fill;

                                table_plot.RowStyles.Add(new RowStyle(SizeType.Absolute, 300));
                                table_plot.RowCount++;
                                table_plot.Controls.Add(plot);
                                index++;


                                VLine temp_vline = plot.vline;
                                //temp_vline.X = 0;
                                temp_vline.PositionLabel = true;

                                HLine temp_hline = plot.hline;
                                //temp_hline.Y = 0;
                                temp_hline.PositionLabel = true;

                                plot.hline = temp_hline;
                                plot.vline = temp_vline;

                                plot.MAIN_formsplot.MouseMove += new System.Windows.Forms.MouseEventHandler(plot_MouseMove);
                                plot.MAIN_formsplot.AxesChanged += OnAxesChanged;
                            }
                            index_value++;
                        }
                    }
                    int init_time = -1;
                    string str_data = "";
                    while (file_reader.EndOfStream != true)
                    {
                        str_data = file_reader.ReadLine();
                        string[] str_arr_data = str_data.Split('\t');
                        if (str_arr_data.Length == str_arr.Length)
                        {
                            List<float> data_y_tmp = new List<float>();
                            for (int i = 15; i < str_arr_data.Length; i++)
                                data_y_tmp.Add(float.Parse(str_arr_data[i]));

                            data_Y.Add(data_y_tmp);
                            int time_now = 0;
                            string[] time_arr = str_arr_data[0].Split(':');
                            for (int i = time_arr.Length - 1; i >= 0; i--)
                            {
                                if (i == time_arr.Length - 1)
                                    time_now += int.Parse(time_arr[i]);//milisecond
                                else
                                if (i == time_arr.Length - 2)
                                    time_now += int.Parse(time_arr[i]) * 1000;//second
                                else
                                if (i == time_arr.Length - 3)
                                    time_now += int.Parse(time_arr[i]) * 1000 * 60;//minute
                                else
                                if (i == time_arr.Length - 4)
                                    time_now += int.Parse(time_arr[i])* 1000 * 60 * 60;//hour


                            }
                            if (init_time == -1)
                                init_time = time_now;

                            data_X.Add(time_now - init_time);

                            foreach (user_scottplot plot in list_plot)
                            {
                                plot.logger.Add(data_X[data_X.Count - 1], data_Y[data_Y.Count - 1][plot.index]);
                                dataLoggers[plot.index].Add(data_X[data_X.Count - 1], data_Y[data_Y.Count - 1][plot.index]);
                            }
                        }
                    }
                    foreach (user_scottplot plot in list_plot)
                    {
                        plot.logger.ManageAxisLimits = true;

                        plot.MAIN_formsplot.Refresh();
                        plot.limits = plot.MAIN_formsplot.Plot.GetAxisLimits();
                        plot.logger.ManageAxisLimits = false;
                        plot.size = plot.Size;
                    }
                    full_plot.MAIN_formsplot.Plot.AxisAuto();
                    
                    full_plot.MAIN_formsplot.Refresh();
                    switch_plot.TabPages[0].Controls.Add(full_plot);
                }
                catch (Exception e)
                {
                    string message = "Во время чтения файла произошла ошибка: " + e.Message;
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result =  MessageBox.Show(message, caption, buttons);
                    this.Close();
                }

            }

        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            user_chBox chBox = sender as user_chBox;
            if (chBox.Checked)
            {
                //foreach (user_Plot plot in list_plot)
                //    plot.Height =  plot.Height - plot.Height/list_plot.Count;
                chBox.plot.Show();
                chBox.logger.Color = chBox.color;
                
                //table_check_box.RowCount++;
            }
            else
            {
                //foreach (user_Plot plot in list_plot)
                //    plot.Height =  plot.Height + plot.Height/list_plot.Count;
                chBox.plot.Hide();
                chBox.logger.Color = Color.White;
                //table_check_box.RowCount--;

            }
            full_plot.MAIN_formsplot.Refresh();
            chBox.plot.Refresh();


        }

        private void OnAxesChanged(object sender, EventArgs e)
        {
            FormsPlot changedPlot = sender as FormsPlot;

            if (changedPlot != null)
            {
                AxisLimits newAxisLimits = changedPlot.Plot.GetAxisLimits();

                foreach (user_scottplot plot in list_plot)
                {
                    if (plot.MAIN_formsplot != changedPlot)
                    {
                        AxisLimits newLimits = new AxisLimits(newAxisLimits.XMin, newAxisLimits.XMax, plot.limits.YMin, plot.limits.YMax);
                        plot.limits = newLimits;
                        plot.MAIN_formsplot.Configuration.AxesChangedEventEnabled = false;
                        plot.MAIN_formsplot.Plot.SetAxisLimits(newLimits);
                        plot.MAIN_formsplot.Refresh();
                        plot.MAIN_formsplot.Configuration.AxesChangedEventEnabled = true;
                    }
                    //if (plot.MAIN_formsplot == changedPlot)
                    //{
                    //    plot.limits = newAxisLimits;
                    //    continue;
                    //}


                    //plot.Plot.
                    // disable events briefly to avoid an infinite loop

                    //double xMin = plot.limits.XMin + (newAxisLimits.XMin - changedPlot.limits.XMin)/changedPlot.limits.XMin * plot.limits.XMin;
                    //double xMax = plot.limits.XMax + (newAxisLimits.XMax - changedPlot.limits.XMax)/changedPlot.limits.XMax * plot.limits.XMax;
                    //double yMin = plot.limits.YMin + (newAxisLimits.YMin - changedPlot.limits.YMin)/changedPlot.limits.YMin * plot.limits.YMin;
                    //double yMax = plot.limits.YMax + (newAxisLimits.YMax - changedPlot.limits.YMax)/changedPlot.limits.YMax * plot.limits.YMax;

                    //newLimits.WithX(xMin , xMax);
                    //newLimits.WithY(yMin , yMax);
                    //newLimits.
                    //newLimits.WithX(newAxisLimits.XMin , newAxisLimits.XMax);
                    //newLimits.WithY(plot.limits.YMin, plot.limits.YMax);

                    //plot.MAIN_formsplot.Render(); 
                }
            }
        }

        private void plot_MouseMove(object sender, MouseEventArgs e)
        {
            FormsPlot plt = (sender as FormsPlot);
            (double x, double y) = plt.GetMouseCoordinates();
            // MyScatterPlot = plt.Plot.AddScatterPoints();
            foreach (user_scottplot plot in list_plot)
                if (plot.MAIN_formsplot == plt)
                {
                    plot.hline.Y = y;
                    plot.vline.X = x;
                    continue;
                }
            // plt.Plot.AddVerticalLine(x);
            plt.Refresh();
            //Console.WriteLine($"Mouse at ({x}, {y})");
        }


        private void plot_MouseMove_full_plot(object sender, MouseEventArgs e)
        {
            FormsPlot plt = (sender as FormsPlot);
            (double x, double y) = plt.GetMouseCoordinates();
            // MyScatterPlot = plt.Plot.AddScatterPoints();

            full_plot.hline.Y = y;
            full_plot.vline.X = x;

            // plt.Plot.AddVerticalLine(x);
            plt.Refresh();
            //Console.WriteLine($"Mouse at ({x}, {y})");
        }
    }
}