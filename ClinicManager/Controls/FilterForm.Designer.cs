
namespace ClinicManager.Controls
{
    partial class FilterForm
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
            this.secondLogic = new System.Windows.Forms.ComboBox();
            this.thirdLogic = new System.Windows.Forms.ComboBox();
            this.firstLogic = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.firstCondition = new System.Windows.Forms.TextBox();
            this.secondCondition = new System.Windows.Forms.TextBox();
            this.thirdCondition = new System.Windows.Forms.TextBox();
            this.fourthCondition = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // secondLogic
            // 
            this.secondLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondLogic.FormattingEnabled = true;
            this.secondLogic.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.secondLogic.Location = new System.Drawing.Point(12, 91);
            this.secondLogic.Name = "secondLogic";
            this.secondLogic.Size = new System.Drawing.Size(461, 21);
            this.secondLogic.TabIndex = 0;
            // 
            // thirdLogic
            // 
            this.thirdLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thirdLogic.FormattingEnabled = true;
            this.thirdLogic.Items.AddRange(new object[] {
            "AND ",
            "OR"});
            this.thirdLogic.Location = new System.Drawing.Point(12, 140);
            this.thirdLogic.Name = "thirdLogic";
            this.thirdLogic.Size = new System.Drawing.Size(461, 21);
            this.thirdLogic.TabIndex = 1;
            // 
            // firstLogic
            // 
            this.firstLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstLogic.FormattingEnabled = true;
            this.firstLogic.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.firstLogic.Location = new System.Drawing.Point(12, 38);
            this.firstLogic.Name = "firstLogic";
            this.firstLogic.Size = new System.Drawing.Size(461, 21);
            this.firstLogic.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(461, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Zatwierdź";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // firstCondition
            // 
            this.firstCondition.Location = new System.Drawing.Point(12, 12);
            this.firstCondition.Name = "firstCondition";
            this.firstCondition.Size = new System.Drawing.Size(461, 20);
            this.firstCondition.TabIndex = 12;
            // 
            // secondCondition
            // 
            this.secondCondition.Location = new System.Drawing.Point(12, 65);
            this.secondCondition.Name = "secondCondition";
            this.secondCondition.Size = new System.Drawing.Size(461, 20);
            this.secondCondition.TabIndex = 13;
            // 
            // thirdCondition
            // 
            this.thirdCondition.Location = new System.Drawing.Point(12, 114);
            this.thirdCondition.Name = "thirdCondition";
            this.thirdCondition.Size = new System.Drawing.Size(461, 20);
            this.thirdCondition.TabIndex = 14;
            // 
            // fourthCondition
            // 
            this.fourthCondition.Location = new System.Drawing.Point(12, 167);
            this.fourthCondition.Name = "fourthCondition";
            this.fourthCondition.Size = new System.Drawing.Size(461, 20);
            this.fourthCondition.TabIndex = 15;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 226);
            this.Controls.Add(this.fourthCondition);
            this.Controls.Add(this.thirdCondition);
            this.Controls.Add(this.secondCondition);
            this.Controls.Add(this.firstCondition);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.firstLogic);
            this.Controls.Add(this.thirdLogic);
            this.Controls.Add(this.secondLogic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.Text = "Kreator filtrów";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox secondLogic;
        private System.Windows.Forms.ComboBox thirdLogic;
        private System.Windows.Forms.ComboBox firstLogic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox firstCondition;
        private System.Windows.Forms.TextBox secondCondition;
        private System.Windows.Forms.TextBox thirdCondition;
        private System.Windows.Forms.TextBox fourthCondition;
    }
}