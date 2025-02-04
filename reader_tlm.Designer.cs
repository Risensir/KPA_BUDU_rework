namespace KPA_BUDU_rework
{
    partial class reader_tlm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.split_play_plots = new System.Windows.Forms.SplitContainer();
            this.table_check_box = new System.Windows.Forms.TableLayoutPanel();
            this.table_plot = new System.Windows.Forms.TableLayoutPanel();
            this.switch_plot = new System.Windows.Forms.TabControl();
            this.fulls_plot = new System.Windows.Forms.TabPage();
            this.split_plot = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.split_play_plots)).BeginInit();
            this.split_play_plots.Panel1.SuspendLayout();
            this.split_play_plots.Panel2.SuspendLayout();
            this.split_play_plots.SuspendLayout();
            this.switch_plot.SuspendLayout();
            this.split_plot.SuspendLayout();
            this.SuspendLayout();
            // 
            // split_play_plots
            // 
            this.split_play_plots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_play_plots.Location = new System.Drawing.Point(0, 0);
            this.split_play_plots.Name = "split_play_plots";
            // 
            // split_play_plots.Panel1
            // 
            this.split_play_plots.Panel1.Controls.Add(this.switch_plot);
            // 
            // split_play_plots.Panel2
            // 
            this.split_play_plots.Panel2.Controls.Add(this.table_check_box);
            this.split_play_plots.Size = new System.Drawing.Size(800, 450);
            this.split_play_plots.SplitterDistance = 648;
            this.split_play_plots.TabIndex = 0;
            // 
            // table_check_box
            // 
            this.table_check_box.AutoScroll = true;
            this.table_check_box.ColumnCount = 1;
            this.table_check_box.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_check_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_check_box.Location = new System.Drawing.Point(0, 0);
            this.table_check_box.Name = "table_check_box";
            this.table_check_box.RowCount = 1;
            this.table_check_box.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_check_box.Size = new System.Drawing.Size(148, 450);
            this.table_check_box.TabIndex = 0;
            // 
            // table_plot
            // 
            this.table_plot.AutoScroll = true;
            this.table_plot.ColumnCount = 1;
            this.table_plot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_plot.Location = new System.Drawing.Point(3, 3);
            this.table_plot.Name = "table_plot";
            this.table_plot.RowCount = 1;
            this.table_plot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_plot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_plot.Size = new System.Drawing.Size(634, 415);
            this.table_plot.TabIndex = 0;
            // 
            // switch_plot
            // 
            this.switch_plot.Controls.Add(this.fulls_plot);
            this.switch_plot.Controls.Add(this.split_plot);
            this.switch_plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switch_plot.Location = new System.Drawing.Point(0, 0);
            this.switch_plot.Name = "switch_plot";
            this.switch_plot.SelectedIndex = 0;
            this.switch_plot.Size = new System.Drawing.Size(648, 450);
            this.switch_plot.TabIndex = 0;
            // 
            // fulls_plot
            // 
            this.fulls_plot.Location = new System.Drawing.Point(4, 25);
            this.fulls_plot.Name = "fulls_plot";
            this.fulls_plot.Padding = new System.Windows.Forms.Padding(3);
            this.fulls_plot.Size = new System.Drawing.Size(634, 415);
            this.fulls_plot.TabIndex = 0;
            this.fulls_plot.Text = "Общий график";
            this.fulls_plot.UseVisualStyleBackColor = true;
            // 
            // split_plot
            // 
            this.split_plot.Controls.Add(this.table_plot);
            this.split_plot.Location = new System.Drawing.Point(4, 25);
            this.split_plot.Name = "split_plot";
            this.split_plot.Padding = new System.Windows.Forms.Padding(3);
            this.split_plot.Size = new System.Drawing.Size(640, 421);
            this.split_plot.TabIndex = 1;
            this.split_plot.Text = "Отдельные графики";
            this.split_plot.UseVisualStyleBackColor = true;
            // 
            // reader_tlm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.split_play_plots);
            this.Name = "reader_tlm";
            this.Text = "reader_tlm";
            this.split_play_plots.Panel1.ResumeLayout(false);
            this.split_play_plots.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_play_plots)).EndInit();
            this.split_play_plots.ResumeLayout(false);
            this.switch_plot.ResumeLayout(false);
            this.split_plot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split_play_plots;
        private System.Windows.Forms.TableLayoutPanel table_check_box;
        private System.Windows.Forms.TableLayoutPanel table_plot;
        private System.Windows.Forms.TabControl switch_plot;
        private System.Windows.Forms.TabPage fulls_plot;
        private System.Windows.Forms.TabPage split_plot;
    }
}