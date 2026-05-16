namespace TechStockManager
{
    partial class Form9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            txtManufacturerName = new TextBox();
            txtCountry = new TextBox();
            label18 = new Label();
            btnClearManufacturer = new Button();
            label23 = new Label();
            btnUpdateManufacturer = new Button();
            btnDeleteManufacturer = new Button();
            btnAddManufacturer = new Button();
            dataGridManufacturers = new DataGridView();
            label1 = new Label();
            txtManufacturerSearch = new TextBox();
            btnPrintManufacturer = new Button();
            comboExportFormat6 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridManufacturers).BeginInit();
            SuspendLayout();
            // 
            // txtManufacturerName
            // 
            txtManufacturerName.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtManufacturerName.Location = new Point(175, 90);
            txtManufacturerName.Name = "txtManufacturerName";
            txtManufacturerName.Size = new Size(100, 29);
            txtManufacturerName.TabIndex = 86;
            // 
            // txtCountry
            // 
            txtCountry.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCountry.Location = new Point(175, 121);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(100, 29);
            txtCountry.TabIndex = 85;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(16, 122);
            label18.Name = "label18";
            label18.Size = new Size(82, 22);
            label18.TabIndex = 84;
            label18.Text = "Country";
            // 
            // btnClearManufacturer
            // 
            btnClearManufacturer.FlatStyle = FlatStyle.Flat;
            btnClearManufacturer.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearManufacturer.Location = new Point(16, 166);
            btnClearManufacturer.Name = "btnClearManufacturer";
            btnClearManufacturer.Size = new Size(118, 39);
            btnClearManufacturer.TabIndex = 83;
            btnClearManufacturer.Text = "Clear fields";
            btnClearManufacturer.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label23.Location = new Point(16, 93);
            label23.Name = "label23";
            label23.Size = new Size(132, 22);
            label23.TabIndex = 82;
            label23.Text = "Manufacturer";
            // 
            // btnUpdateManufacturer
            // 
            btnUpdateManufacturer.FlatStyle = FlatStyle.Flat;
            btnUpdateManufacturer.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateManufacturer.Location = new Point(180, 395);
            btnUpdateManufacturer.Name = "btnUpdateManufacturer";
            btnUpdateManufacturer.Size = new Size(95, 40);
            btnUpdateManufacturer.TabIndex = 81;
            btnUpdateManufacturer.Text = "Edit";
            btnUpdateManufacturer.UseVisualStyleBackColor = true;
            // 
            // btnDeleteManufacturer
            // 
            btnDeleteManufacturer.FlatStyle = FlatStyle.Flat;
            btnDeleteManufacturer.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteManufacturer.Location = new Point(90, 395);
            btnDeleteManufacturer.Name = "btnDeleteManufacturer";
            btnDeleteManufacturer.Size = new Size(84, 40);
            btnDeleteManufacturer.TabIndex = 80;
            btnDeleteManufacturer.Text = "Delete";
            btnDeleteManufacturer.UseVisualStyleBackColor = true;
            // 
            // btnAddManufacturer
            // 
            btnAddManufacturer.FlatStyle = FlatStyle.Flat;
            btnAddManufacturer.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddManufacturer.Location = new Point(9, 395);
            btnAddManufacturer.Name = "btnAddManufacturer";
            btnAddManufacturer.Size = new Size(75, 40);
            btnAddManufacturer.TabIndex = 79;
            btnAddManufacturer.Text = "Add";
            btnAddManufacturer.UseVisualStyleBackColor = true;
            // 
            // dataGridManufacturers
            // 
            dataGridManufacturers.AllowUserToAddRows = false;
            dataGridManufacturers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridManufacturers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridManufacturers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridManufacturers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridManufacturers.Location = new Point(291, 51);
            dataGridManufacturers.Name = "dataGridManufacturers";
            dataGridManufacturers.RowHeadersWidth = 51;
            dataGridManufacturers.RowTemplate.Height = 25;
            dataGridManufacturers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridManufacturers.Size = new Size(719, 392);
            dataGridManufacturers.TabIndex = 78;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(52, 9);
            label1.Name = "label1";
            label1.Size = new Size(132, 44);
            label1.TabIndex = 88;
            label1.Text = "Search by ID \r\nand title\r\n";
            // 
            // txtManufacturerSearch
            // 
            txtManufacturerSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtManufacturerSearch.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtManufacturerSearch.Location = new Point(175, 12);
            txtManufacturerSearch.Multiline = true;
            txtManufacturerSearch.Name = "txtManufacturerSearch";
            txtManufacturerSearch.Size = new Size(776, 33);
            txtManufacturerSearch.TabIndex = 87;
            // 
            // btnPrintManufacturer
            // 
            btnPrintManufacturer.FlatStyle = FlatStyle.Flat;
            btnPrintManufacturer.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrintManufacturer.Location = new Point(9, 322);
            btnPrintManufacturer.Name = "btnPrintManufacturer";
            btnPrintManufacturer.Size = new Size(75, 40);
            btnPrintManufacturer.TabIndex = 89;
            btnPrintManufacturer.Text = "Print";
            btnPrintManufacturer.UseVisualStyleBackColor = true;
            // 
            // comboExportFormat6
            // 
            comboExportFormat6.FormattingEnabled = true;
            comboExportFormat6.Items.AddRange(new object[] { "PDF", "Excel" });
            comboExportFormat6.Location = new Point(90, 333);
            comboExportFormat6.Name = "comboExportFormat6";
            comboExportFormat6.Size = new Size(73, 23);
            comboExportFormat6.TabIndex = 90;
            // 
            // Form9
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 447);
            Controls.Add(comboExportFormat6);
            Controls.Add(btnPrintManufacturer);
            Controls.Add(label1);
            Controls.Add(txtManufacturerSearch);
            Controls.Add(txtManufacturerName);
            Controls.Add(txtCountry);
            Controls.Add(label18);
            Controls.Add(btnClearManufacturer);
            Controls.Add(label23);
            Controls.Add(btnUpdateManufacturer);
            Controls.Add(btnDeleteManufacturer);
            Controls.Add(btnAddManufacturer);
            Controls.Add(dataGridManufacturers);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1030, 486);
            Name = "Form9";
            Text = "Manufacturer";
            ((System.ComponentModel.ISupportInitialize)dataGridManufacturers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtManufacturerName;
        private TextBox txtCountry;
        private Label label18;
        private Button btnClearManufacturer;
        private Label label23;
        private Button btnUpdateManufacturer;
        private Button btnDeleteManufacturer;
        private Button btnAddManufacturer;
        private DataGridView dataGridManufacturers;
        private Label label1;
        private TextBox txtManufacturerSearch;
        private Button btnPrintManufacturer;
        private ComboBox comboExportFormat6;
    }
}