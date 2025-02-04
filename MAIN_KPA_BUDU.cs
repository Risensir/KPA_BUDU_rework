using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KPA_BUDU_rework.user_tlm;

namespace KPA_BUDU_rework
{
    public partial class MAIN_KPA_BUDU : Form
    {
       // private uart_setting uart_set = new uart_setting();
        user_tlm user_TLM = new user_tlm();
        Graph_write graph;
        public MAIN_KPA_BUDU()
        {
            InitializeComponent();
            UART_setting.PrintHandler += Set_Text;
            UART_setting.TelemetryHandler += Construct_Telemetry;
            UART_setting.AskTelemetry += Telemetry_request;
            xml_button.PrintHandler += Set_Text;
            xml_button.TableHandler += xml_table_construct;
           // XML_reader.PrintHandler+= Set_Text;
            xml_button.SendByteHandler += UART_out;
            user_TLM.ShowTelemetryHandler += Set_Telemetry;
            //XML_reader.XML_STRUCT_COMMAND_READ("STRUCT_COMMAND.xml");
            //XML_reader.XML_STRUCT_ANSWER_READ("STRUCT_ANSWER.xml");
            xml_button.xml_load();

            
            saver.PrintHandler+= Set_Text;

        }
        private void Set_Text(string str)
        {
            Console.SetText(str);
        }

        private void Telemetry_request()
        {
            if (saver.isInit == false)
                saver.init_saver(user_TLM.list_tlm);
            xml_button.Telemetry_request();
        }

        private void xml_table_construct(TableLayoutPanel table)
        {
            xml_button_panel.Controls.Add(table);
        }

        private void UART_out(byte[] msg)
        {
            Set_Text(BitConverter.ToString(msg) + Environment.NewLine);
            UART_setting.UART_WRITE(msg);
        }

        private void записьТелеметрииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph = new Graph_write(user_TLM.list_tlm);
            graph.Show();
        }
        private void чтениеТелеметрииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reader_tlm tlm_reader = new reader_tlm();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                tlm_reader.read_file(@openFileDialog.FileName);
                tlm_reader.Show();
            }
        }

        private void Construct_Telemetry(List<byte> data)
        {
            user_TLM.construct_telemetry_list(data);
            saver.SaveTelemetry(user_TLM.list_tlm);
            if (graph != null)
                graph.refresh_flag(user_TLM.list_tlm);
        }
        private void Set_Telemetry(List<param_val> tlm)
        {
            if (graph != null)
                graph.refresh_flag(tlm);

            
        }

        
    }
}
