using ConstructionMaterialManagementSystem.Model;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConstructionMaterialManagementSystem
{
    internal class CodeRepos
    {
        /*
         
         >>>>>>>>>>>>>>>>>>>>>  frmCategoryView <<<<<<<<<<<<<<<<<<<<<<


        public partial class frmCategoryView : SampleView
    {
       // MySqlConnection con;
       // MySqlCommand cmd;
       // MySqlDataReader dr;
        //MainClass mc = new MainClass();

        public frmCategoryView()
        {
            InitializeComponent();
            //guna2MessageDialog1.Parent = frmDashboard.Instance;
            //con = new MySqlConnection(mc.dbconnect());
            //LoadRecords();
        }

        public int i = 0;

        /*
        public void LoadRecords()
        {
            int i = 0;
            guna2DataGridView1.Rows.Clear();
            cmd = new MySqlCommand("SELECT * FROM category",con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                guna2DataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }    

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd categoryAdd = new frmCategoryAdd(this);
            categoryAdd.ShowDialog();
            //LoadRecords();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "dgvedit")
            {
                frmCategoryAdd frm = new frmCategoryAdd(this);
                frm.btnCatSave.Enabled = false;
                frm.lblcatId.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtCatName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.ShowDialog();
            }
            else if (colName == "dgvdel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new MySqlCommand("DELETE FROM category WHERE catID LIKE '" + guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Record has been deleted");
                }
            }
            LoadRecords();
        }
    }

        >>>>>>>>>>>>>>>>>>>>>>>>>>  frmCategoryAdd <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public partial class frmCategoryAdd : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MainClass mc = new MainClass();
        frmCategoryView frmcatview;

        public frmCategoryAdd(frmCategoryView frmcatView)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmcatview = frmcatView;
        }

        private void btnCatSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCatName.Text == string.Empty)
                {
                    guna2MessageDialog1.Show("Warning: Required empty field","Warning");
                    return;
                }
                con.Open();
                cmd = new MySqlCommand("INSERT INTO category(catName) VALUES (@catName)", con);
                cmd.Parameters.AddWithValue("@catName", txtCatName.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                guna2MessageDialog1.Show("Save Successfully.", "Category Added");
                txtCatName.Clear();
                frmcatview.LoadRecords();
            } catch(Exception ex) 
            {
                con.Close();
                MessageBox.Show("Warning: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCatClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCatName.Text == string.Empty)
                {
                    guna2MessageDialog1.Show("Warning: Required empty field", "Warning");
                    return;
                }
                con.Open();
                cmd = new MySqlCommand("UPDATE category SET catName = '" + txtCatName.Text + "' WHERE catID LIKE '"+ lblcatId.Text +"' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                guna2MessageDialog1.Show("Successfully Updated.", "Category Added");
                txtCatName.Clear();
                frmcatview.LoadRecords();
                this.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                guna2MessageDialog1.Show("Warning: " + ex.Message, "Error");
            }
        }
    }

        >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> frmProductView <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public partial class frmProductView : SampleView
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();

        public frmProductView()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            LoadRecords();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd productAdd = new frmProductAdd(this);
            MainClass.BlurBackground(new frmProductAdd(this));
            // productAdd.btnUpdate.Enabled = false;
            productAdd.LoadBrand();
            productAdd.LoadCategory();
            productAdd.ShowDialog();
            LoadRecords();

            
        }

        public void LoadRecords()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            con.Open();
            cmd = new MySqlCommand("SELECT p.pName, c.catName, b.brand, p.Barcode, p.pCost, p.pPric FROM tblproducts as p INNER JOIN tbl_brand as b ON b.id = p.pBrandID INNER JOIN category as c ON c.catID = p.pCatID WHERE p.pName LIKE '%"+ txtSearch.Text +"%' ", con);      
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }


        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "dgvedit")
            {
                frmProductAdd frm = new frmProductAdd(this);
                frm.btnCatSave.Enabled = false;
                frm.lblcatId.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtCatName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.ShowDialog();
            }
            else if (colName == "dgvdel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new MySqlCommand("DELETE FROM category WHERE catID LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Record has been deleted");
                }
            }
            LoadRecords(); 
        }
    }

        >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.  frmProductAdd  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public partial class frmProductAdd : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();
        frmProductView frmproview;

        public frmProductAdd(frmProductView frmPROVIEW)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmproview = frmPROVIEW;
        }

        public void Clear ()
        {
            txtProName.Clear();
            txtProBarcode.Clear();
            txtProCost.Clear();
            cboCategory.Items.Clear();
            cboBrand.Items.Clear();
        }

        public void LoadCategory ()
        {
            cboCategory.Items.Clear ();
            con.Open ();
            cmd = new MySqlCommand ("SELECT catName FROM category", con);
            dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                cboCategory.Items.Add(dr[0].ToString());
            }
            dr.Close ();
            con.Close ();
        }

        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            con.Open();
            cmd = new MySqlCommand("SELECT brand FROM tbl_brand", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboBrand.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
 
        private void btnProSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtProName.Text == string.Empty) || (txtProBarcode.Text == string.Empty) || (txtProCost.Text == string.Empty))
                {
                    guna2MessageDialog2.Show("Warning: Required empty field", "Warning");
                    return;
                }

                string bid = ""; string cid = "";
                con.Open();
                cmd = new MySqlCommand("SELECT catID FROM category LIKE '" + cboCategory.Text + "' ", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows){ cid = dr[0].ToString(); }
                dr.Close();
                con.Close();

                con.Open();
                cmd = new MySqlCommand("SELECT id FROM tbl_brand LIKE '" + cboBrand.Text + "' ", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows) { bid = dr[0].ToString(); }
                dr.Close();
                con.Close();

                con.Open();
                cmd = new MySqlCommand("INSERT INTO tblproducts (pName, pCatID, pBrandID, pBarcode, pCost, pPric) VALUES (@pName, @pCatID, @pBrandID, @pBarcode, @pCost, @pPric)", con);
                cmd.Parameters.AddWithValue(" @pName",txtProName);
                cmd.Parameters.AddWithValue(" @pCatID", cid);
                cmd.Parameters.AddWithValue(" @pBrandID", bid);
                cmd.Parameters.AddWithValue(" @pBarcode", txtProBarcode);
                cmd.Parameters.AddWithValue(" @pCost", txtProCost);
                cmd.Parameters.AddWithValue(" @pPric", txtProSP);
                cmd.ExecuteNonQuery();
                con.Close();
                guna2MessageDialog2.Show("Save Successfully.", "Category Added");
                Clear();
                frmproview.LoadRecords();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Warning: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnProBrowse_Click(object sender, EventArgs e)
        {
           // using ofd As new OpenFileDialog With {.Filter = "(Image Files)|*.jpg;*"}
        }


    }

        >>>>>>>>>>>>>>>>>>>>>>>>>>>>>> frmLogin <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }

            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = ""; 
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both username and password.";
                txtUsername.Text = "Username";
                txtPassword.Text = "Password";
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 0)
                    {
                        lblMessage.Text = "User Not Found";
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtUsername.Focus();
                        user_focus();
                        
                    }
                    else
                    {
                        query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                        command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            frmDashboard frmDashboard = new frmDashboard();
                            frmDashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtPassword.Text))
                            {
                                lblMessage.Text = "Input password.";
                                txtPassword.Focus();
                            }
                            else
                            {
                                lblMessage.Text = "Incorrect password.";
                                txtPassword.Focus();
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        >>>>>>>>>>>>>>>>>>>>>> frmSupplierAdd <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public partial class frmSupplierAdd : SampleAdd
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MainClass mc = new MainClass();
        frmSupplierView frmsupplierview;

        public frmSupplierAdd(frmSupplierView SUPVIEW, int recordId = -1)
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            frmsupplierview = SUPVIEW;
            RecordId = recordId; // Set RecordId based on received value
        }

        private int _recordId = -1; // -1 indicates new record

        public int RecordId
        {
            get { return _recordId; }
            set { _recordId = value; }
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
                try
                {
                    con.Open();

                    if (RecordId == -1) // Insert new record
                    {
                        cmd = new MySqlCommand("INSERT INTO tbl_supplier (sName, sContact_Person, sEmail, sPhone, sAddress) " +
                            "VALUES (@sName, @sContact_person, @sEmail, @sPhone, @sAddress)", con);
                    }
                    else // Update existing record
                    {
                        cmd = new MySqlCommand("UPDATE tbl_supplier SET sName = @sName, sContact_Person = @sContact_person, " +
                            "sEmail = @sEmail, sPhone = @sPhone, sAddress = @sAddress WHERE sID = @recordId", con);
                        cmd.Parameters.AddWithValue("@recordId", RecordId);
                    }

                    cmd.Parameters.AddWithValue("@sName", txtsName.Text);
                    cmd.Parameters.AddWithValue("@sContact_person", txtsConPerson.Text);
                    cmd.Parameters.AddWithValue("@sEmail", txtsEmail.Text);
                    cmd.Parameters.AddWithValue("@sPhone", txtusPhone.Text);
                    cmd.Parameters.AddWithValue("@sAddress", txtsAddress.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    gmdSampleAdd.Show("Operation Successful.", "Supplier Details");

                    // Clear input fields after operation
                    txtsAddress.Clear();
                    txtsConPerson.Clear();
                    txtsEmail.Clear();
                    txtsName.Clear();
                    txtusPhone.Clear();

                    // Reload records in the view
                    frmsupplierview.LoadRecords();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Warning: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }
    }
        >>>>>>>>>>>>>>>>>>>>>>> frmSupplierView <<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 
         private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "dgvbEdit")
            {
                int selectedId = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()); // Get selected ID
                frmSupplierAdd frm = new frmSupplierAdd(this, selectedId); // Pass selected ID to frmSupplierAdd
                MainClass.BlurBackground(frm);
            }
            else if (colName == "dgvbDel")
            {

                if (MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new MySqlCommand("DELETE FROM tbl_supplier WHERE sID LIKE '" + guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadRecords();
        }





         */
    }
}
