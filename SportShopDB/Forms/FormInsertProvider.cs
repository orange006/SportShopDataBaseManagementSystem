using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormInsertProvider : Form
    {
        private SqlConnection con;

        public FormInsertProvider(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
              !string.IsNullOrEmpty(textBoxPos.Text) && !string.IsNullOrWhiteSpace(textBoxPos.Text) &&
              !string.IsNullOrEmpty(maskedTextBoxNumb.Text) && !string.IsNullOrWhiteSpace(maskedTextBoxNumb.Text))
            {
                Provider ins = new Provider
                {
                    Name = textBoxName.Text,
                    Representative = textBoxPos.Text,
                    PhoneNumber = maskedTextBoxNumb.Text
                };

                await ins.InsertProv();
            }
            else
            {
                MessageBox.Show(
                "All fields must be filled!!!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            textBoxName.Clear();
            textBoxPos.Clear();
            maskedTextBoxNumb.Clear();
        }
    }
}