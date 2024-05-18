using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionMaterialManagementSystem.View;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace ConstructionMaterialManagementSystem.Model
{
    public partial class frmSupplierAdd : SampleAdd
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MainClass mc = new MainClass();
        frmSupplierView frmsupplierview;

        public frmSupplierAdd(frmSupplierView SUPVIEW)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmsupplierview = SUPVIEW;
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
                    cmd = new MySqlCommand("INSERT INTO tbl_supplier (sName, sContact_person, sEmail, sPhone, sAddress) " +
                                "VALUES (@sName, @sContact_person, @sEmail, @sPhone, @sAddress)", con);
                    cmd.Parameters.AddWithValue("@sName", txtsName.Text);
                    cmd.Parameters.AddWithValue("@sContact_person", txtsConPerson.Text);
                    cmd.Parameters.AddWithValue("@sEmail", txtsEmail.Text);
                    cmd.Parameters.AddWithValue("@sPhone", txtusPhone.Text);
                    cmd.Parameters.AddWithValue("@sAddress", txtsAddress.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //MessageBox.Show("Info: Save Successfully", "WSupplier Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gmdSampleAdd.Show("Save Successfully.", "Supplier Added");
                    txtsAddress.Clear();
                    txtsConPerson.Clear();
                    txtsEmail.Clear();
                    txtsName.Clear();
                    txtusPhone.Clear();
                    frmsupplierview.LoadRecords();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Warning: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        public override void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("UPDATE tbl_supplier SET sName = @sName, sContact_person = @sContact_person, sEmail = @sEmail, sPhone = @sPhone, sAddress = @sAddress", con);
                cmd.Parameters.AddWithValue("@sName", txtsName.Text);
                cmd.Parameters.AddWithValue("@sContact_person", txtsConPerson.Text);
                cmd.Parameters.AddWithValue("@sEmail", txtsEmail.Text);
                cmd.Parameters.AddWithValue("@sPhone", txtusPhone.Text);
                cmd.Parameters.AddWithValue("@sAddress", txtsAddress.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("Info: Save Successfully", "WSupplier Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gmdSampleAdd.Show("Save Successfully.", "Supplier Added");
                txtsAddress.Clear();
                txtsConPerson.Clear();
                txtsEmail.Clear();
                txtsName.Clear();
                txtusPhone.Clear();
                frmsupplierview.LoadRecords();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Warning: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
