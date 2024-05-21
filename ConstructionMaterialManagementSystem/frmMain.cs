using ConstructionMaterialManagementSystem.Model;
using ConstructionMaterialManagementSystem.Order_Process;
using ConstructionMaterialManagementSystem.View;
using Guna.UI2.WinForms;
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
    public partial class frmDashboard : Form
    {

        public frmDashboard()
        {
            InitializeComponent();
            btnDashboard.BorderColor = Color.FromArgb(37, 189, 176);
            btnDashboard.FillColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmHome());
        }

        //Add controls to the mainform
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

        // for instance
        static frmDashboard _obj;
        public static frmDashboard Instance 
        {
            get { if (_obj == null) {_obj = new frmDashboard(); } return _obj; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _obj = this;
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

        private Guna2Button lastClickedButton;

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            btn.BorderColor = Color.FromArgb(37, 189, 176);
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnDashboard, null);
            Addcontrols(new frmHome());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnProducts, null);
            Addcontrols(new frmProductView());
            frmProductView frm = new frmProductView();
            frm.LoadRecords();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnSupplier, null);
            Addcontrols(new frmSupplierView());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnReports, null);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnUser, null);
            Addcontrols(new frmUsersView());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnLogout, null);
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }


        private void btnPOS_Click(object sender, EventArgs e)
        {
            frmPOS pos = new frmPOS();
            pos.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnOrders, null);
            frmManageOders frmManage = new frmManageOders();
            frmManage.LoadOrderDetails();
            Addcontrols(frmManage);
        }
    }
}
