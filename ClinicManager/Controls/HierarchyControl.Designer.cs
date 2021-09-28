
namespace ClinicManager.Controls
{
    partial class HierarchyControl
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
            this.clinicTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // clinicTree
            // 
            this.clinicTree.Location = new System.Drawing.Point(12, 12);
            this.clinicTree.Name = "clinicTree";
            this.clinicTree.Size = new System.Drawing.Size(272, 444);
            this.clinicTree.TabIndex = 0;
            // 
            // HierarchyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 468);
            this.Controls.Add(this.clinicTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HierarchyControl";
            this.Text = "Struktura praw przychodni";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView clinicTree;
    }
}