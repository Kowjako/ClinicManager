
namespace ClinicManager
{
    partial class CostDetails
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
            this.drugsBox = new System.Windows.Forms.ComboBox();
            this.bsDrugs = new System.Windows.Forms.BindingSource(this.components);
            this.producentBox = new System.Windows.Forms.ComboBox();
            this.bsProducent = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bsCosts = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsDrugs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // drugsBox
            // 
            this.drugsBox.DataSource = this.bsDrugs;
            this.drugsBox.DisplayMember = "Nazwa";
            this.drugsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drugsBox.FormattingEnabled = true;
            this.drugsBox.Location = new System.Drawing.Point(182, 34);
            this.drugsBox.Name = "drugsBox";
            this.drugsBox.Size = new System.Drawing.Size(325, 21);
            this.drugsBox.TabIndex = 24;
            // 
            // bsDrugs
            // 
            this.bsDrugs.DataSource = typeof(ClinicManager.DataAccessLayer.DrugRow);
            // 
            // producentBox
            // 
            this.producentBox.DataSource = this.bsProducent;
            this.producentBox.DisplayMember = "Nazwa_producenta";
            this.producentBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.producentBox.FormattingEnabled = true;
            this.producentBox.Location = new System.Drawing.Point(182, 6);
            this.producentBox.Name = "producentBox";
            this.producentBox.Size = new System.Drawing.Size(325, 21);
            this.producentBox.TabIndex = 23;
            // 
            // bsProducent
            // 
            this.bsProducent.DataSource = typeof(ClinicManager.DataAccessLayer.ProducentRow);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Lek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Producent";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCosts, "MinPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(182, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 29;
            // 
            // bsCosts
            // 
            this.bsCosts.DataSource = typeof(ClinicManager.DataAccessLayer.Costs);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Minimalna cena";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCosts, "MaxPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(182, 87);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(325, 20);
            this.textBox2.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 30;
            this.label3.Text = "Maksymalna cena";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 18);
            this.label5.TabIndex = 32;
            this.label5.Text = "Czas dostawy (dni)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCosts, "TransportDays", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.Location = new System.Drawing.Point(182, 113);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(325, 20);
            this.numericUpDown1.TabIndex = 33;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 144);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(495, 23);
            this.saveBtn.TabIndex = 40;
            this.saveBtn.Text = "Zatwierdź";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // CostDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 173);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drugsBox);
            this.Controls.Add(this.producentBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CostDetails";
            this.Text = "Szczególy cennika";
            ((System.ComponentModel.ISupportInitialize)(this.bsDrugs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox drugsBox;
        private System.Windows.Forms.ComboBox producentBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.BindingSource bsCosts;
        private System.Windows.Forms.BindingSource bsProducent;
        private System.Windows.Forms.BindingSource bsDrugs;
    }
}