using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TechStockManager
{
    public partial class Form11 : Form
    {
        private string userDepartment;
        private DB db = new DB();
        public Form11(string department)
        {
            InitializeComponent();
            userDepartment = department;
            LoadProducts();
            btnAddQuantity.Click += BtnAddQuantity_Click;
        }
        private void LoadProducts()
        {
            try
            {
                db.OpenConnection();
                string tableName = $"{userDepartment}_product";
                string query = $"SELECT ID, name FROM `{tableName}`";
                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbProducts.Items.Add(new ComboBoxItem
                    {
                        Text = $"{reader["name"]} (ID: {reader["ID"]})",
                        Value = Convert.ToInt32(reader["ID"])
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }
        private void BtnAddQuantity_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is ComboBoxItem selectedItem && int.TryParse(txtAddQuantity.Text, out int quantityToAdd))
            {
                try
                {
                    db.OpenConnection();
                    string tableName = $"{userDepartment}_product";
                    int productId = (int)selectedItem.Value;
                    string query = $"UPDATE `{tableName}` SET stock_quantity = stock_quantity + @quantity WHERE ID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@quantity", quantityToAdd);
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("The quantity has been successfully added!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update error: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Please select an item and enter the correct quantity.");
            }
        }
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
    }
}