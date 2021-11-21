
namespace ClinicManager.Controls
{
    partial class OrderDetails
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.clinicBox = new System.Windows.Forms.ComboBox();
            this.bsClinic = new System.Windows.Forms.BindingSource(this.components);
            this.drugBox = new System.Windows.Forms.ComboBox();
            this.bsDrugs = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.producentBox = new System.Windows.Forms.ComboBox();
            this.bsProducent = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.NumericUpDown();
            this.bsOrder = new System.Windows.Forms.BindingSource(this.components);
            this.unitBox = new System.Windows.Forms.ComboBox();
            this.erp = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsClinic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDrugs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 150);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(495, 23);
            this.saveBtn.TabIndex = 21;
            this.saveBtn.Text = "Zatwierdź";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // clinicBox
            // 
            this.clinicBox.DataSource = this.bsClinic;
            this.clinicBox.DisplayMember = "Nazwa";
            this.clinicBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clinicBox.FormattingEnabled = true;
            this.clinicBox.Location = new System.Drawing.Point(182, 38);
            this.clinicBox.Name = "clinicBox";
            this.clinicBox.Size = new System.Drawing.Size(325, 21);
            this.clinicBox.TabIndex = 20;
            this.clinicBox.ValueMember = "Id";
            // 
            // bsClinic
            // 
            this.bsClinic.DataSource = typeof(ClinicManager.DataAccessLayer.ClinicRow);
            // 
            // drugBox
            // 
            this.drugBox.DataSource = this.bsDrugs;
            this.drugBox.DisplayMember = "Nazwa";
            this.drugBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drugBox.FormattingEnabled = true;
            this.drugBox.Location = new System.Drawing.Point(182, 9);
            this.drugBox.Name = "drugBox";
            this.drugBox.Size = new System.Drawing.Size(325, 21);
            this.drugBox.TabIndex = 19;
            this.drugBox.ValueMember = "Id";
            // 
            // bsDrugs
            // 
            this.bsDrugs.DataSource = typeof(ClinicManager.DataAccessLayer.DrugRow);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Jednostka";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ilość";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Przychodnia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Lek";
            // 
            // producentBox
            // 
            this.producentBox.DataSource = this.bsProducent;
            this.producentBox.DisplayMember = "Nazwa_producenta";
            this.producentBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.producentBox.FormattingEnabled = true;
            this.producentBox.Location = new System.Drawing.Point(182, 65);
            this.producentBox.Name = "producentBox";
            this.producentBox.Size = new System.Drawing.Size(325, 21);
            this.producentBox.TabIndex = 23;
            this.producentBox.ValueMember = "Id";
            // 
            // bsProducent
            // 
            this.bsProducent.DataSource = typeof(ClinicManager.DataAccessLayer.ProducentRow);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Producent";
            // 
            // amount
            // 
            this.amount.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsOrder, "Amount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.amount.Location = new System.Drawing.Point(182, 95);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(324, 20);
            this.amount.TabIndex = 24;
            this.amount.Validating += new System.ComponentModel.CancelEventHandler(this.amount_Validating);
            // 
            // bsOrder
            // 
            this.bsOrder.DataSource = typeof(ClinicManager.DataAccessLayer.Orders);
            // 
            // unitBox
            // 
            this.unitBox.DisplayMember = "Adres";
            this.unitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitBox.FormattingEnabled = true;
            this.unitBox.Location = new System.Drawing.Point(182, 121);
            this.unitBox.Name = "unitBox";
            this.unitBox.Size = new System.Drawing.Size(325, 21);
            this.unitBox.TabIndex = 25;
            this.unitBox.ValueMember = "Id";
            this.unitBox.Validating += new System.ComponentModel.CancelEventHandler(this.unitBox_Validating);
            // 
            // erp
            // 
            this.erp.ContainerControl = this;
            this.erp.RightToLeft = true;
            // 
            // OrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 181);
            this.Controls.Add(this.unitBox);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.producentBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.clinicBox);
            this.Controls.Add(this.drugBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetails";
            this.Text = "Zamówienie towaru dla przychodni";
            ((System.ComponentModel.ISupportInitialize)(this.bsClinic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDrugs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox clinicBox;
        private System.Windows.Forms.ComboBox drugBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox producentBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown amount;
        private System.Windows.Forms.BindingSource bsOrder;
        private System.Windows.Forms.ComboBox unitBox;
        private System.Windows.Forms.BindingSource bsDrugs;
        private System.Windows.Forms.BindingSource bsClinic;
        private System.Windows.Forms.BindingSource bsProducent;
        private System.Windows.Forms.ErrorProvider erp;
    }
}