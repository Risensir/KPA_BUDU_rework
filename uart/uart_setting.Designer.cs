namespace KPA_BUDU_rework
{
    partial class uart_setting
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
            this.components = new System.ComponentModel.Container();
            this.uart_main_table = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.uart_open_close = new System.Windows.Forms.Button();
            this.uart_stop_tlm_but = new System.Windows.Forms.Button();
            this.uart_start_tlm_but = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uart_port_combobox = new System.Windows.Forms.ComboBox();
            this.uart_port_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uart_baudrate_combobox = new System.Windows.Forms.ComboBox();
            this.uart_parity_combobox = new System.Windows.Forms.ComboBox();
            this.uart_data_bits_combobox = new System.Windows.Forms.ComboBox();
            this.uart_stop_label = new System.Windows.Forms.Label();
            this.uart_stop_combobox = new System.Windows.Forms.ComboBox();
            this.uart_number_bits_label = new System.Windows.Forms.Label();
            this.uart_baudrate_label = new System.Windows.Forms.Label();
            this.uart_parity_label = new System.Windows.Forms.Label();
            this.uart_check_timer = new System.Windows.Forms.Timer(this.components);
            this.Telemetry_request_timer = new System.Windows.Forms.Timer(this.components);
            this.uart_main_table.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uart_main_table
            // 
            this.uart_main_table.ColumnCount = 1;
            this.uart_main_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uart_main_table.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.uart_main_table.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.uart_main_table.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.uart_main_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uart_main_table.Location = new System.Drawing.Point(0, 0);
            this.uart_main_table.Margin = new System.Windows.Forms.Padding(2);
            this.uart_main_table.Name = "uart_main_table";
            this.uart_main_table.RowCount = 3;
            this.uart_main_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uart_main_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uart_main_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uart_main_table.Size = new System.Drawing.Size(536, 448);
            this.uart_main_table.TabIndex = 56;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.uart_open_close, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.uart_stop_tlm_but, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.uart_start_tlm_but, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 300);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(532, 146);
            this.tableLayoutPanel4.TabIndex = 58;
            // 
            // uart_open_close
            // 
            this.uart_open_close.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.uart_open_close.AutoEllipsis = true;
            this.uart_open_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uart_open_close.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.uart_open_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uart_open_close.ForeColor = System.Drawing.Color.ForestGreen;
            this.uart_open_close.Location = new System.Drawing.Point(2, 2);
            this.uart_open_close.Margin = new System.Windows.Forms.Padding(2);
            this.uart_open_close.Name = "uart_open_close";
            this.uart_open_close.Size = new System.Drawing.Size(262, 142);
            this.uart_open_close.TabIndex = 52;
            this.uart_open_close.Text = "Запустить";
            this.uart_open_close.UseVisualStyleBackColor = true;
            // 
            // uart_stop_tlm_but
            // 
            this.uart_stop_tlm_but.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uart_stop_tlm_but.Location = new System.Drawing.Point(401, 2);
            this.uart_stop_tlm_but.Margin = new System.Windows.Forms.Padding(2);
            this.uart_stop_tlm_but.Name = "uart_stop_tlm_but";
            this.uart_stop_tlm_but.Size = new System.Drawing.Size(129, 142);
            this.uart_stop_tlm_but.TabIndex = 54;
            this.uart_stop_tlm_but.Text = "Стоп Телеметрии";
            this.uart_stop_tlm_but.UseVisualStyleBackColor = true;
            this.uart_stop_tlm_but.Click += new System.EventHandler(this.uart_stop_tlm_but_Click);
            // 
            // uart_start_tlm_but
            // 
            this.uart_start_tlm_but.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uart_start_tlm_but.Location = new System.Drawing.Point(268, 2);
            this.uart_start_tlm_but.Margin = new System.Windows.Forms.Padding(2);
            this.uart_start_tlm_but.Name = "uart_start_tlm_but";
            this.uart_start_tlm_but.Size = new System.Drawing.Size(129, 142);
            this.uart_start_tlm_but.TabIndex = 53;
            this.uart_start_tlm_but.Text = "Запрос Телеметрии";
            this.uart_start_tlm_but.UseVisualStyleBackColor = true;
            this.uart_start_tlm_but.Click += new System.EventHandler(this.uart_start_tlm_but_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.uart_port_combobox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uart_port_label, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(532, 145);
            this.tableLayoutPanel2.TabIndex = 56;
            // 
            // uart_port_combobox
            // 
            this.uart_port_combobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uart_port_combobox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.uart_port_combobox.FormattingEnabled = true;
            this.uart_port_combobox.Location = new System.Drawing.Point(2, 74);
            this.uart_port_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.uart_port_combobox.Name = "uart_port_combobox";
            this.uart_port_combobox.Size = new System.Drawing.Size(528, 21);
            this.uart_port_combobox.TabIndex = 43;
            // 
            // uart_port_label
            // 
            this.uart_port_label.AutoSize = true;
            this.uart_port_label.Location = new System.Drawing.Point(2, 0);
            this.uart_port_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uart_port_label.Name = "uart_port_label";
            this.uart_port_label.Size = new System.Drawing.Size(57, 13);
            this.uart_port_label.TabIndex = 42;
            this.uart_port_label.Text = "COM порт";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.uart_baudrate_combobox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.uart_parity_combobox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.uart_data_bits_combobox, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.uart_stop_label, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.uart_stop_combobox, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.uart_number_bits_label, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.uart_baudrate_label, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.uart_parity_label, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 151);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(532, 145);
            this.tableLayoutPanel3.TabIndex = 57;
            // 
            // uart_baudrate_combobox
            // 
            this.uart_baudrate_combobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uart_baudrate_combobox.FormattingEnabled = true;
            this.uart_baudrate_combobox.Items.AddRange(new object[] {
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "921600"});
            this.uart_baudrate_combobox.Location = new System.Drawing.Point(2, 74);
            this.uart_baudrate_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.uart_baudrate_combobox.Name = "uart_baudrate_combobox";
            this.uart_baudrate_combobox.Size = new System.Drawing.Size(129, 21);
            this.uart_baudrate_combobox.TabIndex = 44;
            // 
            // uart_parity_combobox
            // 
            this.uart_parity_combobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uart_parity_combobox.FormattingEnabled = true;
            this.uart_parity_combobox.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "Mark",
            "None"});
            this.uart_parity_combobox.Location = new System.Drawing.Point(135, 74);
            this.uart_parity_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.uart_parity_combobox.Name = "uart_parity_combobox";
            this.uart_parity_combobox.Size = new System.Drawing.Size(129, 21);
            this.uart_parity_combobox.TabIndex = 45;
            // 
            // uart_data_bits_combobox
            // 
            this.uart_data_bits_combobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uart_data_bits_combobox.FormattingEnabled = true;
            this.uart_data_bits_combobox.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.uart_data_bits_combobox.Location = new System.Drawing.Point(268, 74);
            this.uart_data_bits_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.uart_data_bits_combobox.Name = "uart_data_bits_combobox";
            this.uart_data_bits_combobox.Size = new System.Drawing.Size(129, 21);
            this.uart_data_bits_combobox.TabIndex = 47;
            // 
            // uart_stop_label
            // 
            this.uart_stop_label.AutoSize = true;
            this.uart_stop_label.Location = new System.Drawing.Point(401, 0);
            this.uart_stop_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uart_stop_label.Name = "uart_stop_label";
            this.uart_stop_label.Size = new System.Drawing.Size(54, 13);
            this.uart_stop_label.TabIndex = 50;
            this.uart_stop_label.Text = "Стоп. бит";
            // 
            // uart_stop_combobox
            // 
            this.uart_stop_combobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uart_stop_combobox.FormattingEnabled = true;
            this.uart_stop_combobox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.uart_stop_combobox.Location = new System.Drawing.Point(401, 74);
            this.uart_stop_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.uart_stop_combobox.Name = "uart_stop_combobox";
            this.uart_stop_combobox.Size = new System.Drawing.Size(129, 21);
            this.uart_stop_combobox.TabIndex = 49;
            // 
            // uart_number_bits_label
            // 
            this.uart_number_bits_label.AutoSize = true;
            this.uart_number_bits_label.Location = new System.Drawing.Point(268, 0);
            this.uart_number_bits_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uart_number_bits_label.Name = "uart_number_bits_label";
            this.uart_number_bits_label.Size = new System.Drawing.Size(49, 13);
            this.uart_number_bits_label.TabIndex = 48;
            this.uart_number_bits_label.Text = "Кол. бит";
            // 
            // uart_baudrate_label
            // 
            this.uart_baudrate_label.AutoSize = true;
            this.uart_baudrate_label.Location = new System.Drawing.Point(2, 0);
            this.uart_baudrate_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uart_baudrate_label.Name = "uart_baudrate_label";
            this.uart_baudrate_label.Size = new System.Drawing.Size(55, 13);
            this.uart_baudrate_label.TabIndex = 51;
            this.uart_baudrate_label.Text = "Скорость";
            // 
            // uart_parity_label
            // 
            this.uart_parity_label.AutoSize = true;
            this.uart_parity_label.Location = new System.Drawing.Point(135, 0);
            this.uart_parity_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uart_parity_label.Name = "uart_parity_label";
            this.uart_parity_label.Size = new System.Drawing.Size(53, 13);
            this.uart_parity_label.TabIndex = 46;
            this.uart_parity_label.Text = "Бит четн.";
            // 
            // uart_check_timer
            // 
            this.uart_check_timer.Tick += new System.EventHandler(this.uart_check_timer_Tick);
            // 
            // Telemetry_request_timer
            // 
            this.Telemetry_request_timer.Tick += new System.EventHandler(this.Telemetry_request_timer_Tick);
            // 
            // uart_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uart_main_table);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uart_setting";
            this.Size = new System.Drawing.Size(536, 448);
            this.uart_main_table.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel uart_main_table;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button uart_open_close;
        private System.Windows.Forms.Button uart_stop_tlm_but;
        private System.Windows.Forms.Button uart_start_tlm_but;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox uart_port_combobox;
        private System.Windows.Forms.Label uart_port_label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox uart_baudrate_combobox;
        private System.Windows.Forms.ComboBox uart_parity_combobox;
        private System.Windows.Forms.ComboBox uart_data_bits_combobox;
        private System.Windows.Forms.Label uart_stop_label;
        private System.Windows.Forms.ComboBox uart_stop_combobox;
        private System.Windows.Forms.Label uart_number_bits_label;
        private System.Windows.Forms.Label uart_baudrate_label;
        private System.Windows.Forms.Label uart_parity_label;
        private System.Windows.Forms.Timer uart_check_timer;
        private System.Windows.Forms.Timer Telemetry_request_timer;
    }
}
