using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportShopDB
{
    class Order
    {
        public int ID { get; set; }
        public int IdProd { get; set; }
        public int IdEmpl { get; set; }
        public int IdCust { get; set; }
        public String DateOrder { get; set; }

        private ConnectToDB con = new ConnectToDB();

        public async Task SelectOrd(ListView l)
        {
            SqlDataReader sqlReader = null;
            await con.ConnectDB();

            SqlCommand command = new SqlCommand("SELECT * FROM [Orders]", con.sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        Convert.ToString(sqlReader["IdOrder"]),
                        Convert.ToString(sqlReader["IdProd"]),
                        Convert.ToString(sqlReader["IdEmpl"]),
                        Convert.ToString(sqlReader["IdCust"]),
                        Convert.ToString(sqlReader["DateOrder"]),
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
        
        public async Task InsertOrd()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("INSERT INTO [Orders] " +
                    "(IdProd, IdEmpl, IdCust, DateOrder) " +
                    "VALUES(@IdProd, @IdEmpl, @IdCust, @DateOrder)", con.sqlConnection);

                command.Parameters.AddWithValue("IdProd", IdProd);
                command.Parameters.AddWithValue("IdEmpl", IdEmpl);
                command.Parameters.AddWithValue("IdCust", IdCust);
                command.Parameters.AddWithValue("DateOrder", DateOrder);

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

        public async Task UpdateOrd()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("UPDATE [Orders] " +
                    "SET [IdProd] = @IdProd, [IdEmpl] = @IdEmpl, " +
                    "[IdCust] = @IdCust, [DateOrder] = @DateOrder " +
                    "WHERE [IdOrder] = @ID", con.sqlConnection);

                command.Parameters.AddWithValue("ID", ID);
                command.Parameters.AddWithValue("IdProd", IdProd);
                command.Parameters.AddWithValue("IdEmpl", IdEmpl);
                command.Parameters.AddWithValue("IdCust", IdCust);
                command.Parameters.AddWithValue("DateOrder", DateOrder);

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

        public async Task DeleteOrd(ListView lv)
        {
            try
            {
                await con.ConnectDB();

                while (lv.SelectedItems.Count > 0)
                {
                    string str = lv.SelectedItems[0].Text;
                    lv.Items.Remove(lv.SelectedItems[0]);

                    SqlCommand command = new SqlCommand("DELETE FROM [Orders] " +
                        "WHERE [IdOrder]='" + str + "'", con.sqlConnection);

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

        public async Task RefreshOrd(ListView l)
        {
            try
            {
                l.Items.Clear();
                await SelectOrd(l);
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