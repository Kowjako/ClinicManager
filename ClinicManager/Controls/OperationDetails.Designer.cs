
namespace ClinicManager
{
    partial class OperationDetails
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._bsOperation = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolBox = new System.Windows.Forms.ComboBox();
            this._bsTools = new System.Windows.Forms.BindingSource(this.components);
            this.drugBox = new System.Windows.Forms.ComboBox();
            this._bsDrugs = new System.Windows.Forms.BindingSource(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.erp = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._bsOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsDrugs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsOperation, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(182, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 28;
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // _bsOperation
            // 
            this._bsOperation.DataSource = typeof(ClinicManager.DataAccessLayer.Operations);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nazwa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 29;
            this.label2.Text = "Typ";
            // 
            // typeBox
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(182, 38);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(325, 21);
            this.typeBox.TabIndex = 30;
            this.typeBox.Validating += new System.ComponentModel.CancelEventHandler(this.typeBox_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Znieczulenie";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this._bsOperation, "IsAnesthesia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(182, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 17);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Tak";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "Narzędzie";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 18);
            this.label5.TabIndex = 34;
            this.label5.Text = "Lek";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Opis";
            // 
            // toolBox
            // 
            this.toolBox.DataSource = this._bsTools;
            this.toolBox.DisplayMember = "Nazwa";
            this.toolBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolBox.FormattingEnabled = true;
            this.toolBox.Location = new System.Drawing.Point(182, 98);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(325, 21);
            this.toolBox.TabIndex = 36;
            this.toolBox.ValueMember = "Id";
            // 
            // _bsTools
            // 
            this._bsTools.DataSource = typeof(ClinicManager.DataAccessLayer.ToolRow);
            // 
            // drugBox
            // 
            this.drugBox.DataSource = this._bsDrugs;
            this.drugBox.DisplayMember = "Nazwa";
            this.drugBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drugBox.FormattingEnabled = true;
            this.drugBox.Location = new System.Drawing.Point(182, 125);
            this.drugBox.Name = "drugBox";
            this.drugBox.Size = new System.Drawing.Size(325, 21);
            this.drugBox.TabIndex = 37;
            this.drugBox.ValueMember = "Id";
            // 
            // _bsDrugs
            // 
            this._bsDrugs.DataSource = typeof(ClinicManager.DataAccessLayer.DrugRow);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(182, 152);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(325, 20);
            this.textBox2.TabIndex = 38;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 178);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(495, 23);
            this.saveBtn.TabIndex = 39;
            this.saveBtn.Text = "Zatwierdź";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // erp
            // 
            this.erp.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erp.ContainerControl = this;
            this.erp.RightToLeft = true;
            // 
            // OperationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 205);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.drugBox);
            this.Controls.Add(this.toolBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperationDetails";
            this.Text = "Szczególy operacji";
            ((System.ComponentModel.ISupportInitialize)(this._bsOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsDrugs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox toolBox;
        private System.Windows.Forms.ComboBox drugBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.BindingSource _bsOperation;
        private System.Windows.Forms.BindingSource _bsTools;
        private System.Windows.Forms.BindingSource _bsDrugs;
        private System.Windows.Forms.ErrorProvider erp;
    }
}