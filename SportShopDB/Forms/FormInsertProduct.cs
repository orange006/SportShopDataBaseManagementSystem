using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormInsertProduct : Form
    {
        private SqlConnection con;

        public FormInsertProduct(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxIdSupp.Text) && !string.IsNullOrWhiteSpace(textBoxIdSupp.Text) &&
              !string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
              !string.IsNullOrEmpty(textBoxType.Text) && !string.IsNullOrWhiteSpace(textBoxType.Text) &&
              !string.IsNullOrEmpty(textBoxPurchase.Text) && !string.IsNullOrWhiteSpace(textBoxPurchase.Text) &&
              !string.IsNullOrEmpty(textBoxSale.Text) && !string.IsNullOrWhiteSpace(textBoxSale.Text) &&
              !string.IsNullOrEmpty(textBoxQuantity.Text) && !string.IsNullOrWhiteSpace(textBoxQuantity.Text) &&
              !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                Product ins = new Product
                {
                    IdSupp = Int32.Parse(textBoxIdSupp.Text),
                    Name = textBoxName.Text,
                    Type = textBoxType.Text,
                    CostPurchase = Int32.Parse(textBoxPurchase.Text),
                    CostSale = Int32.Parse(textBoxSale.Text),
                    Quantity = Int32.Parse(textBoxQuantity.Text)
                };

                if(comboBox1.Text == "False")
                {
                    ins.Availability = 0;
                }
                else if(comboBox1.Text == "True")
                {
                    ins.Availability = 1;
                }

                await ins.InsertProd();
            }
            else
            {
                MessageBox.Show(
                "All fields must be filled!!!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            textBoxIdSupp.Clear();
            textBoxName.Clear();
            textBoxType.Clear();
            textBoxPurchase.Clear();
            textBoxSale.Clear();
            textBoxQuantity.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}