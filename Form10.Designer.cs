namespace TechStockManager
{
    partial class Form10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            txtSupplierAddress = new TextBox();
            btnClearSupplier = new Button();
            txtSupplierEmail = new TextBox();
            txtSupplierName = new TextBox();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            btnUpdateSupplier = new Button();
            btnDeleteSupplier = new Button();
            btnAddSupplier = new Button();
            dataGridSuppliers = new DataGridView();
            label1 = new Label();
            txtSearchSupplier = new TextBox();
            btnPrintSupplier = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridSuppliers).BeginInit();
            SuspendLayout();
            // 
            // txtSupplierAddress
            // 
            txtSupplierAddress.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSupplierAddress.Location = new Point(180, 125);
            txtSupplierAddress.Name = "txtSupplierAddress";
            txtSupplierAddress.Size = new Size(100, 29);
            txtSupplierAddress.TabIndex = 54;
            // 
            // btnClearSupplier
            // 
            btnClearSupplier.FlatStyle = FlatStyle.Flat;
            btnClearSupplier.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearSupplier.Location = new Point(13, 193);
            btnClearSupplier.Name = "btnClearSupplier";
            btnClearSupplier.Size = new Size(118, 39);
            btnClearSupplier.TabIndex = 53;
            btnClearSupplier.Text = "Clear fields";
            btnClearSupplier.UseVisualStyleBackColor = true;
            // 
            // txtSupplierEmail
            // 
            txtSupplierEmail.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSupplierEmail.Location = new Point(180, 159);
            txtSupplierEmail.Name = "txtSupplierEmail";
            txtSupplierEmail.Size = new Size(100, 29);
            txtSupplierEmail.TabIndex = 52;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSupplierName.Location = new Point(180, 89);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(100, 29);
            txtSupplierName.TabIndex = 51;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label29.Location = new Point(2, 159);
            label29.Name = "label29";
            label29.Size = new Size(61, 22);
            label29.TabIndex = 50;
            label29.Text = "Email";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label30.Location = new Point(2, 128);
            label30.Name = "label30";
            label30.Size = new Size(87, 22);
            label30.TabIndex = 49;
            label30.Text = "Address";
            label30.TextAlign = ContentAlignment.TopCenter;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label31.Location = new Point(2, 92);
            label31.Name = "label31";
            label31.Size = new Size(145, 22);
            label31.TabIndex = 48;
            label31.Text = "Supplier Name";
            // 
            // btnUpdateSupplier
            // 
            btnUpdateSupplier.FlatStyle = FlatStyle.Flat;
            btnUpdateSupplier.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateSupplier.Location = new Point(186, 394);
            btnUpdateSupplier.Name = "btnUpdateSupplier";
            btnUpdateSupplier.Size = new Size(94, 40);
            btnUpdateSupplier.TabIndex = 47;
            btnUpdateSupplier.Text = "Edit";
            btnUpdateSupplier.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.FlatStyle = FlatStyle.Flat;
            btnDeleteSupplier.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteSupplier.Location = new Point(94, 394);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(86, 40);
            btnDeleteSupplier.TabIndex = 46;
            btnDeleteSupplier.Text = "Delete";
            btnDeleteSupplier.UseVisualStyleBackColor = true;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.FlatStyle = FlatStyle.Flat;
            btnAddSupplier.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddSupplier.Location = new Point(13, 394);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(75, 40);
            btnAddSupplier.TabIndex = 45;
            btnAddSupplier.Text = "Add";
            btnAddSupplier.UseVisualStyleBackColor = true;
            // 
            // dataGridSuppliers
            // 
            dataGridSuppliers.AllowUserToAddRows = false;
            dataGridSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridSuppliers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSuppliers.Location = new Point(286, 50);
            dataGridSuppliers.Name = "dataGridSuppliers";
            dataGridSuppliers.RowHeadersWidth = 51;
            dataGridSuppliers.RowTemplate.Height = 25;
            dataGridSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridSuppliers.Size = new Size(719, 392);
            dataGridSuppliers.TabIndex = 44;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(28, 14);
            label1.Name = "label1";
            label1.Size = new Size(127, 22);
            label1.TabIndex = 81;
            label1.Text = "Search by ID";
            // 
            // txtSearchSupplier
            // 
            txtSearchSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchSupplier.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchSupplier.Location = new Point(161, 11);
            txtSearchSupplier.Multiline = true;
            txtSearchSupplier.Name = "txtSearchSupplier";
            txtSearchSupplier.Size = new Size(776, 33);
            txtSearchSupplier.TabIndex = 80;
            // 
            // btnPrintSupplier
            // 
            btnPrintSupplier.FlatStyle = FlatStyle.Flat;
            btnPrintSupplier.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrintSupplier.Location = new Point(13, 317);
            btnPrintSupplier.Name = "btnPrintSupplier";
            btnPrintSupplier.Size = new Size(75, 40);
            btnPrintSupplier.TabIndex = 82;
            btnPrintSupplier.Text = "Print";
            btnPrintSupplier.UseVisualStyleBackColor = true;
            // 
            // Form10
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 446);
            Controls.Add(btnPrintSupplier);
            Controls.Add(label1);
            Controls.Add(txtSearchSupplier);
            Controls.Add(txtSupplierAddress);
            Controls.Add(btnClearSupplier);
            Controls.Add(txtSupplierEmail);
            Controls.Add(txtSupplierName);
            Controls.Add(label29);
            Controls.Add(label30);
            Controls.Add(label31);
            Controls.Add(btnUpdateSupplier);
            Controls.Add(btnDeleteSupplier);
            Controls.Add(btnAddSupplier);
            Controls.Add(dataGridSuppliers);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form10";
            Text = "Supplier";
            ((System.ComponentModel.ISupportInitialize)dataGridSuppliers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSupplierAddress;
        private Button btnClearSupplier;
        private TextBox txtSupplierEmail;
        private TextBox txtSupplierName;
        private Label label29;
        private Label label30;
        private Label label31;
        private Button btnUpdateSupplier;
        private Button btnDeleteSupplier;
        private Button btnAddSupplier;
        private DataGridView dataGridSuppliers;
        private Label label1;
        private TextBox txtSearchSupplier;
        private Button btnPrintSupplier;
    }
}