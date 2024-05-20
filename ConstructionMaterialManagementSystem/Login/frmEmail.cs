using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // For SQL Server//using MySql.Data.MySqlClient; // For MySQL
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ConstructionMaterialManagementSystem
{
    public partial class frmEmail : Form
    {
        // Connection string for MySQL 
        private string connectionString = "Server=localhost;Database=constructionmaterialms;Integrated Security=True;";

        public frmEmail()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
           // string username = txtUname.Text;
           // string password = txtUpassword.Text;

            // Hash the password using SHA-256
           // string hashedPassword = HashPassword(password);

            // Insert user data into the database
           // InsertUserIntoDatabase(username, hashedPassword);
        }

        // Method to hash a password using SHA-256
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute hash from the password bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Method to insert user data into the database
        private void InsertUserIntoDatabase(string username, string password)
        {
            try
            {
                // Open a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create SQL command to insert user data
                    string query = "INSERT INTO users (username, password_hash) VALUES (@username, @password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    // Execute the command
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("User registered successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        //Button transition
        private void btnSend_MouseDown(object sender, MouseEventArgs e)
        {
            btnSend.FillColor = Color.FromArgb(237, 191, 67);
            btnSend.ForeColor = Color.FromArgb(23, 32, 42);
        }

        private void btnSend_MouseUp(object sender, MouseEventArgs e)
        {
            btnSend.FillColor = Color.Transparent;
            btnSend.ForeColor = Color.WhiteSmoke;
            btnSend.BorderColor = Color.FromArgb(237, 191, 67);
        }

        private void btnSubmit_MouseDown(object sender, MouseEventArgs e)
        {
            btnSubmit.FillColor = Color.FromArgb(237, 191, 67);
            btnSubmit.ForeColor = Color.FromArgb(23, 32, 42);
        }

        private void btnSubmit_MouseUp(object sender, MouseEventArgs e)
        {
            btnSubmit.FillColor = Color.Transparent;
            btnSubmit.ForeColor = Color.WhiteSmoke;
            btnSubmit.BorderColor = Color.FromArgb(237, 191, 67);
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnClose.FillColor = Color.FromArgb(237, 191, 67);
            btnClose.ForeColor = Color.FromArgb(23, 32, 42);
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            btnClose.FillColor = Color.Transparent;
            btnClose.ForeColor = Color.WhiteSmoke;
            btnClose.BorderColor = Color.FromArgb(237, 191, 67);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

