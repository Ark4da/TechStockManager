namespace TechStockManager
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            txtProductManufacturerId = new TextBox();
            txtProductCategoryId = new TextBox();
            txtProductName = new TextBox();
            txtProductDescription = new TextBox();
            txtProductStock = new TextBox();
            label15 = new Label();
            label14 = new Label();
            btnClearProduct = new Button();
            txtProductPrice = new TextBox();
            label6 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            btnUpdateProduct = new Button();
            btnDeleteProduct = new Button();
            btnAddProduct = new Button();
            dataGridProduct = new DataGridView();
            label1 = new Label();
            txtProductSearch = new TextBox();
            btnPrintProduct = new Button();
            comboExportFormat2 = new ComboBox();
            btnAddStock = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridProduct).BeginInit();
            SuspendLayout();
            // 
            // txtProductManufacturerId
            // 
            txtProductManufacturerId.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductManufacturerId.Location = new Point(220, 139);
            txtProductManufacturerId.Multiline = true;
            txtProductManufacturerId.Name = "txtProductManufacturerId";
            txtProductManufacturerId.Size = new Size(100, 29);
            txtProductManufacturerId.TabIndex = 70;
            // 
            // txtProductCategoryId
            // 
            txtProductCategoryId.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductCategoryId.Location = new Point(220, 104);
            txtProductCategoryId.Multiline = true;
            txtProductCategoryId.Name = "txtProductCategoryId";
            txtProductCategoryId.Size = new Size(100, 29);
            txtProductCategoryId.TabIndex = 69;
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductName.Location = new Point(220, 65);
            txtProductName.Multiline = true;
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(100, 29);
            txtProductName.TabIndex = 68;
            // 
            // txtProductDescription
            // 
            txtProductDescription.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductDescription.Location = new Point(220, 241);
            txtProductDescription.Multiline = true;
            txtProductDescription.Name = "txtProductDescription";
            txtProductDescription.Size = new Size(100, 29);
            txtProductDescription.TabIndex = 67;
            // 
            // txtProductStock
            // 
            txtProductStock.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductStock.Location = new Point(220, 207);
            txtProductStock.Multiline = true;
            txtProductStock.Name = "txtProductStock";
            txtProductStock.Size = new Size(100, 29);
            txtProductStock.TabIndex = 66;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(5, 248);
            label15.Name = "label15";
            label15.Size = new Size(115, 22);
            label15.TabIndex = 65;
            label15.Text = "Description";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(2, 212);
            label14.Name = "label14";
            label14.Size = new Size(163, 22);
            label14.TabIndex = 64;
            label14.Text = "Quantity in stock";
            // 
            // btnClearProduct
            // 
            btnClearProduct.FlatStyle = FlatStyle.Flat;
            btnClearProduct.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearProduct.Location = new Point(12, 284);
            btnClearProduct.Name = "btnClearProduct";
            btnClearProduct.Size = new Size(118, 35);
            btnClearProduct.TabIndex = 63;
            btnClearProduct.Text = "Clear fields";
            btnClearProduct.UseVisualStyleBackColor = true;
            // 
            // txtProductPrice
            // 
            txtProductPrice.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductPrice.Location = new Point(220, 172);
            txtProductPrice.Multiline = true;
            txtProductPrice.Name = "txtProductPrice";
            txtProductPrice.Size = new Size(100, 29);
            txtProductPrice.TabIndex = 62;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(5, 175);
            label6.Name = "label6";
            label6.Size = new Size(58, 22);
            label6.TabIndex = 61;
            label6.Text = "Price";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(5, 142);
            label11.Name = "label11";
            label11.Size = new Size(157, 22);
            label11.TabIndex = 60;
            label11.Text = "Manufacturer ID";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(5, 109);
            label12.Name = "label12";
            label12.Size = new Size(119, 22);
            label12.TabIndex = 59;
            label12.Text = "Category ID";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(5, 72);
            label13.Name = "label13";
            label13.Size = new Size(50, 22);
            label13.TabIndex = 58;
            label13.Text = "Title";
            // 
            // btnUpdateProduct
            // 
            btnUpdateProduct.FlatStyle = FlatStyle.Flat;
            btnUpdateProduct.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateProduct.Location = new Point(184, 401);
            btnUpdateProduct.Name = "btnUpdateProduct";
            btnUpdateProduct.Size = new Size(122, 38);
            btnUpdateProduct.TabIndex = 57;
            btnUpdateProduct.Text = "Edit";
            btnUpdateProduct.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.FlatStyle = FlatStyle.Flat;
            btnDeleteProduct.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteProduct.Location = new Point(93, 401);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(85, 38);
            btnDeleteProduct.TabIndex = 56;
            btnDeleteProduct.Text = "Delete";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            // 
            // btnAddProduct
            // 
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddProduct.Location = new Point(12, 401);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(75, 38);
            btnAddProduct.TabIndex = 55;
            btnAddProduct.Text = "Add";
            btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // dataGridProduct
            // 
            dataGridProduct.AllowUserToAddRows = false;
            dataGridProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProduct.Location = new Point(326, 47);
            dataGridProduct.Name = "dataGridProduct";
            dataGridProduct.RowHeadersWidth = 51;
            dataGridProduct.RowTemplate.Height = 25;
            dataGridProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProduct.Size = new Size(719, 392);
            dataGridProduct.TabIndex = 54;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 11);
            label1.Name = "label1";
            label1.Size = new Size(142, 22);
            label1.TabIndex = 72;
            label1.Text = "Search by title";
            // 
            // txtProductSearch
            // 
            txtProductSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProductSearch.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductSearch.Location = new Point(166, 8);
            txtProductSearch.Multiline = true;
            txtProductSearch.Name = "txtProductSearch";
            txtProductSearch.Size = new Size(776, 33);
            txtProductSearch.TabIndex = 71;
            // 
            // btnPrintProduct
            // 
            btnPrintProduct.FlatStyle = FlatStyle.Flat;
            btnPrintProduct.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrintProduct.Location = new Point(12, 328);
            btnPrintProduct.Name = "btnPrintProduct";
            btnPrintProduct.Size = new Size(75, 50);
            btnPrintProduct.TabIndex = 73;
            btnPrintProduct.Text = "Print";
            btnPrintProduct.UseVisualStyleBackColor = true;
            // 
            // comboExportFormat2
            // 
            comboExportFormat2.FormattingEnabled = true;
            comboExportFormat2.Items.AddRange(new object[] { "PDF", "Excel" });
            comboExportFormat2.Location = new Point(93, 350);
            comboExportFormat2.Name = "comboExportFormat2";
            comboExportFormat2.Size = new Size(73, 23);
            comboExportFormat2.TabIndex = 74;
            // 
            // btnAddStock
            // 
            btnAddStock.FlatStyle = FlatStyle.Flat;
            btnAddStock.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddStock.Location = new Point(184, 328);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(122, 50);
            btnAddStock.TabIndex = 75;
            btnAddStock.Text = "Roster Update";
            btnAddStock.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 442);
            Controls.Add(btnAddStock);
            Controls.Add(comboExportFormat2);
            Controls.Add(btnPrintProduct);
            Controls.Add(label1);
            Controls.Add(txtProductSearch);
            Controls.Add(txtProductManufacturerId);
            Controls.Add(txtProductCategoryId);
            Controls.Add(txtProductName);
            Controls.Add(txtProductDescription);
            Controls.Add(txtProductStock);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(btnClearProduct);
            Controls.Add(txtProductPrice);
            Controls.Add(label6);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(btnUpdateProduct);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnAddProduct);
            Controls.Add(dataGridProduct);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1064, 481);
            Name = "Form5";
            Text = "Product";
            ((System.ComponentModel.ISupportInitialize)dataGridProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProductManufacturerId;
        private TextBox txtProductCategoryId;
        private TextBox txtProductName;
        private TextBox txtProductDescription;
        private TextBox txtProductStock;
        private Label label15;
        private Label label14;
        private Button btnClearProduct;
        private TextBox txtProductPrice;
        private Label label6;
        private Label label11;
        private Label label12;
        private Label label13;
        private Button btnUpdateProduct;
        private Button btnDeleteProduct;
        private Button btnAddProduct;
        private DataGridView dataGridProduct;
        private Label label1;
        private TextBox txtProductSearch;
        private Button btnPrintProduct;
        private ComboBox comboExportFormat2;
        private Button btnAddStock;
    }
}