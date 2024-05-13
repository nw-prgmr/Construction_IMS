﻿using System;
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
