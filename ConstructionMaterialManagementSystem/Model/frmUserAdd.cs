using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using ConstructionMaterialManagementSystem.View;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using TheArtOfDevHtmlRenderer.Adapters;
using Microsoft.Win32;

namespace ConstructionMaterialManagementSystem.Model
{
    public partial class frmUserAdd : SampleAdd
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();
        frmUsersView frmusers;

        public frmUserAdd(frmUsersView FRMUSERS)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmusers = FRMUSERS;
        }

        public void Clear()
        {
            txtuEmail.Text = "";
            txtuName.Text = "";
            txtuPass.Text = "";
            txtuUsername.Text = "";
            txtuName.Focus();
        }

        public int id = 0;

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
                    MemoryStream ms = new MemoryStream();
                    txtuPic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();

                    // Insert product
                    con.Open();
                    //cmd = new MySqlCommand("INSERT INTO tbl_products (pName, pDescription, cID, bID, sID, pCost, pStock) VALUES (@pName, @pDescription, @pCatID, @pBrandID, @pSupplierID, @pCost, @pStock)", con);
                    cmd = new MySqlCommand("INSERT INTO `tbl_users`(`uID`, `uName`, `username`, `uPass`, `uStatus`, `uEmail`, `uImage`) VALUES (@uName, @username, @uPass, @uStatus, @uEmail, @uImage)", con);
                    cmd.Parameters.AddWithValue("@uName", txtuName.Text);
                    cmd.Parameters.AddWithValue("@username", txtuUsername.Text);
                    cmd.Parameters.AddWithValue("@uPass", txtuPass);
                    cmd.Parameters.AddWithValue("@uStatus", txtStatus.Text);
                    cmd.Parameters.AddWithValue("@uEmail", txtuEmail);
                    cmd.Parameters.AddWithValue("@uImage", arrImage);
                    cmd.ExecuteNonQuery();



                    if (gmdSampleAdd.Show("Save Successfully.", "Product Added") == DialogResult.OK)
                    {
                        this.Close();
                    }
                    Clear();
                  //  frmUsersView.LoadData();
                    con.Close();


                }

                catch (Exception ex)
                {
                con.Close(); // Ensure connection is closed even on error
                gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                gmdSampleAdd.Show("Error Insert data in tbl_products: An error occurred: " + ex.Message, "Error");
            }

        }
    }

        private void btnProBrowse_Click(object sender, EventArgs e)
        {
            
        }

        private void btnuBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.png) |*.png| (*.jpg) |*.jpg| (*.gif) |*.gif";
            openFileDialog1.ShowDialog();
            txtuPic.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }
}
