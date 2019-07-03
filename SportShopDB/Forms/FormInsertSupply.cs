using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormInsertSupply : Form
    {
        private SqlConnection con;

        public FormInsertSupply(SqlConnection connection)
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
            if (!string.IsNullOrEmpty(textBoxIdProv.Text) && !string.IsNullOrWhiteSpace(textBoxIdProv.Text) &&
              !string.IsNullOrEmpty(dateTimePickerSupp.Text) && !string.IsNullOrWhiteSpace(dateTimePickerSupp.Text))
            {
                Supply ins = new Supply
                {
                    IdProvid = Int32.Parse(textBoxIdProv.Text),
                    DateSupply = dateTimePickerSupp.Value.ToShortDateString()
                };

                await ins.InsertSupp();
            }
            else
            {
                MessageBox.Show(
                "All fields must be filled!!!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            textBoxIdProv.Clear();
        }
    }
}