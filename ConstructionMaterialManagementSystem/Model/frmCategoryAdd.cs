using ConstructionMaterialManagementSystem.View;
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

namespace ConstructionMaterialManagementSystem.Model
{
    public partial class frmCategoryAdd : SampleAdd 
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MainClass mc = new MainClass();
        frmCategoryView frmcatview;
        public frmCategoryAdd(frmCategoryView frmcatView)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmcatview = frmcatView;
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
                try
                {
                    con.Open();
                    cmd = new MySqlCommand("INSERT INTO tbl_category (cName) VALUES (@catName)", con);
                    cmd.Parameters.AddWithValue("@catName", txtcName.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //MessageBox.Show("Info: Save Successfully ", "Category Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    gmdSampleAdd.Show("Save Successfully.", "Category Added");
                    txtcName.Clear();
                    frmcatview.LoadRecords();
                }
                catch (Exception ex)
                {
                    con.Close();
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                    gmdSampleAdd.Show("Warning: " + ex.Message, "Warning");
                }
            }
            
        }

        public override void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("UPDATE tbl_category SET cName = '" + txtcName.Text + "' WHERE cID LIKE '" + lblcatId.Text + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                gmdSampleAdd.Show("Successfully Updated.", "Category Update");
                txtcName.Clear();
                frmcatview.LoadRecords();
                this.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                gmdSampleAdd.Show("Warning: " + ex.Message, "Error");
            }
        }
    }
}
