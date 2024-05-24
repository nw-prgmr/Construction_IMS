using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConstructionMaterialManagementSystem.Order_Process
{
    public partial class frmToRecieve : SampleAdd
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();

        public frmToRecieve()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            LoadRecords();
        }

        public void LoadRecords()
        {
            int i = 0;
            guna2DataGridView1.Rows.Clear();
            cmd = new MySqlCommand("SELECT `roID`, `ropName`, `roQty`, 'Site', `roREf` FROM tbl_recieve", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                guna2DataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString() );
            }
            dr.Close();
            con.Close();

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Name = "checkBoxColumn";
            checkBoxColumn.Width = 50;
            guna2DataGridView1.Columns.Insert(0, checkBoxColumn);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnRecieve_Click(object sender, EventArgs e)
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

                    {
                        con.Open();

                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);

                            if (isSelected)
                            {
                                // Assuming you have unique identifier columns
                                string selectedRef = row.Cells["dgvRef"].Value.ToString();  // Get unique identifier for deletion

                                // Delete the record from tbl_recieve
                                MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM `tbl_recieve` WHERE roREf = @selectedRef", con);
                                cmdDelete.Parameters.AddWithValue("@selectedRef", selectedRef);
                                cmdDelete.ExecuteNonQuery();

                                int proID;
                                using (MySqlCommand cmdGetProID = new MySqlCommand("SELECT proID FROM `tbl_recieve` WHERE roREf = @selectedRef", con))
                                {
                                    cmdGetProID.Parameters.AddWithValue("@selectedRef", selectedRef);
                                    proID = Convert.ToInt32(cmdGetProID.ExecuteScalar());
                                }

                                // Extract data for update
                                string productName = row.Cells["dgvbName"].Value.ToString(); // Assuming product name cell
                                int recvQty = Convert.ToInt32(row.Cells["dgvQty"].Value);  // Assuming Qty is numeric

                                // Update product stock in tbl_products
                                MySqlCommand cmdUpdateProduct = new MySqlCommand("UPDATE `tbl_products` SET pStock = pStock - @recvQty WHERE pName = @productName", con);
                                cmdUpdateProduct.Parameters.AddWithValue("@recvQty", recvQty);
                                cmdUpdateProduct.Parameters.AddWithValue("@productName", productName);
                                cmdUpdateProduct.ExecuteNonQuery();

                                // Extract data for insertion into tbl_recieve
                                string material = row.Cells["dgvbName"].Value.ToString();
                                int qty = Convert.ToInt32(row.Cells["dgvQty"].Value); // Assuming Qty is numeric
                                string refValue = row.Cells["dgvRef"].Value.ToString();
                                string siteValue = row.Cells["dgvSite"].Value.ToString();

                                // Insert data into tbl_recieve
                                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO `tbl_recieved` (`proID`, `rdName`, `rdQty`, `rdRef`, `rdSite`) VALUES (@proID, @Name, @qty, @Ref, @Site)", con);
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
                    }

                    MessageBox.Show(inserted + " Will be process and to be deliver soon.");
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Warning: " + ex.Message, "Warning");
                }
            }
        }

        private void btnNotRecieve_Click(object sender, EventArgs e)
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

                    {
                       

                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);

                            if (isSelected)
                            {
                                // Assuming you have unique identifier columns
                                string selectedRef = row.Cells["dgvRef"].Value.ToString();  // Get unique identifier for deletion

                                // Delete the record from tbl_recieve (optional, comment out if not needed)
                                con.Open();
                                MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM `tbl_recieve` WHERE roREf = @selectedRef", con);
                                cmdDelete.Parameters.AddWithValue("@selectedRef", selectedRef);
                                cmdDelete.ExecuteNonQuery();
                                con.Clone();

                                int proID;
                                using (MySqlCommand cmdGetProID = new MySqlCommand("SELECT proID FROM `tbl_recieve` WHERE roREf = @selectedRef", con))
                                {
                                    cmdGetProID.Parameters.AddWithValue("@selectedRef", selectedRef);
                                    proID = Convert.ToInt32(cmdGetProID.ExecuteScalar());
                                }

                                // Extract data for insertion into tbl_recieve
                                string material = row.Cells["dgvbName"].Value.ToString();
                                int qty = Convert.ToInt32(row.Cells["dgvQty"].Value); // Assuming Qty is numeric
                                string refValue = row.Cells["dgvRef"].Value.ToString();
                                string siteValue = row.Cells["dgvSite"].Value.ToString();

                                // Insert data into tbl_recieve
                                con.Open();
                                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO `tbl_backorder` (`proID`, `boName`, `boQty`, `boRef`, `boSite`) VALUES (@proID, @Name, @qty, @Ref, @Site)", con);
                                cmdInsert.Parameters.AddWithValue("@proID", proID);
                                cmdInsert.Parameters.AddWithValue("@Name", material);
                                cmdInsert.Parameters.AddWithValue("@qty", qty);
                                cmdInsert.Parameters.AddWithValue("@Ref", refValue);
                                cmdInsert.Parameters.AddWithValue("@Site", siteValue);
                                cmdInsert.ExecuteNonQuery();
                                con.Clone();
                                inserted++;

                                // Optionally, remove the row from the DataGridView (uncomment if needed)
                                guna2DataGridView1.Rows.Remove(row);
                            }
                        }
                    }

                    MessageBox.Show("Order Status: Not Delivered.");
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Warning: " + ex.Message, "Warning");
                }
            }
        }
    }
}
