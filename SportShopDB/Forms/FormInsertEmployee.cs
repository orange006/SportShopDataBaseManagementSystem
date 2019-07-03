using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormInsertEmployee : Form
    {
        private SqlConnection con;

        public FormInsertEmployee(SqlConnection connection)
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
                Employee ins = new Employee
                {
                    FullName = textBoxName.Text,
                    Position = textBoxPos.Text,
                    Birthday = dateTimePickerBirth.Value.ToShortDateString(),
                    PhoneNumber = maskedTextBoxNumb.Text
                };

                await ins.InsertEmp();
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