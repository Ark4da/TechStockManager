using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Forms;

namespace TechStockManager
{
    public partial class Form4 : Form
    {
        DB db = new DB();
        private HashSet<int> changedOrderDetailIds = new HashSet<int>();
        private Form3 form3;
        private string userDepartment;

        public Form4(string department)
        {
            InitializeComponent();
            form3 = new Form3(department);

            userDepartment = department;

            OrderDetailsLoadTable();

            btnAddOrderDetail.Click += (sender, e) => OrderDetailsAdd();
            btnDeleteOrderDetail.Click += (sender, e) => OrderDetailsDelete();
            btnUpdateOrderDetail.Click += (sender, e) => OrderDetailsUpdate();
            btnClearOrderDetail.Click += (sender, e) => ClearOrderDetailFields();
            btnPrintOrderDetail.Click += (sender, e) =>
            {
                string selectedFormat = comboExportFormat1.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedFormat))
                {
                    MessageBox.Show("Please select an export format (PDF or Excel).", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedFormat == "PDF")
                {
                    ExportToPdf(dataGridViewOrderDetails, "Report_Order.pdf");
                }
                else if (selectedFormat == "Excel")
                {
                    ExportToExcel(dataGridViewOrderDetails, "Report_Order.xlsx");
                }
                else
                {
                    MessageBox.Show("Unknown export format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            txtProductId.TextChanged += txtProductId_TextChanged;
            txtQuantity.TextChanged += txtQuantity_TextChanged;

            txtOrderDetailsSearch.TextChanged += (sender, e) => OrderDetailsLoadTable();

            if (ThemeManager.IsDarkTheme)
                ThemeManager.ApplyDarkTheme(this);
            else
                ThemeManager.ApplyLightTheme(this);

            dataGridViewOrderDetails.CellValueChanged += dataGridViewOrderDetails_CellValueChanged;
        }

        // Method for loading the `order_details` table into a DataGridView
        private void OrderDetailsLoadTable()
        {
            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_order_details"; // Select a table based on the department

                string searchValue = txtOrderDetailsSearch.Text.Trim();

                bool isPriceSearch = decimal.TryParse(searchValue, out decimal price);

                string query = $"SELECT * FROM `{tableName}` WHERE " +
                               "(`order_id` LIKE @search OR " +
                               "`product_id` LIKE @search";

                if (isPriceSearch)
                {
                    query += " OR `price` = @price";
                }

                query += ")";

                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@search", "%" + searchValue + "%");

                if (isPriceSearch)
                {
                    command.Parameters.AddWithValue("@price", price);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewOrderDetails.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from the order_details table: " + ex.Message);
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
                    Paragraph title = new Paragraph("Order Details Table Report", titleFont);
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

        // Updates the quantity of items in stock by subtracting the specified quantity.
        private void UpdateProductStock(int productId, int quantity)
        {
            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_product"; // Select a table based on the department

                // Checking the current stock level
                string checkStockQuery = $"SELECT stock_quantity FROM {tableName} WHERE ID = @productId";
                MySqlCommand checkStockCommand = new MySqlCommand(checkStockQuery, db.GetConnection());
                checkStockCommand.Parameters.AddWithValue("@productId", productId);

                int currentStock = Convert.ToInt32(checkStockCommand.ExecuteScalar());

                // Checking if there is enough stock
                if (currentStock < quantity)
                {
                    MessageBox.Show("We don't have enough stock for this order.");
                    return;
                }

                // Update the quantity of items in stock
                string updateQuery = $"UPDATE {tableName} SET stock_quantity = stock_quantity - @quantity WHERE ID = @productId";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, db.GetConnection());
                updateCommand.Parameters.AddWithValue("@quantity", quantity);
                updateCommand.Parameters.AddWithValue("@productId", productId);

                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating inventory levels: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Called when the value in a DataGridView cell changes.
        private void dataGridViewOrderDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check for changes in the values in the "product_id" or "quantity" columns
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridViewOrderDetails.Columns["product_id"].Index ||
                                     e.ColumnIndex == dataGridViewOrderDetails.Columns["quantity"].Index))
            {
                int orderDetailId = Convert.ToInt32(dataGridViewOrderDetails.Rows[e.RowIndex].Cells["ID"].Value);
                changedOrderDetailIds.Add(orderDetailId);

                // Update the price after changing the quantity or the product
                UpdatePriceForRow(e.RowIndex);
            }
        }

        // Updates the price value in the DataGridView row based on the product ID and quantity.
        private void UpdatePriceForRow(int rowIndex)
        {
            // Retrieve the product ID and quantity to calculate the new price
            int productId = Convert.ToInt32(dataGridViewOrderDetails.Rows[rowIndex].Cells["product_id"].Value);
            int quantity = Convert.ToInt32(dataGridViewOrderDetails.Rows[rowIndex].Cells["quantity"].Value);

            // Retrieve the price for this product from the database
            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_product"; // Select a table based on the department

                string query = $"SELECT price FROM {tableName} WHERE ID = @productId";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@productId", productId);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    decimal unitPrice = Convert.ToDecimal(result);

                    decimal totalPrice = unitPrice * quantity;
                    dataGridViewOrderDetails.Rows[rowIndex].Cells["price"].Value = totalPrice;
                }
                else
                {
                    MessageBox.Show("No product with this ID was found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving the product price: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Updates the total order amount in the `order` table in the database.
        private void UpdateOrderTotalAmount(int orderId, decimal totalPrice)
        {
            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_order"; // Select a table based on the department

                string query = $"UPDATE `{tableName}` SET total_amount = @totalAmount WHERE ID = @orderId";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                command.Parameters.AddWithValue("@totalAmount", totalPrice);
                command.Parameters.AddWithValue("@orderId", orderId);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the total amount in the order: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Event to update the price when the quantity changes
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdatePriceByProductId();
        }

        // Updated method for automatically updating the total price
        private void UpdatePriceByProductId()
        {
            if (int.TryParse(txtProductId.Text, out int productId))
            {
                try
                {
                    db.OpenConnection();

                    string tableName = $"{userDepartment}_product"; // Select a table based on the department

                    string query = $"SELECT price FROM {tableName} WHERE ID = @productId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@productId", productId);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        decimal unitPrice = Convert.ToDecimal(result);

                        int quantity = 1;
                        if (!string.IsNullOrEmpty(txtQuantity.Text) && int.TryParse(txtQuantity.Text, out int parsedQuantity))
                        {
                            quantity = parsedQuantity;
                        }

                        decimal totalPrice = unitPrice * quantity;

                        txtPrice.Text = totalPrice.ToString("F2");

                        if (int.TryParse(txtOrderId.Text, out int orderId))
                        {
                            UpdateOrderTotalAmount(orderId, totalPrice);
                        }
                    }
                    else
                    {
                        txtPrice.Text = string.Empty;
                        MessageBox.Show("No product with this ID was found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving the product price: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }


        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            UpdatePriceByProductId();
        }

        // Method for adding a new record to `order_details`
        private void OrderDetailsAdd()
        {
            // Check if all fields are filled in
            if (!string.IsNullOrEmpty(txtOrderId.Text) && !string.IsNullOrEmpty(txtProductId.Text) &&
                !string.IsNullOrEmpty(txtQuantity.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                int orderId = Convert.ToInt32(txtOrderId.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);

                if (!OrderExists(orderId))
                {
                    MessageBox.Show("The order ID does not exist.");
                    return;
                }

                try
                {
                    db.OpenConnection();

                    string tableName = $"{userDepartment}_product"; // Select a table based on the department

                    string tableName1 = $"{userDepartment}_order_details"; // Select a table based on the department

                    int productId = Convert.ToInt32(txtProductId.Text);
                    decimal price = Convert.ToDecimal(txtPrice.Text);

                    string checkStockQuery = $"SELECT stock_quantity FROM {tableName} WHERE ID = @productId";
                    MySqlCommand checkStockCommand = new MySqlCommand(checkStockQuery, db.GetConnection());
                    checkStockCommand.Parameters.AddWithValue("@productId", productId);

                    int currentStock = Convert.ToInt32(checkStockCommand.ExecuteScalar());

                    if (currentStock < quantity)
                    {
                        MessageBox.Show("We don't have enough stock for this order.");
                        return;
                    }

                    string query = $"INSERT INTO `{tableName1}` (order_id, product_id, quantity, price) " +
                                   "VALUES (@order_id, @product_id, @quantity, @price)";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                    command.Parameters.AddWithValue("@order_id", orderId);
                    command.Parameters.AddWithValue("@product_id", productId);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@price", price);

                    command.ExecuteNonQuery();

                    UpdateProductStock(productId, quantity);

                    MessageBox.Show("Your order details have been successfully added!");

                    OrderDetailsLoadTable(); // Update the table after adding
                    ClearOrderDetailFields();

                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Data format error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding order items: " + ex.Message);
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

        // Checks whether an order with the specified ID exists in the `order` table
        private bool OrderExists(int orderId)
        {
            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_order"; // Select a table based on the department

                string query = $"SELECT COUNT(*) FROM `{tableName}` WHERE ID = @orderId";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@orderId", orderId);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Method for updating the selected record in `order_details`
        private void OrderDetailsUpdate()
        {
            if (changedOrderDetailIds.Count == 0)
            {
                MessageBox.Show("No changes to save.");
                return;
            }

            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_order_details"; // Select a table based on the department

                foreach (int orderDetailId in changedOrderDetailIds)
                {
                    DataGridViewRow row = dataGridViewOrderDetails.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["ID"].Value) == orderDetailId);

                    if (row != null)
                    {
                        int orderId = Convert.ToInt32(row.Cells["order_id"].Value);
                        int productId = Convert.ToInt32(row.Cells["product_id"].Value);
                        int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                        decimal price = Convert.ToDecimal(row.Cells["price"].Value);

                        string query = $"UPDATE `{tableName}` SET " +
                                       "order_id = @order_id, " +
                                       "product_id = @product_id, " +
                                       "quantity = @quantity, " +
                                       "price = @price " +
                                       "WHERE ID = @orderDetailId";

                        MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                        command.Parameters.AddWithValue("@orderDetailId", orderDetailId);
                        command.Parameters.AddWithValue("@order_id", orderId);
                        command.Parameters.AddWithValue("@product_id", productId);
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@price", price);

                        command.ExecuteNonQuery();
                    }
                }

                changedOrderDetailIds.Clear();

                MessageBox.Show("The changes have been successfully saved!");
                OrderDetailsLoadTable();
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

        // Method for removing the selected record from `order_details`
        private void OrderDetailsDelete()
        {

            if (dataGridViewOrderDetails.SelectedRows.Count > 0)
            {
                int orderDetailId = Convert.ToInt32(dataGridViewOrderDetails.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    db.OpenConnection();

                    string tableName = $"{userDepartment}_order_details"; // Select a table based on the department

                    string query = $"DELETE FROM `{tableName}` WHERE ID = @orderDetailId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                    command.Parameters.AddWithValue("@orderDetailId", orderDetailId);

                    command.ExecuteNonQuery();

                    MessageBox.Show("The order details have been successfully deleted!");

                    OrderDetailsLoadTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting order items: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Please select the order details you wish to delete.");
            }
        }

        // Clears the text input fields associated with the order details.
        private void ClearOrderDetailFields()
        {
            txtOrderId.Clear();
            txtProductId.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
        }
    }
}