using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClosedXML.Excel;
using System.Windows.Forms;

namespace TechStockManager
{
    public partial class Form5 : Form
    {
        DB db = new DB();
        private HashSet<int> changedProductIds = new HashSet<int>(); // HashSet for storing modified product IDs

        private string userDepartment;

        public Form5(string department)
        {
            InitializeComponent();

            userDepartment = department;

            ProductLoadTable();

            btnAddProduct.Click += (sender, e) => AddProduct(); // Add a product
            btnUpdateProduct.Click += (sender, e) => UpdateProduct();   // Product Update
            btnDeleteProduct.Click += (sender, e) => DeleteProduct();   // Deleting a product
            btnClearProduct.Click += (sender, e) => ClearProductFields();   // Clearing fields
            btnAddStock.Click += (sender, e) =>
            {
                Form11 addStockForm = new Form11(userDepartment); // Pass the department
                addStockForm.FormClosed += (s, args) => ProductLoadTable();   // Refresh the table after closing
                addStockForm.ShowDialog();
            };
            btnPrintProduct.Click += (sender, e) =>
            {
                string selectedFormat = comboExportFormat2.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedFormat))
                {
                    MessageBox.Show("Please select an export format (PDF or Excel).", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedFormat == "PDF")
                {
                    ExportToPdf(dataGridProduct, "Report_Order.pdf");
                }
                else if (selectedFormat == "Excel")
                {
                    ExportToExcel(dataGridProduct, "Report_Order.xlsx");
                }
                else
                {
                    MessageBox.Show("Unknown export format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            dataGridProduct.CellValueChanged += dataGridProduct_CellValueChanged;

            if (ThemeManager.IsDarkTheme)
                ThemeManager.ApplyDarkTheme(this);
            else
                ThemeManager.ApplyLightTheme(this);

            txtProductSearch.TextChanged += (sender, e) => SearchProduct();
        }

        private void ProductLoadTable(string searchTerm = "")
        {
            try
            {
                db.OpenConnection();
                DataTable dataTable = new DataTable();
                MySqlCommand command;

                if (userDepartment == "admin")
                {
                    label13.Visible = false;
                    label12.Visible = false;
                    label11.Visible = false;
                    label6.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    txtProductName.Visible = false;
                    txtProductCategoryId.Visible = false;
                    txtProductManufacturerId.Visible = false;
                    txtProductPrice.Visible = false;
                    txtProductStock.Visible = false;
                    txtProductDescription.Visible = false;
                    btnClearProduct.Visible = false;
                    btnAddProduct.Visible = false;
                    btnDeleteProduct.Visible = false;
                    btnUpdateProduct.Visible = false;
                    btnAddStock.Visible = false;
                    dataGridProduct.ReadOnly = true;

                    string query = @"
    SELECT 'computer' AS department, CONCAT('computer_', p.ID) AS unique_id, 
           p.name, p.price, p.stock_quantity, p.category_id, 
           p.manufacturer_id, p.date_added 
    FROM computer_product p
    UNION ALL
    SELECT 'mobile', CONCAT('mobile_', p.ID), 
           p.name, p.price, p.stock_quantity, p.category_id, 
           p.manufacturer_id, p.date_added 
    FROM mobile_product p
    UNION ALL
    SELECT 'audio', CONCAT('audio_', p.ID), 
           p.name, p.price, p.stock_quantity, p.category_id, 
           p.manufacturer_id, p.date_added 
    FROM audio_product p
    UNION ALL
    SELECT 'peripheral', CONCAT('peripheral_', p.ID), 
           p.name, p.price, p.stock_quantity, p.category_id, 
           p.manufacturer_id, p.date_added 
    FROM peripheral_product p
    UNION ALL
    SELECT 'television', CONCAT('television_', p.ID), 
           p.name, p.price, p.stock_quantity, p.category_id, 
           p.manufacturer_id, p.date_added 
    FROM television_product p
";

                    // Search filter
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query = $"SELECT * FROM ({query}) AS all_products WHERE name LIKE @searchTerm OR category_id LIKE @searchTerm OR manufacturer_id LIKE @searchTerm OR price LIKE @searchTerm OR date_added LIKE @searchTerm";
                    }

                    command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                }
                else
                {
                    // If not an admin — load only products from your department
                    string tableName = $"{userDepartment}_product";
                    string query = $"SELECT * FROM `{tableName}`";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE name LIKE @searchTerm OR category_id LIKE @searchTerm OR manufacturer_id LIKE @searchTerm " +
                                 "OR price LIKE @searchTerm OR date_added LIKE @searchTerm";
                    }

                    command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
                dataGridProduct.DataSource = dataTable;
                changedProductIds.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the product table: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Exports table data to PDF.
        private void ExportToPdf(DataGridView dataGridView, string filename)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4.Rotate(), 10, 10, 10, 10);

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Save the report as a PDF",
                    FileName = filename
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Loading the Arial font
                    string arialFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    BaseFont baseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 11, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                    // Add a title
                    Paragraph title = new Paragraph("Products Table Report", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 10f;
                    document.Add(title);

                    // Creating a PDF table
                    PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count)
                    {
                        WidthPercentage = 100,
                        SpacingBefore = 10f
                    };

                    // Set column widths
                    float[] columnWidths = new float[dataGridView.Columns.Count];
                    for (int i = 0; i < columnWidths.Length; i++)
                        columnWidths[i] = 1f;
                    pdfTable.SetWidths(columnWidths);

                    // Adding column headers
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, font))
                        {
                            BackgroundColor = new BaseColor(220, 220, 220),
                            Padding = 5,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        pdfTable.AddCell(headerCell);
                    }

                    // Check if any lines are selected
                    var selectedRows = dataGridView.SelectedRows.Count > 0
                        ? dataGridView.SelectedRows.Cast<DataGridViewRow>().OrderBy(r => r.Index)
                        : dataGridView.Rows.Cast<DataGridViewRow>();

                    // Add data
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (row.IsNewRow) continue;

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? string.Empty, font))
                            {
                                Padding = 5,
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                VerticalAlignment = Element.ALIGN_MIDDLE
                            };
                            pdfTable.AddCell(dataCell);
                        }
                    }

                    document.Add(pdfTable);
                    MessageBox.Show("The report has been saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                document.Close();
            }
        }

        private void ExportToExcel(DataGridView dataGridView, string filename)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save the report as an Excel file",
                FileName = filename + ".xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Report");

                        // Add headings
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dataGridView.Columns[col].HeaderText;
                            worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                            worksheet.Column(col + 1).AdjustToContents();
                        }

                        // Check if any lines are selected
                        var selectedRows = dataGridView.SelectedRows.Count > 0
                            ? dataGridView.SelectedRows.Cast<DataGridViewRow>().OrderBy(r => r.Index)
                            : dataGridView.Rows.Cast<DataGridViewRow>();

                        int rowIndex = 2;

                        foreach (DataGridViewRow row in selectedRows)
                        {
                            if (row.IsNewRow) continue;

                            for (int col = 0; col < row.Cells.Count; col++)
                            {
                                worksheet.Cell(rowIndex, col + 1).Value = row.Cells[col].Value?.ToString();
                            }

                            rowIndex++;
                        }

                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("The report has been saved in Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Event handler for table cell changes
        private void dataGridProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dataGridProduct.Rows[e.RowIndex].Cells["ID"].Value);
                changedProductIds.Add(productId);
            }
        }

        // Method for searching for a product
        private void SearchProduct()
        {
            string searchTerm = txtProductSearch.Text.Trim();
            ProductLoadTable(searchTerm);
        }

        // Method for adding a new product
        private void AddProduct()
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtProductCategoryId.Text) &&
                !string.IsNullOrEmpty(txtProductManufacturerId.Text) && !string.IsNullOrEmpty(txtProductPrice.Text) &&
                !string.IsNullOrEmpty(txtProductStock.Text))
            {
                try
                {
                    db.OpenConnection();

                    string tableName = $"{userDepartment}_product"; // Select a table based on the department

                    string query = $"INSERT INTO `{tableName}` (name, category_id, manufacturer_id, price, stock_quantity, description, date_added) " +
                                   "VALUES (@name, @categoryId, @manufacturerId, @price, @stock, @description, @dateAdded)";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                    command.Parameters.AddWithValue("@name", txtProductName.Text);
                    command.Parameters.AddWithValue("@categoryId", Convert.ToInt32(txtProductCategoryId.Text));
                    command.Parameters.AddWithValue("@manufacturerId", Convert.ToInt32(txtProductManufacturerId.Text));
                    command.Parameters.AddWithValue("@price", Convert.ToDecimal(txtProductPrice.Text));
                    command.Parameters.AddWithValue("@stock", Convert.ToInt32(txtProductStock.Text));
                    command.Parameters.AddWithValue("@description", txtProductDescription.Text);
                    command.Parameters.AddWithValue("@dateAdded", DateTime.Now);

                    command.ExecuteNonQuery();
                    MessageBox.Show("The item has been successfully added!");
                    ProductLoadTable();
                    ClearProductFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding an item: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the fields.");
            }
        }

        // Method for updating products
        private void UpdateProduct()
        {
            if (changedProductIds.Count == 0)
            {
                MessageBox.Show("No changes to save.");
                return;
            }

            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_product"; // Select a table based on the department

                foreach (int productId in changedProductIds)
                {
                    DataGridViewRow row = dataGridProduct.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["ID"].Value) == productId);

                    if (row != null)
                    {
                        string query = $"UPDATE `{tableName}` SET name = @name, category_id = @categoryId, " +
                                       "manufacturer_id = @manufacturerId, price = @price, stock_quantity = @stock, " +
                                       "description = @description, date_added = @dateAdded WHERE ID = @productId";
                        MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                        command.Parameters.AddWithValue("@productId", productId);
                        command.Parameters.AddWithValue("@name", row.Cells["name"].Value);
                        command.Parameters.AddWithValue("@categoryId", Convert.ToInt32(row.Cells["category_id"].Value));
                        command.Parameters.AddWithValue("@manufacturerId", Convert.ToInt32(row.Cells["manufacturer_id"].Value));
                        command.Parameters.AddWithValue("@price", Convert.ToDecimal(row.Cells["price"].Value));
                        command.Parameters.AddWithValue("@stock", Convert.ToInt32(row.Cells["stock_quantity"].Value));
                        command.Parameters.AddWithValue("@description", row.Cells["description"].Value);
                        command.Parameters.AddWithValue("@dateAdded", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("The changes have been successfully saved!");
                changedProductIds.Clear();
                ProductLoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Method for deleting a product
        private void DeleteProduct()
        {
            if (dataGridProduct.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dataGridProduct.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    db.OpenConnection();

                    string tableName = $"{userDepartment}_product"; // Select a table based on the department

                    string query = $"DELETE FROM `{tableName}` WHERE ID = @productId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@productId", productId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("The item has been successfully removed!");
                    ProductLoadTable();
                    ClearProductFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while removing an item: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Select the item you want to delete.");
            }
        }

        // Method for clearing form text fields
        private void ClearProductFields()
        {
            txtProductName.Clear();
            txtProductCategoryId.Clear();
            txtProductManufacturerId.Clear();
            txtProductPrice.Clear();
            txtProductStock.Clear();
            txtProductDescription.Clear();
        }
    }
}