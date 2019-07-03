using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormUpdateOrder : Form
    {
        private SqlConnection con;
        private ConnectToDB connect = new ConnectToDB();

        public FormUpdateOrder(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }

        private void FormUpdateOrder_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;

            if (mf.listViewOrd.SelectedItems.Count > 0)
            {
                textBoxId.Text = mf.listViewOrd.FocusedItem.SubItems[0].Text;
                textBoxIdProd.Text = mf.listViewOrd.FocusedItem.SubItems[1].Text;
                textBoxIdEmp.Text = mf.listViewOrd.FocusedItem.SubItems[2].Text;
                textBoxIdCust.Text = mf.listViewOrd.FocusedItem.SubItems[3].Text;
                dateTimePickerOrd.Text = mf.listViewOrd.FocusedItem.SubItems[4].Text;
                textBoxId.Enabled = false;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxIdProd.Text) && !string.IsNullOrWhiteSpace(textBoxIdProd.Text) &&
             !string.IsNullOrEmpty(dateTimePickerOrd.Text) && !string.IsNullOrWhiteSpace(dateTimePickerOrd.Text) &&
             !string.IsNullOrEmpty(textBoxIdEmp.Text) && !string.IsNullOrWhiteSpace(textBoxIdEmp.Text) &&
             !string.IsNullOrEmpty(textBoxIdCust.Text) && !string.IsNullOrWhiteSpace(textBoxIdCust.Text))
            {
                Order upd = new Order
                {
                    ID = Int32.Parse(textBoxId.Text),
                    IdProd = Int32.Parse(textBoxIdProd.Text),
                    IdEmpl = Int32.Parse(textBoxIdEmp.Text),
                    IdCust = Int32.Parse(textBoxIdCust.Text),
                    DateOrder = dateTimePickerOrd.Value.ToShortDateString()
                };

                int temp = Int32.Parse(textBoxIdProd.Text);

                Product prod = new Product
                {
                    ID = temp
                };

                ConnectToDB connect = new ConnectToDB();

                SqlDataReader sqlReader = null;

                await connect.ConnectDB();

                try
                {
                    SqlCommand command = new SqlCommand("SELECT [Quantity] FROM [Products] " +
                        "WHERE [IdProduct] = " + @temp, connect.sqlConnection);

                    sqlReader = await command.ExecuteReaderAsync();

                    await sqlReader.ReadAsync();

                    int q = Int32.Parse(Convert.ToString(sqlReader["Quantity"]));

                    sqlReader.Close();

                    if (q > 0)
                    {
                        q--;

                        prod.Quantity = q;

                        SqlCommand command2 = new SqlCommand("UPDATE [Products] " +
                            "SET [Quantity] = " + q +
                            " WHERE [IdProduct] = " + @temp, connect.sqlConnection);

                        command2.Parameters.AddWithValue("ID", prod.ID);
                        command2.Parameters.AddWithValue("Quantity", prod.Quantity);

                        await command2.ExecuteNonQueryAsync();

                        await upd.UpdateOrd();
                    }
                    else if (q == 0)
                    {
                        SqlCommand command3 = new SqlCommand("UPDATE [Products] " +
                           "SET [Availability] = " + 0 +
                           " WHERE [IdProduct] = " + @temp, connect.sqlConnection);

                        command3.Parameters.AddWithValue("ID", prod.ID);
                        command3.Parameters.AddWithValue("Availability", prod.Availability);

                        MessageBox.Show(
                        "Quantity of product = 0",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(
                        "Error!!!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}