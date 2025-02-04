using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ScottPlot;
using ScottPlot.Plottable;
namespace KPA_BUDU_rework
{
    public partial class user_scottplot : UserControl
    {
        public VLine vline = new VLine();
        public HLine hline = new HLine();
        //private DataLogger logger;
        private DateTime start = DateTime.Now;
        public DataLogger logger;
        public int index = 0;

        public AxisLimits limits;
        public Size size;

        public user_scottplot(string name)
        {
            InitializeComponent();
            logger = MAIN_formsplot.Plot.AddDataLogger();
            logger.MarkerSize = 8;
            logger.ManageAxisLimits = true;
            logger.Label = name;
            logger.ViewFull();

            hline = logger.Plot.AddHorizontalLine(0);
            hline.PositionLabel = true;

            vline = logger.Plot.AddVerticalLine(0);
            vline.PositionLabel = true;

            MAIN_formsplot.Plot.Title(name);
            MAIN_formsplot.Plot.XLabel("Время");
            MAIN_formsplot.Plot.AxisAuto();
            logger.LineColor = Color.OrangeRed;
            logger.MarkerColor = Color.OrangeRed;
            MAIN_formsplot.Refresh();
        }
        public user_scottplot(user_tlm.param_val param)
        {

            InitializeComponent();
            logger = MAIN_formsplot.Plot.AddDataLogger();
            logger.MarkerSize = 8;
            logger.ManageAxisLimits = true;
            logger.Label = param.name;
            logger.ViewFull();
            
            hline = logger.Plot.AddHorizontalLine(0);
            hline.PositionLabel = true;

            vline = logger.Plot.AddVerticalLine(0);
            vline.PositionLabel = true;

            MAIN_formsplot.Plot.Title(param.name);
            MAIN_formsplot.Plot.XLabel("Время");
            MAIN_formsplot.Plot.AxisAuto();
            logger.LineColor = Color.OrangeRed;
            logger.MarkerColor = Color.OrangeRed;
            MAIN_formsplot.Refresh();
        }

        //private void plot_MouseMove (object sender, MouseEventArgs e)
        //{
        //    FormsPlot plt = (sender as FormsPlot);
        //    (double x, double y) = plt.GetMouseCoordinates();
        //    // MyScatterPlot = plt.Plot.AddScatterPoints();
        //    plt.hline.Y = y;
        //    plt.vline.X = x;
        //    // plt.Plot.AddVerticalLine(x);
        //    plt.Refresh();
        //    //Console.WriteLine($"Mouse at ({x}, {y})");
        //}
        delegate Task ButLogger();
        public async Task FULL_Click()
        {
            if (MAIN_formsplot.InvokeRequired)
            {
                // ...тогда создаем обратный вызов...
                ButLogger d = new ButLogger(FULL_Click);
                this.Invoke(d, new object[] { });
            }
            // ...иначе все по старинке
            else
            {
                logger.ViewFull();
                MAIN_formsplot.Refresh();
            }
        }

        public async Task SLIDE_Click()
        {
            if (MAIN_formsplot.InvokeRequired)
            {
                // ...тогда создаем обратный вызов...
                ButLogger d = new ButLogger(SLIDE_Click);
                this.Invoke(d, new object[] { });
            }
            // ...иначе все по старинке
            else
            {
                logger.ViewSlide(100);
                MAIN_formsplot.Refresh();
            }
        }

        public async Task JUMP_Click()
        {
            if (MAIN_formsplot.InvokeRequired)
            {
                // ...тогда создаем обратный вызов...
                ButLogger d = new ButLogger(JUMP_Click);
                this.Invoke(d, new object[] { });
            }
            // ...иначе все по старинке
            else
            {
                logger.ViewJump(100);
                MAIN_formsplot.Refresh();
            }
        }
        
        public async Task Clear_data()
        {
            if (MAIN_formsplot.InvokeRequired)
            {
                // ...тогда создаем обратный вызов...
                ButLogger d = new ButLogger(Clear_data);
                this.Invoke(d, new object[] {  });
            }
            // ...иначе все по старинке
            else
            {
                start  = DateTime.Now;
                logger.Clear();
                hline.Y = 0;
                vline.X = 0;
                MAIN_formsplot.Refresh();
            }
        }

       

        delegate Task SetChartCallback(user_tlm.param_val param);

        public async Task Refresh_chart(user_tlm.param_val param)
        //public void Refresh_chart()
        {
            // Если процесс пытающийся установить текст в элементах формы не тот же из которого они были созданы...
            if (MAIN_formsplot.InvokeRequired)
            {
                // ...тогда создаем обратный вызов...
                SetChartCallback d = new SetChartCallback(Refresh_chart);
                this.Invoke(d, new object[] { param });
            }
            // ...иначе все по старинке
            else
            {
                double temp_time = (DateTime.Now.Ticks - start.Ticks)/1000000;
                logger.Add(temp_time, param.val);
                hline.Y = param.val;
                vline.X = temp_time;
                MAIN_formsplot.Refresh();


                //while ((j < list_tlm.Count) && (list_tlm[j].type == "bool"))
                //    j++;

                //for (int i = 0; i < list_logger.Count; i++)
                //{
                //    if (list_logger[i].Label == "Напряжение анода")
                //    {
                //        list_logger[i].Add(temp_time, list_tlm[i+j].val);
                //        //hline[i].Y = list_tlm[i+j].val;
                //    }
                //    else
                //    {
                //        if (list_tlm[i+j].val > max)
                //            max =  list_tlm[i+j].val;
                //        if (list_tlm[i+j].val < min)
                //            min =  list_tlm[i+j].val;

                //        list_logger[i].Add(temp_time, list_tlm[i+j].val);

                //        //hline[i].Y = list_tlm[i+j].val;
                //    }
                //}

                //for (int i = 0; i < list_logger.Count; i++)
                //{
                //    if (list_logger[i].Label != "Напряжение анода")
                //    {
                //        list_logger[i].Plot.SetAxisLimitsY(min,max);
                //        //list_logger[i].Plot.AxisAuto();
                //    }
                //}
                //logger.Add(temp_time, val);
                //MAIN_formsplot.Plot.AxisAuto();

                //hline.Y = val;

            }
        }
    }
}
