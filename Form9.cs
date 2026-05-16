using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using ClosedXML.Excel;
using System.Windows.Forms;

namespace TechStockManager
{
    public partial class Form9 : Form
    {
        DB db = new DB();

        private string userDepartment;
        public Form9(string department)
        {
            InitializeComponent();

            userDepartment = department;

            ManufacturerLoadTable();

            btnAddManufacturer.Click += (sender, e) => AddManufacturer();
            btnUpdateManufacturer.Click += (sender, e) => UpdateManufacturer();
            btnDeleteManufacturer.Click += (sender, e) => DeleteManufacturer();
            btnClearManufacturer.Click += (sender, e) => ClearManufacturerFields();
            btnPrintManufacturer.Click += (sender, e) =>
            {
                string selectedFormat = comboExportFormat6.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedFormat))
                {
                    MessageBox.Show("Please select an export format (PDF or Excel).", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedFormat == "PDF")
                {
                    ExportToPdf(dataGridManufacturers, "Report_Order.pdf");
                }
                else if (selectedFormat == "Excel")
                {
                    ExportToExcel(dataGridManufacturers, "Report_Order.xlsx");
                }
                else
                {
                    MessageBox.Show("Unknown export format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            txtManufacturerSearch.TextChanged += (sender, e) => SearchManufacturers();

            if (ThemeManager.IsDarkTheme)
                ThemeManager.ApplyDarkTheme(this);
            else
                ThemeManager.ApplyLightTheme(this);
        }

        // Loading manufacturer data into the table
        private void ManufacturerLoadTable()
        {
            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_manufacturer";

                string query = $"SELECT * FROM {tableName}";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (userDepartment == "admin")
                {
                    label23.Visible = false;
                    label18.Visible = false;
                    txtManufacturerName.Visible = false;
                    txtCountry.Visible = false;
                    btnClearManufacturer.Visible = false;
                    btnAddManufacturer.Visible = false;
                    btnDeleteManufacturer.Visible = false;
                    btnUpdateManufacturer.Visible = false;
                    dataGridManufacturers.ReadOnly = true;
                }

                dataGridManufacturers.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the list of manufacturers: " + ex.Message);
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

                    Paragraph title = new Paragraph("Manufacturers Table Report", titleFont);
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

        // Adding a new manufacturer
        private void AddManufacturer()
        {
            if (string.IsNullOrWhiteSpace(txtManufacturerName?.Text) ||
                string.IsNullOrWhiteSpace(txtCountry?.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }
            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_manufacturer";

                string query = $"INSERT INTO {tableName} (manufacturer_name, country) VALUES (@manufacturerName, @country)";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                command.Parameters.AddWithValue("@manufacturerName", txtManufacturerName.Text);
                command.Parameters.AddWithValue("@country", txtCountry.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("The manufacturer has been successfully added!");

                ManufacturerLoadTable();
                ClearManufacturerFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding a manufacturer: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Remove manufacturer
        private void DeleteManufacturer()
        {
            if (dataGridManufacturers.SelectedRows.Count > 0)
            {
                int manufacturerId = Convert.ToInt32(dataGridManufacturers.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    db.OpenConnection();

                    string tableName = $"{userDepartment}_manufacturer";

                    string query = $"DELETE FROM {tableName} WHERE ID = @manufacturerId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@manufacturerId", manufacturerId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("The manufacturer has been successfully removed!");

                    ManufacturerLoadTable();
                    ClearManufacturerFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while removing the manufacturer: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Please select a manufacturer to delete.");
            }
        }

        // Update manufacturer data
        private void UpdateManufacturer()
        {
            if (dataGridManufacturers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a manufacturer to update.");
                return;
            }

            List<int> changedManufacturerIds = new List<int>();

            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_manufacturer";

                foreach (DataGridViewRow selectedRow in dataGridManufacturers.SelectedRows)
                {
                    int manufacturerId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    changedManufacturerIds.Add(manufacturerId);

                    string currentManufacturerName;
                    string currentCountry;

                    using (MySqlCommand getManufacturerCommand = new MySqlCommand($"SELECT manufacturer_name, country FROM {tableName} WHERE ID = @manufacturerId", db.GetConnection()))
                    {
                        getManufacturerCommand.Parameters.AddWithValue("@manufacturerId", manufacturerId);
                        using (MySqlDataReader reader = getManufacturerCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentManufacturerName = reader["manufacturer_name"].ToString();
                                currentCountry = reader["country"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No manufacturer found.");
                                return;
                            }
                        }
                    }

                    string query = $"UPDATE {tableName} SET manufacturer_name = @manufacturerName, country = @country WHERE ID = @manufacturerId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                    command.Parameters.AddWithValue("@manufacturerId", manufacturerId);
                    command.Parameters.AddWithValue("@manufacturerName",
                        string.IsNullOrWhiteSpace(selectedRow.Cells["manufacturer_name"].Value.ToString()) ? currentManufacturerName : selectedRow.Cells["manufacturer_name"].Value.ToString());
                    command.Parameters.AddWithValue("@country",
                        string.IsNullOrWhiteSpace(selectedRow.Cells["country"].Value.ToString()) ? currentCountry : selectedRow.Cells["country"].Value.ToString());

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("The changes have been successfully saved!");
                changedManufacturerIds.Clear();
                ManufacturerLoadTable();
                ClearManufacturerFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the manufacturer: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Clearing the input fields
        private void ClearManufacturerFields()
        {
            txtManufacturerName.Clear();
            txtCountry.Clear();
            txtManufacturerSearch.Clear();
        }

        // Search for manufacturers
        private void SearchManufacturers()
        {
            try
            {
                db.OpenConnection();

                string tableName = $"{userDepartment}_manufacturer";

                string query = $"SELECT * FROM {tableName} WHERE 1=1";
                bool hasCondition = false;

                if (!string.IsNullOrWhiteSpace(txtManufacturerSearch.Text))
                {
                    query += " AND (ID = @manufacturerId OR manufacturer_name LIKE @manufacturerName OR country LIKE @country)";
                    hasCondition = true;
                }

                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                if (hasCondition)
                {
                    command.Parameters.AddWithValue("@manufacturerName", "%" + txtManufacturerSearch.Text + "%");
                    command.Parameters.AddWithValue("@country", "%" + txtManufacturerSearch.Text + "%");

                    if (int.TryParse(txtManufacturerSearch.Text, out int manufacturerId))
                        command.Parameters.AddWithValue("@manufacturerId", manufacturerId);
                    else
                        command.Parameters.AddWithValue("@manufacturerId", null);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridManufacturers.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching for manufacturers: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}