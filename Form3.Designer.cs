namespace TechStockManager
{
    partial class Form3
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            btnClearOrder = new Button();
            txtStatus = new TextBox();
            txtCustomerId = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            txtOrderSearch = new TextBox();
            label6 = new Label();
            BtnUpdatePrice = new Button();
            btnPrintOrder = new Button();
            txtDeliveryDate = new TextBox();
            comboExportFormat = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnClearOrder
            // 
            btnClearOrder.FlatStyle = FlatStyle.Flat;
            btnClearOrder.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearOrder.Location = new Point(12, 197);
            btnClearOrder.Name = "btnClearOrder";
            btnClearOrder.Size = new Size(123, 31);
            btnClearOrder.TabIndex = 29;
            btnClearOrder.Text = "Clear fields";
            btnClearOrder.UseVisualStyleBackColor = true;
            // 
            // txtStatus
            // 
            txtStatus.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtStatus.Location = new Point(204, 108);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(131, 32);
            txtStatus.TabIndex = 27;
            // 
            // txtCustomerId
            // 
            txtCustomerId.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomerId.Location = new Point(204, 68);
            txtCustomerId.Multiline = true;
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(131, 33);
            txtCustomerId.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 152);
            label5.Name = "label5";
            label5.Size = new Size(130, 22);
            label5.TabIndex = 23;
            label5.Text = "Delivery date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 117);
            label4.Name = "label4";
            label4.Size = new Size(69, 22);
            label4.TabIndex = 22;
            label4.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 77);
            label1.Name = "label1";
            label1.Size = new Size(124, 22);
            label1.TabIndex = 19;
            label1.Text = "Customer ID";
            // 
            // btnUpdate
            // 
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.Location = new Point(181, 53);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(93, 34);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Edit";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(82, 53);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(93, 34);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(3, 53);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(73, 34);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(370, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(640, 392);
            dataGridView1.TabIndex = 15;
            // 
            // txtOrderSearch
            // 
            txtOrderSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOrderSearch.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderSearch.Location = new Point(124, 2);
            txtOrderSearch.Multiline = true;
            txtOrderSearch.Name = "txtOrderSearch";
            txtOrderSearch.Size = new Size(776, 33);
            txtOrderSearch.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(127, 22);
            label6.TabIndex = 31;
            label6.Text = "Search by ID";
            // 
            // BtnUpdatePrice
            // 
            BtnUpdatePrice.FlatStyle = FlatStyle.Flat;
            BtnUpdatePrice.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnUpdatePrice.Location = new Point(280, 53);
            BtnUpdatePrice.Name = "BtnUpdatePrice";
            BtnUpdatePrice.Size = new Size(75, 34);
            BtnUpdatePrice.TabIndex = 32;
            BtnUpdatePrice.Text = "Update";
            BtnUpdatePrice.UseVisualStyleBackColor = true;
            BtnUpdatePrice.Click += BtnUpdatePrice_Click;
            // 
            // btnPrintOrder
            // 
            btnPrintOrder.FlatStyle = FlatStyle.Flat;
            btnPrintOrder.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrintOrder.Location = new Point(3, 3);
            btnPrintOrder.Name = "btnPrintOrder";
            btnPrintOrder.Size = new Size(73, 34);
            btnPrintOrder.TabIndex = 33;
            btnPrintOrder.Text = "Print";
            btnPrintOrder.UseVisualStyleBackColor = true;
            // 
            // txtDeliveryDate
            // 
            txtDeliveryDate.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtDeliveryDate.Location = new Point(204, 149);
            txtDeliveryDate.Multiline = true;
            txtDeliveryDate.Name = "txtDeliveryDate";
            txtDeliveryDate.Size = new Size(131, 32);
            txtDeliveryDate.TabIndex = 34;
            // 
            // comboExportFormat
            // 
            comboExportFormat.FormattingEnabled = true;
            comboExportFormat.Items.AddRange(new object[] { "PDF", "Excel" });
            comboExportFormat.Location = new Point(82, 3);
            comboExportFormat.Name = "comboExportFormat";
            comboExportFormat.Size = new Size(73, 23);
            comboExportFormat.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.2222214F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.7777786F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.7777786F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.2222214F));
            tableLayoutPanel1.Controls.Add(btnPrintOrder, 0, 0);
            tableLayoutPanel1.Controls.Add(comboExportFormat, 1, 0);
            tableLayoutPanel1.Controls.Add(BtnUpdatePrice, 3, 1);
            tableLayoutPanel1.Controls.Add(btnAdd, 0, 1);
            tableLayoutPanel1.Controls.Add(btnDelete, 1, 1);
            tableLayoutPanel1.Controls.Add(btnUpdate, 2, 1);
            tableLayoutPanel1.Location = new Point(5, 327);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(359, 100);
            tableLayoutPanel1.TabIndex = 36;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 439);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(txtDeliveryDate);
            Controls.Add(label6);
            Controls.Add(txtOrderSearch);
            Controls.Add(btnClearOrder);
            Controls.Add(txtStatus);
            Controls.Add(txtCustomerId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1038, 478);
            Name = "Form3";
            Text = "Order";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClearOrder;
        private TextBox txtStatus;
        private TextBox txtCustomerId;
        private Label label5;
        private Label label4;
        private Label label1;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private DataGridView dataGridView1;
        private TextBox txtOrderSearch;
        private Label label6;
        private Button BtnUpdatePrice;
        private Button btnPrintOrder;
        private TextBox txtDeliveryDate;
        private ComboBox comboExportFormat;
        private TableLayoutPanel tableLayoutPanel1;
    }
}