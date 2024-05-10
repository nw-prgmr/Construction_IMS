using ConstructionMaterialManagementSystem.Model;
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
    public partial class frmUsersView : SampleView
    {
        public frmUsersView()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmUserAdd());
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvUsername);
            lb.Items.Add(dgvpass);
            lb.Items.Add(dgvEmail);

            string qry = @"SELECT uID, uName, uPass, username, uEmail FROM tbl_users
                             ORDER BY uID desc ";
            MainClass.LoadData(qry, dgvUserView, lb);
        }   

        private void frmUsersView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvUserView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
