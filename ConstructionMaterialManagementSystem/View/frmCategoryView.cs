using ConstructionMaterialManagementSystem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConstructionMaterialManagementSystem.View
{
    public partial class frmCategoryView : SampleView
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();

        public frmCategoryView()
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
            cmd = new MySqlCommand("SELECT * FROM tbl_category WHERE cName LIKE '%"+ guna2TextBox1.Text + "%'", con);
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
            frmCategoryAdd frmcat = new frmCategoryAdd(this);
            frmcat.btnUpdate.Visible = false;
            MainClass.BlurBackground(frmcat);
            LoadRecords();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "dgvcEdit")
            {
                frmCategoryAdd frm = new frmCategoryAdd(this);
                frm.btnSave.Visible = false;
                frm.lblcatId.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtcName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                MainClass.BlurBackground(frm);
            }
            else if (colName == "dgvcDel")
            {
                
                if (MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new MySqlCommand("DELETE FROM tbl_category WHERE cID LIKE '" + guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadRecords();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}
