using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormUpdateProduct : Form
    {
        private SqlConnection con;

        public FormUpdateProduct(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FormUpdateProduct_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;

            if (mf.listViewProd.SelectedItems.Count > 0)
            {
                textBoxId.Text = mf.listViewProd.FocusedItem.SubItems[0].Text;
                textBoxIdSupp.Text = mf.listViewProd.FocusedItem.SubItems[1].Text;
                textBoxName.Text = mf.listViewProd.FocusedItem.SubItems[2].Text;
                textBoxType.Text = mf.listViewProd.FocusedItem.SubItems[3].Text;
                textBoxPurchase.Text = mf.listViewProd.FocusedItem.SubItems[4].Text;
                textBoxSale.Text = mf.listViewProd.FocusedItem.SubItems[5].Text;
                comboBox1.Text = mf.listViewProd.FocusedItem.SubItems[6].Text;
                textBoxQuantity.Text = mf.listViewProd.FocusedItem.SubItems[7].Text;
                textBoxId.Enabled = false;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxIdSupp.Text) && !string.IsNullOrWhiteSpace(textBoxIdSupp.Text) &&
              !string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
              !string.IsNullOrEmpty(textBoxType.Text) && !string.IsNullOrWhiteSpace(textBoxType.Text) &&
              !string.IsNullOrEmpty(textBoxPurchase.Text) && !string.IsNullOrWhiteSpace(textBoxPurchase.Text) &&
              !string.IsNullOrEmpty(textBoxSale.Text) && !string.IsNullOrWhiteSpace(textBoxSale.Text) &&
              !string.IsNullOrEmpty(textBoxQuantity.Text) && !string.IsNullOrWhiteSpace(textBoxQuantity.Text) &&
              !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                Product upd = new Product
                {
                    ID = Int32.Parse(textBoxId.Text),
                    IdSupp = Int32.Parse(textBoxIdSupp.Text),
                    Name = textBoxName.Text,
                    Type = textBoxType.Text,
                    CostPurchase = Int32.Parse(textBoxPurchase.Text),
                    CostSale = Int32.Parse(textBoxSale.Text),
                    Quantity = Int32.Parse(textBoxQuantity.Text)
                };

                if (comboBox1.Text == "False")
                {
                    upd.Availability = 0;
                }
                else if (comboBox1.Text == "True")
                {
                    upd.Availability = 1;
                }

                await upd.UpdateProd();
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