﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConstructionMaterialManagementSystem
{
    public partial class frmMainUser : Form
    {
        public frmMainUser()
        {
            InitializeComponent();
            Addcontrols(new frmHome());
            btnHome.BorderColor = Color.FromArgb(37, 189, 176);
            btnHome.FillColor = Color.FromArgb(37, 189, 176);
        }

        public void Addcontrols(Form f)
        {
            ControlPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ControlPanel.Controls.Add(f);
            f.Show();
        }

        private void btnSettings(object sender, EventArgs e)
        {
            foreach (Control c in buttonPanel.Controls)
            {
                if (c is Guna2Button) // Check for Guna2Button type
                {
                    ((Guna2Button)c).FillColor = Color.FromArgb(31, 52, 64); // Use FillColor for Guna2Button
                }
            }

            // Get the clicked button (assuming Guna2Button)
            Guna2Button clickedButton = (Guna2Button)sender;
            if (clickedButton != null) // Check if button was clicked (sender might be null)
            {
                clickedButton.FillColor = Color.FromArgb(37, 189, 176); // Set clicked button color
            }
        }

        private Guna2Button lastClickedButton;

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            btn.BorderColor = Color.FromArgb(37, 189, 176);
        }

        private void frmMainUser_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
            lblStatus.Text = MainClass.STATUS;


            foreach (Control c in buttonPanel.Controls)
            {
                if (c is Guna2Button) // Check for Guna2Button type
                {
                    ((Guna2Button)c).MouseEnter += new EventHandler(button_MouseEnter); // Attach individual hover event
                    ((Guna2Button)c).MouseLeave += new EventHandler(button_MouseLeave); // Attach individual leave event
                }
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            foreach (Control c in buttonPanel.Controls)
            {
                if (c != lastClickedButton && c is Guna2Button) // Check for clicked button and Guna2Button type
                {
                    ((Guna2Button)c).BorderColor = Color.FromArgb(31, 52, 64); // Set default border color on leave
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnHome, null);
            Addcontrols(new frmHome());
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnMaterials, null);
            Addcontrols(new frmPOS());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnLogout, null);
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }
    }
}
