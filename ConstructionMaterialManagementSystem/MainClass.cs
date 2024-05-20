using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ConstructionMaterialManagementSystem
{
    internal class MainClass
    {
        public string dbconnect()
        {
            string con = "server = localhost; user id = root; password=; database = contruction_ims;";
                return con;
        }

        public static readonly string con_string = "server = localhost; user id = root; password=; database = contruction_ims;";
        public static MySqlConnection con = new MySqlConnection(con_string);


        //Method for use Validation
        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;

            try
            {
                using (MySqlConnection con = new MySqlConnection(con_string))
                {
                    con.Open();

                    string qry = "SELECT * FROM tbl_users WHERE username = @user AND uPass = @pass";
                    MySqlCommand cmd = new MySqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        isValid = true;
                        USER = dt.Rows[0]["uName"].ToString();
                        STATUS = dt.Rows[0]["uStatus"].ToString();

                       // byte[] imageArray = (byte[])dt.Rows[0]["uImage"];
                       // IMG = Image.FromStream(new MemoryStream(imageArray));
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return isValid;
        }

        //Property for username
        public static string user;

        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

        //for user status
        public static string status;

        public static string STATUS
        {
            get { return status; }
            private set { status = value; }
        }

        //for user image
        public static Image img;

        public static Image IMG
        {
            get { return img; }
            private set { img = value; }
        }

        public static void StopBuffering(Panel ctr, bool doublebuffer)
        {
            try 
            {
                typeof(Control).InvokeMember("DoubleBUffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, ctr, new object[] {doublebuffer});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public static bool validation(Form F)
        {
            bool isValid = false; // Initialize isValid as true

            int count = 0;

            foreach (Control c in F.Controls)
            {
                // Using tag of the controls to check if we want to validate it or not
                if (Convert.ToString(c.Tag) != "" && Convert.ToString(c.Tag) != null)
                {
                    if (c is Guna.UI2.WinForms.Guna2TextBox)
                    {
                        Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                        if (t.Text.Trim()=="") // Use IsNullOrWhiteSpace to check for empty or whitespace-only text
                        {
                            t.BorderColor = Color.Red;
                            t.FocusedState.BorderColor = Color.Red;
                            t.HoverState.BorderColor = Color.Red;
                            count++;
                        }
                        else
                        {
                            t.BorderColor = Color.FromArgb(213, 218, 223);
                            t.FocusedState.BorderColor = Color.FromArgb(213, 218, 223);
                            t.HoverState.BorderColor = Color.FromArgb(213, 218, 223);
                        }
                    }
                }

                if (count == 0)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid; // Return isValid after all controls have been validated
        }


        

        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = frmDashboard.Instance.Size;
                Background.StartPosition = FormStartPosition.CenterScreen;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }


        //Method for CRUD  Operation
        public static int SQL(string qry,Hashtable ht)
        {
            int result = 0;

            try
            {
                MySqlCommand cmd = new MySqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }

                if (con.State == ConnectionState.Closed) { con.Open(); }
                result = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

            return result;
        }

        // for Loading data from database
        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {
            // Serial no in gridview
            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);
            try
            {
                MySqlCommand cmd = new MySqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);    

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colName = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colName].DataPropertyName = dt.Columns[i].ToString();    
                }

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }  

        private static void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int count = 0;

            foreach (DataGridViewRow row in gv.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

    }
}
