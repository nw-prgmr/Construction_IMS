using ConstructionMaterialManagementSystem.Model;
using ConstructionMaterialManagementSystem.View;
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

       public void btnClear()
        {
            btnDashboard.BackColor = Color.FromArgb(31, 52, 64);
            btnProducts.BackColor = Color.FromArgb(31, 52, 64);
            btnLogout.BackColor = Color.FromArgb(31, 52, 64);
            btnReports.BackColor = Color.FromArgb(31, 52, 64); 
            btnUsers.BackColor = Color.FromArgb(31, 52, 64);
            btnSupplier.BackColor = Color.FromArgb(31, 52, 64);
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

        

        private void btnReports_Click(object sender, EventArgs e)
        {
            //btnClear();
            //btnReports.BackColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmProductView());
        }


        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _obj = this;
            lblUser.Text = MainClass.USER;
            lblStatus.Text = MainClass.STATUS;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //btnClear();
            //btnDash.BackColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmHome());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            //btnClear();
            //btnSupplier.BackColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmSupplierView());
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            //btnClear();
            //btnCat.BackColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmCategoryView());
        }

        private void button19_Click(object sender, EventArgs e)
        {
           // btnClear();
           //button19.BackColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmBrandView());
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            //btnClear();
           //btnuser.BackColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmUsersView());
        }

        private void btnpro_Click(object sender, EventArgs e)
        {
           // btnClear();
           // btnProducts.BackColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmProductView());
            frmProductView frm = new frmProductView();
            frm.LoadRecords();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //btnClear();
           // btnLogout.BackColor = Color.FromArgb(37, 189, 176);
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            this.Close();

        }
    }
}
