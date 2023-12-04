using eBAFormExample.Models;
using eBAFormExample.Models.Request;
using eBAFormExample.Models.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace eBAFormExample
{
    public partial class Main : System.Windows.Forms.Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SetContinueButtonEnabled();
            LoadDetailsGridDataGridViewComboBox();
            LoadDetailsDataGridViewComboBox();
            LoadDepartments();
            LoadFruits();
        }
        private void LoadFruits()
        {
            List<ObjectItem> listBoxItems = new List<ObjectItem>
            {
                new ObjectItem{Key="1",Value="Elma"},
                new ObjectItem{Key="2",Value="Armut"},
                new ObjectItem{Key="3",Value="Muz"},
                new ObjectItem{Key="4",Value="Kiraz"},
                new ObjectItem{Key="5",Value="Karpuz"},
                new ObjectItem{Key="6",Value="Kavun"},
                new ObjectItem{Key="7",Value="Şeftali"},
            };
            lstMeyveler.DataSource = listBoxItems;
            lstMeyveler.DisplayMember = "Value";
            lstMeyveler.ValueMember = "Key";
        }

        private void LoadDepartments()
        {
            List<ObjectItem> comboBoxItems = new List<ObjectItem>();
            foreach (DataRow row in ProcessHelper.ExecuteIntegrationQuery("eBAConnection", "GetAllDepartments").Data.Rows)
            {
                comboBoxItems.Add(new ObjectItem { Key = row["ID"].ToString(), Value = row["NAME"].ToString() });
            }
            cmbDepartment.DataSource = comboBoxItems;
            cmbDepartment.DisplayMember = "Value";
            cmbDepartment.ValueMember = "Key";
        }

        private void LoadDetailsGridDataGridViewComboBox()
        {
            List<ObjectItem> comboBoxItems = new List<ObjectItem>
            {
                new ObjectItem{Key="A",Value="A Sınıfı"},
                new ObjectItem{Key="A2",Value="A2 Sınıfı"},
                new ObjectItem{Key="A1",Value="A1 Sınıfı"},
                new ObjectItem{Key="B",Value="B Sınıfı"}
            };
            DTG_CMB_DrivingLicence.DataSource = comboBoxItems;
            DTG_CMB_DrivingLicence.DisplayMember = "Value";
            DTG_CMB_DrivingLicence.ValueMember = "Key";
        }

        private void LoadDetailsDataGridViewComboBox()
        {
            List<ObjectItem> comboBoxItems = new List<ObjectItem>
            {
                new ObjectItem{Key="1",Value="Bilgisayar"},
                new ObjectItem{Key="2",Value="Monitör"},
                new ObjectItem{Key="3",Value="Telefon"},
                new ObjectItem{Key="4",Value="Çanta"},
                new ObjectItem{Key="5",Value="Klavye-Mouse"}
            };
            cmbInventoryType.DataSource = comboBoxItems;
            cmbInventoryType.DisplayMember = "Value";
            cmbInventoryType.ValueMember = "Key";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MainFormData data = CreateMainFormData();
            ProcessHelper.StartProcess("Tozer_YeniPersonel", data);
            MessageBox.Show("Süreç başarıyla oluşturuldu.", "İşlem başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtProcessId_TextChanged(object sender, EventArgs e)
        {
            SetContinueButtonEnabled();
        }

        private void SetContinueButtonEnabled()
        {
            if (string.IsNullOrEmpty(txtProcessId.Text) || string.IsNullOrEmpty(txtRequestId.Text))
                btnGetEvents.Enabled = false;
            else
                btnGetEvents.Enabled = true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtProcessId.Text, "[^0-9]") || System.Text.RegularExpressions.Regex.IsMatch(txtRequestId.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen süreç ve istek numarasını sayısal olarak girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcessId.Clear();
            }
            GetProcessEventsResponse response = ProcessHelper.GetProcessEvents(int.Parse(txtProcessId.Text), int.Parse(txtRequestId.Text));
            if (response.DetailedEvents.Count > 0)
            {
                foreach (DetailedEvent detailedEvent in response.DetailedEvents)
                {
                    if (detailedEvent.IdField == 4 || detailedEvent.IdField == 5)
                    {
                        btnApprove.Text = detailedEvent.DescriptionField;
                        btnApprove.Tag = detailedEvent.IdField;
                        btnApprove.Visible = true;
                    }
                    else if (detailedEvent.IdField == 6 || detailedEvent.IdField == 7)
                    {
                        btnCancel.Text = detailedEvent.DescriptionField;
                        btnCancel.Tag = detailedEvent.IdField;
                        btnCancel.Visible = true;
                    }
                }
                txtProcessId.Enabled = false;
                txtRequestId.Enabled = false;
            }
            else
            {
                btnApprove.Visible = false;
                btnCancel.Visible = false;
            }
        }

        private void ContinueProcess(int requestId)
        {
            ProcessHelper.ContinueProcess(int.Parse(txtProcessId.Text), int.Parse(txtRequestId.Text), requestId, CreateMainFormData());
            txtProcessId.Enabled = true;
            txtRequestId.Enabled = true;
            txtProcessId.Clear();
            txtRequestId.Clear();
            btnGetEvents.Enabled = true;
            btnApprove.Visible = false;
            btnCancel.Visible = false;
            MessageBox.Show("Süreç başarıyla ilerletildi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetContinueButtonEnabled();
        }

        private MainFormData CreateMainFormData()
        {
            List<ObjectItem> fruits = new List<ObjectItem>();
            foreach (var item in lstMeyveler.SelectedItems)
            {
                fruits.Add((ObjectItem)item);
            }

            return new MainFormData
            {
                Department = new KeyValuePair<string, string>(cmbDepartment.SelectedValue.ToString(), cmbDepartment.Text),
                Name = txtName.Text,
                Surname = txtSurname.Text,
                IsOpen = chkIsOpen.Checked,
                Gender = rdbMale.Checked ? new KeyValuePair<string, string>("1", "Erkek") : new KeyValuePair<string, string>("2", "Kadın"),
                OptionName = rdbOption1.Checked ? "RDBSECENEK1" : "RDBSECENEK2",
                Fruits = fruits,
                DetailsGridItem = SetDetailsGridItems(),
                TableItem = SetTableItems(),
                Details = SetDetails()
            };
        }

        private Details SetDetails()
        {
            Details details = new Details();
            details.DetailsForm = "EnvanterFormu";
            List<DetailsRow> rows = new List<DetailsRow>();
            for (int i = 0; i < dtgEnvanter.Rows.Count; i++)
            {
                if (dtgEnvanter.Rows.Count != dtgEnvanter.Rows[i].Index + 1)
                {
                    DetailsRow row = new DetailsRow();
                    Models.Request.Control inventoryType = new Models.Request.Control
                    {
                        Type = "ComboBox",
                        Name = "CMBENVANTERTIPI",
                        Value = new ObjectItem
                        {
                            Key = dtgEnvanter.Rows[i].Cells[0].Value.ToString(),
                            Value = dtgEnvanter.Rows[i].Cells[0].FormattedValue.ToString()
                        }
                    };
                    Models.Request.Control serialNumber = new Models.Request.Control
                    {
                        Type = "TextBox",
                        Name = "TXTSERINUMARASI",
                        Value = dtgEnvanter.Rows[i].Cells[1].Value.ToString()
                    };
                    row.Controls.Add(inventoryType);
                    row.Controls.Add(serialNumber);
                    rows.Add(row);
                }
            }
            details.Rows = rows;
            return details;
        }

        private List<TableItem> SetTableItems()
        {
            List<TableItem> tableItems = new List<TableItem>();
            for (int i = 0; i < dtgPersoneller.Rows.Count; i++)
            {
                if (dtgPersoneller.Rows.Count != dtgPersoneller.Rows[i].Index + 1)
                {
                    List<TableRowItem> columns = new List<TableRowItem>();
                    TableRowItem id = new TableRowItem
                    {
                        Name = "ID",
                        Value = dtgPersoneller.Rows[i].Cells[0].Value.ToString()
                    };
                    TableRowItem fullname = new TableRowItem
                    {
                        Name = "FULLNAME",
                        Value = dtgPersoneller.Rows[i].Cells[1].Value.ToString()
                    };
                    columns.Add(id);
                    columns.Add(fullname);
                    tableItems.Add(new TableItem { Columns = columns });
                }
            }
            return tableItems;
        }

        private List<DetailsGridItem> SetDetailsGridItems()
        {
            List<DetailsGridItem> detailsGridItems = new List<DetailsGridItem>();
            for (int i = 0; i < dtgKayitliKullanicilar.Rows.Count; i++)
            {
                if (dtgKayitliKullanicilar.Rows.Count != dtgKayitliKullanicilar.Rows[i].Index + 1)
                {
                    List<Models.Request.Control> columns = new List<Models.Request.Control>();
                    Models.Request.Control name = new Models.Request.Control
                    {
                        Type = "TextBox",
                        Name = "DTG_TXT_AD",
                        Value = dtgKayitliKullanicilar.Rows[i].Cells[0].Value
                    };
                    Models.Request.Control surname = new Models.Request.Control
                    {
                        Type = "TextBox",
                        Name = "DTG_TXT_SOYAD",
                        Value = dtgKayitliKullanicilar.Rows[i].Cells[1].Value
                    };
                    Models.Request.Control driverLicence = new Models.Request.Control
                    {
                        Type = "ComboBox",
                        Name = "DTG_CMB_EHLIYET",
                        Value = new ObjectItem
                        {
                            Key = dtgKayitliKullanicilar.Rows[i].Cells[2].Value.ToString(),
                            Value = dtgKayitliKullanicilar.Rows[i].Cells[2].FormattedValue.ToString()
                        }
                    };
                    columns.Add(name);
                    columns.Add(surname);
                    columns.Add(driverLicence);
                    detailsGridItems.Add(new DetailsGridItem { Columns = columns });
                }
            }
            return detailsGridItems;
        }

        private void btnApprove_Click(object sender, EventArgs e) => ContinueProcess((int)((Button)sender).Tag);

        private void btnCancel_Click(object sender, EventArgs e) => ContinueProcess((int)((Button)sender).Tag);
    }
}
