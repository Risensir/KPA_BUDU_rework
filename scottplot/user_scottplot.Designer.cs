namespace KPA_BUDU_rework
{
    partial class user_scottplot
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
            this.MAIN_formsplot = new ScottPlot.FormsPlot();
            this.SuspendLayout();
            // 
            // MAIN_formsplot
            // 
            this.MAIN_formsplot.Dock = System.Windows.Forms.DockStyle.Left;
            this.MAIN_formsplot.Location = new System.Drawing.Point(0, 0);
            this.MAIN_formsplot.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MAIN_formsplot.Name = "MAIN_formsplot";
            this.MAIN_formsplot.Size = new System.Drawing.Size(532, 376);
            this.MAIN_formsplot.TabIndex = 0;
            // 
            // user_scottplot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.MAIN_formsplot);
            this.Name = "user_scottplot";
            this.Size = new System.Drawing.Size(532, 376);
            this.ResumeLayout(false);

        }

        #endregion

        public ScottPlot.FormsPlot MAIN_formsplot;
    }
}
