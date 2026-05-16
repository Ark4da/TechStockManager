namespace TechStockManager
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            txtCategoryName = new TextBox();
            txtCategoryDescription = new TextBox();
            label16 = new Label();
            btnClearCategory = new Button();
            label21 = new Label();
            btnUpdateCategory = new Button();
            btnDeleteCategory = new Button();
            btnAddCategory = new Button();
            dataGridProductCategory = new DataGridView();
            label1 = new Label();
            txtCategorySearch = new TextBox();
            btnPrintProductCategory = new Button();
            comboExportFormat3 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridProductCategory).BeginInit();
            SuspendLayout();
            // 
            // txtCategoryName
            // 
            txtCategoryName.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategoryName.Location = new Point(170, 90);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(100, 29);
            txtCategoryName.TabIndex = 77;
            // 
            // txtCategoryDescription
            // 
            txtCategoryDescription.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategoryDescription.Location = new Point(170, 121);
            txtCategoryDescription.Name = "txtCategoryDescription";
            txtCategoryDescription.Size = new Size(100, 29);
            txtCategoryDescription.TabIndex = 76;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(11, 124);
            label16.Name = "label16";
            label16.Size = new Size(115, 22);
            label16.TabIndex = 75;
            label16.Text = "Description";
            // 
            // btnClearCategory
            // 
            btnClearCategory.FlatStyle = FlatStyle.Flat;
            btnClearCategory.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearCategory.Location = new Point(11, 166);
            btnClearCategory.Name = "btnClearCategory";
            btnClearCategory.Size = new Size(118, 36);
            btnClearCategory.TabIndex = 74;
            btnClearCategory.Text = "Очистити поля";
            btnClearCategory.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label21.Location = new Point(11, 93);
            label21.Name = "label21";
            label21.Size = new Size(50, 22);
            label21.TabIndex = 73;
            label21.Text = "Title";
            // 
            // btnUpdateCategory
            // 
            btnUpdateCategory.FlatStyle = FlatStyle.Flat;
            btnUpdateCategory.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateCategory.Location = new Point(175, 397);
            btnUpdateCategory.Name = "btnUpdateCategory";
            btnUpdateCategory.Size = new Size(108, 36);
            btnUpdateCategory.TabIndex = 72;
            btnUpdateCategory.Text = "Edit";
            btnUpdateCategory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.FlatStyle = FlatStyle.Flat;
            btnDeleteCategory.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteCategory.Location = new Point(84, 397);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(85, 36);
            btnDeleteCategory.TabIndex = 71;
            btnDeleteCategory.Text = "Delete";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            // 
            // btnAddCategory
            // 
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddCategory.Location = new Point(3, 397);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(75, 36);
            btnAddCategory.TabIndex = 70;
            btnAddCategory.Text = "Add";
            btnAddCategory.UseVisualStyleBackColor = true;
            // 
            // dataGridProductCategory
            // 
            dataGridProductCategory.AllowUserToAddRows = false;
            dataGridProductCategory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProductCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProductCategory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridProductCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductCategory.Location = new Point(286, 51);
            dataGridProductCategory.Name = "dataGridProductCategory";
            dataGridProductCategory.RowHeadersWidth = 51;
            dataGridProductCategory.RowTemplate.Height = 25;
            dataGridProductCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProductCategory.Size = new Size(719, 392);
            dataGridProductCategory.TabIndex = 69;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(37, 15);
            label1.Name = "label1";
            label1.Size = new Size(127, 22);
            label1.TabIndex = 79;
            label1.Text = "Search by ID";
            // 
            // txtCategorySearch
            // 
            txtCategorySearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCategorySearch.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategorySearch.Location = new Point(170, 12);
            txtCategorySearch.Multiline = true;
            txtCategorySearch.Name = "txtCategorySearch";
            txtCategorySearch.Size = new Size(776, 33);
            txtCategorySearch.TabIndex = 78;
            // 
            // btnPrintProductCategory
            // 
            btnPrintProductCategory.FlatStyle = FlatStyle.Flat;
            btnPrintProductCategory.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrintProductCategory.Location = new Point(3, 327);
            btnPrintProductCategory.Name = "btnPrintProductCategory";
            btnPrintProductCategory.Size = new Size(75, 36);
            btnPrintProductCategory.TabIndex = 80;
            btnPrintProductCategory.Text = "Print";
            btnPrintProductCategory.UseVisualStyleBackColor = true;
            // 
            // comboExportFormat3
            // 
            comboExportFormat3.FormattingEnabled = true;
            comboExportFormat3.Items.AddRange(new object[] { "PDF", "Excel" });
            comboExportFormat3.Location = new Point(84, 336);
            comboExportFormat3.Name = "comboExportFormat3";
            comboExportFormat3.Size = new Size(73, 23);
            comboExportFormat3.TabIndex = 81;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 445);
            Controls.Add(comboExportFormat3);
            Controls.Add(btnPrintProductCategory);
            Controls.Add(label1);
            Controls.Add(txtCategorySearch);
            Controls.Add(txtCategoryName);
            Controls.Add(txtCategoryDescription);
            Controls.Add(label16);
            Controls.Add(btnClearCategory);
            Controls.Add(label21);
            Controls.Add(btnUpdateCategory);
            Controls.Add(btnDeleteCategory);
            Controls.Add(btnAddCategory);
            Controls.Add(dataGridProductCategory);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1023, 484);
            Name = "Form6";
            Text = "Product category";
            ((System.ComponentModel.ISupportInitialize)dataGridProductCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCategoryName;
        private TextBox txtCategoryDescription;
        private Label label16;
        private Button btnClearCategory;
        private Label label21;
        private Button btnUpdateCategory;
        private Button btnDeleteCategory;
        private Button btnAddCategory;
        private DataGridView dataGridProductCategory;
        private Label label1;
        private TextBox txtCategorySearch;
        private Button btnPrintProductCategory;
        private ComboBox comboExportFormat3;
    }
}