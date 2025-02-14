﻿using MySql.Data.MySqlClient;
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
    public partial class frmMyOrders : SampleAdd
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();

        public frmMyOrders()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            LoadRecords();
        }

        public void LoadRecords()
        {
            int i = 0;
            guna2DataGridView1.Rows.Clear();
            cmd = new MySqlCommand("SELECT `moID`, `Date and Time`, `Material`, `Qty`, `Site`, `Ref`s FROM tbl_myorder", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                guna2DataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
