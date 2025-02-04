using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;
using static ScottPlot.Plottable.PopulationPlot;

namespace KPA_BUDU_rework
{
    public partial class user_scottplot_bar : UserControl
    {
        private class user_bar
        {
            public double xs = 0;
            public double ys = 0;
            public double yoffset = 0;
            public double error = 0;
            public Color color;
            public BarPlot bar;
            public HLine hline = new HLine();
            public Func<double, string> position_format_user;
        }
        private VLine vline = new VLine();
        private int STATE = 0;
        private double yoffset_global = 0;
        private DateTime start = DateTime.Now;
        private List<Color> colors = new List<Color>() { Color.Red ,Color.Green , Color.Black , Color.Blue ,
                                                        Color.Brown, Color.Azure, Color.Linen, Color.Maroon,
                                                        Color.Orange,Color.Olive,Color.Pink,Color.Violet,Color.Gold,
                                                        Color.Fuchsia,Color.Gray};
        List<user_bar> BARS  = new List<user_bar>();
        private UInt32 slide_size = 300;
        private double time_old_jump = 0;
        public user_scottplot_bar(List<user_tlm.param_val> list_tlm)
        {
            InitializeComponent();
            MAIN_formsplot_bar.Plot.AxisAuto();
            vline.PositionLabel = true;
            vline.X = 0;
            vline.IsVisible= true;
            MAIN_formsplot_bar.Plot.Add(vline);
            foreach (user_tlm.param_val param in list_tlm)
            {
                if (param.type == "bool")
                {
                    
                    BARS.Add(new user_bar());
                    BARS[BARS.Count-1].position_format_user = position => param.short_name;
                }
            }
            int xoffset = 0;
            int color_id = 0;
            foreach(user_bar bar in BARS)
            {
                bar.color  = colors[color_id];

                bar.hline.Y = xoffset;
                bar.hline.IsVisible = true;
                
                bar.hline.PositionFormatter = bar.position_format_user;
                bar.hline.PositionLabel = true;
                bar.hline.Color = bar.color;
                bar.hline.PositionLabelFont.Size = 12;

                color_id++;
                bar.xs = xoffset;
                xoffset += 2;
                bar.ys = 0;
                bar.error = 0;
                bar.yoffset = 0;
                bar.bar = new BarPlot(new double[] { bar.xs } ,new double[] { bar.ys },new double[] { bar.error },new double[] { bar.yoffset });
                bar.bar.HorizontalOrientation = true;
                bar.bar.Color = bar.color;
                
                MAIN_formsplot_bar.Plot.Add(bar.bar);
                MAIN_formsplot_bar.Plot.Add(bar.hline);
            }
            MAIN_formsplot_bar.Refresh();
        }
        delegate Task RefreshDelegate(List<user_tlm.param_val> list_tlm);
        public async Task refresh_bar(List<user_tlm.param_val> list_tlm)
        {
            if (MAIN_formsplot_bar.InvokeRequired)
            {
                RefreshDelegate d = new RefreshDelegate(refresh_bar);
                this.Invoke(d, new object[] { list_tlm });
            }
            else
            {
                int i = 0;
                double temp_time = (DateTime.Now.Ticks - start.Ticks)/1000000;
                foreach (user_tlm.param_val param in list_tlm)
                {
                    if (param.type == "bool")
                    {
                        if (param.val == 1)
                        {
                            BARS[i].ys = 1;

                            BARS[i].yoffset = temp_time;
                            BARS[i].bar = new BarPlot(new double[] { BARS[i].xs }, new double[] { BARS[i].ys }, new double[] { BARS[i].error }, new double[] { BARS[i].yoffset });
                            BARS[i].bar.PositionOffset = BARS[i].bar.BarWidth/2;
                            BARS[i].bar.HorizontalOrientation = true;
                            BARS[i].bar.Color = BARS[i].color;
                            MAIN_formsplot_bar.Plot.Add(BARS[i].bar);
                            i++;
                        }
                    }
                }
                vline.X = temp_time;
                if (STATE == 0)
                {
                    MAIN_formsplot_bar.Plot.AxisAuto();
                }
                else if (STATE == 1)
                {
                    MAIN_formsplot_bar.Plot.SetAxisLimitsX(temp_time - slide_size, temp_time);
                }
                else if (STATE == 2)
                {
                    if (time_old_jump < temp_time - slide_size)
                    {
                        MAIN_formsplot_bar.Plot.SetAxisLimitsX(temp_time , temp_time + slide_size);
                        time_old_jump = temp_time;
                    }
                }
                    
                MAIN_formsplot_bar.Refresh();
                yoffset_global++;
            }
        }
        public void switch_STATE(int state)
        {
            STATE = state;
        }
    }
}
