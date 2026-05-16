namespace TechStockManager
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            txtProductId = new TextBox();
            btnClearOrderDetail = new Button();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            txtOrderId = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            btnUpdateOrderDetail = new Button();
            btnDeleteOrderDetail = new Button();
            btnAddOrderDetail = new Button();
            dataGridViewOrderDetails = new DataGridView();
            label6 = new Label();
            txtOrderDetailsSearch = new TextBox();
            btnPrintOrderDetail = new Button();
            comboExportFormat1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderDetails).BeginInit();
            SuspendLayout();
            // 
            // txtProductId
            // 
            txtProductId.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductId.Location = new Point(241, 112);
            txtProductId.Multiline = true;
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(100, 30);
            txtProductId.TabIndex = 43;
            // 
            // btnClearOrderDetail
            // 
            btnClearOrderDetail.FlatStyle = FlatStyle.Flat;
            btnClearOrderDetail.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearOrderDetail.Location = new Point(12, 224);
            btnClearOrderDetail.Name = "btnClearOrderDetail";
            btnClearOrderDetail.Size = new Size(118, 27);
            btnClearOrderDetail.TabIndex = 42;
            btnClearOrderDetail.Text = "Clear fields";
            btnClearOrderDetail.UseVisualStyleBackColor = true;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPrice.Location = new Point(241, 179);
            txtPrice.Multiline = true;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 30);
            txtPrice.TabIndex = 41;
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtQuantity.Location = new Point(241, 146);
            txtQuantity.Multiline = true;
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 30);
            txtQuantity.TabIndex = 40;
            // 
            // txtOrderId
            // 
            txtOrderId.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderId.Location = new Point(241, 76);
            txtOrderId.Multiline = true;
            txtOrderId.Name = "txtOrderId";
            txtOrderId.Size = new Size(100, 30);
            txtOrderId.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(14, 187);
            label7.Name = "label7";
            label7.Size = new Size(58, 22);
            label7.TabIndex = 38;
            label7.Text = "Price";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(14, 156);
            label8.Name = "label8";
            label8.Size = new Size(87, 22);
            label8.TabIndex = 37;
            label8.Text = "Quantity";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(14, 120);
            label9.Name = "label9";
            label9.Size = new Size(108, 22);
            label9.TabIndex = 36;
            label9.Text = "Product ID";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(14, 84);
            label10.Name = "label10";
            label10.Size = new Size(89, 22);
            label10.TabIndex = 35;
            label10.Text = "Order ID\t";
            // 
            // btnUpdateOrderDetail
            // 
            btnUpdateOrderDetail.FlatStyle = FlatStyle.Flat;
            btnUpdateOrderDetail.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateOrderDetail.Location = new Point(188, 396);
            btnUpdateOrderDetail.Name = "btnUpdateOrderDetail";
            btnUpdateOrderDetail.Size = new Size(96, 32);
            btnUpdateOrderDetail.TabIndex = 34;
            btnUpdateOrderDetail.Text = "Edit";
            btnUpdateOrderDetail.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOrderDetail
            // 
            btnDeleteOrderDetail.FlatStyle = FlatStyle.Flat;
            btnDeleteOrderDetail.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteOrderDetail.Location = new Point(93, 396);
            btnDeleteOrderDetail.Name = "btnDeleteOrderDetail";
            btnDeleteOrderDetail.Size = new Size(89, 32);
            btnDeleteOrderDetail.TabIndex = 33;
            btnDeleteOrderDetail.Text = "Delete";
            btnDeleteOrderDetail.UseVisualStyleBackColor = true;
            // 
            // btnAddOrderDetail
            // 
            btnAddOrderDetail.FlatStyle = FlatStyle.Flat;
            btnAddOrderDetail.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddOrderDetail.Location = new Point(12, 396);
            btnAddOrderDetail.Name = "btnAddOrderDetail";
            btnAddOrderDetail.Size = new Size(75, 32);
            btnAddOrderDetail.TabIndex = 32;
            btnAddOrderDetail.Text = "Add";
            btnAddOrderDetail.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOrderDetails
            // 
            dataGridViewOrderDetails.AllowUserToAddRows = false;
            dataGridViewOrderDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrderDetails.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrderDetails.Location = new Point(347, 42);
            dataGridViewOrderDetails.MinimumSize = new Size(661, 392);
            dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            dataGridViewOrderDetails.RowHeadersWidth = 51;
            dataGridViewOrderDetails.RowTemplate.Height = 25;
            dataGridViewOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrderDetails.Size = new Size(661, 392);
            dataGridViewOrderDetails.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 9);
            label6.Name = "label6";
            label6.Size = new Size(127, 22);
            label6.TabIndex = 45;
            label6.Text = "Search by ID";
            // 
            // txtOrderDetailsSearch
            // 
            txtOrderDetailsSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOrderDetailsSearch.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderDetailsSearch.Location = new Point(126, 3);
            txtOrderDetailsSearch.Multiline = true;
            txtOrderDetailsSearch.Name = "txtOrderDetailsSearch";
            txtOrderDetailsSearch.Size = new Size(776, 33);
            txtOrderDetailsSearch.TabIndex = 44;
            // 
            // btnPrintOrderDetail
            // 
            btnPrintOrderDetail.FlatStyle = FlatStyle.Flat;
            btnPrintOrderDetail.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrintOrderDetail.Location = new Point(12, 322);
            btnPrintOrderDetail.Name = "btnPrintOrderDetail";
            btnPrintOrderDetail.Size = new Size(75, 32);
            btnPrintOrderDetail.TabIndex = 46;
            btnPrintOrderDetail.Text = "Print";
            btnPrintOrderDetail.UseVisualStyleBackColor = true;
            // 
            // comboExportFormat1
            // 
            comboExportFormat1.FormattingEnabled = true;
            comboExportFormat1.Items.AddRange(new object[] { "PDF", "Excel" });
            comboExportFormat1.Location = new Point(93, 329);
            comboExportFormat1.Name = "comboExportFormat1";
            comboExportFormat1.Size = new Size(73, 23);
            comboExportFormat1.TabIndex = 47;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 440);
            Controls.Add(comboExportFormat1);
            Controls.Add(btnPrintOrderDetail);
            Controls.Add(label6);
            Controls.Add(txtOrderDetailsSearch);
            Controls.Add(txtProductId);
            Controls.Add(btnClearOrderDetail);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(txtOrderId);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(btnUpdateOrderDetail);
            Controls.Add(btnDeleteOrderDetail);
            Controls.Add(btnAddOrderDetail);
            Controls.Add(dataGridViewOrderDetails);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form4";
            Text = "Order Details";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProductId;
        private Button btnClearOrderDetail;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtOrderId;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnUpdateOrderDetail;
        private Button btnDeleteOrderDetail;
        private Button btnAddOrderDetail;
        private DataGridView dataGridViewOrderDetails;
        private Label label6;
        private TextBox txtOrderDetailsSearch;
        private Button btnPrintOrderDetail;
        private ComboBox comboExportFormat1;
    }
}