using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormUpdateEmployee : Form
    {
        private SqlConnection con;

        public FormUpdateEmployee(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FormUpdateEmployee_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;

            if (mf.listViewEmp.SelectedItems.Count > 0)
            {
                textBoxID.Text = mf.listViewEmp.FocusedItem.SubItems[0].Text;
                textBoxName.Text = mf.listViewEmp.FocusedItem.SubItems[1].Text;
                textBoxPos.Text = mf.listViewEmp.FocusedItem.SubItems[2].Text;
                dateTimePickerBirth.Text = mf.listViewEmp.FocusedItem.SubItems[3].Text;
                maskedTextBoxNumb.Text = mf.listViewEmp.FocusedItem.SubItems[4].Text;
                textBoxID.Enabled = false;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
              !string.IsNullOrEmpty(textBoxPos.Text) && !string.IsNullOrWhiteSpace(textBoxPos.Text) &&
              !string.IsNullOrEmpty(maskedTextBoxNumb.Text) && !string.IsNullOrWhiteSpace(maskedTextBoxNumb.Text))
            {
                Employee upd = new Employee
                {
                    ID = Int32.Parse(textBoxID.Text),
                    FullName = textBoxName.Text,
                    Position = textBoxPos.Text,
                    Birthday = dateTimePickerBirth.Value.ToShortDateString(),
                    PhoneNumber = maskedTextBoxNumb.Text
                };

                await upd.UpdateEmp();
            }
            else
            {
                MessageBox.Show(
                "All fields must be filled!!!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            Hide();
        }
    }
}