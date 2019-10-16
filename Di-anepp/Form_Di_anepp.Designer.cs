namespace Di_anepp
{
    partial class Form_Di_anepp
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Di_anepp));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel_LUT = new System.Windows.Forms.Panel();
            this.label_val_5 = new System.Windows.Forms.Label();
            this.label_val_4 = new System.Windows.Forms.Label();
            this.label_val_3 = new System.Windows.Forms.Label();
            this.label_val_2 = new System.Windows.Forms.Label();
            this.label_val_1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox_Brightness = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Max = new System.Windows.Forms.TextBox();
            this.textBox_Min = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Store = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.textBox_Gfactor = new System.Windows.Forms.TextBox();
            this.textBox_Threshold = new System.Windows.Forms.TextBox();
            this.comboBox_Disordered = new System.Windows.Forms.ComboBox();
            this.comboBox_Ordered = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Panel_Border = new System.Windows.Forms.Panel();
            this.panel_Chart = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel_Img = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_ROIs = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel_LUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.Panel_Border.SuspendLayout();
            this.panel_Chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel_Img.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acquisition ordered channel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Acquisition disordered channel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(22, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lower threshold value for GP image";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(9, 122);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Use G factor";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_ROIs);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Store);
            this.groupBox1.Controls.Add(this.button_Refresh);
            this.groupBox1.Controls.Add(this.textBox_Gfactor);
            this.groupBox1.Controls.Add(this.textBox_Threshold);
            this.groupBox1.Controls.Add(this.comboBox_Disordered);
            this.groupBox1.Controls.Add(this.comboBox_Ordered);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 459);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel_LUT);
            this.groupBox2.Controls.Add(this.textBox_Brightness);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_Max);
            this.groupBox2.Controls.Add(this.textBox_Min);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(20, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 143);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lookup Table";
            // 
            // panel_LUT
            // 
            this.panel_LUT.BackColor = System.Drawing.Color.White;
            this.panel_LUT.Controls.Add(this.label_val_5);
            this.panel_LUT.Controls.Add(this.label_val_4);
            this.panel_LUT.Controls.Add(this.label_val_3);
            this.panel_LUT.Controls.Add(this.label_val_2);
            this.panel_LUT.Controls.Add(this.label_val_1);
            this.panel_LUT.Controls.Add(this.pictureBox2);
            this.panel_LUT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_LUT.Location = new System.Drawing.Point(3, 77);
            this.panel_LUT.Name = "panel_LUT";
            this.panel_LUT.Size = new System.Drawing.Size(300, 63);
            this.panel_LUT.TabIndex = 13;
            // 
            // label_val_5
            // 
            this.label_val_5.AutoSize = true;
            this.label_val_5.Location = new System.Drawing.Point(248, 43);
            this.label_val_5.Name = "label_val_5";
            this.label_val_5.Size = new System.Drawing.Size(48, 13);
            this.label_val_5.TabIndex = 18;
            this.label_val_5.Text = "label12";
            // 
            // label_val_4
            // 
            this.label_val_4.AutoSize = true;
            this.label_val_4.Location = new System.Drawing.Point(189, 43);
            this.label_val_4.Name = "label_val_4";
            this.label_val_4.Size = new System.Drawing.Size(48, 13);
            this.label_val_4.TabIndex = 17;
            this.label_val_4.Text = "label11";
            // 
            // label_val_3
            // 
            this.label_val_3.AutoSize = true;
            this.label_val_3.Location = new System.Drawing.Point(126, 43);
            this.label_val_3.Name = "label_val_3";
            this.label_val_3.Size = new System.Drawing.Size(48, 13);
            this.label_val_3.TabIndex = 16;
            this.label_val_3.Text = "label10";
            // 
            // label_val_2
            // 
            this.label_val_2.AutoSize = true;
            this.label_val_2.Location = new System.Drawing.Point(64, 43);
            this.label_val_2.Name = "label_val_2";
            this.label_val_2.Size = new System.Drawing.Size(41, 13);
            this.label_val_2.TabIndex = 15;
            this.label_val_2.Text = "label9";
            // 
            // label_val_1
            // 
            this.label_val_1.AutoSize = true;
            this.label_val_1.Location = new System.Drawing.Point(4, 43);
            this.label_val_1.Name = "label_val_1";
            this.label_val_1.Size = new System.Drawing.Size(72, 13);
            this.label_val_1.TabIndex = 14;
            this.label_val_1.Text = "label_val_1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(24, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(251, 23);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // textBox_Brightness
            // 
            this.textBox_Brightness.Location = new System.Drawing.Point(131, 47);
            this.textBox_Brightness.Name = "textBox_Brightness";
            this.textBox_Brightness.Size = new System.Drawing.Size(52, 20);
            this.textBox_Brightness.TabIndex = 7;
            this.textBox_Brightness.Text = "0.7";
            this.textBox_Brightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(129, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Brightness";
            // 
            // textBox_Max
            // 
            this.textBox_Max.Location = new System.Drawing.Point(248, 47);
            this.textBox_Max.Name = "textBox_Max";
            this.textBox_Max.Size = new System.Drawing.Size(52, 20);
            this.textBox_Max.TabIndex = 4;
            this.textBox_Max.Text = "1";
            this.textBox_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Min
            // 
            this.textBox_Min.Location = new System.Drawing.Point(10, 47);
            this.textBox_Min.Name = "textBox_Min";
            this.textBox_Min.Size = new System.Drawing.Size(52, 20);
            this.textBox_Min.TabIndex = 3;
            this.textBox_Min.Text = "-1";
            this.textBox_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(248, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Maximum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Minimum";
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(253, 373);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 10;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Store
            // 
            this.button_Store.Location = new System.Drawing.Point(135, 373);
            this.button_Store.Name = "button_Store";
            this.button_Store.Size = new System.Drawing.Size(75, 23);
            this.button_Store.TabIndex = 9;
            this.button_Store.Text = "Store";
            this.button_Store.UseVisualStyleBackColor = true;
            this.button_Store.Click += new System.EventHandler(this.button_Store_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(25, 373);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(75, 23);
            this.button_Refresh.TabIndex = 8;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // textBox_Gfactor
            // 
            this.textBox_Gfactor.Enabled = false;
            this.textBox_Gfactor.Location = new System.Drawing.Point(222, 120);
            this.textBox_Gfactor.Name = "textBox_Gfactor";
            this.textBox_Gfactor.Size = new System.Drawing.Size(109, 20);
            this.textBox_Gfactor.TabIndex = 7;
            this.textBox_Gfactor.Text = "1";
            this.textBox_Gfactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Threshold
            // 
            this.textBox_Threshold.Location = new System.Drawing.Point(222, 90);
            this.textBox_Threshold.Name = "textBox_Threshold";
            this.textBox_Threshold.Size = new System.Drawing.Size(109, 20);
            this.textBox_Threshold.TabIndex = 6;
            this.textBox_Threshold.Text = "15";
            this.textBox_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBox_Disordered
            // 
            this.comboBox_Disordered.FormattingEnabled = true;
            this.comboBox_Disordered.Location = new System.Drawing.Point(222, 58);
            this.comboBox_Disordered.Name = "comboBox_Disordered";
            this.comboBox_Disordered.Size = new System.Drawing.Size(109, 21);
            this.comboBox_Disordered.TabIndex = 5;
            // 
            // comboBox_Ordered
            // 
            this.comboBox_Ordered.FormattingEnabled = true;
            this.comboBox_Ordered.Location = new System.Drawing.Point(222, 26);
            this.comboBox_Ordered.Name = "comboBox_Ordered";
            this.comboBox_Ordered.Size = new System.Drawing.Size(109, 21);
            this.comboBox_Ordered.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 29);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 488);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 29);
            this.panel2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(893, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Copyright (C) 2018  Georgi Danovski";
            // 
            // Panel_Border
            // 
            this.Panel_Border.Controls.Add(this.panel_Chart);
            this.Panel_Border.Controls.Add(this.panel_Img);
            this.Panel_Border.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Border.Location = new System.Drawing.Point(349, 29);
            this.Panel_Border.Name = "Panel_Border";
            this.Panel_Border.Size = new System.Drawing.Size(735, 459);
            this.Panel_Border.TabIndex = 8;
            // 
            // panel_Chart
            // 
            this.panel_Chart.Controls.Add(this.dataGridView1);
            this.panel_Chart.Controls.Add(this.chart1);
            this.panel_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Chart.Location = new System.Drawing.Point(356, 0);
            this.panel_Chart.Name = "panel_Chart";
            this.panel_Chart.Size = new System.Drawing.Size(379, 459);
            this.panel_Chart.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 238);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(379, 221);
            this.dataGridView1.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(379, 238);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panel_Img
            // 
            this.panel_Img.AutoScroll = true;
            this.panel_Img.Controls.Add(this.pictureBox1);
            this.panel_Img.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Img.Location = new System.Drawing.Point(0, 0);
            this.panel_Img.Name = "panel_Img";
            this.panel_Img.Size = new System.Drawing.Size(356, 459);
            this.panel_Img.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(22, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Use ROI:";
            // 
            // comboBox_ROIs
            // 
            this.comboBox_ROIs.FormattingEnabled = true;
            this.comboBox_ROIs.Location = new System.Drawing.Point(222, 151);
            this.comboBox_ROIs.Name = "comboBox_ROIs";
            this.comboBox_ROIs.Size = new System.Drawing.Size(109, 21);
            this.comboBox_ROIs.TabIndex = 13;
            // 
            // Form_Di_anepp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 517);
            this.Controls.Add(this.Panel_Border);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form_Di_anepp";
            this.Text = "Di_anepp PlugIn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Di_anepp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel_LUT.ResumeLayout(false);
            this.panel_LUT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Panel_Border.ResumeLayout(false);
            this.panel_Chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel_Img.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Gfactor;
        private System.Windows.Forms.TextBox textBox_Threshold;
        private System.Windows.Forms.ComboBox comboBox_Disordered;
        private System.Windows.Forms.ComboBox comboBox_Ordered;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Store;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Panel Panel_Border;
        private System.Windows.Forms.Panel panel_Chart;
        private System.Windows.Forms.Panel panel_Img;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Max;
        private System.Windows.Forms.TextBox textBox_Min;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Brightness;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel_LUT;
        private System.Windows.Forms.Label label_val_5;
        private System.Windows.Forms.Label label_val_4;
        private System.Windows.Forms.Label label_val_3;
        private System.Windows.Forms.Label label_val_2;
        private System.Windows.Forms.Label label_val_1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBox_ROIs;
        private System.Windows.Forms.Label label8;
    }
}