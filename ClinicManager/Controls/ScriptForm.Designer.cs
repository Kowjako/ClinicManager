
namespace ClinicManager.Controls
{
    partial class ScriptForm
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
            this.dbMainScript = new System.Windows.Forms.RichTextBox();
            this.headerLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dbMainScript
            // 
            this.dbMainScript.Location = new System.Drawing.Point(12, 41);
            this.dbMainScript.Name = "dbMainScript";
            this.dbMainScript.Size = new System.Drawing.Size(602, 355);
            this.dbMainScript.TabIndex = 0;
            this.dbMainScript.Text = "";
            // 
            // headerLbl
            // 
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headerLbl.ForeColor = System.Drawing.Color.Red;
            this.headerLbl.Location = new System.Drawing.Point(12, 9);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(497, 18);
            this.headerLbl.TabIndex = 1;
            this.headerLbl.Text = "Poniższy skrypt należy uruchomić na bazie danych do tworzenia struktury:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(602, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Gotowe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 449);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.headerLbl);
            this.Controls.Add(this.dbMainScript);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptForm";
            this.Text = "Skrypty konfiguracyjne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox dbMainScript;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.Button button1;
    }
}