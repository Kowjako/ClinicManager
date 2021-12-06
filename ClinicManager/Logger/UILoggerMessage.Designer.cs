
namespace ClinicManager.Logger
{
    partial class UILoggerMessage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbSeverity = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeverity)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSeverity
            // 
            this.pbSeverity.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbSeverity.Location = new System.Drawing.Point(0, 0);
            this.pbSeverity.Name = "pbSeverity";
            this.pbSeverity.Size = new System.Drawing.Size(22, 22);
            this.pbSeverity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSeverity.TabIndex = 0;
            this.pbSeverity.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMessage.Location = new System.Drawing.Point(29, 5);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(64, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Message : s";
            // 
            // UILoggerMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pbSeverity);
            this.Name = "UILoggerMessage";
            this.Size = new System.Drawing.Size(350, 22);
            ((System.ComponentModel.ISupportInitialize)(this.pbSeverity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSeverity;
        private System.Windows.Forms.Label lblMessage;
    }
}
