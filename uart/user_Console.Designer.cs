namespace KPA_BUDU_rework
{
    partial class user_Console
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.user_console_text_box = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.user_console_clean_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // user_console_text_box
            // 
            this.user_console_text_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_console_text_box.Location = new System.Drawing.Point(3, 43);
            this.user_console_text_box.Multiline = true;
            this.user_console_text_box.Name = "user_console_text_box";
            this.user_console_text_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.user_console_text_box.Size = new System.Drawing.Size(443, 399);
            this.user_console_text_box.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.user_console_text_box, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.user_console_clean_button, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 445);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // user_console_clean_button
            // 
            this.user_console_clean_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_console_clean_button.Location = new System.Drawing.Point(3, 3);
            this.user_console_clean_button.Name = "user_console_clean_button";
            this.user_console_clean_button.Size = new System.Drawing.Size(443, 34);
            this.user_console_clean_button.TabIndex = 1;
            this.user_console_clean_button.Text = "Очистить";
            this.user_console_clean_button.UseVisualStyleBackColor = true;
            this.user_console_clean_button.Click += new System.EventHandler(this.user_console_clean_button_Click);
            // 
            // user_Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "user_Console";
            this.Size = new System.Drawing.Size(449, 445);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox user_console_text_box;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button user_console_clean_button;
    }
}
