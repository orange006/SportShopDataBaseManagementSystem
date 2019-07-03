using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormUpdateProvider : Form
    {
        private SqlConnection con;

        public FormUpdateProvider(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
              !string.IsNullOrEmpty(textBoxPos.Text) && !string.IsNullOrWhiteSpace(textBoxPos.Text) &&
              !string.IsNullOrEmpty(maskedTextBoxNumb.Text) && !string.IsNullOrWhiteSpace(maskedTextBoxNumb.Text))
            {
                Provider upd = new Provider
                {
                    ID = Int32.Parse(textBoxID.Text),
                    Name = textBoxName.Text,
                    Representative = textBoxPos.Text,
                    PhoneNumber = maskedTextBoxNumb.Text
                };

                await upd.UpdateProv();
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

        private void FormUpdateProvider_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;

            if (mf.listViewProv.SelectedItems.Count > 0)
            {
                textBoxID.Text = mf.listViewProv.FocusedItem.SubItems[0].Text;
                textBoxName.Text = mf.listViewProv.FocusedItem.SubItems[1].Text;
                textBoxPos.Text = mf.listViewProv.FocusedItem.SubItems[2].Text;
                maskedTextBoxNumb.Text = mf.listViewProv.FocusedItem.SubItems[3].Text;
                textBoxID.Enabled = false;
            }
        }
    }
}