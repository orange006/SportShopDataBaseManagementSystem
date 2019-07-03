using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormUpdateCustomer : Form
    {
        private SqlConnection con;

        public FormUpdateCustomer(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
              !string.IsNullOrEmpty(maskedTextBoxNumb.Text) && !string.IsNullOrWhiteSpace(maskedTextBoxNumb.Text))
            {
                Customer upd = new Customer
                {
                    ID = Int32.Parse(textBoxID.Text),
                    FullName = textBoxName.Text,
                    PhoneNumber = maskedTextBoxNumb.Text
                };

                await upd.UpdateCust();
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

        private void FormUpdateCustomer_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;

            if (mf.listViewCust.SelectedItems.Count > 0)
            {
                textBoxID.Text = mf.listViewCust.FocusedItem.SubItems[0].Text;
                textBoxName.Text = mf.listViewCust.FocusedItem.SubItems[1].Text;
                maskedTextBoxNumb.Text = mf.listViewCust.FocusedItem.SubItems[2].Text;
                textBoxID.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}