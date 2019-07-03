using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportShopDB
{
    class ConnectToDB
    {
        public SqlConnection sqlConnection;

        public async Task ConnectDB()
        {
            try
            {
                System.AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory + "../../../SportShopDB"));

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SportShopDB.mdf;Integrated Security=True";

                sqlConnection = new SqlConnection(connectionString);

                await sqlConnection.OpenAsync();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
