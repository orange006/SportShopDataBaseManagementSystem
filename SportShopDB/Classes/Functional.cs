using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SportShopDB
{
    static class Functional
    {
        public static void autoResizeColumns(ListView lv)
        {
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.ColumnHeaderCollection cc = lv.Columns;

            for (int i = 0; i < cc.Count; i++)
            {
                int colWidth = TextRenderer.MeasureText(cc[i].Text, lv.Font).Width + 10;

                if (colWidth > cc[i].Width)
                {
                    cc[i].Width = colWidth + 7;
                }
            }
        }

        public static async void SearchEmpl(TextBox tb, ListView lv)
        {
            ConnectToDB connect = new ConnectToDB();
            await connect.ConnectDB();

            if (!string.IsNullOrEmpty(tb.Text) && !string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb.Text == "Search...")
                {
                    MessageBox.Show(
                    "Field must be filled!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    SqlDataAdapter daName = new SqlDataAdapter();
                    DataTable dtName = new DataTable();

                    SqlDataAdapter daPos = new SqlDataAdapter();
                    DataTable dtPos = new DataTable();

                    SqlDataAdapter daPhoneNumber = new SqlDataAdapter();
                    DataTable dtPhoneNumber = new DataTable();

                    SqlDataAdapter daBirthday = new SqlDataAdapter();
                    DataTable dtBirthday = new DataTable();

                    try
                    {
                        SqlCommand command1 = new SqlCommand("Select * FROM Employees " +
                            "WHERE FullNameEmp LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daName = new SqlDataAdapter
                        {
                            SelectCommand = command1
                        };
                        dtName = new DataTable();
                        daName.Fill(dtName);

                        SqlCommand command2 = new SqlCommand("Select * FROM Employees " +
                            "WHERE Birthday LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daBirthday = new SqlDataAdapter
                        {
                            SelectCommand = command2
                        };
                        dtBirthday = new DataTable();
                        daBirthday.Fill(dtBirthday);

                        SqlCommand command3 = new SqlCommand("Select * FROM Employees " +
                            "WHERE Position LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daPos = new SqlDataAdapter
                        {
                            SelectCommand = command3
                        };
                        dtPos = new DataTable();
                        daPos.Fill(dtPos);

                        SqlCommand command4 = new SqlCommand("Select * FROM Employees " +
                            "WHERE PhoneNumberEmp LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daPhoneNumber = new SqlDataAdapter
                        {
                            SelectCommand = command4
                        };
                        dtPhoneNumber = new DataTable();
                        daPhoneNumber.Fill(dtPhoneNumber);

                        lv.Items.Clear();

                        foreach (DataRow r in dtName.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<string>(1));
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<string>(4));
                        }

                        foreach (DataRow r in dtPos.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<string>(1));
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<string>(4));
                        }

                        foreach (DataRow r in dtPhoneNumber.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<string>(1));
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<string>(4));
                        }

                        foreach (DataRow r in dtBirthday.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<string>(1));
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<string>(4));
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

                    daName.Dispose();
                    daPos.Dispose();
                    daPhoneNumber.Dispose();
                }
            }
            else
            {
                MessageBox.Show(
               "Field must be filled!!!",
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        public static async void SearchCust(TextBox tb, ListView lv)
        {
            ConnectToDB connect = new ConnectToDB();
            await connect.ConnectDB();

            if (!string.IsNullOrEmpty(tb.Text) && !string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb.Text == "Search...")
                {
                    MessageBox.Show(
                    "Field must be filled!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    SqlDataAdapter daName = new SqlDataAdapter();
                    DataTable dtName = new DataTable();

                    SqlDataAdapter daPhoneNumber = new SqlDataAdapter();
                    DataTable dtPhoneNumber = new DataTable();

                    try
                    {
                        SqlCommand command1 = new SqlCommand("Select * FROM Customers " +
                            "WHERE FullNameCust LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daName = new SqlDataAdapter
                        {
                            SelectCommand = command1
                        };
                        dtName = new DataTable();
                        daName.Fill(dtName);

                        SqlCommand command2 = new SqlCommand("Select * FROM Customers " +
                            "WHERE PhoneNumberCust LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daPhoneNumber = new SqlDataAdapter
                        {
                            SelectCommand = command2
                        };
                        dtPhoneNumber = new DataTable();
                        daPhoneNumber.Fill(dtPhoneNumber);

                        lv.Items.Clear();

                        foreach (DataRow r in dtName.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<string>(1));
                            list.SubItems.Add(r.Field<string>(2));
                        }

                        foreach (DataRow r in dtPhoneNumber.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<string>(1));
                            list.SubItems.Add(r.Field<string>(2));
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

                    daName.Dispose();
                    daPhoneNumber.Dispose();
                }
            }
            else
            {
                MessageBox.Show(
               "Field must be filled!!!",
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        public static async void SearchProv(TextBox tb, ListView lv)
        {
            ConnectToDB connect = new ConnectToDB();
            await connect.ConnectDB();

            if (!string.IsNullOrEmpty(tb.Text) && !string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb.Text == "Search...")
                {
                    MessageBox.Show(
                    "Field must be filled!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    SqlDataAdapter daName = new SqlDataAdapter();
                    DataTable dtName = new DataTable();

                    SqlDataAdapter daRepr = new SqlDataAdapter();
                    DataTable dtRepr = new DataTable();

                    SqlDataAdapter daPhoneNumber = new SqlDataAdapter();
                    DataTable dtPhoneNumber = new DataTable();

                    try
                    {
                        SqlCommand command1 = new SqlCommand("Select * FROM Providers " +
                            "WHERE NameProvider LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daName = new SqlDataAdapter
                        {
                            SelectCommand = command1
                        };
                        dtName = new DataTable();
                        daName.Fill(dtName);

                        SqlCommand command2 = new SqlCommand("Select * FROM Providers " +
                            "WHERE Representative LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daRepr = new SqlDataAdapter
                        {
                            SelectCommand = command2
                        };
                        dtRepr = new DataTable();
                        daRepr.Fill(dtRepr);

                        SqlCommand command3 = new SqlCommand("Select * FROM Providers " +
                            "WHERE PhoneNumberProv LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daPhoneNumber = new SqlDataAdapter
                        {
                            SelectCommand = command3
                        };
                        dtPhoneNumber = new DataTable();
                        daPhoneNumber.Fill(dtPhoneNumber);

                        lv.Items.Clear();

                        foreach (DataRow r in dtName.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<string>(1));
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                        }

                        foreach (DataRow r in dtRepr.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<string>(1));
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                        }

                        foreach (DataRow r in dtPhoneNumber.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<string>(1));
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
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

                    daName.Dispose();
                    daRepr.Dispose();
                    daPhoneNumber.Dispose();
                }
            }
            else
            {
                MessageBox.Show(
               "Field must be filled!!!",
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        public static async void SearchSupp(TextBox tb, ListView lv)
        {
            ConnectToDB connect = new ConnectToDB();
            await connect.ConnectDB();

            if (!string.IsNullOrEmpty(tb.Text) && !string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb.Text == "Search...")
                {
                    MessageBox.Show(
                    "Field must be filled!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    SqlDataAdapter daIdProv = new SqlDataAdapter();
                    DataTable dtIdProv = new DataTable();

                    SqlDataAdapter daDate = new SqlDataAdapter();
                    DataTable dtDate = new DataTable();

                    try
                    {
                        SqlCommand command1 = new SqlCommand("Select * FROM Supplies " +
                            "WHERE IdProv LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daIdProv = new SqlDataAdapter
                        {
                            SelectCommand = command1
                        };
                        dtIdProv = new DataTable();
                        daIdProv.Fill(dtIdProv);

                        SqlCommand command2 = new SqlCommand("Select * FROM Supplies " +
                            "WHERE dateSupply LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daDate = new SqlDataAdapter
                        {
                            SelectCommand = command2
                        };
                        dtDate = new DataTable();
                        daDate.Fill(dtDate);

                        lv.Items.Clear();

                        foreach (DataRow r in dtIdProv.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<string>(2));
                        }

                        foreach (DataRow r in dtDate.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<string>(2));
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

                    daIdProv.Dispose();
                }
            }
            else
            {
                MessageBox.Show(
               "Field must be filled!!!",
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        public static async void SearchProd(TextBox tb, ListView lv)
        {
            ConnectToDB connect = new ConnectToDB();
            await connect.ConnectDB();

            if (!string.IsNullOrEmpty(tb.Text) && !string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb.Text == "Search...")
                {
                    MessageBox.Show(
                    "Field must be filled!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    SqlDataAdapter daIdSuppl = new SqlDataAdapter();
                    DataTable dtIdSuppl = new DataTable();

                    SqlDataAdapter daNameProd = new SqlDataAdapter();
                    DataTable dtNameProd = new DataTable();

                    SqlDataAdapter daType = new SqlDataAdapter();
                    DataTable dtType = new DataTable();

                    SqlDataAdapter daCostP = new SqlDataAdapter();
                    DataTable dtCostP = new DataTable();

                    SqlDataAdapter daCostS = new SqlDataAdapter();
                    DataTable dtCostS = new DataTable();

                    SqlDataAdapter daQuantity = new SqlDataAdapter();
                    DataTable dtQuantity = new DataTable();

                    try
                    {
                        SqlCommand command1 = new SqlCommand("Select * FROM Products " +
                            "WHERE IdSupp LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daIdSuppl = new SqlDataAdapter
                        {
                            SelectCommand = command1
                        };
                        dtIdSuppl = new DataTable();
                        daIdSuppl.Fill(dtIdSuppl);

                        SqlCommand command2 = new SqlCommand("Select * FROM Products " +
                            "WHERE NameProduct LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daNameProd = new SqlDataAdapter
                        {
                            SelectCommand = command2
                        };
                        dtNameProd = new DataTable();
                        daNameProd.Fill(dtNameProd);

                        SqlCommand command3 = new SqlCommand("Select * FROM Products " +
                            "WHERE TypeProduct LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daType = new SqlDataAdapter
                        {
                            SelectCommand = command3
                        };
                        dtType = new DataTable();
                        daType.Fill(dtType);

                        SqlCommand command4 = new SqlCommand("Select * FROM Products " +
                            "WHERE CostPurchase LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daCostP = new SqlDataAdapter
                        {
                            SelectCommand = command4
                        };
                        dtCostP = new DataTable();
                        daCostP.Fill(dtCostP);

                        SqlCommand command5 = new SqlCommand("Select * FROM Products " +
                            "WHERE CostSale LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daCostS = new SqlDataAdapter
                        {
                            SelectCommand = command5
                        };
                        dtCostS = new DataTable();
                        daCostS.Fill(dtCostS);

                        SqlCommand command6 = new SqlCommand("Select * FROM Products " +
                            "WHERE Quantity LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daQuantity = new SqlDataAdapter
                        {
                            SelectCommand = command6
                        };
                        dtQuantity = new DataTable();
                        daQuantity.Fill(dtQuantity);

                        lv.Items.Clear();

                        foreach (DataRow r in dtIdSuppl.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<int>(4).ToString());
                            list.SubItems.Add(r.Field<int>(5).ToString());
                            list.SubItems.Add(r.Field<bool>(6).ToString());
                            list.SubItems.Add(r.Field<int>(7).ToString());
                        }

                        foreach (DataRow r in dtNameProd.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<int>(4).ToString());
                            list.SubItems.Add(r.Field<int>(5).ToString());
                            list.SubItems.Add(r.Field<bool>(6).ToString());
                            list.SubItems.Add(r.Field<int>(7).ToString());
                        }

                        foreach (DataRow r in dtType.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<int>(4).ToString());
                            list.SubItems.Add(r.Field<int>(5).ToString());
                            list.SubItems.Add(r.Field<bool>(6).ToString());
                            list.SubItems.Add(r.Field<int>(7).ToString());
                        }

                        foreach (DataRow r in dtCostP.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<int>(4).ToString());
                            list.SubItems.Add(r.Field<int>(5).ToString());
                            list.SubItems.Add(r.Field<bool>(6).ToString());
                            list.SubItems.Add(r.Field<int>(7).ToString());
                        }

                        foreach (DataRow r in dtCostS.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<int>(4).ToString());
                            list.SubItems.Add(r.Field<int>(5).ToString());
                            list.SubItems.Add(r.Field<bool>(6).ToString());
                            list.SubItems.Add(r.Field<int>(7).ToString());
                        }

                        foreach (DataRow r in dtQuantity.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<string>(2));
                            list.SubItems.Add(r.Field<string>(3));
                            list.SubItems.Add(r.Field<int>(4).ToString());
                            list.SubItems.Add(r.Field<int>(5).ToString());
                            list.SubItems.Add(r.Field<bool>(6).ToString());
                            list.SubItems.Add(r.Field<int>(7).ToString());
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

                    daIdSuppl.Dispose();
                    daNameProd.Dispose();
                    daType.Dispose();
                    daCostP.Dispose();
                    daCostS.Dispose();
                    daQuantity.Dispose();
                }
            }
            else
            {
                MessageBox.Show(
               "Field must be filled!!!",
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        public static async void SearchOrd(TextBox tb, ListView lv)
        {
            ConnectToDB connect = new ConnectToDB();
            await connect.ConnectDB();

            if (!string.IsNullOrEmpty(tb.Text) && !string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb.Text == "Search...")
                {
                    MessageBox.Show(
                    "Field must be filled!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    SqlDataAdapter daProd = new SqlDataAdapter();
                    DataTable dtProd = new DataTable();

                    SqlDataAdapter daEmp = new SqlDataAdapter();
                    DataTable dtEmp = new DataTable();

                    SqlDataAdapter daCust = new SqlDataAdapter();
                    DataTable dtCust = new DataTable();

                    SqlDataAdapter daDate = new SqlDataAdapter();
                    DataTable dtDate = new DataTable();

                    try
                    {
                        SqlCommand command1 = new SqlCommand("Select * FROM Orders " +
                            "WHERE IdProd LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daProd = new SqlDataAdapter
                        {
                            SelectCommand = command1
                        };
                        dtProd = new DataTable();
                        daProd.Fill(dtProd);

                        SqlCommand command2 = new SqlCommand("Select * FROM Orders " +
                            "WHERE IdEmpl LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daEmp = new SqlDataAdapter
                        {
                            SelectCommand = command2
                        };
                        dtEmp = new DataTable();
                        daEmp.Fill(dtEmp);

                        SqlCommand command3 = new SqlCommand("Select * FROM Orders " +
                            "WHERE IdCust LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daCust = new SqlDataAdapter
                        {
                            SelectCommand = command3
                        };
                        dtCust = new DataTable();
                        daCust.Fill(dtCust);

                        SqlCommand command4 = new SqlCommand("Select * FROM Orders " +
                            "WHERE DateOrder LIKE '%" + tb.Text + "%'", connect.sqlConnection);

                        daDate = new SqlDataAdapter
                        {
                            SelectCommand = command4
                        };
                        dtDate = new DataTable();
                        daDate.Fill(dtDate);

                        lv.Items.Clear();

                        foreach (DataRow r in dtProd.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<int>(2).ToString());
                            list.SubItems.Add(r.Field<int>(3).ToString());
                            list.SubItems.Add(r.Field<string>(4));
                        }

                        foreach (DataRow r in dtEmp.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<int>(2).ToString());
                            list.SubItems.Add(r.Field<int>(3).ToString());
                            list.SubItems.Add(r.Field<string>(4));
                        }

                        foreach (DataRow r in dtCust.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<int>(2).ToString());
                            list.SubItems.Add(r.Field<int>(3).ToString());
                            list.SubItems.Add(r.Field<string>(4));
                        }

                        foreach (DataRow r in dtDate.Rows)
                        {
                            var list = lv.Items.Add(r.Field<int>(0).ToString());
                            list.SubItems.Add(r.Field<int>(1).ToString());
                            list.SubItems.Add(r.Field<int>(2).ToString());
                            list.SubItems.Add(r.Field<int>(3).ToString());
                            list.SubItems.Add(r.Field<string>(4));
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

                    daProd.Dispose();
                    daEmp.Dispose();
                    daCust.Dispose();
                    daDate.Dispose();
                }
            }
            else
            {
                MessageBox.Show(
               "Field must be filled!!!",
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        public static void ExportToExcelEmployees(ListView lv)
        {
            try
            {
                var ExcelApp = new Excel.Application
                {
                    Visible = true
                };

                var wb = ExcelApp.Workbooks.Add(1);
                var ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "ID";
                ws.Cells[1, 2] = "Full Name";
                ws.Cells[1, 3] = "Position";
                ws.Cells[1, 4] = "Birthday";
                ws.Cells[1, 5] = "Phone Number";

                int Columns = 1;
                int Rows = 2;

                foreach (ListViewItem lvi in lv.Items)
                {
                    Columns = 1;

                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[Rows, Columns] = lvs.Text;
                        Columns++;
                    }
                    Rows++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportToExcelCustomers(ListView lv)
        {
            try
            {
                var ExcelApp = new Excel.Application
                {
                    Visible = true
                };

                var wb = ExcelApp.Workbooks.Add(1);
                var ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "ID";
                ws.Cells[1, 2] = "Full Name";
                ws.Cells[1, 3] = "Phone Number";

                int Columns = 1;
                int Rows = 2;

                foreach (ListViewItem lvi in lv.Items)
                {
                    Columns = 1;

                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[Rows, Columns] = lvs.Text;
                        Columns++;
                    }
                    Rows++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportToExcelProviders(ListView lv)
        {
            try
            {
                var ExcelApp = new Excel.Application
                {
                    Visible = true
                };

                var wb = ExcelApp.Workbooks.Add(1);
                var ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "ID";
                ws.Cells[1, 2] = "Name";
                ws.Cells[1, 3] = "Representative";
                ws.Cells[1, 4] = "Phone Number";

                int Columns = 1;
                int Rows = 2;

                foreach (ListViewItem lvi in lv.Items)
                {
                    Columns = 1;

                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[Rows, Columns] = lvs.Text;
                        Columns++;
                    }
                    Rows++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportToExcelSupplies(ListView lv)
        {
            try
            {
                var ExcelApp = new Excel.Application
                {
                    Visible = true
                };

                var wb = ExcelApp.Workbooks.Add(1);
                var ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "ID";
                ws.Cells[1, 2] = "Id Provider";
                ws.Cells[1, 3] = "Date Supply";

                int Columns = 1;
                int Rows = 2;

                foreach (ListViewItem lvi in lv.Items)
                {
                    Columns = 1;

                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[Rows, Columns] = lvs.Text;
                        Columns++;
                    }
                    Rows++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportToExcelProducts(ListView lv)
        {
            try
            {
                var ExcelApp = new Excel.Application
                {
                    Visible = true
                };

                var wb = ExcelApp.Workbooks.Add(1);
                var ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "ID";
                ws.Cells[1, 2] = "Id Supply";
                ws.Cells[1, 3] = "Name";
                ws.Cells[1, 4] = "Type";
                ws.Cells[1, 5] = "Cost Purchase";
                ws.Cells[1, 6] = "Cost Sale";
                ws.Cells[1, 7] = "Availability";
                ws.Cells[1, 8] = "Quantity";

                int Columns = 1;
                int Rows = 2;

                foreach (ListViewItem lvi in lv.Items)
                {
                    Columns = 1;

                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[Rows, Columns] = lvs.Text;
                        Columns++;
                    }
                    Rows++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportToExcelOrders(ListView lv)
        {
            try
            {
                var ExcelApp = new Excel.Application
                {
                    Visible = true
                };

                var wb = ExcelApp.Workbooks.Add(1);
                var ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "ID";
                ws.Cells[1, 2] = "Id Product";
                ws.Cells[1, 3] = "Id Employee";
                ws.Cells[1, 4] = "Id Customer";
                ws.Cells[1, 5] = "Date Order";

                int Columns = 1;
                int Rows = 2;

                foreach (ListViewItem lvi in lv.Items)
                {
                    Columns = 1;

                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[Rows, Columns] = lvs.Text;
                        Columns++;
                    }
                    Rows++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}