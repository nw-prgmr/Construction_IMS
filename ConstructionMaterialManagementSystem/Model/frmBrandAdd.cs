using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionMaterialManagementSystem.View;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace ConstructionMaterialManagementSystem.Model
{
    public partial class frmBrandAdd : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MainClass mc = new MainClass();
        frmBrandView frmbrand;

        public frmBrandAdd(frmBrandView frmBRAND)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmbrand = frmBRAND;
        }

        private void btnBrandSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBrandName.Text == string.Empty)
                {
                    MessageBox.Show("Warning: Required Empty Field" , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // guna2MessageDialog1.Show("Warning: Required empty field", "Warning");
                    return;
                }
                con.Open();
                cmd = new MySqlCommand("INSERT INTO tbl_brand(bName) VALUES (@brand)", con);
                cmd.Parameters.AddWithValue("@brand", txtBrandName.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Info: Save Successfully", "Brand Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //guna2MessageDialog1.Show("Save Successfully.", "Category Added");
                txtBrandName.Clear();
                frmbrand.LoadRecords();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Warning: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBrandClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBrandName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
