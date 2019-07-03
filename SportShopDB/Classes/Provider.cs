using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportShopDB
{
    class Provider
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Representative { get; set; }
        public String PhoneNumber { get; set; }

        private ConnectToDB con = new ConnectToDB();

        public async Task SelectProv(ListView l)
        {
            SqlDataReader sqlReader = null;
            await con.ConnectDB();

            SqlCommand command = new SqlCommand("SELECT * FROM [Providers]", con.sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        Convert.ToString(sqlReader["IdProvider"]),
                        Convert.ToString(sqlReader["NameProvider"]),
                        Convert.ToString(sqlReader["Representative"]),
                        Convert.ToString(sqlReader["PhoneNumberProv"]),
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

        public async Task InsertProv()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("INSERT INTO [Providers] " +
                    "(NameProvider, Representative, PhoneNumberProv) " +
                    "VALUES(@Name, @Representative, @PhoneNumber)", con.sqlConnection);

                command.Parameters.AddWithValue("Name", Name);
                command.Parameters.AddWithValue("Representative", Representative);
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

        public async Task UpdateProv()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("UPDATE [Providers] " +
                    "SET [NameProvider] = @Name, [Representative] = @Representative, [PhoneNumberProv] = @PhoneNumber " +
                    "WHERE [IdProvider] = @ID", con.sqlConnection);

                command.Parameters.AddWithValue("ID", ID);
                command.Parameters.AddWithValue("Name", Name);
                command.Parameters.AddWithValue("Representative", Representative);
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

        public async Task DeleteProv(ListView lv)
        {
            try
            {
                await con.ConnectDB();

                while (lv.SelectedItems.Count > 0)
                {
                    string str = lv.SelectedItems[0].Text;
                    lv.Items.Remove(lv.SelectedItems[0]);

                    SqlCommand command = new SqlCommand("DELETE FROM [Providers] " +
                        "WHERE [IdProvider]='" + str + "'", con.sqlConnection);

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

        public async Task RefreshProv(ListView l)
        {
            try
            {
                l.Items.Clear();
                await SelectProv(l);
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