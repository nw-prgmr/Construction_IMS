using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionMaterialManagementSystem.Model;
using ConstructionMaterialManagementSystem.Order_Process;
using ConstructionMaterialManagementSystem.View;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;


namespace ConstructionMaterialManagementSystem
{
    public partial class frmPOS : Form
    {
        MySqlCommand cmd;
        MySqlConnection con;
        MySqlDataReader dr;
        MainClass mc = new MainClass();

        private PictureBox pic;
        private string _filter = "";
        private Label name;

        public frmPOS()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
        }

        public void LoadUser()
        {
            cboUser.Items.Clear();
            con.Open();
            cmd = new MySqlCommand("SELECT uName FROM tbl_users", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboUser.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();
            LoadUser();
            GetData();

            foreach (Control c in TopPanel.Controls)
            {
                if (c is Guna2Button) // Check for Guna2Button type
                {
                    ((Guna2Button)c).MouseEnter += new EventHandler(button_MouseEnter); // Attach individual hover event
                    ((Guna2Button)c).MouseLeave += new EventHandler(button_MouseLeave); // Attach individual leave event
                }
            }
        }

        private void btnSettings(object sender, EventArgs e)
        {
            foreach (Control c in TopPanel.Controls)
            {
                if (c is Guna2Button) // Check for Guna2Button type
                {
                    ((Guna2Button)c).ForeColor = Color.White;
                    ((Guna2Button)c).FillColor = Color.FromArgb(23, 32, 42); // Use FillColor for Guna2Button
                }
            }

            // Get the clicked button (assuming Guna2Button)
            Guna2Button clickedButton = (Guna2Button)sender;
            if (clickedButton != null) // Check if button was clicked (sender might be null)
            {
                clickedButton.ForeColor = Color.FromArgb(23, 32, 42);
                clickedButton.FillColor = Color.FromArgb(237, 191, 67); // Set clicked button color
            }
        }

        private Guna2Button lastClickedButton;

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            btn.ForeColor = Color.FromArgb(23, 32, 42);
            btn.FillColor = Color.FromArgb(237, 191, 67);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            foreach (Control c in TopPanel.Controls)
            {
                if (c != lastClickedButton && c is Guna2Button) // Check for clicked button and Guna2Button type
                {
                    ((Guna2Button)c).ForeColor = Color.White;
                    ((Guna2Button)c).FillColor = Color.FromArgb(23, 32, 42); // Set default border color on leave
                }
            }
        }

        private Dictionary<string, int> productQuantities = new Dictionary<string, int>(); // Dictionary to store product ID and its quantity

        private void GetData()
        {
            con.Open();
            cmd = new MySqlCommand("SELECT p.pImage, p.pName, p.pID, c.cName FROM tbl_products AS p INNER JOIN tbl_category AS c ON c.cID =  p.cID WHERE c.cName LIKE '"+ _filter +"%' ORDER BY pName", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                long len = dr.GetBytes(0,0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                dr.GetBytes(0,0, array, 0, System.Convert.ToInt32(len));
                pic = new PictureBox();
                pic.Width = 150;
                pic.Height = 150;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Cursor = Cursors.Hand;
                pic.Tag = dr["pID"].ToString();


                name = new Label();
                name.Text = dr["pName"].ToString();
                name.BackColor = Color.White;
                name.ForeColor = Color.Black;
                name.TextAlign = ContentAlignment.MiddleCenter;
                name.Font = new Font("Sogui UI",8, FontStyle.Regular);
                name.Dock = DockStyle.Bottom;
                name.Tag = dr["pID"].ToString();

                MemoryStream ms = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(ms);
                pic.BackgroundImage = bitmap;

                pic.Controls.Add(name);
                productPanel.Controls.Add(pic);

                pic.Click += new EventHandler(OnClick);
            }
            dr.Close();
            con.Close();
        }

        public void OnClick(object sender, EventArgs e)
        {
            string clickedProductId = ((PictureBox)sender).Tag.ToString();

            // Check if product already exists in DataGridView
            if (productQuantities.ContainsKey(clickedProductId))
            {
                // Update quantity for existing product
                productQuantities[clickedProductId]++;
            }
            else
            {
                // Add new product with quantity 1
                productQuantities.Add(clickedProductId, 1);

                // Assuming you have separate columns for product ID, name, and quantity in DataGridView
                con.Open();
                cmd = new MySqlCommand("SELECT * FROM tbl_products WHERE pID LIKE '" + clickedProductId + "' ", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    guna2DataGridView1.Rows.Add(guna2DataGridView1.Rows.Count + 1, dr["pID"].ToString(), dr["pName"].ToString(), dr["pDescription"].ToString(), productQuantities[clickedProductId]); // Add with initial quantity 1
                }
                dr.Close();
                con.Close();

               
            }

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                string rowProductId = row.Cells["dgvID"].Value.ToString();  // Assuming "pID" is the product ID column name
                if (productQuantities.ContainsKey(rowProductId))
                {
                    row.Cells["dgvQty"].Value = productQuantities[rowProductId];
                }
            }
        }

        private void AddCategory()
        {
            string qry = "SELECT * FROM tbl_category";
            MySqlCommand cmd = new MySqlCommand(qry, MainClass.con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            categoryPanel.Controls.Clear();

            if (dt.Rows.Count > 0 )
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(201, 40);
                    b.TextAlign = (HorizontalAlignment)ContentAlignment.MiddleCenter;
                    b.Font = new Font("Sogui UI", 9, FontStyle.Bold);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["cName"].ToString();

                    b.Click += new EventHandler(filter_Click);
                    categoryPanel.Controls.Add(b);
                }
                
            }
        }

        private void filter_Click(object sender, EventArgs e)
        {
            _filter = ((Guna2Button)sender).Text; // Cast sender to Guna2Button and access Text property
            productPanel.Controls.Clear();
            GetData();
        }


        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnMyOrders, null);
            frmMyOrders frmMy = new frmMyOrders();
            frmMy.btnClose.Visible = false;
            frmMy.btnSave.Visible = false;
            frmMy.btnUpdate.Visible = false;
            MainClass.BlurBackground(frmMy);
        }

        private void btnToShip_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnToShip, null);
            frmToShip frmto = new frmToShip();
            frmto.btnClose.Visible = false;
            frmto.btnSave.Visible = false;
            frmto.btnUpdate.Visible = false;
            MainClass.BlurBackground(frmto);
        }

        private void btnToRecieve_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnToRecieve, null);
            frmToRecieve frmto = new frmToRecieve();
            frmto.btnClose.Visible = false;
            frmto.btnSave.Visible = false;
            frmto.btnUpdate.Visible = false;
            MainClass.BlurBackground(frmto);
        }

        private void btnBackOrder_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnBackOrder, null);
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) // Check for valid click
            {
                if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvdel")
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string productId = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvID"].Value.ToString(); // Assuming "dgvID" is the product ID column

                        // Remove product from dictionary (if applicable)
                        if (productQuantities.ContainsKey(productId))
                        {
                            productQuantities.Remove(productId);
                        }

                        // Remove row from DataGridView
                        guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        
        private void btnRequest_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

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

                    string uid = "";
                    con.Open();
                    cmd = new MySqlCommand("SELECT uID FROM tbl_users WHERE uName LIKE '" + cboUser.Text + "' ", con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { uid = dr[0].ToString(); }
                    dr.Close();
                    con.Close();

                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        con.Open();
                        cmd = new MySqlCommand("INSERT INTO tbl_myorder (mouID, moDate, mopName, moQty, moSite, moRef) VALUES (@mouID,@moDate, @mopName, @moQty, @moSite, @moRef)", con);
                        cmd.Parameters.AddWithValue("@mouID", int.Parse(uid));
                        cmd.Parameters.AddWithValue("@moDate", dtpMO.Value);
                        cmd.Parameters.AddWithValue("@mopName", row.Cells["dgvcName"].Value);
                        cmd.Parameters.AddWithValue("@moSite", txtSiteLoc.Text);
                        cmd.Parameters.AddWithValue("@moRef", txtOrdRef.Text);
                        cmd.Parameters.AddWithValue("@moQty", Convert.ToInt32(row.Cells["dgvQty"].Value));
                        cmd.ExecuteNonQuery();
                        dr.Close() ;
                        con.Close();
                        
                        inserted++;
                    }

                    if (inserted > 0)
                    {
                        if  (MessageBox.Show(string.Format("{0} Item(s) Requested", inserted), "Message") == DialogResult.OK)
                        {
                            txtOrdRef.Clear();
                            txtSiteLoc.Clear();
                            cboUser.Items.Clear();
                            guna2DataGridView1.Rows.Clear();
                        }
                        
                    }

                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Warning: " + ex.Message, "Warning");
                }
            }
                
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
