using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportShopDB
{
    class Employee
    {
        public int ID { get; set; }
        public String FullName { get; set; }
        public String Position { get; set; }
        public String Birthday { get; set; }
        public String PhoneNumber { get; set; }

        private ConnectToDB con = new ConnectToDB();

        public async Task SelectEmp(ListView l)
        {
            SqlDataReader sqlReader = null;
            await con.ConnectDB();

            SqlCommand command = new SqlCommand("SELECT * FROM [Employees]", con.sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        Convert.ToString(sqlReader["IdEmployee"]),
                        Convert.ToString(sqlReader["FullNameEmp"]),
                        Convert.ToString(sqlReader["Position"]),
                        Convert.ToString(sqlReader["Birthday"]),
                        Convert.ToString(sqlReader["PhoneNumberEmp"]),
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

        public async Task InsertEmp()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("INSERT INTO [Employees] " +
                    "(FullNameEmp, Position, Birthday, PhoneNumberEmp) " +
                    "VALUES(@FullName, @Position, @Birthday, @PhoneNumber)", con.sqlConnection);

                command.Parameters.AddWithValue("FullName", FullName);
                command.Parameters.AddWithValue("Position", Position);
                command.Parameters.AddWithValue("Birthday", Birthday);
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

        public async Task UpdateEmp()
        {
            try
            {
                await con.ConnectDB();
                SqlCommand command = new SqlCommand("UPDATE [Employees] " +
                    "SET [FullNameEmp] = @FullName, [Position] = @Position, [Birthday] = @Birthday, [PhoneNumberEmp] = @PhoneNumber " +
                    "WHERE [IdEmployee] = @ID", con.sqlConnection);

                command.Parameters.AddWithValue("ID", ID);
                command.Parameters.AddWithValue("FullName", FullName);
                command.Parameters.AddWithValue("Position", Position);
                command.Parameters.AddWithValue("Birthday", Birthday);
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

        public async Task DeleteEmp(ListView lv)
        {
            try
            {
                await con.ConnectDB();

                while (lv.SelectedItems.Count > 0)
                {
                    string str = lv.SelectedItems[0].Text;
                    lv.Items.Remove(lv.SelectedItems[0]);

                    SqlCommand command = new SqlCommand("DELETE FROM [Employees] " +
                        "WHERE [IdEmployee]='" + str + "'", con.sqlConnection);

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

        public async Task RefreshEmp(ListView l)
        {
            try
            {
                l.Items.Clear();
                await SelectEmp(l);
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