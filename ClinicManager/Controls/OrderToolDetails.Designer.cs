
namespace ClinicManager.Controls
{
    partial class OrderToolDetails
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
            this.bsOrderTools = new System.Windows.Forms.BindingSource(this.components);
            this.bsClinic = new System.Windows.Forms.BindingSource(this.components);
            this.bsTools = new System.Windows.Forms.BindingSource(this.components);
            this.bsProducents = new System.Windows.Forms.BindingSource(this.components);
            this.amount = new System.Windows.Forms.NumericUpDown();
            this.producentBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.clinicBox = new System.Windows.Forms.ComboBox();
            this.toolBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.erp = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsOrderTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClinic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // bsOrderTools
            // 
            this.bsOrderTools.DataSource = typeof(ClinicManager.DataAccessLayer.OrdersTools);
            // 
            // bsClinic
            // 
            this.bsClinic.DataSource = typeof(ClinicManager.DataAccessLayer.ClinicRow);
            // 
            // bsTools
            // 
            this.bsTools.DataSource = typeof(ClinicManager.DataAccessLayer.ToolRow);
            // 
            // bsProducents
            // 
            this.bsProducents.DataSource = typeof(ClinicManager.DataAccessLayer.ProducentRow);
            // 
            // amount
            // 
            this.amount.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsOrderTools, "Amount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.amount.Location = new System.Drawing.Point(182, 95);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(326, 20);
            this.amount.TabIndex = 35;
            this.amount.Validating += new System.ComponentModel.CancelEventHandler(this.amount_Validating);
            // 
            // producentBox
            // 
            this.producentBox.DataSource = this.bsProducents;
            this.producentBox.DisplayMember = "Nazwa_producenta";
            this.producentBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.producentBox.FormattingEnabled = true;
            this.producentBox.Location = new System.Drawing.Point(182, 65);
            this.producentBox.Name = "producentBox";
            this.producentBox.Size = new System.Drawing.Size(325, 21);
            this.producentBox.TabIndex = 34;
            this.producentBox.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "Producent";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(11, 121);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(497, 23);
            this.saveBtn.TabIndex = 32;
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
            this.clinicBox.TabIndex = 31;
            this.clinicBox.ValueMember = "Id";
            // 
            // toolBox
            // 
            this.toolBox.DataSource = this.bsTools;
            this.toolBox.DisplayMember = "Nazwa";
            this.toolBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolBox.FormattingEnabled = true;
            this.toolBox.Location = new System.Drawing.Point(182, 9);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(325, 21);
            this.toolBox.TabIndex = 30;
            this.toolBox.ValueMember = "Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "Ilość";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Przychodnia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 26;
            this.label1.Text = "Narzędzie";
            // 
            // erp
            // 
            this.erp.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erp.ContainerControl = this;
            this.erp.RightToLeft = true;
            // 
            // OrderToolDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 151);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.producentBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.clinicBox);
            this.Controls.Add(this.toolBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderToolDetails";
            this.Text = "Zamówienie narzędzia";
            ((System.ComponentModel.ISupportInitialize)(this.bsOrderTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClinic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsOrderTools;
        private System.Windows.Forms.BindingSource bsClinic;
        private System.Windows.Forms.BindingSource bsTools;
        private System.Windows.Forms.BindingSource bsProducents;
        private System.Windows.Forms.NumericUpDown amount;
        private System.Windows.Forms.ComboBox producentBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox clinicBox;
        private System.Windows.Forms.ComboBox toolBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider erp;
    }
}