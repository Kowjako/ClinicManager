
namespace ClinicManager.Controls
{
    partial class SortDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortDetails));
            this.parametersList = new System.Windows.Forms.CheckedListBox();
            this.ascSort = new System.Windows.Forms.Button();
            this.descSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // parametersList
            // 
            this.parametersList.FormattingEnabled = true;
            this.parametersList.Location = new System.Drawing.Point(12, 12);
            this.parametersList.Name = "parametersList";
            this.parametersList.Size = new System.Drawing.Size(243, 109);
            this.parametersList.TabIndex = 0;
            // 
            // ascSort
            // 
            this.ascSort.Image = ((System.Drawing.Image)(resources.GetObject("ascSort.Image")));
            this.ascSort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ascSort.Location = new System.Drawing.Point(12, 127);
            this.ascSort.Name = "ascSort";
            this.ascSort.Size = new System.Drawing.Size(243, 60);
            this.ascSort.TabIndex = 1;
            this.ascSort.Text = "Sortuj rosnąco";
            this.ascSort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ascSort.UseVisualStyleBackColor = true;
            // 
            // descSort
            // 
            this.descSort.Image = ((System.Drawing.Image)(resources.GetObject("descSort.Image")));
            this.descSort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.descSort.Location = new System.Drawing.Point(12, 193);
            this.descSort.Name = "descSort";
            this.descSort.Size = new System.Drawing.Size(243, 61);
            this.descSort.TabIndex = 2;
            this.descSort.Text = "Sortuj malejąco";
            this.descSort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.descSort.UseVisualStyleBackColor = true;
            // 
            // SortDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 268);
            this.Controls.Add(this.descSort);
            this.Controls.Add(this.ascSort);
            this.Controls.Add(this.parametersList);
            this.Name = "SortDetails";
            this.Text = "Sortowanie danych";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox parametersList;
        private System.Windows.Forms.Button ascSort;
        private System.Windows.Forms.Button descSort;
    }
}