using ConstructionMaterialManagementSystem.View;
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

namespace ConstructionMaterialManagementSystem.Model
{
    public partial class frmBrandAdding : SampleAdd
    {

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();
        frmBrandView frmbrand;

        public frmBrandAdding(frmBrandView frmBRAND)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmbrand = frmBRAND;
        }

        public void LoadCategory()
        {
            cbobCategory.Items.Clear();
            con.Open();
            cmd = new MySqlCommand("SELECT cName FROM tbl_category", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbobCategory.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (MainClass.validation(this) == false)
            {
                gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                gmdSampleAdd.Show("Please remove errors");
                return;
            }
            else
            {
                string cid = "";
                try
                {
                    con.Open();
                    cmd = new MySqlCommand("SELECT cID FROM tbl_category WHERE cName LIKE @cID ", con);
                    cmd.Parameters.AddWithValue("@cID", cbobCategory.Text);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { cid = dr[0].ToString(); }
                    dr.Close();
                    con.Close();

                    con.Open();
                    cmd = new MySqlCommand("INSERT INTO tbl_brand(bName, cID) VALUES (@brand, @cID)", con);
                    cmd.Parameters.AddWithValue("@cID", int.Parse(cid));
                    cmd.Parameters.AddWithValue("@brand", txtBrandName.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    gmdSampleAdd.Show("Brand Successfully added");
                    //guna2MessageDialog1.Show("Save Successfully.", "Category Added");
                    txtBrandName.Clear();
                    frmbrand.LoadRecords();
                }
                catch (Exception ex)
                {
                    con.Close();
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                    gmdSampleAdd.Show("Warning: " + ex.Message, "Warning");
                }
            }
        }

        public override void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MainClass.validation(this) == false)
            {
                gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                gmdSampleAdd.Show("Please remove errors");
                return;
            }
            else
            {
                string cid = "";
                try
                {
                    con.Open();
                    cmd = new MySqlCommand("SELECT cID FROM tbl_category WHERE cName LIKE @cID ", con);
                    cmd.Parameters.AddWithValue("@cID", cbobCategory.Text);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { cid = dr[0].ToString(); }
                    dr.Close();
                    con.Close();

                    con.Open();
                    cmd = new MySqlCommand("UPDATE tbl_brand SET bName = @brand, cID = @cID WHERE bID LIKE @bID ", con);
                    cmd.Parameters.AddWithValue("@cID", int.Parse(cid));
                    cmd.Parameters.AddWithValue("@brand", txtBrandName.Text);
                    cmd.Parameters.AddWithValue("@bID", lblBrandId.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    if (gmdSampleAdd.Show("Brand Successfully update") == DialogResult.OK) { this.Close(); };
                    //guna2MessageDialog1.Show("Save Successfully.", "Category Added");
                    txtBrandName.Clear();
                    cbobCategory.Text = "";
                    frmbrand.LoadRecords();
                }
                catch (Exception ex)
                {
                    con.Close();
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                    gmdSampleAdd.Show("Warning: " + ex.Message, "Warning");
                }
            }
        }
    }
}
