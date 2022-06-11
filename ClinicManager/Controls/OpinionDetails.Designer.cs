
namespace ClinicManager.Controls
{
    partial class OpinionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpinionDetails));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.star1 = new System.Windows.Forms.PictureBox();
            this.star2 = new System.Windows.Forms.PictureBox();
            this.star3 = new System.Windows.Forms.PictureBox();
            this.star4 = new System.Windows.Forms.PictureBox();
            this.star5 = new System.Windows.Forms.PictureBox();
            this.bsClinics = new System.Windows.Forms.BindingSource(this.components);
            this.bsPatients = new System.Windows.Forms.BindingSource(this.components);
            this.patientBox = new System.Windows.Forms.ComboBox();
            this.clinicBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.star1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClinics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Przychodnia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 34;
            this.label1.Text = "Wystawiający";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 96);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(525, 23);
            this.saveBtn.TabIndex = 41;
            this.saveBtn.Text = "Zatwierdź";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 42;
            this.label3.Text = "Ocena";
            // 
            // star1
            // 
            this.star1.Image = ((System.Drawing.Image)(resources.GetObject("star1.Image")));
            this.star1.Location = new System.Drawing.Point(172, 69);
            this.star1.Name = "star1";
            this.star1.Size = new System.Drawing.Size(20, 20);
            this.star1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star1.TabIndex = 43;
            this.star1.TabStop = false;
            this.star1.Click += new System.EventHandler(this.star1_Click);
            this.star1.MouseEnter += new System.EventHandler(this.star1_MouseEnter);
            // 
            // star2
            // 
            this.star2.Image = ((System.Drawing.Image)(resources.GetObject("star2.Image")));
            this.star2.InitialImage = null;
            this.star2.Location = new System.Drawing.Point(198, 69);
            this.star2.Name = "star2";
            this.star2.Size = new System.Drawing.Size(20, 20);
            this.star2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star2.TabIndex = 44;
            this.star2.TabStop = false;
            this.star2.Click += new System.EventHandler(this.star1_Click);
            this.star2.MouseEnter += new System.EventHandler(this.star1_MouseEnter);
            // 
            // star3
            // 
            this.star3.Image = ((System.Drawing.Image)(resources.GetObject("star3.Image")));
            this.star3.Location = new System.Drawing.Point(224, 69);
            this.star3.Name = "star3";
            this.star3.Size = new System.Drawing.Size(20, 20);
            this.star3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star3.TabIndex = 45;
            this.star3.TabStop = false;
            this.star3.Click += new System.EventHandler(this.star1_Click);
            this.star3.MouseEnter += new System.EventHandler(this.star1_MouseEnter);
            // 
            // star4
            // 
            this.star4.Image = ((System.Drawing.Image)(resources.GetObject("star4.Image")));
            this.star4.Location = new System.Drawing.Point(250, 69);
            this.star4.Name = "star4";
            this.star4.Size = new System.Drawing.Size(20, 20);
            this.star4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star4.TabIndex = 46;
            this.star4.TabStop = false;
            this.star4.Click += new System.EventHandler(this.star1_Click);
            this.star4.MouseEnter += new System.EventHandler(this.star1_MouseEnter);
            // 
            // star5
            // 
            this.star5.Image = ((System.Drawing.Image)(resources.GetObject("star5.Image")));
            this.star5.Location = new System.Drawing.Point(276, 69);
            this.star5.Name = "star5";
            this.star5.Size = new System.Drawing.Size(20, 20);
            this.star5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star5.TabIndex = 47;
            this.star5.TabStop = false;
            this.star5.Click += new System.EventHandler(this.star1_Click);
            this.star5.MouseEnter += new System.EventHandler(this.star1_MouseEnter);
            // 
            // bsClinics
            // 
            this.bsClinics.DataSource = typeof(ClinicManager.DataAccessLayer.ClinicRow);
            // 
            // bsPatients
            // 
            this.bsPatients.DataSource = typeof(ClinicManager.DataAccessLayer.PatientRow);
            // 
            // patientBox
            // 
            this.patientBox.DataSource = this.bsPatients;
            this.patientBox.DisplayMember = "Pacjent";
            this.patientBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.patientBox.Enabled = false;
            this.patientBox.FormattingEnabled = true;
            this.patientBox.Location = new System.Drawing.Point(172, 10);
            this.patientBox.Name = "patientBox";
            this.patientBox.Size = new System.Drawing.Size(365, 21);
            this.patientBox.TabIndex = 48;
            // 
            // clinicBox
            // 
            this.clinicBox.DataSource = this.bsClinics;
            this.clinicBox.DisplayMember = "Nazwa";
            this.clinicBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clinicBox.FormattingEnabled = true;
            this.clinicBox.Location = new System.Drawing.Point(172, 39);
            this.clinicBox.Name = "clinicBox";
            this.clinicBox.Size = new System.Drawing.Size(365, 21);
            this.clinicBox.TabIndex = 49;
            // 
            // OpinionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 126);
            this.Controls.Add(this.clinicBox);
            this.Controls.Add(this.patientBox);
            this.Controls.Add(this.star5);
            this.Controls.Add(this.star4);
            this.Controls.Add(this.star3);
            this.Controls.Add(this.star2);
            this.Controls.Add(this.star1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpinionDetails";
            this.Text = "Szczegóły opinii";
            ((System.ComponentModel.ISupportInitialize)(this.star1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClinics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsClinics;
        private System.Windows.Forms.BindingSource bsPatients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox star1;
        private System.Windows.Forms.PictureBox star2;
        private System.Windows.Forms.PictureBox star3;
        private System.Windows.Forms.PictureBox star4;
        private System.Windows.Forms.PictureBox star5;
        private System.Windows.Forms.ComboBox patientBox;
        private System.Windows.Forms.ComboBox clinicBox;
    }
}