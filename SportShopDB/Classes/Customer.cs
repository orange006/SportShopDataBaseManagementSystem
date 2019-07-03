using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportShopDB
{
    class Customer
    {
        public int ID { get; set; }
        public String FullName { get; set; }
        public String PhoneNumber { get; set; }

        private ConnectToDB con = new ConnectToDB();

        public async Task SelectCust(ListView l)
        {
            SqlDataReader sqlReader = null;
            await con.ConnectDB();

            SqlCommand command = new SqlCommand("SELECT * FROM [Customers]", con.sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        Convert.ToString(sqlReader["IdCustomer"]),
                        Convert.ToString(sqlReader["FullNameCust"]),
                        Convert.ToString(sqlReader["PhoneNumberCust"]),
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

        public async Task InsertCust()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("INSERT INTO [Customers] " +
                    "(FullNameCust, PhoneNumberCust) " +
                    "VALUES(@FullName, @PhoneNumber)", con.sqlConnection);

                command.Parameters.AddWithValue("FullName", FullName);
                command.Parameters.AddWithValue("PhoneNumber", PhoneNumber);

                await command.ExecuteNonQueryAsync();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task UpdateCust()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("UPDATE [Customers] " +
                    "SET [FullNameCust] = @FullName, [PhoneNumberCust] = @PhoneNumber " +
                    "WHERE [IdCustomer] = @ID", con.sqlConnection);

                command.Parameters.AddWithValue("ID", ID);
                command.Parameters.AddWithValue("FullName", FullName);
                command.Parameters.AddWithValue("PhoneNumber", PhoneNumber);

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

        public async Task DeleteCust(ListView lv)
        {
            try
            {
                await con.ConnectDB();

                while (lv.SelectedItems.Count > 0)
                {
                    string str = lv.SelectedItems[0].Text;
                    lv.Items.Remove(lv.SelectedItems[0]);

                    SqlCommand command = new SqlCommand("DELETE FROM [Customers] " +
                        "WHERE [IdCustomer]='" + str + "'", con.sqlConnection);

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

        public async Task RefreshCust(ListView l)
        {
            try
            {
                l.Items.Clear();
                await SelectCust(l);
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