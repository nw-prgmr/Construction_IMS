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

namespace ConstructionMaterialManagementSystem.Model
{
    public partial class frmSupplierView : SampleView
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MainClass mc = new MainClass();
        string _id, _name, _contact, _email, _phone, _address;
        public frmSupplierView()
        {
            InitializeComponent();
            con = new MySqlConnection(mc.dbconnect());
            LoadRecords();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        public int i = 0;


        public void LoadRecords()
        {
            int i = 0;
            guna2DataGridView1.Rows.Clear();
            cmd = new MySqlCommand("SELECT * FROM tbl_supplier WHERE sName LIKE '%"+ guna2TextBox1.Text + "%' ", con);
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
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmSupplierAdd frmSupplier = new frmSupplierAdd(this);
            frmSupplier.btnUpdate.Visible = false;
            MainClass.BlurBackground(frmSupplier);
            LoadRecords();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "dgvbEdit")
            {
                frmSupplierAdd frm = new frmSupplierAdd(this);
                frm.btnSave.Visible = false;
                frm.lblsID.Text = _id;
                frm.txtsName.Text = _name;
                frm.txtsConPerson.Text = _contact;
                frm.txtsEmail.Text = _email;
                frm.txtusPhone.Text = _phone;
                frm.txtsAddress.Text = _address;
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

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = guna2DataGridView1.CurrentRow.Index;
            _id = guna2DataGridView1[1, i].Value.ToString();
            _name = guna2DataGridView1[2, i].Value.ToString();
            _contact = guna2DataGridView1[3, i].Value.ToString();
            _email = guna2DataGridView1[4, i].Value.ToString();
            _phone = guna2DataGridView1[5, i].Value.ToString();
            _address = guna2DataGridView1[6, i].Value.ToString();
        }
    }
}
