
namespace ClinicManager.Controls
{
    partial class EnrollDetails
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
            this.bsEmployees = new System.Windows.Forms.BindingSource(this.components);
            this.bsClinics = new System.Windows.Forms.BindingSource(this.components);
            this.clinicBox = new System.Windows.Forms.ComboBox();
            this.patientBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._isManager = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClinics)).BeginInit();
            this.SuspendLayout();
            // 
            // bsEmployees
            // 
            this.bsEmployees.DataSource = typeof(ClinicManager.DataAccessLayer.EmployeeRow);
            // 
            // bsClinics
            // 
            this.bsClinics.DataSource = typeof(ClinicManager.DataAccessLayer.ClinicRow);
            // 
            // clinicBox
            // 
            this.clinicBox.DataSource = this.bsClinics;
            this.clinicBox.DisplayMember = "Nazwa";
            this.clinicBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clinicBox.FormattingEnabled = true;
            this.clinicBox.Location = new System.Drawing.Point(167, 41);
            this.clinicBox.Name = "clinicBox";
            this.clinicBox.Size = new System.Drawing.Size(365, 21);
            this.clinicBox.TabIndex = 53;
            // 
            // patientBox
            // 
            this.patientBox.DataSource = this.bsEmployees;
            this.patientBox.DisplayMember = "Lekarz";
            this.patientBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.patientBox.FormattingEnabled = true;
            this.patientBox.Location = new System.Drawing.Point(167, 12);
            this.patientBox.Name = "patientBox";
            this.patientBox.Size = new System.Drawing.Size(365, 21);
            this.patientBox.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 51;
            this.label2.Text = "Przychodnia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 50;
            this.label1.Text = "Pracownik";
            // 
            // _isManager
            // 
            this._isManager.AutoSize = true;
            this._isManager.Location = new System.Drawing.Point(167, 77);
            this._isManager.Name = "_isManager";
            this._isManager.Size = new System.Drawing.Size(45, 17);
            this._isManager.TabIndex = 54;
            this._isManager.Text = "Tak";
            this._isManager.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 55;
            this.label3.Text = "Kierownik";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(10, 102);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(522, 23);
            this.saveBtn.TabIndex = 56;
            this.saveBtn.Text = "Zatwierdź";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // EnrollDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 131);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._isManager);
            this.Controls.Add(this.clinicBox);
            this.Controls.Add(this.patientBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnrollDetails";
            this.Text = "Zatrudnienie pracownika";
            ((System.ComponentModel.ISupportInitialize)(this.bsEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClinics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsEmployees;
        private System.Windows.Forms.BindingSource bsClinics;
        private System.Windows.Forms.ComboBox clinicBox;
        private System.Windows.Forms.ComboBox patientBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _isManager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveBtn;
    }
}