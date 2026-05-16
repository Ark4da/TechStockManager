using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using MySqlX.XDevAPI;
using DocumentFormat.OpenXml.Bibliography;

namespace TechStockManager
{
    public partial class Form3 : Form
    {
        DB db = new DB();
        private HashSet<int> changedRowIds = new HashSet<int>(); // Using HashSet to avoid duplicate IDs
        private string userDepartment;
        public Form3(string department)
        {
            InitializeComponent();

            userDepartment = department;

            OrdersLoadTable();

            btnAdd.Click += (sender, e) => OrdersAdd();
            btnDelete.Click += (sender, e) => OrdersDelete();
            btnUpdate.Click += (sender, e) => OrdersUpdate(userDepartment);
            btnClearOrder.Click += (sender, e) => ClearOrderFields();
            btnPrintOrder.Click += (sender, e) =>
            {
                string selectedFormat = comboExportFormat.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedFormat))
                {
                    MessageBox.Show("Please select an export format (PDF or Excel).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedFormat == "PDF")
                {
                    ExportToPdf(dataGridView1, "Report_Order.pdf");
                }
                else if (selectedFormat == "Excel")
                {
                    ExportToExcel(dataGridView1, "Report_Order.xlsx");
                }
                else
                {
                    MessageBox.Show("Unknown export format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };


            if (ThemeManager.IsDarkTheme)
                ThemeManager.ApplyDarkTheme(this);
            else
                ThemeManager.ApplyLightTheme(this);

            txtOrderSearch.TextChanged += (sender, e) => OrdersLoadTable(txtOrderSearch.Text.Trim());

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

        }

        private void OrdersLoadTable(string searchTerm = "")
        {
            try
            {
                // Opening database connection
                db.OpenConnection();

                // Getting search text and trimming spaces
                string userInput = txtOrderSearch.Text.Trim();

                // Checking if input can be interpreted as a number (Order ID)
                bool isExactIdSearch = int.TryParse(userInput, out int orderId);

                // Creating a new table to store query results
                DataTable dataTable = new DataTable();
                MySqlCommand command;

                // If searching by specific ID, add WHERE condition
                string whereClause = isExactIdSearch ? " WHERE order_id = @orderId" : "";

                // If user is administrator, create query for all departments
                if (userDepartment == "admin")
                {
                    label1.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    txtCustomerId.Visible = false;
                    txtDeliveryDate.Visible = false;
                    txtStatus.Visible = false;
                    btnAdd.Visible = false;
                    btnClearOrder.Visible = false;
                    string query = $@"
SELECT * FROM (
    SELECT 'computer' AS department, o.ID AS order_id, o.customer_id, o.order_date, o.total_amount, o.status, o.delivery_date, 
        GROUP_CONCAT(CONCAT('(', d.product_id, ') ', p.name, ' x', d.quantity) SEPARATOR ', ') AS items
    FROM computer_order o
    LEFT JOIN computer_order_details d ON o.ID = d.order_id
    LEFT JOIN computer_product p ON d.product_id = p.ID
    GROUP BY o.ID

    UNION ALL

    SELECT 'mobile', o.ID AS order_id, o.customer_id, o.order_date, o.total_amount, o.status, o.delivery_date, 
        GROUP_CONCAT(CONCAT('(', d.product_id, ') ', p.name, ' x', d.quantity) SEPARATOR ', ') AS items
    FROM mobile_order o
    LEFT JOIN mobile_order_details d ON o.ID = d.order_id
    LEFT JOIN mobile_product p ON d.product_id = p.ID
    GROUP BY o.ID

    UNION ALL

    SELECT 'audio', o.ID AS order_id, o.customer_id, o.order_date, o.total_amount, o.status, o.delivery_date, 
        GROUP_CONCAT(CONCAT('(', d.product_id, ') ', p.name, ' x', d.quantity) SEPARATOR ', ') AS items
    FROM audio_order o
    LEFT JOIN audio_order_details d ON o.ID = d.order_id
    LEFT JOIN audio_product p ON d.product_id = p.ID
    GROUP BY o.ID

    UNION ALL

    SELECT 'peripheral', o.ID AS order_id, o.customer_id, o.order_date, o.total_amount, o.status, o.delivery_date, 
        GROUP_CONCAT(CONCAT('(', d.product_id, ') ', p.name, ' x', d.quantity) SEPARATOR ', ') AS items
    FROM peripheral_order o
    LEFT JOIN peripheral_order_details d ON o.ID = d.order_id
    LEFT JOIN peripheral_product p ON d.product_id = p.ID
    GROUP BY o.ID

    UNION ALL

    SELECT 'television', o.ID AS order_id, o.customer_id, o.order_date, o.total_amount, o.status, o.delivery_date, 
        GROUP_CONCAT(CONCAT('(', d.product_id, ') ', p.name, ' x', d.quantity) SEPARATOR ', ') AS items
    FROM television_order o
    LEFT JOIN television_order_details d ON o.ID = d.order_id
    LEFT JOIN television_product p ON d.product_id = p.ID
    GROUP BY o.ID
) AS combined_orders" + whereClause + @"
ORDER BY order_date DESC;";

                    // Create a command with a pre-built SQL query
                    command = new MySqlCommand(query, db.GetConnection());
                }
                else
                {
                    // If user belongs to a specific department, create query for corresponding tables
                    string tableName = $"{userDepartment}_order";
                    string detailsTable = $"{userDepartment}_order_details";
                    string productTable = $"{userDepartment}_product";

                    string query = $@"
SELECT o.ID AS order_id, o.customer_id, o.order_date, o.total_amount, o.status, o.delivery_date, 
    GROUP_CONCAT(CONCAT('(', d.product_id, ') ', p.name, ' x', d.quantity) SEPARATOR ', ') AS items
FROM {tableName} o
LEFT JOIN {detailsTable} d ON o.ID = d.order_id
LEFT JOIN {productTable} p ON d.product_id = p.ID
{whereClause}
GROUP BY o.ID
ORDER BY o.order_date DESC;";

                    // Creating a team for the department
                    command = new MySqlCommand(query, db.GetConnection());
                }

                // If searching by exact ID, add parameter for SQL injection protection
                if (isExactIdSearch)
                {
                    command.Parameters.AddWithValue("@orderId", orderId);
                }

                // Executing query and filling DataTable with results
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                // Setting received data as DataGridView source
                dataGridView1.DataSource = dataTable;

                // Clearing list of changed rows
                changedRowIds.Clear();

                // If administrator, perform additional order processing
                if (userDepartment == "admin")
                {
                    SaveOrdersToAdminOrder(dataTable);
                }
            }
            catch (Exception ex)
            {
                // Display error message if exception occurs
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                // Always close database connection
                db.CloseConnection();
            }
        }

        private void SaveOrdersToAdminOrder(DataTable dataTable)
        {
            try
            {
                db.OpenConnection();

                foreach (DataRow row in dataTable.Rows)
                {
                    // Reading order ID and department from current row
                    string orderId = row["order_id"].ToString();
                    string department = row["department"].ToString();

                    // Checking if order already exists in admin_order table (to avoid duplicates)
                    string checkQuery = "SELECT COUNT(*) FROM admin_order WHERE order_id = @order_id AND department = @department;";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, db.GetConnection());
                    checkCommand.Parameters.AddWithValue("@order_id", orderId);
                    checkCommand.Parameters.AddWithValue("@department", department);

                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    // If record does not exist, insert new record
                    if (count == 0)
                    {
                        string insertQuery = @"
            INSERT INTO admin_order 
            (order_id, department, customer_id, order_date, total_amount, status, delivery_date, items) 
            VALUES 
            (@order_id, @department, @customer_id, @order_date, @total_amount, @status, @delivery_date, @items);";

                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, db.GetConnection());

                        // Binding parameters for insertion, converting types according to database
                        insertCommand.Parameters.AddWithValue("@order_id", Convert.ToInt32(row["order_id"]));
                        insertCommand.Parameters.AddWithValue("@department", row["department"].ToString());
                        insertCommand.Parameters.AddWithValue("@customer_id", Convert.ToInt32(row["customer_id"]));
                        insertCommand.Parameters.AddWithValue("@order_date", Convert.ToDateTime(row["order_date"]));
                        insertCommand.Parameters.AddWithValue("@total_amount", Convert.ToDecimal(row["total_amount"]));
                        insertCommand.Parameters.AddWithValue("@status", row["status"].ToString());
                        insertCommand.Parameters.AddWithValue("@delivery_date", Convert.ToDateTime(row["delivery_date"]));
                        insertCommand.Parameters.AddWithValue("@items", row["items"].ToString());

                        // Executing insertion of new record into table
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data to admin_order table: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }


        // Updates total order amount in the database
        public void UpdateOrderTotalAmount(string userDepartment, int orderId, decimal totalPrice)
        {
            try
            {
                db.OpenConnection();

                // Generating table name based on user department
                string tableName = $"{userDepartment}_order";

                // Updating total order amount in database
                string query = $"UPDATE `{tableName}` SET total_amount = @totalAmount WHERE ID = @orderId";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@totalAmount", totalPrice);
                command.Parameters.AddWithValue("@orderId", orderId);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating total order amount: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }



        // Method for calculating total order amount considering userDepartment
        private decimal CalculateTotalAmount(int orderId, string userDepartment)
        {
            // If user is administrator, skip calculation
            if (userDepartment.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            decimal totalAmount = 0;
            string tableName = $"{userDepartment}_order_details"; // Generating table name

            try
            {
                db.OpenConnection();
                string query = $"SELECT SUM(price) FROM `{tableName}` WHERE order_id = @orderId";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@orderId", orderId);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    totalAmount = Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total order amount in table {tableName}:\n{ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }

            return totalAmount;
        }


        // Tracks changes in the table
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["order_id"].Value);
                changedRowIds.Add(orderId);
            }
        }

        // Updates database based on table changes
        private void OrdersUpdate(string userDepartment)
        {
            if (changedRowIds.Count == 0)
            {
                MessageBox.Show("No changes to save.");
                return;
            }

            try
            {
                db.OpenConnection();

                foreach (int orderId in changedRowIds)
                {
                    DataGridViewRow row = dataGridView1.Rows
                        .Cast<DataGridViewRow>()
                        .FirstOrDefault(r => Convert.ToInt32(r.Cells["order_id"].Value) == orderId);

                    if (row != null)
                    {
                        // Determine the table name based on userDepartment, and if the user is an admin, retrieve it from the Department column
                        string tableName;

                        if (userDepartment == "admin")
                        {
                            string department1 = dataGridView1.SelectedRows[0].Cells["department"].Value.ToString().ToLower().Trim();
                            tableName = $"{department1}_order";
                        }
                        else
                        {
                            tableName = $"{userDepartment}_order";
                        }

                        int customerId = row.Cells["customer_id"].Value != DBNull.Value
                            ? Convert.ToInt32(row.Cells["customer_id"].Value) : 0;
                        DateTime orderDate = row.Cells["order_date"].Value != DBNull.Value
                            ? Convert.ToDateTime(row.Cells["order_date"].Value) : DateTime.MinValue;
                        decimal totalAmount = row.Cells["total_amount"].Value != DBNull.Value
                            ? Convert.ToDecimal(row.Cells["total_amount"].Value) : 0;
                        string status = row.Cells["status"].Value != DBNull.Value
                            ? row.Cells["status"].Value.ToString() : "Unknown";
                        DateTime deliveryDate = row.Cells["delivery_date"].Value != DBNull.Value
                            ? Convert.ToDateTime(row.Cells["delivery_date"].Value) : DateTime.MinValue;

                        string query = $"UPDATE `{tableName}` SET " +
                                       "`customer_id` = @customer_id, " +
                                       "`order_date` = @order_date, " +
                                       "`total_amount` = @total_amount, " +
                                       "`status` = @status, " +
                                       "`delivery_date` = @delivery_date " +
                                       $"WHERE `ID` = @orderId";

                        using (MySqlCommand command = new MySqlCommand(query, db.GetConnection()))
                        {
                            command.Parameters.AddWithValue("@orderId", orderId);
                            command.Parameters.AddWithValue("@customer_id", customerId);
                            command.Parameters.AddWithValue("@order_date", orderDate);
                            command.Parameters.AddWithValue("@total_amount", totalAmount);
                            command.Parameters.AddWithValue("@status", status);
                            command.Parameters.AddWithValue("@delivery_date", deliveryDate);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Changes saved successfully!");
                changedRowIds.Clear();
                OrdersLoadTable();
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

        // Exports table data to PDF
        private void ExportToPdf(DataGridView dataGridView, string filename)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4.Rotate(), 10, 10, 10, 10);

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Save report as PDF",
                    FileName = filename
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Loading Arial font
                    string arialFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    BaseFont baseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 11, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                    // Adding title
                    Paragraph title = new Paragraph("Orders Table Report", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 10f;
                    document.Add(title);

                    // Creating PDF table
                    PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count)
                    {
                        WidthPercentage = 100,
                        SpacingBefore = 10f
                    };

                    // Setting column widths
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

                    // Checking if rows are selected
                    var selectedRows = dataGridView.SelectedRows.Count > 0
                        ? dataGridView.SelectedRows.Cast<DataGridViewRow>().OrderBy(r => r.Index)
                        : dataGridView.Rows.Cast<DataGridViewRow>();

                    // Adding data
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
                    MessageBox.Show("Report saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Title = "Save report as Excel",
                FileName = filename + ".xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Report");

                        // Adding headers
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dataGridView.Columns[col].HeaderText;
                            worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                            worksheet.Column(col + 1).AdjustToContents();
                        }

                        // Checking if rows are selected
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
                        MessageBox.Show("Report saved in Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // Adds a new order to the database
        private void OrdersAdd()
        {
            // Checking if all required fields are filled
            if (string.IsNullOrEmpty(txtCustomerId?.Text) || string.IsNullOrEmpty(txtStatus?.Text) || string.IsNullOrEmpty(txtDeliveryDate?.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Checking if customer ID is numeric
            if (!int.TryParse(txtCustomerId.Text, out int customerId))
            {
                MessageBox.Show("Customer ID must be a number.");
                return;
            }

            // Checking if delivery date is valid
            if (!DateTime.TryParse(txtDeliveryDate.Text, out DateTime deliveryDate))
            {
                MessageBox.Show("Invalid delivery date format.");
                return;
            }

            try
            {
                db.OpenConnection();
                DateTime orderDate = DateTime.Now;

                string tableName = $"{userDepartment}_order"; // Dynamic table name

                string query = $"INSERT INTO `{tableName}` (`customer_id`, `order_date`, `total_amount`, `status`, `delivery_date`) " +
                               "VALUES (@customer_id, @order_date, '000', @status, @delivery_date)";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                command.Parameters.AddWithValue("@customer_id", customerId);
                command.Parameters.AddWithValue("@order_date", orderDate);
                command.Parameters.AddWithValue("@status", txtStatus.Text);
                command.Parameters.AddWithValue("@delivery_date", deliveryDate);

                command.ExecuteNonQuery();

                MessageBox.Show("Order added successfully!");

                OrdersLoadTable();
                ClearOrderFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding order: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }


        // Deletes selected order
        private void OrdersDelete()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an order to delete.");
                return;
            }

            int orderId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["order_id"].Value);
            string tableName;

            if (userDepartment == "admin")
            {
                // Extracting department name from table
                string department1 = dataGridView1.SelectedRows[0].Cells["department"].Value.ToString().ToLower().Trim();
                tableName = $"{department1}_order";
                if (string.IsNullOrEmpty(department1))
                {
                    MessageBox.Show("Unknown Department: " + department1);
                    return;
                }

            }
            else
            {
                // For regular user — deleting from their department table
                tableName = $"{userDepartment}_order";
            }

            // Deletion confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to delete this order?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                db.OpenConnection();

                string query = $"DELETE FROM `{tableName}` WHERE ID = @orderId";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@orderId", orderId);

                command.ExecuteNonQuery();

                MessageBox.Show("Order deleted successfully!");

                OrdersLoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting order: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }


        // Clears form fields
        private void ClearOrderFields()
        {
            txtCustomerId.Clear();
            txtStatus.Clear();
            txtDeliveryDate.Clear();
        }

        // Updates total amount for selected order
        private void BtnUpdatePrice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["order_id"].Value);

                // Make sure userDepartment contains a value
                if (string.IsNullOrEmpty(userDepartment))
                {
                    MessageBox.Show("The user's department is not specified!");
                    return;
                }

                decimal newTotalAmount = CalculateTotalAmount(orderId, userDepartment);

                UpdateOrderTotalAmount(userDepartment, orderId, newTotalAmount);

                // Refreshing table to display changes
                OrdersLoadTable();

                MessageBox.Show("Order updated!");
            }
            else
            {
                MessageBox.Show("Please select an order to update.");
            }
        }

    }
}