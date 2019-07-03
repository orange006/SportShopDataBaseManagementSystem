namespace SportShopDB
{
    partial class FormInsertOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerOrd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxIdProd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIdEmp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIdCust = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePickerOrd
            // 
            this.dateTimePickerOrd.Location = new System.Drawing.Point(146, 156);
            this.dateTimePickerOrd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerOrd.Name = "dateTimePickerOrd";
            this.dateTimePickerOrd.Size = new System.Drawing.Size(228, 20);
            this.dateTimePickerOrd.TabIndex = 40;
            this.dateTimePickerOrd.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Date";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(222, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(98, 195);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBoxIdProd
            // 
            this.textBoxIdProd.Location = new System.Drawing.Point(144, 28);
            this.textBoxIdProd.Name = "textBoxIdProd";
            this.textBoxIdProd.Size = new System.Drawing.Size(228, 20);
            this.textBoxIdProd.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Id Product";
            // 
            // textBoxIdEmp
            // 
            this.textBoxIdEmp.Location = new System.Drawing.Point(144, 70);
            this.textBoxIdEmp.Name = "textBoxIdEmp";
            this.textBoxIdEmp.Size = new System.Drawing.Size(228, 20);
            this.textBoxIdEmp.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Id Employee";
            // 
            // textBoxIdCust
            // 
            this.textBoxIdCust.Location = new System.Drawing.Point(144, 115);
            this.textBoxIdCust.Name = "textBoxIdCust";
            this.textBoxIdCust.Size = new System.Drawing.Size(228, 20);
            this.textBoxIdCust.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Id Customer";
            // 
            // FormInsertOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 242);
            this.Controls.Add(this.textBoxIdCust);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxIdEmp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerOrd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxIdProd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInsertOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerOrd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBoxIdProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIdEmp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIdCust;
        private System.Windows.Forms.Label label4;
    }
}