using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionMaterialManagementSystem.Model;
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
        //private Label price;
        private Label name;

        public frmPOS()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

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

        private void GetData()
        {
            con.Open();
            cmd = new MySqlCommand("SELECT pImage, pName, pID FROM tbl_products ", con);
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
            string tag = ((PictureBox)sender).Tag.ToString();
            con.Open();
            cmd = new MySqlCommand("SELECT * FROM tbl_products WHERE pID LIKE '"+ tag +"' ",con);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                guna2DataGridView1.Rows.Add(guna2DataGridView1.Rows.Count + 1, dr["pID"].ToString(), dr["pName"].ToString(), dr["pDescription"].ToString());
            }
            dr.Close();
            con.Close();
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
                    b.Size = new Size(229, 50);
                    b.TextAlign = HorizontalAlignment.Left;
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["cName"].ToString();

                    categoryPanel.Controls.Add(b);
                }
                
            }
        }

       

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnMyOrders, null);
        }

        private void btnToShip_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnToShip, null);
        }

        private void btnToRecieve_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnToRecieve, null);
        }

        private void btnBackOrder_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender; // Get the clicked button
            lastClickedButton = clickedButton; // Update the tracked button
            btnSettings(btnBackOrder, null);
        }




        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
           // frmMyOrderAdd orderAdd = new frmMyOrderAdd();
            //MainClass.BlurBackground(orderAdd);
        }
    }
}
