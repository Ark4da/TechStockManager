using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TechStockManager
{
    public partial class Form10 : Form
    {
        DB db = new DB();

        public Form10()
        {
            InitializeComponent();
            SupplierLoadTable();

            btnAddSupplier.Click += (sender, e) => AddSupplier();
            btnUpdateSupplier.Click += (sender, e) => UpdateSupplier();
            btnDeleteSupplier.Click += (sender, e) => DeleteSupplier();
            btnClearSupplier.Click += (sender, e) => ClearSupplierFields();
            btnPrintSupplier.Click += (sender, e) => ExportToPdf(dataGridSuppliers, "Report_Supplier.pdf");

            txtSearchSupplier.TextChanged += (sender, e) => SearchSuppliers();

            if (ThemeManager.IsDarkTheme)
                ThemeManager.ApplyDarkTheme(this);
            else
                ThemeManager.ApplyLightTheme(this);
        }

        // Method for loading the supplier table
        private void SupplierLoadTable()
        {
            try
            {
                db.OpenConnection();
                string query = "SELECT * FROM supplier";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridSuppliers.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the supplier table: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Method for exporting DataGridView data to PDF
        private void ExportToPdf(DataGridView dataGridView, string filename)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document();
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
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                    document.Add(new Paragraph("Suppliers Table Report", font));

                    PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);

                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfTable.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(new Phrase(cell.Value?.ToString() ?? string.Empty, font));
                        }
                    }

                    document.Add(pdfTable);
                    MessageBox.Show("The report has been saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF: " + ex.Message);
            }
            finally
            {
                document.Close();
            }
        }

        // Adding a new supplier
        private void AddSupplier()
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName?.Text) ||
                string.IsNullOrWhiteSpace(txtSupplierAddress?.Text) ||
                string.IsNullOrWhiteSpace(txtSupplierEmail?.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }
            try
            {
                db.OpenConnection();

                string query = "INSERT INTO supplier (supplier_name, address, Email) VALUES (@supplierName, @address, @email)";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                command.Parameters.AddWithValue("@supplierName", txtSupplierName.Text);
                command.Parameters.AddWithValue("@address", txtSupplierAddress.Text);
                command.Parameters.AddWithValue("@email", txtSupplierEmail.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("The supplier has been successfully added!");

                SupplierLoadTable();
                ClearSupplierFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding a supplier: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Update information about the selected supplier
        private void UpdateSupplier()
        {
            if (dataGridSuppliers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a provider to update.");
                return;
            }

            List<int> changedSupplierIds = new List<int>();

            try
            {
                db.OpenConnection();

                foreach (DataGridViewRow selectedRow in dataGridSuppliers.SelectedRows)
                {
                    int supplierId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    changedSupplierIds.Add(supplierId);

                    string currentSupplierName;
                    string currentAddress;
                    string currentEmail;

                    using (MySqlCommand getSupplierCommand = new MySqlCommand("SELECT supplier_name, address, Email FROM supplier WHERE ID = @supplierId", db.GetConnection()))
                    {
                        getSupplierCommand.Parameters.AddWithValue("@supplierId", supplierId);
                        using (MySqlDataReader reader = getSupplierCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentSupplierName = reader["supplier_name"].ToString();
                                currentAddress = reader["address"].ToString();
                                currentEmail = reader["Email"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No supplier found.");
                                return;
                            }
                        }
                    }

                    string query = "UPDATE supplier SET supplier_name = @supplierName, address = @address, Email = @email WHERE ID = @supplierId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                    command.Parameters.AddWithValue("@supplierId", supplierId);
                    command.Parameters.AddWithValue("@supplierName",
                        string.IsNullOrWhiteSpace(selectedRow.Cells["supplier_name"].Value.ToString()) ? currentSupplierName : selectedRow.Cells["supplier_name"].Value.ToString());
                    command.Parameters.AddWithValue("@address",
                        string.IsNullOrWhiteSpace(selectedRow.Cells["address"].Value.ToString()) ? currentAddress : selectedRow.Cells["address"].Value.ToString());
                    command.Parameters.AddWithValue("@email",
                        string.IsNullOrWhiteSpace(selectedRow.Cells["Email"].Value.ToString()) ? currentEmail : selectedRow.Cells["Email"].Value.ToString());

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("The changes have been successfully saved!");
                changedSupplierIds.Clear();
                SupplierLoadTable();
                ClearSupplierFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the supplier: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Delete the selected supplier
        private void DeleteSupplier()
        {
            if (dataGridSuppliers.SelectedRows.Count > 0)
            {
                int supplierId = Convert.ToInt32(dataGridSuppliers.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    db.OpenConnection();

                    string query = "DELETE FROM supplier WHERE ID = @supplierId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@supplierId", supplierId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("The supplier has been successfully removed!");

                    SupplierLoadTable();
                    ClearSupplierFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting a supplier: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Please select a provider to delete.");
            }
        }

        // Clearing the supplier input fields
        private void ClearSupplierFields()
        {
            txtSupplierName.Clear();
            txtSupplierAddress.Clear();
            txtSupplierEmail.Clear();
            txtSearchSupplier.Clear();
        }

        // Search for suppliers in the table by name or ID
        private void SearchSuppliers()
        {
            try
            {
                db.OpenConnection();

                string query = "SELECT * FROM supplier WHERE 1=1";
                bool hasCondition = false;

                if (!string.IsNullOrWhiteSpace(txtSearchSupplier.Text))
                {
                    query += " AND (ID = @supplierId OR supplier_name LIKE @supplierName)";
                    hasCondition = true;
                }

                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                if (hasCondition)
                {
                    command.Parameters.AddWithValue("@supplierName", "%" + txtSearchSupplier.Text + "%");

                    if (int.TryParse(txtSearchSupplier.Text, out int supplierId))
                        command.Parameters.AddWithValue("@supplierId", supplierId);
                    else
                        command.Parameters.AddWithValue("@supplierId", null);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridSuppliers.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching for suppliers: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}