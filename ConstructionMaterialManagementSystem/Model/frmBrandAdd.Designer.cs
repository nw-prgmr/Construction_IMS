namespace ConstructionMaterialManagementSystem.Model
{
    partial class frmBrandAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBrandSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnBrandClose = new Guna.UI2.WinForms.Guna2Button();
            this.txtBrandName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblBrandId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 117);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(164, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Brand";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConstructionMaterialManagementSystem.Properties.Resources.icons8_hammer_100;
            this.pictureBox1.Location = new System.Drawing.Point(22, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 102);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.btnBrandSave);
            this.panel2.Controls.Add(this.btnBrandClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 291);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 68);
            this.panel2.TabIndex = 5;
            // 
            // btnBrandSave
            // 
            this.btnBrandSave.AutoRoundedCorners = true;
            this.btnBrandSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnBrandSave.BorderRadius = 21;
            this.btnBrandSave.CustomizableEdges.TopRight = false;
            this.btnBrandSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBrandSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBrandSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBrandSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBrandSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(191)))), ((int)(((byte)(67)))));
            this.btnBrandSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrandSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.btnBrandSave.Location = new System.Drawing.Point(22, 11);
            this.btnBrandSave.Name = "btnBrandSave";
            this.btnBrandSave.Size = new System.Drawing.Size(108, 45);
            this.btnBrandSave.TabIndex = 1;
            this.btnBrandSave.Text = "SAVE";
            this.btnBrandSave.Click += new System.EventHandler(this.btnBrandSave_Click);
            // 
            // btnBrandClose
            // 
            this.btnBrandClose.AutoRoundedCorners = true;
            this.btnBrandClose.BackColor = System.Drawing.Color.Transparent;
            this.btnBrandClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBrandClose.BorderColor = System.Drawing.Color.Transparent;
            this.btnBrandClose.BorderRadius = 21;
            this.btnBrandClose.CustomizableEdges.TopRight = false;
            this.btnBrandClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBrandClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBrandClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBrandClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBrandClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.btnBrandClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBrandClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBrandClose.Location = new System.Drawing.Point(136, 11);
            this.btnBrandClose.Name = "btnBrandClose";
            this.btnBrandClose.Size = new System.Drawing.Size(108, 45);
            this.btnBrandClose.TabIndex = 1;
            this.btnBrandClose.Text = "CLOSE";
            this.btnBrandClose.UseTransparentBackground = true;
            this.btnBrandClose.Click += new System.EventHandler(this.btnBrandClose_Click);
            // 
            // txtBrandName
            // 
            this.txtBrandName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBrandName.DefaultText = "";
            this.txtBrandName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBrandName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBrandName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBrandName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBrandName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBrandName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBrandName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBrandName.Location = new System.Drawing.Point(43, 185);
            this.txtBrandName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.PasswordChar = '\0';
            this.txtBrandName.PlaceholderText = "";
            this.txtBrandName.SelectedText = "";
            this.txtBrandName.Size = new System.Drawing.Size(265, 41);
            this.txtBrandName.TabIndex = 6;
            this.txtBrandName.TextChanged += new System.EventHandler(this.txtBrandName_TextChanged);
            // 
            // lblBrandId
            // 
            this.lblBrandId.AutoSize = true;
            this.lblBrandId.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandId.Location = new System.Drawing.Point(41, 230);
            this.lblBrandId.Name = "lblBrandId";
            this.lblBrandId.Size = new System.Drawing.Size(52, 15);
            this.lblBrandId.TabIndex = 7;
            this.lblBrandId.Text = "Brand ID";
            this.lblBrandId.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Brand Name";
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = "IMS";
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.guna2MessageDialog1.Text = null;
            // 
            // frmBrandAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 359);
            this.Controls.Add(this.txtBrandName);
            this.Controls.Add(this.lblBrandId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBrandAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBrandAdd";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        public Guna.UI2.WinForms.Guna2Button btnBrandSave;
        public Guna.UI2.WinForms.Guna2Button btnBrandClose;
        public Guna.UI2.WinForms.Guna2TextBox txtBrandName;
        public System.Windows.Forms.Label lblBrandId;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}