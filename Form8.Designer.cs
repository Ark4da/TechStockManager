namespace TechStockManager
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtFullName = new TextBox();
            btnClearCustomer = new Button();
            txtDeliveryAddress = new TextBox();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            btnUpdateCustomer = new Button();
            btnDeleteCustomer = new Button();
            btnAddCustomer = new Button();
            dataGridCustomers = new DataGridView();
            label1 = new Label();
            txtClientSearch = new TextBox();
            btnPrintCustomers = new Button();
            comboExportFormat5 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridCustomers).BeginInit();
            SuspendLayout();
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPhone.Location = new Point(173, 160);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 29);
            txtPhone.TabIndex = 83;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(173, 126);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 29);
            txtEmail.TabIndex = 82;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtFullName.Location = new Point(173, 91);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(100, 29);
            txtFullName.TabIndex = 81;
            // 
            // btnClearCustomer
            // 
            btnClearCustomer.FlatStyle = FlatStyle.Flat;
            btnClearCustomer.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearCustomer.Location = new Point(7, 236);
            btnClearCustomer.Name = "btnClearCustomer";
            btnClearCustomer.Size = new Size(118, 37);
            btnClearCustomer.TabIndex = 80;
            btnClearCustomer.Text = "Clear fields";
            btnClearCustomer.UseVisualStyleBackColor = true;
            // 
            // txtDeliveryAddress
            // 
            txtDeliveryAddress.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtDeliveryAddress.Location = new Point(173, 196);
            txtDeliveryAddress.Name = "txtDeliveryAddress";
            txtDeliveryAddress.Size = new Size(100, 29);
            txtDeliveryAddress.TabIndex = 79;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label24.Location = new Point(4, 196);
            label24.Name = "label24";
            label24.Size = new Size(170, 22);
            label24.TabIndex = 78;
            label24.Text = "Shipping address";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label25.Location = new Point(4, 160);
            label25.Name = "label25";
            label25.Size = new Size(67, 22);
            label25.TabIndex = 77;
            label25.Text = "Phone";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label26.Location = new Point(4, 129);
            label26.Name = "label26";
            label26.Size = new Size(61, 22);
            label26.TabIndex = 76;
            label26.Text = "Email";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label27.Location = new Point(4, 93);
            label27.Name = "label27";
            label27.Size = new Size(118, 22);
            label27.TabIndex = 75;
            label27.Text = "Store Name";
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.FlatStyle = FlatStyle.Flat;
            btnUpdateCustomer.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateCustomer.Location = new Point(176, 407);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(97, 36);
            btnUpdateCustomer.TabIndex = 74;
            btnUpdateCustomer.Text = "Edit";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.FlatStyle = FlatStyle.Flat;
            btnDeleteCustomer.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteCustomer.Location = new Point(88, 407);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(82, 36);
            btnDeleteCustomer.TabIndex = 73;
            btnDeleteCustomer.Text = "Delete";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddCustomer.Location = new Point(7, 407);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(75, 36);
            btnAddCustomer.TabIndex = 72;
            btnAddCustomer.Text = "Add";
            btnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // dataGridCustomers
            // 
            dataGridCustomers.AllowUserToAddRows = false;
            dataGridCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCustomers.Location = new Point(279, 51);
            dataGridCustomers.Name = "dataGridCustomers";
            dataGridCustomers.RowHeadersWidth = 51;
            dataGridCustomers.RowTemplate.Height = 25;
            dataGridCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridCustomers.Size = new Size(719, 392);
            dataGridCustomers.TabIndex = 71;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 9);
            label1.Name = "label1";
            label1.Size = new Size(127, 44);
            label1.TabIndex = 85;
            label1.Text = "Search by ID\r\nand title\r\n";
            // 
            // txtClientSearch
            // 
            txtClientSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtClientSearch.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientSearch.Location = new Point(163, 10);
            txtClientSearch.Multiline = true;
            txtClientSearch.Name = "txtClientSearch";
            txtClientSearch.Size = new Size(776, 33);
            txtClientSearch.TabIndex = 84;
            // 
            // btnPrintCustomers
            // 
            btnPrintCustomers.FlatStyle = FlatStyle.Flat;
            btnPrintCustomers.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrintCustomers.Location = new Point(7, 342);
            btnPrintCustomers.Name = "btnPrintCustomers";
            btnPrintCustomers.Size = new Size(75, 36);
            btnPrintCustomers.TabIndex = 86;
            btnPrintCustomers.Text = "Print";
            btnPrintCustomers.UseVisualStyleBackColor = true;
            // 
            // comboExportFormat5
            // 
            comboExportFormat5.FormattingEnabled = true;
            comboExportFormat5.Items.AddRange(new object[] { "PDF", "Excel" });
            comboExportFormat5.Location = new Point(88, 351);
            comboExportFormat5.Name = "comboExportFormat5";
            comboExportFormat5.Size = new Size(73, 23);
            comboExportFormat5.TabIndex = 87;
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 455);
            Controls.Add(comboExportFormat5);
            Controls.Add(btnPrintCustomers);
            Controls.Add(label1);
            Controls.Add(txtClientSearch);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(btnClearCustomer);
            Controls.Add(txtDeliveryAddress);
            Controls.Add(label24);
            Controls.Add(label25);
            Controls.Add(label26);
            Controls.Add(label27);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnAddCustomer);
            Controls.Add(dataGridCustomers);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1026, 494);
            Name = "Form8";
            Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)dataGridCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private Button btnClearCustomer;
        private TextBox txtDeliveryAddress;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Button btnUpdateCustomer;
        private Button btnDeleteCustomer;
        private Button btnAddCustomer;
        private DataGridView dataGridCustomers;
        private Label label1;
        private TextBox txtClientSearch;
        private Button btnPrintCustomers;
        private ComboBox comboExportFormat5;
    }
}