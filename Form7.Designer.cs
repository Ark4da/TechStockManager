namespace TechStockManager
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            btnClearPayment = new Button();
            txtPaymentStatus = new TextBox();
            txtPaymentOrderId = new TextBox();
            label17 = new Label();
            label22 = new Label();
            btnUpdatePayment = new Button();
            btnDeletePayment = new Button();
            btnAddPayment = new Button();
            dataGridPayments = new DataGridView();
            label1 = new Label();
            txtPaymentSearch = new TextBox();
            BtnPaymentUpdatePrice = new Button();
            btnPrintPayment = new Button();
            label2 = new Label();
            comboBoxDepartment = new ComboBox();
            comboExportFormat4 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridPayments).BeginInit();
            SuspendLayout();
            // 
            // btnClearPayment
            // 
            btnClearPayment.FlatStyle = FlatStyle.Flat;
            btnClearPayment.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearPayment.Location = new Point(7, 198);
            btnClearPayment.Name = "btnClearPayment";
            btnClearPayment.Size = new Size(114, 33);
            btnClearPayment.TabIndex = 42;
            btnClearPayment.Text = "Clear fields";
            btnClearPayment.UseVisualStyleBackColor = true;
            // 
            // txtPaymentStatus
            // 
            txtPaymentStatus.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPaymentStatus.Location = new Point(232, 160);
            txtPaymentStatus.Name = "txtPaymentStatus";
            txtPaymentStatus.Size = new Size(100, 29);
            txtPaymentStatus.TabIndex = 41;
            // 
            // txtPaymentOrderId
            // 
            txtPaymentOrderId.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPaymentOrderId.Location = new Point(232, 93);
            txtPaymentOrderId.Name = "txtPaymentOrderId";
            txtPaymentOrderId.Size = new Size(100, 29);
            txtPaymentOrderId.TabIndex = 38;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(5, 160);
            label17.Name = "label17";
            label17.Size = new Size(154, 22);
            label17.TabIndex = 37;
            label17.Text = "Payment Status";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label22.Location = new Point(5, 93);
            label22.Name = "label22";
            label22.Size = new Size(89, 22);
            label22.TabIndex = 34;
            label22.Text = "Order ID";
            // 
            // btnUpdatePayment
            // 
            btnUpdatePayment.FlatStyle = FlatStyle.Flat;
            btnUpdatePayment.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdatePayment.Location = new Point(171, 398);
            btnUpdatePayment.Name = "btnUpdatePayment";
            btnUpdatePayment.Size = new Size(93, 36);
            btnUpdatePayment.TabIndex = 33;
            btnUpdatePayment.Text = "Edit";
            btnUpdatePayment.UseVisualStyleBackColor = true;
            // 
            // btnDeletePayment
            // 
            btnDeletePayment.FlatStyle = FlatStyle.Flat;
            btnDeletePayment.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeletePayment.Location = new Point(81, 398);
            btnDeletePayment.Name = "btnDeletePayment";
            btnDeletePayment.Size = new Size(86, 36);
            btnDeletePayment.TabIndex = 32;
            btnDeletePayment.Text = "Delete";
            btnDeletePayment.UseVisualStyleBackColor = true;
            // 
            // btnAddPayment
            // 
            btnAddPayment.FlatStyle = FlatStyle.Flat;
            btnAddPayment.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddPayment.Location = new Point(6, 398);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.Size = new Size(71, 36);
            btnAddPayment.TabIndex = 31;
            btnAddPayment.Text = "Add";
            btnAddPayment.UseVisualStyleBackColor = true;
            // 
            // dataGridPayments
            // 
            dataGridPayments.AllowUserToAddRows = false;
            dataGridPayments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPayments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPayments.Location = new Point(350, 51);
            dataGridPayments.Name = "dataGridPayments";
            dataGridPayments.RowHeadersWidth = 51;
            dataGridPayments.RowTemplate.Height = 25;
            dataGridPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPayments.Size = new Size(707, 392);
            dataGridPayments.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(31, 15);
            label1.Name = "label1";
            label1.Size = new Size(127, 22);
            label1.TabIndex = 81;
            label1.Text = "Search by ID";
            // 
            // txtPaymentSearch
            // 
            txtPaymentSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPaymentSearch.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPaymentSearch.Location = new Point(164, 12);
            txtPaymentSearch.Multiline = true;
            txtPaymentSearch.Name = "txtPaymentSearch";
            txtPaymentSearch.Size = new Size(776, 33);
            txtPaymentSearch.TabIndex = 80;
            // 
            // BtnPaymentUpdatePrice
            // 
            BtnPaymentUpdatePrice.FlatStyle = FlatStyle.Flat;
            BtnPaymentUpdatePrice.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnPaymentUpdatePrice.Location = new Point(267, 398);
            BtnPaymentUpdatePrice.Name = "BtnPaymentUpdatePrice";
            BtnPaymentUpdatePrice.Size = new Size(81, 36);
            BtnPaymentUpdatePrice.TabIndex = 82;
            BtnPaymentUpdatePrice.Text = "Update";
            BtnPaymentUpdatePrice.UseVisualStyleBackColor = true;
            BtnPaymentUpdatePrice.Click += button1_Click;
            // 
            // btnPrintPayment
            // 
            btnPrintPayment.FlatStyle = FlatStyle.Flat;
            btnPrintPayment.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrintPayment.Location = new Point(6, 329);
            btnPrintPayment.Name = "btnPrintPayment";
            btnPrintPayment.Size = new Size(71, 36);
            btnPrintPayment.TabIndex = 83;
            btnPrintPayment.Text = "Print";
            btnPrintPayment.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(7, 132);
            label2.Name = "label2";
            label2.Size = new Size(119, 22);
            label2.TabIndex = 84;
            label2.Text = "Department";
            // 
            // comboBoxDepartment
            // 
            comboBoxDepartment.FormattingEnabled = true;
            comboBoxDepartment.Items.AddRange(new object[] { "mobile", "computer", "audio", "peripheral", "television" });
            comboBoxDepartment.Location = new Point(232, 131);
            comboBoxDepartment.Name = "comboBoxDepartment";
            comboBoxDepartment.Size = new Size(100, 23);
            comboBoxDepartment.TabIndex = 85;
            // 
            // comboExportFormat4
            // 
            comboExportFormat4.FormattingEnabled = true;
            comboExportFormat4.Items.AddRange(new object[] { "PDF", "Excel" });
            comboExportFormat4.Location = new Point(83, 338);
            comboExportFormat4.Name = "comboExportFormat4";
            comboExportFormat4.Size = new Size(73, 23);
            comboExportFormat4.TabIndex = 86;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 446);
            Controls.Add(comboExportFormat4);
            Controls.Add(comboBoxDepartment);
            Controls.Add(label2);
            Controls.Add(btnPrintPayment);
            Controls.Add(BtnPaymentUpdatePrice);
            Controls.Add(label1);
            Controls.Add(txtPaymentSearch);
            Controls.Add(btnClearPayment);
            Controls.Add(txtPaymentStatus);
            Controls.Add(txtPaymentOrderId);
            Controls.Add(label17);
            Controls.Add(label22);
            Controls.Add(btnUpdatePayment);
            Controls.Add(btnDeletePayment);
            Controls.Add(btnAddPayment);
            Controls.Add(dataGridPayments);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1079, 485);
            Name = "Form7";
            Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)dataGridPayments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClearPayment;
        private TextBox txtPaymentStatus;
        private TextBox txtPaymentOrderId;
        private Label label17;
        private Label label22;
        private Button btnUpdatePayment;
        private Button btnDeletePayment;
        private Button btnAddPayment;
        private DataGridView dataGridPayments;
        private Label label1;
        private TextBox txtPaymentSearch;
        private Button BtnPaymentUpdatePrice;
        private Button btnPrintPayment;
        private Label label2;
        private ComboBox comboBoxDepartment;
        private ComboBox comboExportFormat4;
    }
}