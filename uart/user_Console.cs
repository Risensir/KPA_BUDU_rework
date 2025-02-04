using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_BUDU_rework
{
    public partial class user_Console : UserControl
    {
        public user_Console()
        {
            InitializeComponent();
        }

        private void user_console_clean_button_Click(object sender, EventArgs e)
        {
            this.user_console_text_box.Text = "";
        }

        delegate void SetTextCallback(string text1);
        public void SetText(string text)
        {
            // Если процесс пытающийся установить текст в элементах формы не тот же из которого они были созданы...
            if (this.user_console_text_box.InvokeRequired)
            {
                // ...тогда создаем обратный вызов...
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            // ...иначе все по старинке
            else
            { 
                if (user_console_text_box.Text.Length > 3000)
                    user_console_text_box.Text = "";

                this.user_console_text_box.AppendText(user_Time.get_time_string() + "-  " + text);

                //SetLog(text, log_file);

                //this.textBox1.Text += text1;
            }
        }
    }
}
