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
    public partial class frmMyOrderAdd : SampleAdd
    {

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();
        frmMyOrders frmMyOrders;

        public frmMyOrderAdd(frmMyOrders FRMMYOR)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmMyOrders = FRMMYOR;
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
                    cmd = new MySqlCommand("INSERT INTO tbl_brand(bName, cID) VALUES (@brand, @cID)", con);
                    cmd.Parameters.AddWithValue("@brand", txtSiteLoc.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    gmdSampleAdd.Show("Brand Successfully added");
                    //guna2MessageDialog1.Show("Save Successfully.", "Category Added");
                    txtSiteLoc.Clear();
                    frmMyOrders.LoadRecords();
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
