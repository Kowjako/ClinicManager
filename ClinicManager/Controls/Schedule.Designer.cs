
namespace ClinicManager.Controls
{
    partial class Schedule
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.scheduleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClinics = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDoctor = new System.Windows.Forms.ComboBox();
            this.bsClinics = new System.Windows.Forms.BindingSource(this.components);
            this.bsDoctors = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClinics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDoctors)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(371, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "Zatwierdź okres";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(454, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(371, 23);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "Wyjdź";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // startDate
            // 
            this.startDate.CalendarFont = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDate.Location = new System.Drawing.Point(227, 11);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 20);
            this.startDate.TabIndex = 2;
            this.startDate.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data początkowa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data końcowa";
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(227, 44);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 20);
            this.endDate.TabIndex = 6;
            this.endDate.TabStop = false;
            // 
            // scheduleChart
            // 
            this.scheduleChart.BackColor = System.Drawing.SystemColors.Control;
            this.scheduleChart.BackSecondaryColor = System.Drawing.SystemColors.Control;
            chartArea4.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.BackColor = System.Drawing.SystemColors.Control;
            chartArea4.Name = "ChartArea1";
            this.scheduleChart.ChartAreas.Add(chartArea4);
            this.scheduleChart.Location = new System.Drawing.Point(12, 264);
            this.scheduleChart.Name = "scheduleChart";
            this.scheduleChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend2";
            series4.Name = "SeriesData";
            series4.YValuesPerPoint = 2;
            this.scheduleChart.Series.Add(series4);
            this.scheduleChart.Size = new System.Drawing.Size(809, 437);
            this.scheduleChart.TabIndex = 7;
            this.scheduleChart.Text = "chart1";
            title4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title4.Name = "Title1";
            title4.Text = "Ilość wizyt w zależności od dnia tygodnia";
            this.scheduleChart.Titles.Add(title4);
            this.scheduleChart.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Przychodnia";
            // 
            // cbClinics
            // 
            this.cbClinics.DataSource = this.bsClinics;
            this.cbClinics.DisplayMember = "Nazwa";
            this.cbClinics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClinics.FormattingEnabled = true;
            this.cbClinics.Location = new System.Drawing.Point(227, 80);
            this.cbClinics.Name = "cbClinics";
            this.cbClinics.Size = new System.Drawing.Size(200, 21);
            this.cbClinics.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Magenta;
            this.label4.Location = new System.Drawing.Point(13, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lekarz";
            // 
            // cbDoctor
            // 
            this.cbDoctor.DataSource = this.bsDoctors;
            this.cbDoctor.DisplayMember = "Lekarz";
            this.cbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoctor.FormattingEnabled = true;
            this.cbDoctor.Location = new System.Drawing.Point(227, 114);
            this.cbDoctor.Name = "cbDoctor";
            this.cbDoctor.Size = new System.Drawing.Size(200, 21);
            this.cbDoctor.TabIndex = 11;
            // 
            // bsClinics
            // 
            this.bsClinics.DataSource = typeof(ClinicManager.DataAccessLayer.ClinicRow);
            // 
            // bsDoctors
            // 
            this.bsDoctors.DataSource = typeof(ClinicManager.DataAccessLayer.EmployeeRow);
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 147);
            this.Controls.Add(this.cbDoctor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbClinics);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scheduleChart);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Schedule";
            this.Text = "Rozkład ilości wizyt w zależności od dnia";
            ((System.ComponentModel.ISupportInitialize)(this.scheduleChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClinics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDoctors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart scheduleChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClinics;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDoctor;
        private System.Windows.Forms.BindingSource bsClinics;
        private System.Windows.Forms.BindingSource bsDoctors;
    }
}