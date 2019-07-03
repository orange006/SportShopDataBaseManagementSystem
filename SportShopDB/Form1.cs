using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportShopDB
{
    public partial class MainForm : Form
    {
        private int x = 0;
        private int y = 0;

        ConnectToDB connectDB = new ConnectToDB();

        private ColumnHeader SortingColumn = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void panelMove_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }

        private void panelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            TextBoxPlaceHolder(textBoxSearch, "Search...");

            listViewEmp.GridLines = true;
            listViewEmp.FullRowSelect = true;
            listViewEmp.View = View.Details;

            listViewEmp.Columns.Add("ID");
            listViewEmp.Columns.Add("Full Name");
            listViewEmp.Columns.Add("Position");
            listViewEmp.Columns.Add("Birthday");
            listViewEmp.Columns.Add("Phone Number");

            // ..

            listViewCust.GridLines = true;
            listViewCust.FullRowSelect = true;
            listViewCust.View = View.Details;

            listViewCust.Columns.Add("ID");
            listViewCust.Columns.Add("Full Name");
            listViewCust.Columns.Add("Phone Number");

            // ..

            listViewOrd.GridLines = true;
            listViewOrd.FullRowSelect = true;
            listViewOrd.View = View.Details;

            listViewOrd.Columns.Add("ID");
            listViewOrd.Columns.Add("ID Product");
            listViewOrd.Columns.Add("ID Employee");
            listViewOrd.Columns.Add("ID Customer");
            listViewOrd.Columns.Add("Date");

            // ..

            listViewProd.GridLines = true;
            listViewProd.FullRowSelect = true;
            listViewProd.View = View.Details;

            listViewProd.Columns.Add("ID");
            listViewProd.Columns.Add("ID Supply");
            listViewProd.Columns.Add("Name Product");
            listViewProd.Columns.Add("Type Product");
            listViewProd.Columns.Add("Cost Purchase");
            listViewProd.Columns.Add("Cost Sale");
            listViewProd.Columns.Add("Availability");
            listViewProd.Columns.Add("Quantity");

            // ..

            listViewSuppl.GridLines = true;
            listViewSuppl.FullRowSelect = true;
            listViewSuppl.View = View.Details;

            listViewSuppl.Columns.Add("ID");
            listViewSuppl.Columns.Add("ID Provider");
            listViewSuppl.Columns.Add("Date");

            // ..

            listViewProv.GridLines = true;
            listViewProv.FullRowSelect = true;
            listViewProv.View = View.Details;

            listViewProv.Columns.Add("ID");
            listViewProv.Columns.Add("Name");
            listViewProv.Columns.Add("Representative");
            listViewProv.Columns.Add("Phone Number");
           
            try
            {
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Functional.autoResizeColumns(listViewEmp);
            Functional.autoResizeColumns(listViewCust);
            Functional.autoResizeColumns(listViewOrd);
            Functional.autoResizeColumns(listViewProd);
            Functional.autoResizeColumns(listViewSuppl);
            Functional.autoResizeColumns(listViewProv);
        }

        private async Task LoadDataAsync()
        {
            Employee loadEmp = new Employee();
            await loadEmp.SelectEmp(listViewEmp);

            Customer loadCust = new Customer();
            await loadCust.SelectCust(listViewCust);

            Provider loadProv = new Provider();
            await loadProv.SelectProv(listViewProv);

            Supply loadSupp = new Supply();
            await loadSupp.SelectSupp(listViewSuppl);

            Product loadProd = new Product();
            await loadProd.SelectProd(listViewProd);

            Order loadOrd = new Order();
            await loadOrd.SelectOrd(listViewOrd);
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            if (TableControl.SelectedTab == tabEmpl)
            {
                FormInsertEmployee f = new FormInsertEmployee(connectDB.sqlConnection);
                f.ShowDialog();

                Employee refresh = new Employee();
                await refresh.RefreshEmp(listViewEmp);
            }
            else if (TableControl.SelectedTab == tabCust)
            {
                FormInsertCustomer f = new FormInsertCustomer(connectDB.sqlConnection);
                f.ShowDialog();

                Customer refresh = new Customer();
                await refresh.RefreshCust(listViewCust);
            }
            else if (TableControl.SelectedTab == tabProv)
            {
                FormInsertProvider f = new FormInsertProvider(connectDB.sqlConnection);
                f.ShowDialog();

                Provider refresh = new Provider();
                await refresh.RefreshProv(listViewProv);
            }
            else if(TableControl.SelectedTab == tabSuppl)
            {
                FormInsertSupply f = new FormInsertSupply(connectDB.sqlConnection);
                f.ShowDialog();

                Supply refresh = new Supply();
                await refresh.RefreshSupp(listViewSuppl);
            }
            else if(TableControl.SelectedTab == tabProd)
            {
                FormInsertProduct f = new FormInsertProduct(connectDB.sqlConnection);
                f.ShowDialog();

                Product refresh = new Product();
                await refresh.RefreshProd(listViewProd);
            }
            else if (TableControl.SelectedTab == tabOrd)
            {
                FormInsertOrder f = new FormInsertOrder(connectDB.sqlConnection);
                f.ShowDialog();

                Order refresh = new Order();
                await refresh.RefreshOrd(listViewOrd);

                Product refresh2 = new Product();
                await refresh2.RefreshProd(listViewProd);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (TableControl.SelectedTab == tabEmpl)
            {
                FormUpdateEmployee f = new FormUpdateEmployee(connectDB.sqlConnection)
                {
                    Owner = this
                };

                f.ShowDialog();

                Employee refresh = new Employee();
                await refresh.RefreshEmp(listViewEmp);
            }
            else if (TableControl.SelectedTab == tabCust)
            {
                FormUpdateCustomer f = new FormUpdateCustomer(connectDB.sqlConnection)
                {
                    Owner = this
                };

                f.ShowDialog();

                Customer refresh = new Customer();
                await refresh.RefreshCust(listViewCust);
            }
            else if (TableControl.SelectedTab == tabProv)
            {
                FormUpdateProvider f = new FormUpdateProvider(connectDB.sqlConnection)
                {
                    Owner = this
                };

                f.ShowDialog();

                Provider refresh = new Provider();
                await refresh.RefreshProv(listViewProv);
            }
            else if (TableControl.SelectedTab == tabSuppl)
            {
                FormUpdateSupply f = new FormUpdateSupply(connectDB.sqlConnection)
                {
                    Owner = this
                };

                f.ShowDialog();

                Supply refresh = new Supply();
                await refresh.RefreshSupp(listViewSuppl);
            }
            else if (TableControl.SelectedTab == tabProd)
            {
                FormUpdateProduct f = new FormUpdateProduct(connectDB.sqlConnection)
                {
                    Owner = this
                };

                f.ShowDialog();

                Product refresh = new Product();
                await refresh.RefreshProd(listViewProd);
            }
            else if (TableControl.SelectedTab == tabOrd)
            {
                FormUpdateOrder f = new FormUpdateOrder(connectDB.sqlConnection)
                {
                    Owner = this
                };

                f.ShowDialog();

                Order refresh = new Order();
                await refresh.RefreshOrd(listViewOrd);

                Product refresh2 = new Product();
                await refresh2.RefreshProd(listViewProd);
            }
        }
        
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TableControl.SelectedTab == tabEmpl)
            {
                Employee refresh = new Employee();
                await refresh.RefreshEmp(listViewEmp);
            }
            else if(TableControl.SelectedTab == tabCust)
            {
                Customer refresh = new Customer();
                await refresh.RefreshCust(listViewCust);
            }
            else if(TableControl.SelectedTab == tabProv)
            {
                Provider refresh = new Provider();
                await refresh.RefreshProv(listViewProv);
            }
            else if(TableControl.SelectedTab == tabSuppl)
            {
                Supply refresh = new Supply();
                await refresh.RefreshSupp(listViewSuppl);
            }
            else if(TableControl.SelectedTab == tabProd)
            {
                Product refresh = new Product();
                await refresh.RefreshProd(listViewProd);
            }
            else if (TableControl.SelectedTab == tabOrd)
            {
                Order refresh = new Order();
                await refresh.RefreshOrd(listViewOrd);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (TableControl.SelectedTab == tabEmpl)
            {
                Employee del = new Employee();
                await del.DeleteEmp(listViewEmp);
            }
            else if (TableControl.SelectedTab == tabCust)
            {
                Customer del = new Customer();
                await del.DeleteCust(listViewCust);
            }
            else if (TableControl.SelectedTab == tabProv)
            {
                Provider del = new Provider();
                await del.DeleteProv(listViewProv);
            }
            else if(TableControl.SelectedTab == tabSuppl)
            {
                Supply del = new Supply();
                await del.DeleteSupp(listViewSuppl);
            }
            else if (TableControl.SelectedTab == tabProd)
            {
                Product del = new Product();
                await del.DeleteProd(listViewProd);
            }
            else if (TableControl.SelectedTab == tabOrd)
            {
                Order del = new Order();
                await del.DeleteOrd(listViewOrd);
            }
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (TableControl.SelectedTab == tabCust)
            {
                Functional.autoResizeColumns(listViewCust);
            }
            else if (TableControl.SelectedTab == tabEmpl)
            {
                Functional.autoResizeColumns(listViewEmp);
            }
            else if (TableControl.SelectedTab == tabProv)
            {
                Functional.autoResizeColumns(listViewProv);
            }
            else if (TableControl.SelectedTab == tabSuppl)
            {
                Functional.autoResizeColumns(listViewSuppl);
            }
            else if (TableControl.SelectedTab == tabProd)
            {
                Functional.autoResizeColumns(listViewProd);
            }
            else if (TableControl.SelectedTab == tabOrd)
            {
                Functional.autoResizeColumns(listViewOrd);
            }
        }

        private void listViewEmp_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader new_sorting_column = listViewEmp.Columns[e.Column];

            SortOrder sort_order;
            if (SortingColumn == null)
            {
                sort_order = SortOrder.Ascending;
            }
            else
            {
                if (new_sorting_column == SortingColumn)
                {
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    sort_order = SortOrder.Ascending;
                }
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            SortingColumn = new_sorting_column;

            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            listViewEmp.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);
            listViewEmp.Sort();
        }

        private void listViewCust_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader new_sorting_column = listViewCust.Columns[e.Column];

            SortOrder sort_order;
            if (SortingColumn == null)
            {
                sort_order = SortOrder.Ascending;
            }
            else
            {
                if (new_sorting_column == SortingColumn)
                {
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    sort_order = SortOrder.Ascending;
                }
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            SortingColumn = new_sorting_column;

            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            listViewCust.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);
            listViewCust.Sort();
        }

        private void listViewOrd_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader new_sorting_column = listViewOrd.Columns[e.Column];

            SortOrder sort_order;
            if (SortingColumn == null)
            {
                sort_order = SortOrder.Ascending;
            }
            else
            {
                if (new_sorting_column == SortingColumn)
                {
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    sort_order = SortOrder.Ascending;
                }
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            SortingColumn = new_sorting_column;

            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            listViewOrd.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);
            listViewOrd.Sort();
        }

        private void listViewProd_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader new_sorting_column = listViewProd.Columns[e.Column];

            SortOrder sort_order;
            if (SortingColumn == null)
            {
                sort_order = SortOrder.Ascending;
            }
            else
            {
                if (new_sorting_column == SortingColumn)
                {
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    sort_order = SortOrder.Ascending;
                }
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            SortingColumn = new_sorting_column;

            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            listViewProd.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);
            listViewProd.Sort();
        }

        private void listViewSuppl_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader new_sorting_column = listViewSuppl.Columns[e.Column];

            SortOrder sort_order;
            if (SortingColumn == null)
            {
                sort_order = SortOrder.Ascending;
            }
            else
            {
                if (new_sorting_column == SortingColumn)
                {
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    sort_order = SortOrder.Ascending;
                }
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            SortingColumn = new_sorting_column;

            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            listViewSuppl.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);
            listViewSuppl.Sort();
        }

        private void listViewProv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader new_sorting_column = listViewProv.Columns[e.Column];

            SortOrder sort_order;
            if (SortingColumn == null)
            {
                sort_order = SortOrder.Ascending;
            }
            else
            {
                if (new_sorting_column == SortingColumn)
                {
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    sort_order = SortOrder.Ascending;
                }
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            SortingColumn = new_sorting_column;

            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            listViewProv.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);
            listViewProv.Sort();
        }

        private void TextBoxPlaceHolder(Control control, string PlaceHolderText)
        {
            control.Text = PlaceHolderText;

            control.GotFocus += delegate (object sender, EventArgs args)
            {
                if (control.Text == PlaceHolderText)
                {
                    control.Text = "";
                }
            };

            control.LostFocus += delegate (object sender, EventArgs args)
            {
                if (control.Text.Length == 0)
                {
                    control.Text = PlaceHolderText;
                }
            };
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();

            TextBoxPlaceHolder(textBoxSearch, "Search...");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (TableControl.SelectedTab == tabEmpl)
            {
                Functional.SearchEmpl(textBoxSearch, listViewEmp);
            }
            else if (TableControl.SelectedTab == tabCust)
            {
                Functional.SearchCust(textBoxSearch, listViewCust);
            }
            else if (TableControl.SelectedTab == tabProv)
            {
                Functional.SearchProv(textBoxSearch, listViewProv);
            }
            else if (TableControl.SelectedTab == tabSuppl)
            {
                Functional.SearchSupp(textBoxSearch, listViewSuppl);
            }
            else if (TableControl.SelectedTab == tabProd)
            {
                Functional.SearchProd(textBoxSearch, listViewProd);
            }
            else if (TableControl.SelectedTab == tabOrd)
            {
                Functional.SearchOrd(textBoxSearch, listViewOrd);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (TableControl.SelectedTab == tabEmpl)
            {
                Functional.ExportToExcelEmployees(listViewEmp);
            }
            else if (TableControl.SelectedTab == tabCust)
            {
                Functional.ExportToExcelCustomers(listViewCust);
            }
            else if (TableControl.SelectedTab == tabProv)
            {
                Functional.ExportToExcelProviders(listViewProv);
            }
            else if (TableControl.SelectedTab == tabSuppl)
            {
                Functional.ExportToExcelSupplies(listViewSuppl);
            }
            else if (TableControl.SelectedTab == tabProd)
            {
                Functional.ExportToExcelProducts(listViewProd);
            }
            else if (TableControl.SelectedTab == tabOrd)
            {
                Functional.ExportToExcelOrders(listViewOrd);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Sport Shop Data Base Management System\n" +
            "Created by Alexey Efimov, group 208\n" +
            "Support: alexeyefimov15@gmail.com",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
    }
}