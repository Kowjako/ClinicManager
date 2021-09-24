
namespace ClinicManager
{
    partial class ClinicDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._bsDetails = new System.Windows.Forms.BindingSource(this.components);
            this.openDatePicker = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.employeeBox = new System.Windows.Forms.ComboBox();
            this._bsEmployees = new System.Windows.Forms.BindingSource(this.components);
            this.localizationBox = new System.Windows.Forms.ComboBox();
            this._bsLocalizations = new System.Windows.Forms.BindingSource(this.components);
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._bsDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsLocalizations)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data otwarcia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prywatna";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kierownik";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lokalizacja";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsDetails, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(182, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 5;
            // 
            // _bsDetails
            // 
            this._bsDetails.DataSource = typeof(ClinicManager.DataAccessLayer.Clinics);
            // 
            // openDatePicker
            // 
            this.openDatePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this._bsDetails, "OpenDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.openDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.openDatePicker.Location = new System.Drawing.Point(182, 38);
            this.openDatePicker.Name = "openDatePicker";
            this.openDatePicker.Size = new System.Drawing.Size(325, 20);
            this.openDatePicker.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this._bsDetails, "IsPrivate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(182, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Tak";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // employeeBox
            // 
            this.employeeBox.DataSource = this._bsEmployees;
            this.employeeBox.DisplayMember = "Lekarz";
            this.employeeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeBox.FormattingEnabled = true;
            this.employeeBox.Location = new System.Drawing.Point(182, 96);
            this.employeeBox.Name = "employeeBox";
            this.employeeBox.Size = new System.Drawing.Size(325, 21);
            this.employeeBox.TabIndex = 8;
            this.employeeBox.ValueMember = "Id";
            // 
            // _bsEmployees
            // 
            this._bsEmployees.DataSource = typeof(ClinicManager.DataAccessLayer.EmployeeRow);
            // 
            // localizationBox
            // 
            this.localizationBox.DataSource = this._bsLocalizations;
            this.localizationBox.DisplayMember = "Adres";
            this.localizationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localizationBox.FormattingEnabled = true;
            this.localizationBox.Location = new System.Drawing.Point(182, 123);
            this.localizationBox.Name = "localizationBox";
            this.localizationBox.Size = new System.Drawing.Size(325, 21);
            this.localizationBox.TabIndex = 9;
            this.localizationBox.ValueMember = "Id";
            // 
            // _bsLocalizations
            // 
            this._bsLocalizations.DataSource = typeof(ClinicManager.DataAccessLayer.LocalizationRow);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 150);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(495, 23);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Zatwierdź";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // ClinicDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(519, 177);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.localizationBox);
            this.Controls.Add(this.employeeBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.openDatePicker);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClinicDetails";
            this.Text = "Szczególy przychodni";
            ((System.ComponentModel.ISupportInitialize)(this._bsDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsLocalizations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker openDatePicker;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox employeeBox;
        private System.Windows.Forms.ComboBox localizationBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.BindingSource _bsDetails;
        private System.Windows.Forms.BindingSource _bsEmployees;
        private System.Windows.Forms.BindingSource _bsLocalizations;
    }
}