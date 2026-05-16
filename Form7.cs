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
    public partial class Form7 : Form
    {
        DB db = new DB();
        private HashSet<int> changedPaymentIds = new HashSet<int>(); // Saves the updated payment IDs

        private string userDepartment;
        public Form7(string department)
        {
            InitializeComponent();

            userDepartment = department;

            PaymentLoadTable();

            btnAddPayment.Click += (sender, e) => AddPayment();           // "Add Payment" button
            btnUpdatePayment.Click += (sender, e) => UpdatePayments();    // "Update Payment" button
            btnDeletePayment.Click += (sender, e) => DeletePayment();     // "Delete Payment" button
            btnClearPayment.Click += (sender, e) => ClearPaymentFields(); // "Clear Fields" button
            btnPrintPayment.Click += (sender, e) =>
            {
                string selectedFormat = comboExportFormat4.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedFormat))
                {
                    MessageBox.Show("Please select an export format (PDF or Excel).", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedFormat == "PDF")
                {
                    ExportToPdf(dataGridPayments, "Report_Order.pdf");
                }
                else if (selectedFormat == "Excel")
                {
                    ExportToExcel(dataGridPayments, "Report_Order.xlsx");
                }
                else
                {
                    MessageBox.Show("Unknown export format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            dataGridPayments.CellValueChanged += dataGridPayments_CellValueChanged;

            txtPaymentSearch.TextChanged += (sender, e) => PaymentLoadTable();

            if (ThemeManager.IsDarkTheme)
                ThemeManager.ApplyDarkTheme(this);
            else
                ThemeManager.ApplyLightTheme(this);
        }

        // Loading the payment table from the database
        private void PaymentLoadTable()
        {
            try
            {
                db.OpenConnection();

                string tableName = $"admin_payment";

                string userInput = txtPaymentSearch.Text.Trim();
                bool isExactAmountSearch = decimal.TryParse(userInput, out decimal amount);
                bool isExactDateSearch = DateTime.TryParseExact(userInput, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime paymentDate);
                bool isExactIdSearch = int.TryParse(userInput, out int id);
                bool isExactOrderIdentifierSearch = int.TryParse(userInput, out int orderIdentifier);

                string query = $"SELECT * FROM `{tableName}`";

                if (!string.IsNullOrEmpty(userInput))
                {
                    query += " WHERE ";

                    if (isExactIdSearch)
                        query += "`ID` = @id ";
                    else
                        query += "`ID` LIKE @searchTerm ";

                    query += "OR ";

                    if (isExactOrderIdentifierSearch)
                        query += "`order_id` = @orderIdentifier ";
                    else
                        query += "`order_id` LIKE @searchTerm ";

                    query += "OR ";

                    if (isExactDateSearch)
                        query += "`payment_date` = @paymentDate ";
                    else
                        query += "`payment_date` LIKE @searchTerm ";

                    query += "OR ";

                    if (isExactAmountSearch)
                        query += "`payment_amount` = @amount ";
                    else
                        query += "`payment_amount` LIKE @searchTerm ";
                }

                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                if (!string.IsNullOrEmpty(userInput))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + userInput + "%");

                    if (isExactIdSearch)
                        command.Parameters.AddWithValue("@id", id);

                    if (isExactOrderIdentifierSearch)
                        command.Parameters.AddWithValue("@orderIdentifier", orderIdentifier);

                    if (isExactDateSearch)
                        command.Parameters.AddWithValue("@paymentDate", paymentDate);

                    if (isExactAmountSearch)
                        command.Parameters.AddWithValue("@amount", amount);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridPayments.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from the payment table: " + ex.Message);
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
                    Paragraph title = new Paragraph("Payments Table Report", titleFont);
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

        // Calculating the total amount for the order, taking the department into account
        private decimal CalculateTotalAmount(int orderId, string department)
        {
            decimal totalAmount = 0;
            try
            {
                db.OpenConnection();

                string query = "SELECT total_amount FROM admin_order " +
                               "WHERE order_id = @orderId AND department = @department";

                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@orderId", orderId);
                command.Parameters.AddWithValue("@department", department);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    totalAmount = Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating the total order amount: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
            return totalAmount;
        }

        // Update the payment amount based on the department
        private void UpdatePaymentTotalAmount(int orderId, string department, decimal newTotalAmount)
        {
            try
            {
                db.OpenConnection();

                string tableName = "admin_payment";

                string query = $"UPDATE {tableName} SET payment_amount = @newTotalAmount " +
                               "WHERE order_id = @orderId AND department = @department";

                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@newTotalAmount", newTotalAmount);
                command.Parameters.AddWithValue("@orderId", orderId);
                command.Parameters.AddWithValue("@department", department);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the total amount: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Event for changing the value in a DataGrid cell
        private void dataGridPayments_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int paymentId = Convert.ToInt32(dataGridPayments.Rows[e.RowIndex].Cells["ID"].Value);
                changedPaymentIds.Add(paymentId);
            }
        }

        // Add a new payment
        private void AddPayment()
        {
            if (string.IsNullOrWhiteSpace(txtPaymentOrderId?.Text) ||
                string.IsNullOrWhiteSpace(txtPaymentStatus?.Text) ||
                string.IsNullOrWhiteSpace(comboBoxDepartment?.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            try
            {
                db.OpenConnection();

                string department = comboBoxDepartment.SelectedItem?.ToString();

                string tableName = $"admin_payment";

                string query = $"INSERT INTO {tableName} (order_id, department, payment_amount, payment_date, payment_status) " +
                               "VALUES (@orderId, @department, @paymentAmount, @paymentDate, @paymentStatus)";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                command.Parameters.AddWithValue("@orderId", Convert.ToInt32(txtPaymentOrderId.Text));
                command.Parameters.AddWithValue("@department", department);
                command.Parameters.AddWithValue("@paymentAmount", 0);
                command.Parameters.AddWithValue("@paymentDate", DateTime.Now);
                command.Parameters.AddWithValue("@paymentStatus", txtPaymentStatus.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("The payment has been successfully added!");

                decimal totalAmount = CalculateTotalAmount(Convert.ToInt32(txtPaymentOrderId.Text), department);
                UpdatePaymentTotalAmount(Convert.ToInt32(txtPaymentOrderId.Text), department, totalAmount);

                PaymentLoadTable();
                ClearPaymentFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding a payment: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Update payments in the table
        private void UpdatePayments()
        {
            if (changedPaymentIds.Count == 0)
            {
                MessageBox.Show("No changes to save.");
                return;
            }

            try
            {
                db.OpenConnection();

                string tableName = $"admin_payment";

                foreach (int paymentId in changedPaymentIds)
                {
                    DataGridViewRow row = dataGridPayments.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["ID"].Value) == paymentId);

                    if (row != null)
                    {
                        string query = $"UPDATE {tableName} SET order_id = @orderId, " +
                                       "payment_amount = @amount, payment_date = @paymentDate, payment_status = @paymentStatus WHERE ID = @paymentId";
                        MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                        command.Parameters.AddWithValue("@paymentId", paymentId);
                        command.Parameters.AddWithValue("@orderId", Convert.ToInt32(row.Cells["order_id"].Value));
                        command.Parameters.AddWithValue("@amount", Convert.ToDecimal(row.Cells["payment_amount"].Value));
                        command.Parameters.AddWithValue("@paymentDate", DateTime.Now);
                        command.Parameters.AddWithValue("@paymentStatus", row.Cells["payment_status"].Value.ToString());

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("The changes have been successfully saved!");
                changedPaymentIds.Clear();
                PaymentLoadTable();
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

        // Deleting a payment from the table
        private void DeletePayment()
        {
            if (dataGridPayments.SelectedRows.Count > 0)
            {
                int paymentId = Convert.ToInt32(dataGridPayments.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    db.OpenConnection();

                    string tableName = $"admin_payment";

                    string query = $"DELETE FROM {tableName} WHERE ID = @paymentId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@paymentId", paymentId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("The payment has been successfully deleted!");

                    PaymentLoadTable();
                    ClearPaymentFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting a payment: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Please select a payment method for deletion.");
            }
        }

        // Clearing the input fields
        private void ClearPaymentFields()
        {
            txtPaymentOrderId.Clear();
            txtPaymentStatus.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridPayments.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dataGridPayments.SelectedRows[0].Cells["order_id"].Value);

                string department = comboBoxDepartment.SelectedItem?.ToString();

                decimal newTotalAmount = CalculateTotalAmount(orderId, department);

                UpdatePaymentTotalAmount(orderId, department, newTotalAmount);

                PaymentLoadTable();

                MessageBox.Show("The order price has been updated!");
            }
            else
            {
                MessageBox.Show("Please select an order to update the price.");
            }
        }
    }
}