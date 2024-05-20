using ConstructionMaterialManagementSystem.Model;
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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            btnDashboard.BorderColor = Color.FromArgb(37, 189, 176);
            btnDashboard.FillColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmDashboard());
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
                if (c is Guna2Button)
                {
                    ((Guna2Button)c).FillColor = Color.FromArgb(31, 52, 64); 
                }
            }

            // Get the clicked button (assuming Guna2Button)
            Guna2Button clickedButton = (Guna2Button)sender;
            if (clickedButton != null) // Check if button was clicked (sender might be null)
            {
                clickedButton.FillColor = Color.FromArgb(37, 189, 176);
            }
        }

        // for instance
        static frmMain _obj;
        public static frmMain Instance 
        {
            get { if (_obj == null) {_obj = new frmMain(); } return _obj; }
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
                if (c is Guna2Button)
                {
                    ((Guna2Button)c).MouseEnter += new EventHandler(button_MouseEnter); 
                    ((Guna2Button)c).MouseLeave += new EventHandler(button_MouseLeave); 
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
                if (c != lastClickedButton && c is Guna2Button) 
                {
                    ((Guna2Button)c).BorderColor = Color.FromArgb(31, 52, 64);
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; 
            lastClickedButton = clickedButton; 
            btnSettings(btnDashboard, null);
            Addcontrols(new frmDashboard());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; 
            lastClickedButton = clickedButton; 
            btnSettings(btnProducts, null);
            Addcontrols(new frmProductView());
            frmProductView frm = new frmProductView();
            frm.LoadRecords();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; 
            lastClickedButton = clickedButton; 
            btnSettings(btnSupplier, null);
            Addcontrols(new frmSupplierView());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; 
            lastClickedButton = clickedButton; 
            btnSettings(btnReports, null);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; 
            lastClickedButton = clickedButton; 
            btnSettings(btnUser, null);
            Addcontrols(new frmUsersView());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; 
            lastClickedButton = clickedButton; 
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
    }
}
