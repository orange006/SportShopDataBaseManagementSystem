namespace SportShopDB
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.panelMove = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TableControl = new System.Windows.Forms.TabControl();
            this.tabEmpl = new System.Windows.Forms.TabPage();
            this.listViewEmp = new System.Windows.Forms.ListView();
            this.tabCust = new System.Windows.Forms.TabPage();
            this.listViewCust = new System.Windows.Forms.ListView();
            this.tabOrd = new System.Windows.Forms.TabPage();
            this.listViewOrd = new System.Windows.Forms.ListView();
            this.tabProd = new System.Windows.Forms.TabPage();
            this.listViewProd = new System.Windows.Forms.ListView();
            this.tabSuppl = new System.Windows.Forms.TabPage();
            this.listViewSuppl = new System.Windows.Forms.ListView();
            this.tabProv = new System.Windows.Forms.TabPage();
            this.listViewProv = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.TableControl.SuspendLayout();
            this.tabEmpl.SuspendLayout();
            this.tabCust.SuspendLayout();
            this.tabOrd.SuspendLayout();
            this.tabProd.SuspendLayout();
            this.tabSuppl.SuspendLayout();
            this.tabProv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnAbout);
            this.panel1.Controls.Add(this.btnResize);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 520);
            this.panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(27, 303);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(147, 40);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "  Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAbout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.Location = new System.Drawing.Point(27, 362);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(147, 40);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "  About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnResize
            // 
            this.btnResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnResize.FlatAppearance.BorderSize = 0;
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResize.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnResize.Image = ((System.Drawing.Image)(resources.GetObject("btnResize.Image")));
            this.btnResize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResize.Location = new System.Drawing.Point(27, 79);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(147, 40);
            this.btnResize.TabIndex = 3;
            this.btnResize.Text = "  Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(27, 246);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(147, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "   Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(27, 190);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(147, 40);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "   Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInsert.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.Image")));
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.Location = new System.Drawing.Point(27, 132);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(147, 40);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "  Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // panelMove
            // 
            this.panelMove.BackColor = System.Drawing.Color.DarkRed;
            this.panelMove.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMove.Location = new System.Drawing.Point(194, 0);
            this.panelMove.Name = "panelMove";
            this.panelMove.Size = new System.Drawing.Size(739, 25);
            this.panelMove.TabIndex = 1;
            this.panelMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMove_MouseDown);
            this.panelMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMove_MouseMove);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(894, 33);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(31, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(853, 33);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(31, 29);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(235, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Short Shop Data Base Management System";
            // 
            // TableControl
            // 
            this.TableControl.Controls.Add(this.tabEmpl);
            this.TableControl.Controls.Add(this.tabCust);
            this.TableControl.Controls.Add(this.tabOrd);
            this.TableControl.Controls.Add(this.tabProd);
            this.TableControl.Controls.Add(this.tabSuppl);
            this.TableControl.Controls.Add(this.tabProv);
            this.TableControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableControl.Location = new System.Drawing.Point(194, 152);
            this.TableControl.Name = "TableControl";
            this.TableControl.SelectedIndex = 0;
            this.TableControl.Size = new System.Drawing.Size(739, 368);
            this.TableControl.TabIndex = 5;
            // 
            // tabEmpl
            // 
            this.tabEmpl.Controls.Add(this.listViewEmp);
            this.tabEmpl.Location = new System.Drawing.Point(4, 22);
            this.tabEmpl.Name = "tabEmpl";
            this.tabEmpl.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmpl.Size = new System.Drawing.Size(731, 342);
            this.tabEmpl.TabIndex = 0;
            this.tabEmpl.Text = "Employees";
            this.tabEmpl.UseVisualStyleBackColor = true;
            // 
            // listViewEmp
            // 
            this.listViewEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEmp.Location = new System.Drawing.Point(3, 3);
            this.listViewEmp.Name = "listViewEmp";
            this.listViewEmp.Size = new System.Drawing.Size(725, 336);
            this.listViewEmp.TabIndex = 0;
            this.listViewEmp.UseCompatibleStateImageBehavior = false;
            this.listViewEmp.View = System.Windows.Forms.View.Details;
            this.listViewEmp.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewEmp_ColumnClick);
            // 
            // tabCust
            // 
            this.tabCust.Controls.Add(this.listViewCust);
            this.tabCust.Location = new System.Drawing.Point(4, 22);
            this.tabCust.Name = "tabCust";
            this.tabCust.Padding = new System.Windows.Forms.Padding(3);
            this.tabCust.Size = new System.Drawing.Size(731, 342);
            this.tabCust.TabIndex = 1;
            this.tabCust.Text = "Customers";
            this.tabCust.UseVisualStyleBackColor = true;
            // 
            // listViewCust
            // 
            this.listViewCust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCust.Location = new System.Drawing.Point(3, 3);
            this.listViewCust.Name = "listViewCust";
            this.listViewCust.Size = new System.Drawing.Size(725, 336);
            this.listViewCust.TabIndex = 0;
            this.listViewCust.UseCompatibleStateImageBehavior = false;
            this.listViewCust.View = System.Windows.Forms.View.Details;
            this.listViewCust.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewCust_ColumnClick);
            // 
            // tabOrd
            // 
            this.tabOrd.Controls.Add(this.listViewOrd);
            this.tabOrd.Location = new System.Drawing.Point(4, 22);
            this.tabOrd.Name = "tabOrd";
            this.tabOrd.Size = new System.Drawing.Size(731, 342);
            this.tabOrd.TabIndex = 2;
            this.tabOrd.Text = "Orders";
            this.tabOrd.UseVisualStyleBackColor = true;
            // 
            // listViewOrd
            // 
            this.listViewOrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOrd.Location = new System.Drawing.Point(0, 0);
            this.listViewOrd.Name = "listViewOrd";
            this.listViewOrd.Size = new System.Drawing.Size(731, 342);
            this.listViewOrd.TabIndex = 0;
            this.listViewOrd.UseCompatibleStateImageBehavior = false;
            this.listViewOrd.View = System.Windows.Forms.View.Details;
            this.listViewOrd.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewOrd_ColumnClick);
            // 
            // tabProd
            // 
            this.tabProd.Controls.Add(this.listViewProd);
            this.tabProd.Location = new System.Drawing.Point(4, 22);
            this.tabProd.Name = "tabProd";
            this.tabProd.Size = new System.Drawing.Size(731, 342);
            this.tabProd.TabIndex = 3;
            this.tabProd.Text = "Products";
            this.tabProd.UseVisualStyleBackColor = true;
            // 
            // listViewProd
            // 
            this.listViewProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProd.Location = new System.Drawing.Point(0, 0);
            this.listViewProd.Name = "listViewProd";
            this.listViewProd.Size = new System.Drawing.Size(731, 342);
            this.listViewProd.TabIndex = 0;
            this.listViewProd.UseCompatibleStateImageBehavior = false;
            this.listViewProd.View = System.Windows.Forms.View.Details;
            this.listViewProd.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewProd_ColumnClick);
            // 
            // tabSuppl
            // 
            this.tabSuppl.Controls.Add(this.listViewSuppl);
            this.tabSuppl.Location = new System.Drawing.Point(4, 22);
            this.tabSuppl.Name = "tabSuppl";
            this.tabSuppl.Size = new System.Drawing.Size(731, 342);
            this.tabSuppl.TabIndex = 4;
            this.tabSuppl.Text = "Supplies";
            this.tabSuppl.UseVisualStyleBackColor = true;
            // 
            // listViewSuppl
            // 
            this.listViewSuppl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSuppl.Location = new System.Drawing.Point(0, 0);
            this.listViewSuppl.Name = "listViewSuppl";
            this.listViewSuppl.Size = new System.Drawing.Size(731, 342);
            this.listViewSuppl.TabIndex = 0;
            this.listViewSuppl.UseCompatibleStateImageBehavior = false;
            this.listViewSuppl.View = System.Windows.Forms.View.Details;
            this.listViewSuppl.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewSuppl_ColumnClick);
            // 
            // tabProv
            // 
            this.tabProv.Controls.Add(this.listViewProv);
            this.tabProv.Location = new System.Drawing.Point(4, 22);
            this.tabProv.Name = "tabProv";
            this.tabProv.Size = new System.Drawing.Size(731, 342);
            this.tabProv.TabIndex = 5;
            this.tabProv.Text = "Providers";
            this.tabProv.UseVisualStyleBackColor = true;
            // 
            // listViewProv
            // 
            this.listViewProv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProv.Location = new System.Drawing.Point(0, 0);
            this.listViewProv.Name = "listViewProv";
            this.listViewProv.Size = new System.Drawing.Size(731, 342);
            this.listViewProv.TabIndex = 0;
            this.listViewProv.UseCompatibleStateImageBehavior = false;
            this.listViewProv.View = System.Windows.Forms.View.Details;
            this.listViewProv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewProv_ColumnClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(239, 102);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(31, 29);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxSearch.Location = new System.Drawing.Point(320, 111);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(205, 20);
            this.textBoxSearch.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(536, 109);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(627, 109);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 520);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.TableControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panelMove);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.TableControl.ResumeLayout(false);
            this.tabEmpl.ResumeLayout(false);
            this.tabCust.ResumeLayout(false);
            this.tabOrd.ResumeLayout(false);
            this.tabProd.ResumeLayout(false);
            this.tabSuppl.ResumeLayout(false);
            this.tabProv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMove;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl TableControl;
        private System.Windows.Forms.TabPage tabEmpl;
        private System.Windows.Forms.TabPage tabCust;
        private System.Windows.Forms.TabPage tabOrd;
        private System.Windows.Forms.TabPage tabProd;
        private System.Windows.Forms.TabPage tabSuppl;
        private System.Windows.Forms.TabPage tabProv;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.ListView listViewEmp;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.ListView listViewCust;
        public System.Windows.Forms.ListView listViewOrd;
        public System.Windows.Forms.ListView listViewProd;
        public System.Windows.Forms.ListView listViewSuppl;
        public System.Windows.Forms.ListView listViewProv;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAbout;
    }
}

