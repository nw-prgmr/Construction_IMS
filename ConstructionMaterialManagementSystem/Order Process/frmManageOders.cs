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

namespace ConstructionMaterialManagementSystem.Order_Process
{
    public partial class frmManageOders : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();

        public frmManageOders()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            
        }

        private void frmManageOders_Load(object sender, EventArgs e)
        {

        }


        public void LoadOrderDetails()
        {
            guna2DataGridView1.Rows.Clear();
            cmd = new MySqlCommand("SELECT moID, moDate, u.Uname, mopName, moQty, moSite, moRef FROM tbl_myorder AS m INNER JOIN tbl_users AS u ON u.uID = m.mouID", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                guna2DataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            con.Close();
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (MainClass.validation(this) == false)
            {
                MessageBox.Show("Please remove errors", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    cmd = new MySqlCommand("SELECT moID, moDate, u.Uname, mopName, moQty, moSite, moRef FROM tbl_myorder AS m INNER JOIN tbl_users AS u ON u.uID = m.mouID", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        guna2DataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    }
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Warning: " + ex.Message, "Warning");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
