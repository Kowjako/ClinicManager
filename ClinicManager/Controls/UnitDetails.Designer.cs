
namespace ClinicManager.Controls
{
    partial class UnitDetails
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
            this.typeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeName
            // 
            this.typeName.Location = new System.Drawing.Point(182, 11);
            this.typeName.Name = "typeName";
            this.typeName.Size = new System.Drawing.Size(325, 20);
            this.typeName.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nazwa typu / jednostki";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(15, 38);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(492, 23);
            this.saveBtn.TabIndex = 32;
            this.saveBtn.Text = "Zatwierdź";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // UnitDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 73);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.typeName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitDetails";
            this.Text = "Dodanie nowego typu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox typeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
    }
}