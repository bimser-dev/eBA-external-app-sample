namespace eBAFormExample
{
    partial class Main
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.gbGender = new System.Windows.Forms.GroupBox();
            this.chkIsOpen = new System.Windows.Forms.CheckBox();
            this.lstMeyveler = new System.Windows.Forms.ListBox();
            this.lblMeyveler = new System.Windows.Forms.Label();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.rdbOption2 = new System.Windows.Forms.RadioButton();
            this.rdbOption1 = new System.Windows.Forms.RadioButton();
            this.dtgKayitliKullanicilar = new System.Windows.Forms.DataGridView();
            this.DTG_TXT_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTG_TXT_Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTG_CMB_DrivingLicence = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtProcessId = new System.Windows.Forms.TextBox();
            this.lblProcessId = new System.Windows.Forms.Label();
            this.btnGetEvents = new System.Windows.Forms.Button();
            this.lblRequestId = new System.Windows.Forms.Label();
            this.txtRequestId = new System.Windows.Forms.TextBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtgPersoneller = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FULLNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgEnvanter = new System.Windows.Forms.DataGridView();
            this.cmbInventoryType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbGender.SuspendLayout();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKayitliKullanicilar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPersoneller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEnvanter)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHeader.Location = new System.Drawing.Point(166, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(194, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Yeni Personel Formu";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(103, 49);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(406, 21);
            this.cmbDepartment.TabIndex = 1;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(12, 52);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Departman:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 79);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(23, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Ad:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(103, 76);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(406, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(104, 102);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(406, 20);
            this.txtSurname.TabIndex = 6;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(13, 105);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(40, 13);
            this.lblSurname.TabIndex = 5;
            this.lblSurname.Text = "Soyad:";
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Checked = true;
            this.rdbMale.Location = new System.Drawing.Point(14, 33);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(53, 17);
            this.rdbMale.TabIndex = 8;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "Erkek";
            this.rdbMale.UseVisualStyleBackColor = true;
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Location = new System.Drawing.Point(144, 33);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(52, 17);
            this.rdbFemale.TabIndex = 9;
            this.rdbFemale.Text = "Kadın";
            this.rdbFemale.UseVisualStyleBackColor = true;
            // 
            // gbGender
            // 
            this.gbGender.Controls.Add(this.rdbMale);
            this.gbGender.Controls.Add(this.rdbFemale);
            this.gbGender.Location = new System.Drawing.Point(16, 128);
            this.gbGender.Name = "gbGender";
            this.gbGender.Size = new System.Drawing.Size(493, 66);
            this.gbGender.TabIndex = 10;
            this.gbGender.TabStop = false;
            this.gbGender.Text = "Cinsiyet";
            // 
            // chkIsOpen
            // 
            this.chkIsOpen.AutoSize = true;
            this.chkIsOpen.Location = new System.Drawing.Point(16, 200);
            this.chkIsOpen.Name = "chkIsOpen";
            this.chkIsOpen.Size = new System.Drawing.Size(69, 17);
            this.chkIsOpen.TabIndex = 11;
            this.chkIsOpen.Text = "Açık mı ?";
            this.chkIsOpen.UseVisualStyleBackColor = true;
            // 
            // lstMeyveler
            // 
            this.lstMeyveler.FormattingEnabled = true;
            this.lstMeyveler.Location = new System.Drawing.Point(15, 258);
            this.lstMeyveler.Name = "lstMeyveler";
            this.lstMeyveler.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstMeyveler.Size = new System.Drawing.Size(120, 147);
            this.lstMeyveler.TabIndex = 12;
            // 
            // lblMeyveler
            // 
            this.lblMeyveler.AutoSize = true;
            this.lblMeyveler.Location = new System.Drawing.Point(13, 242);
            this.lblMeyveler.Name = "lblMeyveler";
            this.lblMeyveler.Size = new System.Drawing.Size(53, 13);
            this.lblMeyveler.TabIndex = 13;
            this.lblMeyveler.Text = "Meyveler:";
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.rdbOption2);
            this.gbOptions.Controls.Add(this.rdbOption1);
            this.gbOptions.Location = new System.Drawing.Point(171, 200);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(338, 55);
            this.gbOptions.TabIndex = 14;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Seçenekler";
            // 
            // rdbOption2
            // 
            this.rdbOption2.AutoSize = true;
            this.rdbOption2.Location = new System.Drawing.Point(232, 19);
            this.rdbOption2.Name = "rdbOption2";
            this.rdbOption2.Size = new System.Drawing.Size(77, 17);
            this.rdbOption2.TabIndex = 1;
            this.rdbOption2.Text = "Seçenek-2";
            this.rdbOption2.UseVisualStyleBackColor = true;
            // 
            // rdbOption1
            // 
            this.rdbOption1.AutoSize = true;
            this.rdbOption1.Checked = true;
            this.rdbOption1.Location = new System.Drawing.Point(45, 19);
            this.rdbOption1.Name = "rdbOption1";
            this.rdbOption1.Size = new System.Drawing.Size(77, 17);
            this.rdbOption1.TabIndex = 0;
            this.rdbOption1.TabStop = true;
            this.rdbOption1.Text = "Seçenek-1";
            this.rdbOption1.UseVisualStyleBackColor = true;
            // 
            // dtgKayitliKullanicilar
            // 
            this.dtgKayitliKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgKayitliKullanicilar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DTG_TXT_Name,
            this.DTG_TXT_Surname,
            this.DTG_CMB_DrivingLicence});
            this.dtgKayitliKullanicilar.Location = new System.Drawing.Point(171, 261);
            this.dtgKayitliKullanicilar.Name = "dtgKayitliKullanicilar";
            this.dtgKayitliKullanicilar.Size = new System.Drawing.Size(338, 144);
            this.dtgKayitliKullanicilar.TabIndex = 15;
            // 
            // DTG_TXT_Name
            // 
            this.DTG_TXT_Name.HeaderText = "Ad";
            this.DTG_TXT_Name.Name = "DTG_TXT_Name";
            // 
            // DTG_TXT_Surname
            // 
            this.DTG_TXT_Surname.HeaderText = "Soyad";
            this.DTG_TXT_Surname.Name = "DTG_TXT_Surname";
            // 
            // DTG_CMB_DrivingLicence
            // 
            this.DTG_CMB_DrivingLicence.HeaderText = "Ehliyet";
            this.DTG_CMB_DrivingLicence.Name = "DTG_CMB_DrivingLicence";
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(434, 719);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 56);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Başlat";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtProcessId
            // 
            this.txtProcessId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProcessId.Location = new System.Drawing.Point(73, 721);
            this.txtProcessId.Name = "txtProcessId";
            this.txtProcessId.Size = new System.Drawing.Size(100, 20);
            this.txtProcessId.TabIndex = 17;
            this.txtProcessId.TextChanged += new System.EventHandler(this.txtProcessId_TextChanged);
            // 
            // lblProcessId
            // 
            this.lblProcessId.AutoSize = true;
            this.lblProcessId.Location = new System.Drawing.Point(12, 724);
            this.lblProcessId.Name = "lblProcessId";
            this.lblProcessId.Size = new System.Drawing.Size(55, 13);
            this.lblProcessId.TabIndex = 18;
            this.lblProcessId.Text = "Süreç No:";
            // 
            // btnGetEvents
            // 
            this.btnGetEvents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetEvents.Location = new System.Drawing.Point(179, 719);
            this.btnGetEvents.Name = "btnGetEvents";
            this.btnGetEvents.Size = new System.Drawing.Size(75, 55);
            this.btnGetEvents.TabIndex = 19;
            this.btnGetEvents.Text = "Eventları Getir";
            this.btnGetEvents.UseVisualStyleBackColor = true;
            this.btnGetEvents.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblRequestId
            // 
            this.lblRequestId.AutoSize = true;
            this.lblRequestId.Location = new System.Drawing.Point(13, 757);
            this.lblRequestId.Name = "lblRequestId";
            this.lblRequestId.Size = new System.Drawing.Size(50, 13);
            this.lblRequestId.TabIndex = 21;
            this.lblRequestId.Text = "İstek No:";
            // 
            // txtRequestId
            // 
            this.txtRequestId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRequestId.Location = new System.Drawing.Point(74, 754);
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.Size = new System.Drawing.Size(100, 20);
            this.txtRequestId.TabIndex = 20;
            this.txtRequestId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnApprove
            // 
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.Location = new System.Drawing.Point(260, 719);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 55);
            this.btnApprove.TabIndex = 22;
            this.btnApprove.Text = "btnApprove";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Visible = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(341, 719);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 55);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtgPersoneller
            // 
            this.dtgPersoneller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPersoneller.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FULLNAME});
            this.dtgPersoneller.Location = new System.Drawing.Point(15, 583);
            this.dtgPersoneller.Name = "dtgPersoneller";
            this.dtgPersoneller.Size = new System.Drawing.Size(494, 130);
            this.dtgPersoneller.TabIndex = 24;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Width = 250;
            // 
            // FULLNAME
            // 
            this.FULLNAME.HeaderText = "FULLNAME";
            this.FULLNAME.Name = "FULLNAME";
            this.FULLNAME.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FULLNAME.Width = 250;
            // 
            // dtgEnvanter
            // 
            this.dtgEnvanter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEnvanter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmbInventoryType,
            this.txtSerialNumber});
            this.dtgEnvanter.Location = new System.Drawing.Point(17, 427);
            this.dtgEnvanter.Name = "dtgEnvanter";
            this.dtgEnvanter.Size = new System.Drawing.Size(492, 134);
            this.dtgEnvanter.TabIndex = 25;
            // 
            // cmbInventoryType
            // 
            this.cmbInventoryType.HeaderText = "Envanter Tipi";
            this.cmbInventoryType.Name = "cmbInventoryType";
            this.cmbInventoryType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmbInventoryType.Width = 250;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.HeaderText = "Seri Numarası";
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.txtSerialNumber.Width = 250;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 784);
            this.Controls.Add(this.dtgEnvanter);
            this.Controls.Add(this.dtgPersoneller);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lblRequestId);
            this.Controls.Add(this.txtRequestId);
            this.Controls.Add(this.btnGetEvents);
            this.Controls.Add(this.lblProcessId);
            this.Controls.Add(this.txtProcessId);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dtgKayitliKullanicilar);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.lblMeyveler);
            this.Controls.Add(this.lstMeyveler);
            this.Controls.Add(this.chkIsOpen);
            this.Controls.Add(this.gbGender);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "eBA Yeni Personel";
            this.Load += new System.EventHandler(this.Main_Load);
            this.gbGender.ResumeLayout(false);
            this.gbGender.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKayitliKullanicilar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPersoneller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEnvanter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.RadioButton rdbFemale;
        private System.Windows.Forms.GroupBox gbGender;
        private System.Windows.Forms.CheckBox chkIsOpen;
        private System.Windows.Forms.ListBox lstMeyveler;
        private System.Windows.Forms.Label lblMeyveler;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.RadioButton rdbOption2;
        private System.Windows.Forms.RadioButton rdbOption1;
        private System.Windows.Forms.DataGridView dtgKayitliKullanicilar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTG_TXT_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTG_TXT_Surname;
        private System.Windows.Forms.DataGridViewComboBoxColumn DTG_CMB_DrivingLicence;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtProcessId;
        private System.Windows.Forms.Label lblProcessId;
        private System.Windows.Forms.Button btnGetEvents;
        private System.Windows.Forms.Label lblRequestId;
        private System.Windows.Forms.TextBox txtRequestId;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dtgPersoneller;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FULLNAME;
        private System.Windows.Forms.DataGridView dtgEnvanter;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbInventoryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSerialNumber;
    }
}