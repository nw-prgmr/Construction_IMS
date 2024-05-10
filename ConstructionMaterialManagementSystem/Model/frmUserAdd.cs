using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace ConstructionMaterialManagementSystem.Model
{
    public partial class frmUserAdd : SampleAdd
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

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
                string qry = "";

                if(id==0) // INSERT
                {
                    qry = @"INSERT INTO tbl_users (uName, username, uPass, uEmail, uImage) VALUES (@name, @username, @pass, @email, @image)";
                }
                else //UPDATE
                {
                    qry = @"UPDATE tbl_users SET uName = @name,
                            uPass = @pass,
                            username = @username,
                            uEmail = @email,
                            uImage = @image,
                            WHERE uID = @id";
                }

                Image temp = new Bitmap(txtuPic.Image);
                MemoryStream ms = new MemoryStream();
                temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageByteArray = ms.ToArray();


                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@name", txtuName.Text);
                ht.Add("@username", txtuUsername.Text);
                ht.Add("@pass", txtuPass.Text);
                ht.Add("@email", txtuEmail.Text);
                ht.Add("@image", imageByteArray);

                if (MainClass.SQL(qry, ht)>0)
                {
                    gmdSampleAdd.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    gmdSampleAdd.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    gmdSampleAdd.Show("Data Save Successfully");
                    id = 0;
                    txtuEmail.Text = "";
                    txtuName.Text = "";
                    txtuPass.Text = "";
                    txtuUsername.Text = "";
                    txtuPic.Image = ConstructionMaterialManagementSystem.Properties.Resources.user;
                    txtuName.Focus();
                }
            }
        }

        public string filePath = "";
        Byte[] imageByteArray;
        private void btnuBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|*.png; *jpg";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtuPic.Image = new Bitmap(filePath);
            }
        }
    }
}
