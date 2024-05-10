using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionMaterialManagementSystem.Model;
using MySql.Data.MySqlClient;

namespace ConstructionMaterialManagementSystem.View
{
    public partial class frmBrandView : SampleView
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();

        public frmBrandView()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            LoadRecords();
        }
        
        public int i = 0;


        public void LoadRecords()
        {
            int i = 0;
            guna2DataGridView1.Rows.Clear();
            cmd = new MySqlCommand("SELECT * FROM tbl_brand ORDER BY bName", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                guna2DataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmBrandAdd(this));
            LoadRecords();
        }

    
        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "dgvbEdit")
            {
                frmBrandAdd frm = new frmBrandAdd(this);
                frm.btnBrandSave.Enabled = false;
                frm.lblBrandId.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtBrandName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                MainClass.BlurBackground(new frmBrandAdd(this));
            }
            else if (colName == "dgvbDel")
            {

                if (MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new MySqlCommand("DELETE FROM tbl_brand WHERE bID LIKE '" + guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record has been deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadRecords();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
