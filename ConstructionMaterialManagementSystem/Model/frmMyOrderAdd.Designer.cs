namespace ConstructionMaterialManagementSystem.Model
{
    partial class frmMyOrderAdd
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSiteLoc = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 358);
            this.panel3.Size = new System.Drawing.Size(544, 92);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 29);
            this.label1.Size = new System.Drawing.Size(203, 31);
            this.label1.Text = "Add to your order";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(544, 88);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Site Location / Site Building";
            // 
            // txtSiteLoc
            // 
            this.txtSiteLoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSiteLoc.DefaultText = "";
            this.txtSiteLoc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSiteLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSiteLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSiteLoc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSiteLoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSiteLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSiteLoc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSiteLoc.Location = new System.Drawing.Point(34, 168);
            this.txtSiteLoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSiteLoc.Name = "txtSiteLoc";
            this.txtSiteLoc.PasswordChar = '\0';
            this.txtSiteLoc.PlaceholderText = "";
            this.txtSiteLoc.SelectedText = "";
            this.txtSiteLoc.Size = new System.Drawing.Size(471, 41);
            this.txtSiteLoc.TabIndex = 3;
            // 
            // frmMyOrderAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 450);
            this.Controls.Add(this.txtSiteLoc);
            this.Controls.Add(this.label2);
            this.Name = "frmMyOrderAdd";
            this.Text = "frmMyOrderAdd";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSiteLoc, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtSiteLoc;
    }
}