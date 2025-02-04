namespace KPA_BUDU_rework
{
    partial class user_scottplot_bar
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
            this.MAIN_formsplot_bar = new ScottPlot.FormsPlot();
            this.SuspendLayout();
            // 
            // MAIN_formsplot_bar
            // 
            this.MAIN_formsplot_bar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAIN_formsplot_bar.Location = new System.Drawing.Point(0, 0);
            this.MAIN_formsplot_bar.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.MAIN_formsplot_bar.Name = "MAIN_formsplot_bar";
            this.MAIN_formsplot_bar.Padding = new System.Windows.Forms.Padding(1);
            this.MAIN_formsplot_bar.Size = new System.Drawing.Size(1165, 328);
            this.MAIN_formsplot_bar.TabIndex = 0;
            // 
            // user_scottplot_bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MAIN_formsplot_bar);
            this.Name = "user_scottplot_bar";
            this.Size = new System.Drawing.Size(1165, 328);
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot MAIN_formsplot_bar;
    }
}
