using ConstructionMaterialManagementSystem.Model;
using Guna.UI2.WinForms;
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
    public partial class frmProductView : SampleView
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();

        public frmProductView()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            LoadRecords();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductAd productAdd = new frmProductAd(this);
            productAdd.btnUpdate.Visible = false;
            productAdd.LoadBrand();
            productAdd.LoadCategory();
            productAdd.LoadSupplier();
            MainClass.BlurBackground(productAdd);
            LoadRecords();
        }

        
        public int i = 0;
        public void LoadRecords()
        {
            try
            {
                int i = 0;
                dgvProduct.Rows.Clear();
                con.Open();
                cmd = new MySqlCommand("SELECT p.pID, p.pName, c.cName, b.bName, s.sName, p.pDescription, p.pCost, p.pStock " +
                                       "FROM tbl_products AS p " +
                                       "INNER JOIN tbl_category AS c ON c.cID = p.cID " +
                                       "INNER JOIN tbl_brand AS b ON b.bId = p.bID " +
                                       "INNER JOIN tbl_supplier AS s ON s.sID = p.sID ", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Warning: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //LoadRecords();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "dgvedit")
            {
                frmProductAd frm = new frmProductAd(this);
                frm.btnSave.Visible = false;
                frm.LoadCategory();
                frm.LoadBrand();
                frm.LoadSupplier();
                frm.lblProduct.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtProName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtProDesc.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.txtProCost.Text = dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString();
                frm.txtProStock.Text = dgvProduct.Rows[e.RowIndex].Cells[8].Value.ToString();
                frm.cboBrand.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.cboCategory.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.cboSupplier.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                MainClass.BlurBackground(frm);
            }
            else if (colName == "dgvdel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new MySqlCommand("DELETE FROM tbl_products WHERE pID LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Record has been deleted");
                }
            }
            LoadRecords(); 
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmCategoryView());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmBrandView());
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}
