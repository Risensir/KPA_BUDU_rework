namespace KPA_BUDU_rework
{
    partial class MAIN_KPA_BUDU
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.KPA_BUDU_main_table = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xml_button_panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.записьТелеметрииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чтениеТелеметрииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UART_setting = new KPA_BUDU_rework.uart_setting();
            this.Console = new KPA_BUDU_rework.user_Console();
            this.xml_button = new KPA_BUDU_rework.XML_button();
            this.KPA_BUDU_main_table.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menu_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // KPA_BUDU_main_table
            // 
            this.KPA_BUDU_main_table.ColumnCount = 2;
            this.KPA_BUDU_main_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.KPA_BUDU_main_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KPA_BUDU_main_table.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.KPA_BUDU_main_table.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.KPA_BUDU_main_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KPA_BUDU_main_table.Location = new System.Drawing.Point(4, 35);
            this.KPA_BUDU_main_table.Name = "KPA_BUDU_main_table";
            this.KPA_BUDU_main_table.RowCount = 1;
            this.KPA_BUDU_main_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KPA_BUDU_main_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 529F));
            this.KPA_BUDU_main_table.Size = new System.Drawing.Size(1226, 529);
            this.KPA_BUDU_main_table.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.UART_setting, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Console, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.xml_button, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 523);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.xml_button_panel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(503, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.41281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.58719F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(720, 523);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // xml_button_panel
            // 
            this.xml_button_panel.AutoScroll = true;
            this.xml_button_panel.AutoSize = true;
            this.xml_button_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.xml_button_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.xml_button_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xml_button_panel.Location = new System.Drawing.Point(3, 78);
            this.xml_button_panel.Name = "xml_button_panel";
            this.xml_button_panel.Size = new System.Drawing.Size(714, 442);
            this.xml_button_panel.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1232F));
            this.tableLayoutPanel3.Controls.Add(this.KPA_BUDU_main_table, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.menu_main, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1103, 568);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // menu_main
            // 
            this.menu_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menu_main.Location = new System.Drawing.Point(1, 1);
            this.menu_main.Name = "menu_main";
            this.menu_main.Size = new System.Drawing.Size(1232, 28);
            this.menu_main.TabIndex = 1;
            this.menu_main.Text = "Меню";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.записьТелеметрииToolStripMenuItem,
            this.чтениеТелеметрииToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(65, 24);
            this.toolStripMenuItem1.Text = "Меню";
            // 
            // записьТелеметрииToolStripMenuItem
            // 
            this.записьТелеметрииToolStripMenuItem.Name = "записьТелеметрииToolStripMenuItem";
            this.записьТелеметрииToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.записьТелеметрииToolStripMenuItem.Text = "Запись телеметрии";
            this.записьТелеметрииToolStripMenuItem.Click += new System.EventHandler(this.записьТелеметрииToolStripMenuItem_Click);
            // 
            // чтениеТелеметрииToolStripMenuItem
            // 
            this.чтениеТелеметрииToolStripMenuItem.Name = "чтениеТелеметрииToolStripMenuItem";
            this.чтениеТелеметрииToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.чтениеТелеметрииToolStripMenuItem.Text = "Чтение телеметрии";
            this.чтениеТелеметрииToolStripMenuItem.Click += new System.EventHandler(this.чтениеТелеметрииToolStripMenuItem_Click);
            // 
            // UART_setting
            // 
            this.UART_setting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UART_setting.Location = new System.Drawing.Point(5, 91);
            this.UART_setting.Name = "UART_setting";
            this.UART_setting.Size = new System.Drawing.Size(484, 184);
            this.UART_setting.TabIndex = 0;
            // 
            // Console
            // 
            this.Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Console.Location = new System.Drawing.Point(5, 283);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(484, 235);
            this.Console.TabIndex = 1;
            // 
            // xml_button
            // 
            this.xml_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xml_button.Location = new System.Drawing.Point(5, 5);
            this.xml_button.Name = "xml_button";
            this.xml_button.Size = new System.Drawing.Size(484, 78);
            this.xml_button.TabIndex = 1;
            // 
            // MAIN_KPA_BUDU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 568);
            this.Controls.Add(this.tableLayoutPanel3);
            this.MainMenuStrip = this.menu_main;
            this.Name = "MAIN_KPA_BUDU";
            this.Text = "KPA_BUDU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KPA_BUDU_main_table.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel KPA_BUDU_main_table;
        private uart_setting UART_setting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private user_Console Console;
        private XML_button xml_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel xml_button_panel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.MenuStrip menu_main;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem записьТелеметрииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem чтениеТелеметрииToolStripMenuItem;
    }
}

