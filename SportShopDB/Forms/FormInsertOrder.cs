using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormInsertOrder : Form
    {
        private SqlConnection con;
        private ConnectToDB connect = new ConnectToDB();

        public FormInsertOrder(SqlConnection connection)
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
            if (!string.IsNullOrEmpty(textBoxIdProd.Text) && !string.IsNullOrWhiteSpace(textBoxIdProd.Text) &&
             !string.IsNullOrEmpty(dateTimePickerOrd.Text) && !string.IsNullOrWhiteSpace(dateTimePickerOrd.Text) &&
             !string.IsNullOrEmpty(textBoxIdEmp.Text) && !string.IsNullOrWhiteSpace(textBoxIdEmp.Text) &&
             !string.IsNullOrEmpty(textBoxIdCust.Text) && !string.IsNullOrWhiteSpace(textBoxIdCust.Text))
            {
                Order ins = new Order
                {
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

                        await ins.InsertOrd();
                    }
                    else if (q == 0)
                    {
                        SqlCommand command3 = new SqlCommand("UPDATE [Products] " +
                           "SET [Availability] = " + 0 +
                           " WHERE [IdProduct] = " + @temp, connect.sqlConnection);

                        command3.Parameters.AddWithValue("ID", prod.ID);
                        command3.Parameters.AddWithValue("Availability", prod.Availability);

                        await command3.ExecuteNonQueryAsync();

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

            textBoxIdProd.Clear();
            textBoxIdCust.Clear();
            textBoxIdEmp.Clear();
        }
    }
}