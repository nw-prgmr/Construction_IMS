using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConstructionMaterialManagementSystem.Order_Process
{
    public partial class frmManageOders : Form
    {
        MySqlConnection con;
        MainClass mc = new MainClass();

        public frmManageOders()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            
        }

        private void frmManageOders_Load(object sender, EventArgs e)
        {
            LoadOrderDetails();

        }


        public void LoadOrderDetails()
        {
            // Fill database data
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT `Date and Time`, u.Uname, Material, Qty, Site, Ref FROM tbl_myorder AS m INNER JOIN tbl_users AS u ON u.uID = m.mouID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Add checkbox column to the datagridview
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Name = "checkBoxColumn";
            checkBoxColumn.Width = 50;
            guna2DataGridView1.Columns.Insert(0, checkBoxColumn);

            // Set column names in the DataTable (assuming these match your database columns)
            dt.Columns[0].ColumnName = "Date and Time";
            dt.Columns[1].ColumnName = "Uname";
            dt.Columns[2].ColumnName = "Material";
            dt.Columns[3].ColumnName = "Qty";
            dt.Columns[4].ColumnName = "Site";
            dt.Columns[5].ColumnName = "Ref";

            guna2DataGridView1.DataSource = dt;
            /*
            cmd = new MySqlCommand("SELECT moID, moDate, u.Uname, mopName, moQty, moSite, moRef FROM tbl_myorder AS m INNER JOIN tbl_users AS u ON u.uID = m.mouID", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                guna2DataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            con.Close();    */
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
                    int inserted = 0;

                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);

                            if (isSelected)
                            {
                                // Assuming you have unique identifier columns
                                string selectedRef = row.Cells["Ref"].Value.ToString();  // Get unique identifier for deletion

                            // Delete the record from tbl_myorder (optional, comment out if not needed)
                                con.Open();
                                MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM `tbl_myorder` WHERE Ref = @selectedRef", con);
                                cmdDelete.Parameters.AddWithValue("@selectedRef", selectedRef);
                                cmdDelete.ExecuteNonQuery();
                                con.Close();

                            int proID;
                            con.Open();
                            using (MySqlCommand cmdGetProID = new MySqlCommand("SELECT proID FROM tbl_myorder WHERE Ref = @selectedRef", con))
                            {
                                cmdGetProID.Parameters.AddWithValue("@selectedRef", selectedRef);
                                proID = Convert.ToInt32(cmdGetProID.ExecuteScalar());
                            }
                            con.Close();

                            // Extract data for insertion into tbl_recieve
                            string material = row.Cells["Material"].Value.ToString();
                                int qty = Convert.ToInt32(row.Cells["Qty"].Value); // Assuming Qty is numeric
                                string refValue = row.Cells["Ref"].Value.ToString();
                                string siteValue = row.Cells["Site"].Value.ToString();

                            // Insert data into tbl_recieve
                                con.Open();
                                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO `tbl_recieve` (`proID`, `ropName`, `roQty`, `roREf`, `Site`) VALUES (@proID, @Name, @qty, @Ref, @Site)", con);
                                cmdInsert.Parameters.AddWithValue("@proID", proID);
                                cmdInsert.Parameters.AddWithValue("@Name", material);
                                cmdInsert.Parameters.AddWithValue("@qty", qty);
                                cmdInsert.Parameters.AddWithValue("@Ref", refValue);
                                cmdInsert.Parameters.AddWithValue("@Site", siteValue);
                                cmdInsert.ExecuteNonQuery();
                                con.Close();
                                inserted++;

                            // Optionally, remove the row from the DataGridView (uncomment if needed)
                            guna2DataGridView1.Rows.Remove(row);
                            }
                        }
                    

                    MessageBox.Show(" Item will be process and to be deliver soon.");
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView1.Columns["checkBoxColumn"].Index && e.RowIndex == guna2DataGridView1.Rows.Count - 1)
            {
                // Don't add a new row if clicking on checkbox in the last row
                return;
            }
        }
    }
}
