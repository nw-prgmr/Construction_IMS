using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConstructionMaterialManagementSystem
{
    public partial class frmLogin : Form
    {
       
        public void user_focus()
        {
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Text = "Password";
        }


        public frmLogin()
        {
            InitializeComponent();
            lblMessage.Text = "";
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            btnLogin.FillColor = Color.FromArgb(86, 215, 180);
            btnLogin.ForeColor = Color.FromArgb(31, 52, 64);

            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }

            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = ""; 
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both username and password.";
                txtUsername.Text = "Username";
                txtPassword.Text = "Password";
                return;
            }
            
                if (MainClass.IsValidUser(txtUsername.Text, txtPassword.Text) == false)
                {
                    lblMessage.Text = "Invalid Username or Password";
                    return;
                }

                else
                {
                    frmDashboard dashboard = new frmDashboard();
                    dashboard.Show();
                    this.Hide();
                }
            

          
            
            
            /*
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 0)
                    {
                        lblMessage.Text = "User Not Found";
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtUsername.Focus();
                        user_focus();
                        
                    }
                    else
                    {
                        query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                        command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            frmDashboard frmDashboard = new frmDashboard();
                            frmDashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtPassword.Text))
                            {
                                lblMessage.Text = "Input password.";
                                txtPassword.Focus();
                            }
                            else
                            {
                                lblMessage.Text = "Incorrect password.";
                                txtPassword.Focus();
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } */
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
           user_focus();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar= true;
        }
        

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            frmEmail frmRegister = new frmEmail();
            frmRegister.Show();
            this.Hide();
        }

        private void btnLogin_MouseDown(object sender, MouseEventArgs e)
        {
            btnLogin.FillColor = Color.FromArgb(86, 215, 180);
            btnLogin.ForeColor = Color.FromArgb(31, 52, 64);
        }

        private void btnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            btnLogin.BorderColor = Color.FromArgb(86, 215, 180);
            btnLogin.FillColor = Color.FromArgb(31, 52, 64);
            btnLogin.ForeColor = Color.FromArgb(86, 215, 180);
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
            txtUsername.ForeColor = Color.FromArgb(86, 215, 180);
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.FromArgb(44, 101, 102);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            

            if (txtPassword.Text == "Password")
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.Text = "";
                
            }
            txtPassword.ForeColor = Color.FromArgb(86, 215, 180);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.FromArgb(44, 101, 102);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkFP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEmail FP = new frmEmail();
            FP.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                btnLogin.FillColor = Color.FromArgb(86, 215, 180);
                btnLogin.ForeColor = Color.FromArgb(31, 52, 64);
            }
        }
    }
}
