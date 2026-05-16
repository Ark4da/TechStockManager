namespace TechStockManager
{ 
    partial class Form11
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
            txtAddQuantity = new TextBox();
            cmbProducts = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnAddQuantity = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtAddQuantity
            // 
            txtAddQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAddQuantity.Location = new Point(89, 101);
            txtAddQuantity.Name = "txtAddQuantity";
            txtAddQuantity.Size = new Size(170, 23);
            txtAddQuantity.TabIndex = 0;
            // 
            // cmbProducts
            // 
            cmbProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(89, 68);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(170, 23);
            cmbProducts.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 65);
            label1.Name = "label1";
            label1.Size = new Size(83, 22);
            label1.TabIndex = 2;
            label1.Text = "Product";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 102);
            label2.Name = "label2";
            label2.Size = new Size(87, 22);
            label2.TabIndex = 3;
            label2.Text = "Quantity";
            // 
            // btnAddQuantity
            // 
            btnAddQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAddQuantity.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddQuantity.Location = new Point(12, 145);
            btnAddQuantity.Name = "btnAddQuantity";
            btnAddQuantity.Size = new Size(79, 42);
            btnAddQuantity.TabIndex = 4;
            btnAddQuantity.Text = "Add";
            btnAddQuantity.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(15, 26);
            label3.Name = "label3";
            label3.Size = new Size(275, 22);
            label3.TabIndex = 5;
            label3.Text = "Adding products to inventory";
            // 
            // Form11
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 218);
            Controls.Add(label3);
            Controls.Add(btnAddQuantity);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbProducts);
            Controls.Add(txtAddQuantity);
            MaximumSize = new Size(287, 257);
            MinimumSize = new Size(287, 257);
            Name = "Form11";
            Text = "Adding items to inventory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAddQuantity;
        private ComboBox cmbProducts;
        private Label label1;
        private Label label2;
        private Button btnAddQuantity;
        private Label label3;
    }
}