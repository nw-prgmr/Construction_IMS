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
using MySqlX.XDevAPI;
using Mysqlx;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net;
using ConstructionMaterialManagementSystem.Change_Password;

namespace ConstructionMaterialManagementSystem
{
    public partial class frmEmail : Form
    {
        // Connection string for MySQL 
        //private string connectionString = "Server=localhost;Database=constructionmaterialms;Integrated Security=True;";

        string randomCode;
        public static string to;
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


        /*
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
        }    */


        //Button transition



        private void btnSend_Click(object sender, EventArgs e)
        {
            string from = "junie.antopina07@gmail.com";
            string pass = "yayamanakoAtmakakatulongsaiba"; // **Not recommended in production**
            string messageBody;

            // Generate random code
            Random rand = new Random();
            int randomCode = rand.Next(100000, 999999); // Ensure 6-digit code

            MailMessage message = new MailMessage();
            string to = txtEmail.Text;

            message.To.Add(to);
            message.From = new MailAddress(from);
            messageBody = "Your password reset code is: " + randomCode;
            message.Body = messageBody;
            message.Subject = "Password Reset Code";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("A password reset code has been sent to your email address.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending the email." + ex.Message + " Please try again later");
                // Consider logging the actual exception for debugging purposes
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }
    }
}

