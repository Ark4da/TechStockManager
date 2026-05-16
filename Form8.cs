using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using ClosedXML.Excel;
using System.Windows.Forms;

namespace TechStockManager
{
    public partial class Form8 : Form
    {
        DB db = new DB();

        private string userDepartment;
        public Form8(string department)
        {
            InitializeComponent();

            userDepartment = department;

            CustomerLoadTable();

            btnAddCustomer.Click += (sender, e) => AddCustomer();
            btnUpdateCustomer.Click += (sender, e) => UpdateCustomer();
            btnDeleteCustomer.Click += (sender, e) => DeleteCustomer();
            btnClearCustomer.Click += (sender, e) => ClearCustomerFields();
            btnPrintCustomers.Click += (sender, e) =>
            {
                string selectedFormat = comboExportFormat5.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedFormat))
                {
                    MessageBox.Show("Please select an export format (PDF or Excel).", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedFormat == "PDF")
                {
                    ExportToPdf(dataGridCustomers, "Report_Order.pdf");
                }
                else if (selectedFormat == "Excel")
                {
                    ExportToExcel(dataGridCustomers, "Report_Order.xlsx");
                }
                else
                {
                    MessageBox.Show("Unknown export format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            txtClientSearch.TextChanged += (sender, e) => SearchCustomers();

            if (ThemeManager.IsDarkTheme)
                ThemeManager.ApplyDarkTheme(this);
            else
                ThemeManager.ApplyLightTheme(this);
        }

        // Loading customer data from the database into a table
        private void CustomerLoadTable()
        {
            try
            {
                db.OpenConnection();

                string tableName = $"admin_customer";

                if (userDepartment != "admin")
                {
                    label27.Visible = false;
                    label26.Visible = false;
                    label25.Visible = false;
                    label24.Visible = false;
                    txtFullName.Visible = false;
                    txtEmail.Visible = false;
                    txtPhone.Visible = false;
                    txtDeliveryAddress.Visible = false;
                    btnClearCustomer.Visible = false;
                    btnAddCustomer.Visible = false;
                    btnDeleteCustomer.Visible = false;
                    btnUpdateCustomer.Visible = false;
                    dataGridCustomers.ReadOnly = true;
                }

                string query = $"SELECT * FROM {tableName}";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridCustomers.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the customer table: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Adding a new client
        private void AddCustomer()
        {
            if (string.IsNullOrWhiteSpace(txtFullName?.Text) ||
                string.IsNullOrWhiteSpace(txtEmail?.Text) ||
                string.IsNullOrWhiteSpace(txtPhone?.Text) ||
                string.IsNullOrWhiteSpace(txtDeliveryAddress?.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }
            try
            {
                db.OpenConnection();

                string tableName = $"admin_customer";

                string query = $"INSERT INTO {tableName} (store_name, Email, phone, delivery_address) " +
                               "VALUES (@fullName, @email, @phone, @deliveryAddress)";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                command.Parameters.AddWithValue("@fullName", txtFullName.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@deliveryAddress", txtDeliveryAddress.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("The client has been successfully added!");

                CustomerLoadTable();
                ClearCustomerFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding a client: " + ex.Message);
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

                    string arialFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    BaseFont baseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 11, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                    Paragraph title = new Paragraph("Customers Table Report", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 10f;
                    document.Add(title);

                    PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count)
                    {
                        WidthPercentage = 100,
                        SpacingBefore = 10f
                    };

                    float[] columnWidths = new float[dataGridView.Columns.Count];
                    for (int i = 0; i < columnWidths.Length; i++)
                        columnWidths[i] = 1f;
                    pdfTable.SetWidths(columnWidths);

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

                    var selectedRows = dataGridView.SelectedRows.Count > 0
                        ? dataGridView.SelectedRows.Cast<DataGridViewRow>().OrderBy(r => r.Index)
                        : dataGridView.Rows.Cast<DataGridViewRow>();

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

                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dataGridView.Columns[col].HeaderText;
                            worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                            worksheet.Column(col + 1).AdjustToContents();
                        }

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

        // Update customer information
        private void UpdateCustomer()
        {
            if (dataGridCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a client to update.");
                return;
            }

            List<int> changedCustomerIds = new List<int>();

            try
            {
                db.OpenConnection();

                string tableName = $"admin_customer";

                foreach (DataGridViewRow selectedRow in dataGridCustomers.SelectedRows)
                {
                    int customerId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    changedCustomerIds.Add(customerId);

                    string query = $"UPDATE {tableName} SET store_name = @fullName, Email = @email, phone = @phone, " +
                                   "delivery_address = @deliveryAddress WHERE ID = @customerId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@fullName", selectedRow.Cells["store_name"].Value.ToString());
                    command.Parameters.AddWithValue("@email", selectedRow.Cells["Email"].Value.ToString());
                    command.Parameters.AddWithValue("@phone", selectedRow.Cells["phone"].Value.ToString());
                    command.Parameters.AddWithValue("@deliveryAddress", selectedRow.Cells["delivery_address"].Value.ToString());

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("The changes have been successfully saved!");
                changedCustomerIds.Clear();
                CustomerLoadTable();
                ClearCustomerFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the client: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Deleting a client
        private void DeleteCustomer()
        {
            if (dataGridCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dataGridCustomers.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    db.OpenConnection();

                    string tableName = $"admin_customer";

                    string query = $"DELETE FROM {tableName} WHERE ID = @customerId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@customerId", customerId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("The client has been successfully removed!");

                    CustomerLoadTable();
                    ClearCustomerFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting a client: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Please select a client to delete.");
            }
        }

        // Find customers
        private void SearchCustomers()
        {
            try
            {
                db.OpenConnection();

                string tableName = $"admin_customer";

                string query = $"SELECT * FROM {tableName} WHERE 1=1";
                bool hasCondition = false;

                if (!string.IsNullOrWhiteSpace(txtClientSearch.Text))
                {
                    query += " AND (ID = @customerId OR store_name LIKE @fullName)";
                    hasCondition = true;
                }

                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                if (hasCondition)
                {
                    command.Parameters.AddWithValue("@fullName", "%" + txtClientSearch.Text + "%");
                    if (int.TryParse(txtClientSearch.Text, out int customerId))
                        command.Parameters.AddWithValue("@customerId", customerId);
                    else
                        command.Parameters.AddWithValue("@customerId", null);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridCustomers.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching for customers: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Clearing form fields
        private void ClearCustomerFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtDeliveryAddress.Clear();
        }
    }
}