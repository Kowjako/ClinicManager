
namespace Test
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnHospitalAdd = new System.Windows.Forms.RibbonButton();
            this.btnHospitalEdit = new System.Windows.Forms.RibbonButton();
            this.btnHospitalRemove = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnHospitalLocalization = new System.Windows.Forms.RibbonButton();
            this.btnHospitalManagerMail = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab6 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab7 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab8 = new System.Windows.Forms.RibbonTab();
            this._mainPanel = new System.Windows.Forms.Panel();
            this._gvMain = new System.Windows.Forms.DataGridView();
            this.btnHospitalRefresh = new System.Windows.Forms.RibbonButton();
            this.btnHospitalShowList = new System.Windows.Forms.RibbonButton();
            this.btnHospitalAddOpinion = new System.Windows.Forms.RibbonButton();
            this.btnShowOpinions = new System.Windows.Forms.RibbonButton();
            this.btnAddOpinion = new System.Windows.Forms.RibbonButton();
            this.btnDoctorsShow = new System.Windows.Forms.RibbonButton();
            this.btnDoctorsAdd = new System.Windows.Forms.RibbonButton();
            this.btnDoctorsEdit = new System.Windows.Forms.RibbonButton();
            this.btnDoctorsDelete = new System.Windows.Forms.RibbonButton();
            this.btnDoctorsRefresh = new System.Windows.Forms.RibbonButton();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isOrderDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._bsClinics = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel9 = new System.Windows.Forms.RibbonPanel();
            this.btnClientsShow = new System.Windows.Forms.RibbonButton();
            this.btnClientsAdd = new System.Windows.Forms.RibbonButton();
            this.btnClientsEdit = new System.Windows.Forms.RibbonButton();
            this.btnClientsDelete = new System.Windows.Forms.RibbonButton();
            this.btnClientsRefresh = new System.Windows.Forms.RibbonButton();
            this._mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsClinics)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.BorderMode = System.Windows.Forms.RibbonWindowMode.InsideWindow;
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.ForeColor = System.Drawing.Color.Chocolate;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "Hello";
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.DropDownButtonVisible = false;
            this.ribbon1.QuickAccessToolbar.Enabled = false;
            this.ribbon1.QuickAccessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1313, 122);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.Tabs.Add(this.ribbonTab4);
            this.ribbon1.Tabs.Add(this.ribbonTab5);
            this.ribbon1.Tabs.Add(this.ribbonTab6);
            this.ribbon1.Tabs.Add(this.ribbonTab7);
            this.ribbon1.Tabs.Add(this.ribbonTab8);
            this.ribbon1.TabSpacing = 3;
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "Przychodnie";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnHospitalShowList);
            this.ribbonPanel1.Items.Add(this.btnHospitalAdd);
            this.ribbonPanel1.Items.Add(this.btnHospitalEdit);
            this.ribbonPanel1.Items.Add(this.btnHospitalRemove);
            this.ribbonPanel1.Items.Add(this.btnHospitalRefresh);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Zarządzanie";
            // 
            // btnHospitalAdd
            // 
            this.btnHospitalAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnHospitalAdd.Image")));
            this.btnHospitalAdd.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalAdd.LargeImage")));
            this.btnHospitalAdd.Name = "btnHospitalAdd";
            this.btnHospitalAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalAdd.SmallImage")));
            this.btnHospitalAdd.Text = "Dodaj";
            this.btnHospitalAdd.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.btnHospitalAdd.Click += new System.EventHandler(this.btnHospitalAdd_Click);
            // 
            // btnHospitalEdit
            // 
            this.btnHospitalEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnHospitalEdit.Image")));
            this.btnHospitalEdit.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalEdit.LargeImage")));
            this.btnHospitalEdit.Name = "btnHospitalEdit";
            this.btnHospitalEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalEdit.SmallImage")));
            this.btnHospitalEdit.Text = "Edytuj";
            this.btnHospitalEdit.Click += new System.EventHandler(this.btnHospitalEdit_Click);
            // 
            // btnHospitalRemove
            // 
            this.btnHospitalRemove.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Right;
            this.btnHospitalRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnHospitalRemove.Image")));
            this.btnHospitalRemove.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalRemove.LargeImage")));
            this.btnHospitalRemove.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.btnHospitalRemove.Name = "btnHospitalRemove";
            this.btnHospitalRemove.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalRemove.SmallImage")));
            this.btnHospitalRemove.Text = "Usuń";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.btnHospitalLocalization);
            this.ribbonPanel2.Items.Add(this.btnHospitalManagerMail);
            this.ribbonPanel2.Items.Add(this.btnHospitalAddOpinion);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Ogólne";
            // 
            // btnHospitalLocalization
            // 
            this.btnHospitalLocalization.Image = ((System.Drawing.Image)(resources.GetObject("btnHospitalLocalization.Image")));
            this.btnHospitalLocalization.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalLocalization.LargeImage")));
            this.btnHospitalLocalization.Name = "btnHospitalLocalization";
            this.btnHospitalLocalization.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalLocalization.SmallImage")));
            this.btnHospitalLocalization.Text = "Lokalizacja";
            // 
            // btnHospitalManagerMail
            // 
            this.btnHospitalManagerMail.Image = ((System.Drawing.Image)(resources.GetObject("btnHospitalManagerMail.Image")));
            this.btnHospitalManagerMail.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalManagerMail.LargeImage")));
            this.btnHospitalManagerMail.Name = "btnHospitalManagerMail";
            this.btnHospitalManagerMail.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalManagerMail.SmallImage")));
            this.btnHospitalManagerMail.Text = "Powiadomienie";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Panels.Add(this.ribbonPanel3);
            this.ribbonTab2.Text = "Lekarze";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.btnDoctorsShow);
            this.ribbonPanel3.Items.Add(this.btnDoctorsAdd);
            this.ribbonPanel3.Items.Add(this.btnDoctorsEdit);
            this.ribbonPanel3.Items.Add(this.btnDoctorsDelete);
            this.ribbonPanel3.Items.Add(this.btnDoctorsRefresh);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "Zarządzanie";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Panels.Add(this.ribbonPanel4);
            this.ribbonTab3.Text = "Pacjenci";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Name = "ribbonTab4";
            this.ribbonTab4.Panels.Add(this.ribbonPanel5);
            this.ribbonTab4.Text = "Środki trwałe";
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Name = "ribbonTab5";
            this.ribbonTab5.Panels.Add(this.ribbonPanel6);
            this.ribbonTab5.Text = "Leki";
            // 
            // ribbonTab6
            // 
            this.ribbonTab6.Name = "ribbonTab6";
            this.ribbonTab6.Panels.Add(this.ribbonPanel7);
            this.ribbonTab6.Text = "Wizyty";
            // 
            // ribbonTab7
            // 
            this.ribbonTab7.Name = "ribbonTab7";
            this.ribbonTab7.Panels.Add(this.ribbonPanel8);
            this.ribbonTab7.Text = "Operacje";
            // 
            // ribbonTab8
            // 
            this.ribbonTab8.Name = "ribbonTab8";
            this.ribbonTab8.Panels.Add(this.ribbonPanel9);
            this.ribbonTab8.Text = "Cennik leków";
            // 
            // _mainPanel
            // 
            this._mainPanel.Controls.Add(this._gvMain);
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(0, 122);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(1313, 644);
            this._mainPanel.TabIndex = 3;
            // 
            // _gvMain
            // 
            this._gvMain.AllowUserToAddRows = false;
            this._gvMain.AllowUserToDeleteRows = false;
            this._gvMain.AllowUserToResizeRows = false;
            this._gvMain.AutoGenerateColumns = false;
            this._gvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gvMain.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this._gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.isOrderDataGridViewCheckBoxColumn});
            this._gvMain.DataSource = this._bsClinics;
            this._gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gvMain.Location = new System.Drawing.Point(0, 0);
            this._gvMain.Name = "_gvMain";
            this._gvMain.RowHeadersVisible = false;
            this._gvMain.Size = new System.Drawing.Size(1313, 644);
            this._gvMain.TabIndex = 0;
            // 
            // btnHospitalRefresh
            // 
            this.btnHospitalRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnHospitalRefresh.Image")));
            this.btnHospitalRefresh.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalRefresh.LargeImage")));
            this.btnHospitalRefresh.Name = "btnHospitalRefresh";
            this.btnHospitalRefresh.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalRefresh.SmallImage")));
            this.btnHospitalRefresh.Text = "Odśwież";
            // 
            // btnHospitalShowList
            // 
            this.btnHospitalShowList.Image = ((System.Drawing.Image)(resources.GetObject("btnHospitalShowList.Image")));
            this.btnHospitalShowList.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalShowList.LargeImage")));
            this.btnHospitalShowList.Name = "btnHospitalShowList";
            this.btnHospitalShowList.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalShowList.SmallImage")));
            this.btnHospitalShowList.Text = "Wyświetl";
            // 
            // btnHospitalAddOpinion
            // 
            this.btnHospitalAddOpinion.DropDownItems.Add(this.btnAddOpinion);
            this.btnHospitalAddOpinion.DropDownItems.Add(this.btnShowOpinions);
            this.btnHospitalAddOpinion.Image = ((System.Drawing.Image)(resources.GetObject("btnHospitalAddOpinion.Image")));
            this.btnHospitalAddOpinion.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalAddOpinion.LargeImage")));
            this.btnHospitalAddOpinion.Name = "btnHospitalAddOpinion";
            this.btnHospitalAddOpinion.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHospitalAddOpinion.SmallImage")));
            this.btnHospitalAddOpinion.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.btnHospitalAddOpinion.Text = "Opinie";
            // 
            // btnShowOpinions
            // 
            this.btnShowOpinions.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.btnShowOpinions.Image = ((System.Drawing.Image)(resources.GetObject("btnShowOpinions.Image")));
            this.btnShowOpinions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnShowOpinions.LargeImage")));
            this.btnShowOpinions.Name = "btnShowOpinions";
            this.btnShowOpinions.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnShowOpinions.SmallImage")));
            this.btnShowOpinions.Text = "Wyświetl opinie";
            // 
            // btnAddOpinion
            // 
            this.btnAddOpinion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.btnAddOpinion.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOpinion.Image")));
            this.btnAddOpinion.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddOpinion.LargeImage")));
            this.btnAddOpinion.Name = "btnAddOpinion";
            this.btnAddOpinion.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAddOpinion.SmallImage")));
            this.btnAddOpinion.Text = "Dodaj opinię";
            // 
            // btnDoctorsShow
            // 
            this.btnDoctorsShow.Image = ((System.Drawing.Image)(resources.GetObject("btnDoctorsShow.Image")));
            this.btnDoctorsShow.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsShow.LargeImage")));
            this.btnDoctorsShow.Name = "btnDoctorsShow";
            this.btnDoctorsShow.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsShow.SmallImage")));
            this.btnDoctorsShow.Text = "Wyświetl";
            // 
            // btnDoctorsAdd
            // 
            this.btnDoctorsAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnDoctorsAdd.Image")));
            this.btnDoctorsAdd.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsAdd.LargeImage")));
            this.btnDoctorsAdd.Name = "btnDoctorsAdd";
            this.btnDoctorsAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsAdd.SmallImage")));
            this.btnDoctorsAdd.Text = "Dodaj";
            // 
            // btnDoctorsEdit
            // 
            this.btnDoctorsEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnDoctorsEdit.Image")));
            this.btnDoctorsEdit.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsEdit.LargeImage")));
            this.btnDoctorsEdit.Name = "btnDoctorsEdit";
            this.btnDoctorsEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsEdit.SmallImage")));
            this.btnDoctorsEdit.Text = "Edytuj";
            // 
            // btnDoctorsDelete
            // 
            this.btnDoctorsDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDoctorsDelete.Image")));
            this.btnDoctorsDelete.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsDelete.LargeImage")));
            this.btnDoctorsDelete.Name = "btnDoctorsDelete";
            this.btnDoctorsDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsDelete.SmallImage")));
            this.btnDoctorsDelete.Text = "Usuń";
            // 
            // btnDoctorsRefresh
            // 
            this.btnDoctorsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnDoctorsRefresh.Image")));
            this.btnDoctorsRefresh.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsRefresh.LargeImage")));
            this.btnDoctorsRefresh.Name = "btnDoctorsRefresh";
            this.btnDoctorsRefresh.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDoctorsRefresh.SmallImage")));
            this.btnDoctorsRefresh.Text = "Odśwież";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            // 
            // isOrderDataGridViewCheckBoxColumn
            // 
            this.isOrderDataGridViewCheckBoxColumn.DataPropertyName = "IsOrder";
            this.isOrderDataGridViewCheckBoxColumn.HeaderText = "IsOrder";
            this.isOrderDataGridViewCheckBoxColumn.Name = "isOrderDataGridViewCheckBoxColumn";
            // 
            // _bsClinics
            // 
            this._bsClinics.DataSource = typeof(Test.Person);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.btnClientsShow);
            this.ribbonPanel4.Items.Add(this.btnClientsAdd);
            this.ribbonPanel4.Items.Add(this.btnClientsEdit);
            this.ribbonPanel4.Items.Add(this.btnClientsDelete);
            this.ribbonPanel4.Items.Add(this.btnClientsRefresh);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = "Zarządzanie";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Text = "Zarządzanie";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Text = "Zarządzanie";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.Name = "ribbonPanel7";
            this.ribbonPanel7.Text = "Zarządzanie";
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.Name = "ribbonPanel8";
            this.ribbonPanel8.Text = "Zarządzanie";
            // 
            // ribbonPanel9
            // 
            this.ribbonPanel9.Name = "ribbonPanel9";
            this.ribbonPanel9.Text = "Zarządzanie";
            // 
            // btnClientsShow
            // 
            this.btnClientsShow.Image = ((System.Drawing.Image)(resources.GetObject("btnClientsShow.Image")));
            this.btnClientsShow.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClientsShow.LargeImage")));
            this.btnClientsShow.Name = "btnClientsShow";
            this.btnClientsShow.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnClientsShow.SmallImage")));
            this.btnClientsShow.Text = "Wyświetl";
            // 
            // btnClientsAdd
            // 
            this.btnClientsAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnClientsAdd.Image")));
            this.btnClientsAdd.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClientsAdd.LargeImage")));
            this.btnClientsAdd.Name = "btnClientsAdd";
            this.btnClientsAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnClientsAdd.SmallImage")));
            this.btnClientsAdd.Text = "Dodaj";
            // 
            // btnClientsEdit
            // 
            this.btnClientsEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnClientsEdit.Image")));
            this.btnClientsEdit.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClientsEdit.LargeImage")));
            this.btnClientsEdit.Name = "btnClientsEdit";
            this.btnClientsEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnClientsEdit.SmallImage")));
            this.btnClientsEdit.Text = "Edytuj";
            // 
            // btnClientsDelete
            // 
            this.btnClientsDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnClientsDelete.Image")));
            this.btnClientsDelete.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClientsDelete.LargeImage")));
            this.btnClientsDelete.Name = "btnClientsDelete";
            this.btnClientsDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnClientsDelete.SmallImage")));
            this.btnClientsDelete.Text = "Usuń";
            // 
            // btnClientsRefresh
            // 
            this.btnClientsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnClientsRefresh.Image")));
            this.btnClientsRefresh.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClientsRefresh.LargeImage")));
            this.btnClientsRefresh.Name = "btnClientsRefresh";
            this.btnClientsRefresh.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnClientsRefresh.SmallImage")));
            this.btnClientsRefresh.Text = "Odśwież";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 766);
            this.Controls.Add(this._mainPanel);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Bazy Danych 2 - Projekt";
            this._mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsClinics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.BindingSource _bsClinics;
        private System.Windows.Forms.RibbonButton btnHospitalAdd;
        private System.Windows.Forms.RibbonButton btnHospitalRemove;
        private System.Windows.Forms.RibbonButton btnHospitalEdit;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonButton btnHospitalLocalization;
        private System.Windows.Forms.RibbonButton btnHospitalManagerMail;
        private System.Windows.Forms.Panel _mainPanel;
        private System.Windows.Forms.DataGridView _gvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isOrderDataGridViewCheckBoxColumn;
        private System.Windows.Forms.RibbonTab ribbonTab5;
        private System.Windows.Forms.RibbonTab ribbonTab6;
        private System.Windows.Forms.RibbonTab ribbonTab7;
        private System.Windows.Forms.RibbonTab ribbonTab8;
        private System.Windows.Forms.RibbonButton btnHospitalShowList;
        private System.Windows.Forms.RibbonButton btnHospitalRefresh;
        private System.Windows.Forms.RibbonButton btnHospitalAddOpinion;
        private System.Windows.Forms.RibbonButton btnAddOpinion;
        private System.Windows.Forms.RibbonButton btnShowOpinions;
        private System.Windows.Forms.RibbonButton btnDoctorsShow;
        private System.Windows.Forms.RibbonButton btnDoctorsAdd;
        private System.Windows.Forms.RibbonButton btnDoctorsEdit;
        private System.Windows.Forms.RibbonButton btnDoctorsDelete;
        private System.Windows.Forms.RibbonButton btnDoctorsRefresh;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton btnClientsShow;
        private System.Windows.Forms.RibbonButton btnClientsAdd;
        private System.Windows.Forms.RibbonButton btnClientsEdit;
        private System.Windows.Forms.RibbonButton btnClientsDelete;
        private System.Windows.Forms.RibbonButton btnClientsRefresh;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonPanel ribbonPanel9;
    }
}

