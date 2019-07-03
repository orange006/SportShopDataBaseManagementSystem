using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormInsertCustomer : Form
    {
        private SqlConnection con;

        public FormInsertCustomer(SqlConnection connection)
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
             !string.IsNullOrEmpty(maskedTextBoxNumb.Text) && !string.IsNullOrWhiteSpace(maskedTextBoxNumb.Text))
            {
                Customer ins = new Customer
                {
                    FullName = textBoxName.Text,
                    PhoneNumber = maskedTextBoxNumb.Text
                };

                await ins.InsertCust();
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
            maskedTextBoxNumb.Clear();
        }
    }
}