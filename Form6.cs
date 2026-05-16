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
    public partial class Form6 : Form
    {
        DB db = new DB();
        private HashSet<int> changedCategoryIds = new HashSet<int>(); // HashSet for storing updated category IDs

        private string userDepartment;

        public Form6(string department)
        {
            InitializeComponent();

            userDepartment = department;

            ProductCategoryLoadTable();

            btnAddCategory.Click += (sender, e) => AddProductCategory(); // Add a category
            btnUpdateCategory.Click += (sender, e) => UpdateProductCategories(); // Update categories
            btnDeleteCategory.Click += (sender, e) => DeleteProductCategory(); // Delete category
            btnClearCategory.Click += (sender, e) => ClearProductCategoryFields(); // Clearing fields
            btnPrintProductCategory.Click += (sender, e) => ExportToPdf(dataGridProductCategory, "Report_ProductCategory.pdf"); // Export to PDF
            btnPrintProductCategory.Click += (sender, e) =>
            {
                string selectedFormat = comboExportFormat3.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedFormat))
                {
                    MessageBox.Show("Please select an export format (PDF or Excel).", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedFormat == "PDF")
                {
                    ExportToPdf(dataGridProductCategory, "Report_Order.pdf");
                }
                else if (selectedFormat == "Excel")
                {
                    ExportToExcel(dataGridProductCategory, "Report_Order.xlsx");
                }
                else
                {
                    MessageBox.Show("Unknown export format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Tracking changes in table cells
            dataGridProductCategory.CellValueChanged += dataGridProductCategory_CellValueChanged;

            // Applying a theme (light or dark)
            if (ThemeManager.IsDarkTheme)
                ThemeManager.ApplyDarkTheme(this);
            else
                ThemeManager.ApplyLightTheme(this);
        }


        // Loading the product category table from the database
        private void ProductCategoryLoadTable()
        {
            try
            {
                db.OpenConnection();
                DataTable dataTable = new DataTable();
                MySqlCommand command;

                if (userDepartment == "admin")
                {
                    label21.Visible = false;
                    label16.Visible = false;
                    txtCategoryDescription.Visible = false;
                    txtCategoryName.Visible = false;
                    btnClearCategory.Visible = false;
                    btnAddCategory.Visible = false;
                    btnDeleteCategory.Visible = false;
                    btnUpdateCategory.Visible = false;
                    dataGridProductCategory.ReadOnly = true;

                    string query = @"
                SELECT 'computer' AS department, CONCAT('computer_', ID) AS unique_id, category_name
                FROM computer_productcategory
                UNION ALL
                SELECT 'mobile', CONCAT('mobile_', ID), category_name
                FROM mobile_productcategory
                UNION ALL
                SELECT 'audio', CONCAT('audio_', ID), category_name
                FROM audio_productcategory
                UNION ALL
                SELECT 'peripheral', CONCAT('peripheral_', ID), category_name
                FROM peripheral_productcategory
                UNION ALL
                SELECT 'television', CONCAT('television_', ID), category_name
                FROM television_productcategory;
            ";

                    command = new MySqlCommand(query, db.GetConnection());
                }
                else
                {
                    string tableName = $"{userDepartment}_productcategory";
                    string query = $"SELECT * FROM `{tableName}`";
                    command = new MySqlCommand(query, db.GetConnection());
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
                dataGridProductCategory.DataSource = dataTable;
                changedCategoryIds.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the product category table: " + ex.Message);
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
                    Paragraph title = new Paragraph("Product Categories Table Report", titleFont);
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
        private void dataGridProductCategory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int categoryId = Convert.ToInt32(dataGridProductCategory.Rows[e.RowIndex].Cells["ID"].Value);
                changedCategoryIds.Add(categoryId);
            }
        }

        // Adding a new category
        private void AddProductCategory()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName?.Text) || string.IsNullOrWhiteSpace(txtCategoryDescription?.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }
            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_productcategory"; // Select a table based on the department

                string query = $"INSERT INTO `{tableName}` (category_name, description) VALUES (@categoryName, @description)";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                command.Parameters.AddWithValue("@categoryName", txtCategoryName.Text);
                command.Parameters.AddWithValue("@description", txtCategoryDescription.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("The category has been successfully added!");

                ProductCategoryLoadTable();
                ClearProductCategoryFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding a category: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Update modified categories
        private void UpdateProductCategories()
        {
            if (changedCategoryIds.Count == 0)
            {
                MessageBox.Show("No changes to save.");
                return;
            }

            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_productcategory"; // Select a table based on the department

                foreach (int categoryId in changedCategoryIds)
                {
                    DataGridViewRow row = dataGridProductCategory.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["ID"].Value) == categoryId);

                    if (row != null)
                    {
                        string query = $"UPDATE `{tableName}` SET category_name = @categoryName, description = @description WHERE ID = @categoryId";
                        MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                        command.Parameters.AddWithValue("@categoryId", categoryId);
                        command.Parameters.AddWithValue("@categoryName", row.Cells["category_name"].Value);
                        command.Parameters.AddWithValue("@description", row.Cells["description"].Value);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("The changes have been successfully saved!");
                changedCategoryIds.Clear();
                ProductCategoryLoadTable();
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

        // Delete the selected category
        private void DeleteProductCategory()
        {
            if (dataGridProductCategory.SelectedRows.Count > 0)
            {
                int categoryId = Convert.ToInt32(dataGridProductCategory.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    db.OpenConnection();

                    string tableName = $"{userDepartment}_productcategory"; // Select a table based on the department

                    string query = $"DELETE FROM `{tableName}` WHERE ID = @categoryId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@categoryId", categoryId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("The category has been successfully deleted!");

                    ProductCategoryLoadTable();
                    ClearProductCategoryFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting a category: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete.");
            }
        }

        // Clearing the form's text fields
        private void ClearProductCategoryFields()
        {
            txtCategoryName.Clear();
            txtCategoryDescription.Clear();
        }
    }
}