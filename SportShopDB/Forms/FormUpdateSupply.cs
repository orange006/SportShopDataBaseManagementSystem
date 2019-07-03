using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class FormUpdateSupply : Form
    {
        private SqlConnection con;

        public FormUpdateSupply(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxIdProv.Text) && !string.IsNullOrWhiteSpace(textBoxIdProv.Text))
            {
                Supply upd = new Supply
                {
                    ID = Int32.Parse(textBoxID.Text),
                    IdProvid = Int32.Parse(textBoxIdProv.Text),
                    DateSupply = dateTimePickerSupp.Value.ToShortDateString()
                };

                await upd.UpdateSupp();
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

        private void FormUpdateSupply_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;

            if (mf.listViewSuppl.SelectedItems.Count > 0)
            {
                textBoxID.Text = mf.listViewSuppl.FocusedItem.SubItems[0].Text;
                textBoxIdProv.Text = mf.listViewSuppl.FocusedItem.SubItems[1].Text;
                dateTimePickerSupp.Text = mf.listViewSuppl.FocusedItem.SubItems[2].Text;
                textBoxID.Enabled = false;
            }
        }
    }
}