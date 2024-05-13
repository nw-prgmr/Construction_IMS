using ConstructionMaterialManagementSystem.View;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConstructionMaterialManagementSystem.Model
{
    public partial class frmProductAd : SampleAdd
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();
        frmProductView frmproview;

        public frmProductAd(frmProductView frmPROVIEW)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmproview = frmPROVIEW;
        }

        public void Clear()
        {
            txtProName.Clear();
            txtProDesc.Clear();
            txtProCost.Clear();
            txtProStock.Clear();
            cboCategory.Items.Clear();
            cboBrand.Items.Clear();
            cboSupplier.Items.Clear();
        }

        public void LoadCategory()
        {
            cboCategory.Items.Clear();
            con.Open();
            cmd = new MySqlCommand("SELECT cName FROM tbl_category", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboCategory.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            con.Open();
            cmd = new MySqlCommand("SELECT bName FROM tbl_brand", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboBrand.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadSupplier()
        {
            cboSupplier.Items.Clear();
            con.Open();
            cmd = new MySqlCommand("SELECT sName FROM tbl_supplier", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboSupplier.Items.Add(dr[0].ToString());
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
                string cid = "", bid = "", sid = "";

                try
                {
                    con.Open();
                    cmd = new MySqlCommand("SELECT cID FROM tbl_category WHERE cName LIKE '" + cboCategory.Text + "' ", con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { cid = dr[0].ToString(); }
                    dr.Close();
                    con.Close();

                    con.Open();
                    cmd = new MySqlCommand("SELECT bID FROM tbl_brand WHERE bName LIKE '" + cboBrand.Text + "' ", con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { bid = dr[0].ToString(); }
                    dr.Close();
                    con.Close();

                    con.Open();
                    cmd = new MySqlCommand("SELECT sID FROM tbl_supplier WHERE sName LIKE '" + cboSupplier.Text + "' ", con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { sid = dr[0].ToString(); }
                    dr.Close();
                    con.Close();


                    // Insert product
                    con.Open();
                    //cmd = new MySqlCommand("INSERT INTO tbl_products (pName, pDescription, cID, bID, sID, pCost, pStock) VALUES (@pName, @pDescription, @pCatID, @pBrandID, @pSupplierID, @pCost, @pStock)", con);
                    cmd = new MySqlCommand("INSERT INTO tbl_products (pName, pDescription, cID, bID, sID, pCost, pStock) VALUES (@pName, @pDescription, @pCatID, @pBrandID, @pSupplierID, @pCost, @pStock)", con);
                    cmd.Parameters.AddWithValue("@pName", txtProName.Text);
                    cmd.Parameters.AddWithValue("@pDescription", txtProDesc.Text); 
                    cmd.Parameters.AddWithValue("@pCatID", Convert.ToInt32(cid));
                    cmd.Parameters.AddWithValue("@pBrandID", Convert.ToInt32(bid));
                    cmd.Parameters.AddWithValue("@pSupplierID", Convert.ToInt32(sid));
                    cmd.Parameters.AddWithValue("@pCost",  Convert.ToDouble(txtProCost.Text));
                    cmd.Parameters.AddWithValue("@pStock", Convert.ToUInt32(txtProStock.Text));

                    cmd.ExecuteNonQuery();

                    

                    gmdSampleAdd.Show("Save Successfully.", "Product Added");
                    Clear();
                    frmproview.LoadRecords();
                    con.Close();

                }
                catch (Exception ex)
                {
                    con.Close(); // Ensure connection is closed even on error
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                    gmdSampleAdd.Show("Error Insert data in tbl_products: An error occurred: " + ex.Message, "Error");
                }
   
;            }
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
                string cid = "", bid = "", sid = "";

                try
                {
                    con.Open();
                    cmd = new MySqlCommand("SELECT cID FROM tbl_category WHERE cName LIKE '" + cboCategory.Text + "' ", con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { cid = dr[0].ToString(); }
                    dr.Close();
                    con.Close();

                    con.Open();
                    cmd = new MySqlCommand("SELECT bID FROM tbl_brand WHERE bName LIKE '" + cboBrand.Text + "' ", con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { bid = dr[0].ToString(); }
                    dr.Close();
                    con.Close();

                    con.Open();
                    cmd = new MySqlCommand("SELECT sID FROM tbl_supplier WHERE sName LIKE '" + cboSupplier.Text + "' ", con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { sid = dr[0].ToString(); }
                    dr.Close();
                    con.Close();


                    // Insert product
                    con.Open();
                    //cmd = new MySqlCommand("INSERT INTO tbl_products (pName, pDescription, cID, bID, sID, pCost, pStock) VALUES (@pName, @pDescription, @pCatID, @pBrandID, @pSupplierID, @pCost, @pStock)", con);
                    cmd = new MySqlCommand("UPDATE tbl_products SET pName = @pName, pDescription = @pDescription, cID = @pCatID, bID = @pBrandID, sID = @pSupplierID, pCost = @pCost, pStock = @pStock  WHERE pID LIKE @pID", con);
                    cmd.Parameters.AddWithValue("@pID", lblProduct.Text);
                    cmd.Parameters.AddWithValue("@pName", txtProName.Text);
                    cmd.Parameters.AddWithValue("@pDescription", txtProDesc.Text);
                    cmd.Parameters.AddWithValue("@pCatID", cid);
                    cmd.Parameters.AddWithValue("@pBrandID", bid);
                    cmd.Parameters.AddWithValue("@pSupplierID", sid);
                    cmd.Parameters.AddWithValue("@pCost", Convert.ToDouble(txtProCost.Text));
                    cmd.Parameters.AddWithValue("@pStock", Convert.ToUInt32(txtProStock.Text));

                    cmd.ExecuteNonQuery();



                    gmdSampleAdd.Show("Successfully Updated.", "Product Update");
                    Clear();
                    frmproview.LoadRecords();
                    con.Close();

                }
                catch (Exception ex)
                {
                    con.Close(); // Ensure connection is closed even on error
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                    gmdSampleAdd.Show("Error Update data in tbl_products: An error occurred: " + ex.Message, "Error");
                }
            }

                
        }


    }
}


