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
            btnHome.BorderColor = Color.FromArgb(37, 189, 176);
            btnHome.FillColor = Color.FromArgb(37, 189, 176);
            Addcontrols(new frmDashboard());
        }

        public void Addcontrols(Form f)
        {
            ControlPanelu.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ControlPanelu.Controls.Add(f);
            f.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Addcontrols(new frmDashboard());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmPOS pos = new frmPOS();
            pos.Show();
        }
    }
}
