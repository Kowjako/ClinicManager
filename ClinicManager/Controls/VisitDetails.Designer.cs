
namespace ClinicManager
{
    partial class VisitDetails
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this._bsRegistration = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.patientBox = new System.Windows.Forms.ComboBox();
            this._bsPatients = new System.Windows.Forms.BindingSource(this.components);
            this.employeeBox = new System.Windows.Forms.ComboBox();
            this._bsEmployees = new System.Windows.Forms.BindingSource(this.components);
            this.saveBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.erp = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._bsRegistration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this._bsRegistration, "Date", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(182, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(325, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // _bsRegistration
            // 
            this._bsRegistration.DataSource = typeof(ClinicManager.DataAccessLayer.Registrations);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Data wizyty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Godzina wizyty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Pacjent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Lekarz";
            // 
            // patientBox
            // 
            this.patientBox.DataSource = this._bsPatients;
            this.patientBox.DisplayMember = "Pacjent";
            this.patientBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.patientBox.FormattingEnabled = true;
            this.patientBox.Location = new System.Drawing.Point(182, 68);
            this.patientBox.Name = "patientBox";
            this.patientBox.Size = new System.Drawing.Size(325, 21);
            this.patientBox.TabIndex = 19;
            this.patientBox.ValueMember = "Id";
            // 
            // _bsPatients
            // 
            this._bsPatients.DataSource = typeof(ClinicManager.DataAccessLayer.PatientRow);
            // 
            // employeeBox
            // 
            this.employeeBox.DataSource = this._bsEmployees;
            this.employeeBox.DisplayMember = "Lekarz";
            this.employeeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeBox.FormattingEnabled = true;
            this.employeeBox.Location = new System.Drawing.Point(182, 100);
            this.employeeBox.Name = "employeeBox";
            this.employeeBox.Size = new System.Drawing.Size(325, 21);
            this.employeeBox.TabIndex = 20;
            this.employeeBox.ValueMember = "Id";
            // 
            // _bsEmployees
            // 
            this._bsEmployees.DataSource = typeof(ClinicManager.DataAccessLayer.EmployeeRow);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 127);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(495, 23);
            this.saveBtn.TabIndex = 26;
            this.saveBtn.Text = "Zatwierdź";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsRegistration, "Time", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(182, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 27;
            // 
            // erp
            // 
            this.erp.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erp.ContainerControl = this;
            this.erp.RightToLeft = true;
            // 
            // VisitDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 156);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.employeeBox);
            this.Controls.Add(this.patientBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VisitDetails";
            this.Text = "Szczególy wizyty";
            ((System.ComponentModel.ISupportInitialize)(this._bsRegistration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox employeeBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource _bsRegistration;
        private System.Windows.Forms.BindingSource _bsPatients;
        private System.Windows.Forms.BindingSource _bsEmployees;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.ComboBox patientBox;
        private System.Windows.Forms.ErrorProvider erp;
    }
}