namespace ConstructionMaterialManagementSystem.Model
{
    partial class frmBrandAdding
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
            this.txtBrandName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblBrandId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbobCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblBrandId);
            this.panel3.Location = new System.Drawing.Point(0, 311);
            this.panel3.Size = new System.Drawing.Size(353, 92);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 39);
            this.label1.Size = new System.Drawing.Size(76, 31);
            this.label1.Text = "Brand";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Size = new System.Drawing.Size(353, 116);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.pictureBox1, 0);
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
            this.txtBrandName.Location = new System.Drawing.Point(39, 174);
            this.txtBrandName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.PasswordChar = '\0';
            this.txtBrandName.PlaceholderText = "";
            this.txtBrandName.SelectedText = "";
            this.txtBrandName.Size = new System.Drawing.Size(265, 41);
            this.txtBrandName.TabIndex = 9;
            this.txtBrandName.Tag = "v";
            // 
            // lblBrandId
            // 
            this.lblBrandId.AutoSize = true;
            this.lblBrandId.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandId.Location = new System.Drawing.Point(3, 77);
            this.lblBrandId.Name = "lblBrandId";
            this.lblBrandId.Size = new System.Drawing.Size(52, 15);
            this.lblBrandId.TabIndex = 10;
            this.lblBrandId.Text = "Brand ID";
            this.lblBrandId.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Brand Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConstructionMaterialManagementSystem.Properties.Resources.icons8_hammer_100;
            this.pictureBox1.Location = new System.Drawing.Point(22, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 102);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // cbobCategory
            // 
            this.cbobCategory.BackColor = System.Drawing.Color.Transparent;
            this.cbobCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbobCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbobCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbobCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbobCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbobCategory.ItemHeight = 30;
            this.cbobCategory.Location = new System.Drawing.Point(39, 231);
            this.cbobCategory.Name = "cbobCategory";
            this.cbobCategory.Size = new System.Drawing.Size(265, 36);
            this.cbobCategory.TabIndex = 12;
            this.cbobCategory.Tag = "v";
            // 
            // frmBrandAdding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 403);
            this.Controls.Add(this.cbobCategory);
            this.Controls.Add(this.txtBrandName);
            this.Controls.Add(this.label2);
            this.Name = "frmBrandAdding";
            this.Text = "frmBrandAdding";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtBrandName, 0);
            this.Controls.SetChildIndex(this.cbobCategory, 0);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2TextBox txtBrandName;
        public System.Windows.Forms.Label lblBrandId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Guna.UI2.WinForms.Guna2ComboBox cbobCategory;
    }
}