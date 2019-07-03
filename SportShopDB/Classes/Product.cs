using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportShopDB
{
    class Product
    {
        public int ID { get; set; }
        public int IdSupp { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public int CostPurchase { get; set; }
        public int CostSale { get; set; }
        public int Availability { get; set; }
        public int Quantity { get; set; }

        private ConnectToDB con = new ConnectToDB();

        public async Task SelectProd(ListView l)
        {
            SqlDataReader sqlReader = null;
            await con.ConnectDB();

            SqlCommand command = new SqlCommand("SELECT * FROM [Products]", con.sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        Convert.ToString(sqlReader["IdProduct"]),
                        Convert.ToString(sqlReader["IdSupp"]),
                        Convert.ToString(sqlReader["NameProduct"]),
                        Convert.ToString(sqlReader["TypeProduct"]),
                        Convert.ToString(sqlReader["CostPurchase"]),
                        Convert.ToString(sqlReader["CostSale"]),
                        Convert.ToString(sqlReader["Availability"]),
                        Convert.ToString(sqlReader["Quantity"]),
                    });

                    l.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }
        }

        public async Task InsertProd()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("INSERT INTO [Products] " +
                    "(IdSupp, NameProduct, TypeProduct, CostPurchase, CostSale, Availability, Quantity) " +
                    "VALUES(@IdSupp, @Name, @Type, @CostPurchase, @CostSale, @Availability, @Quantity)", con.sqlConnection);

                command.Parameters.AddWithValue("IdSupp", IdSupp);
                command.Parameters.AddWithValue("Name", Name);
                command.Parameters.AddWithValue("Type", Type);
                command.Parameters.AddWithValue("CostPurchase", CostPurchase);
                command.Parameters.AddWithValue("CostSale", CostSale);
                command.Parameters.AddWithValue("Availability", Availability);
                command.Parameters.AddWithValue("Quantity", Quantity);

                await command.ExecuteNonQueryAsync();
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

        public async Task UpdateProd()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("UPDATE [Products] " +
                    "SET [IdSupp] = @IdSupp, [NameProduct] = @Name, " +
                    "[TypeProduct] = @Type, [CostPurchase] = @CostPurchase, " +
                    "[CostSale] = @CostSale, [Availability] = @Availability, " +
                    "[Quantity] = @Quantity " +
                    "WHERE [IdProduct] = @ID", con.sqlConnection);

                command.Parameters.AddWithValue("ID", ID);
                command.Parameters.AddWithValue("IdSupp", IdSupp);
                command.Parameters.AddWithValue("Name", Name);
                command.Parameters.AddWithValue("Type", Type);
                command.Parameters.AddWithValue("CostPurchase", CostPurchase);
                command.Parameters.AddWithValue("CostSale", CostSale);
                command.Parameters.AddWithValue("Availability", Availability);
                command.Parameters.AddWithValue("Quantity", Quantity);

                await command.ExecuteNonQueryAsync();
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

        public async Task DeleteProd(ListView lv)
        {
            try
            {
                await con.ConnectDB();

                while (lv.SelectedItems.Count > 0)
                {
                    string str = lv.SelectedItems[0].Text;
                    lv.Items.Remove(lv.SelectedItems[0]);

                    SqlCommand command = new SqlCommand("DELETE FROM [Products] " +
                        "WHERE [IdProduct]='" + str + "'", con.sqlConnection);

                    await command.ExecuteNonQueryAsync();
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

        public async Task RefreshProd(ListView l)
        {
            try
            {
                l.Items.Clear();
                await SelectProd(l);
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
    }
}