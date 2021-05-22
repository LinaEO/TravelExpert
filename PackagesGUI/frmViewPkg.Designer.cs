
namespace PackagesGUI
{
    partial class frmViewPkg
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
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_pkgID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComm = new System.Windows.Forms.TextBox();
            this.txtBasePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Base = new System.Windows.Forms.Label();
            this.rt_PkgDes = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPkgName = new System.Windows.Forms.TextBox();
            this.lbo_prods = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStarts = new System.Windows.Forms.TextBox();
            this.txtEnds = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 48;
            this.label7.Text = "Package ID";
            // 
            // lbl_pkgID
            // 
            this.lbl_pkgID.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_pkgID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_pkgID.Location = new System.Drawing.Point(116, 47);
            this.lbl_pkgID.Name = "lbl_pkgID";
            this.lbl_pkgID.Size = new System.Drawing.Size(105, 30);
            this.lbl_pkgID.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "Ends";
            // 
            // txtComm
            // 
            this.txtComm.Location = new System.Drawing.Point(113, 208);
            this.txtComm.Name = "txtComm";
            this.txtComm.ReadOnly = true;
            this.txtComm.Size = new System.Drawing.Size(147, 23);
            this.txtComm.TabIndex = 43;
            // 
            // txtBasePrice
            // 
            this.txtBasePrice.Location = new System.Drawing.Point(113, 171);
            this.txtBasePrice.Name = "txtBasePrice";
            this.txtBasePrice.ReadOnly = true;
            this.txtBasePrice.Size = new System.Drawing.Size(147, 23);
            this.txtBasePrice.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 41;
            this.label6.Text = "Commission";
            // 
            // Base
            // 
            this.Base.AutoSize = true;
            this.Base.Location = new System.Drawing.Point(23, 174);
            this.Base.Name = "Base";
            this.Base.Size = new System.Drawing.Size(60, 15);
            this.Base.TabIndex = 40;
            this.Base.Text = "Base Price";
            // 
            // rt_PkgDes
            // 
            this.rt_PkgDes.Location = new System.Drawing.Point(476, 24);
            this.rt_PkgDes.MaxLength = 50;
            this.rt_PkgDes.Name = "rt_PkgDes";
            this.rt_PkgDes.ReadOnly = true;
            this.rt_PkgDes.Size = new System.Drawing.Size(227, 96);
            this.rt_PkgDes.TabIndex = 39;
            this.rt_PkgDes.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Package Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(374, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Starts on";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(299, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 32);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Back to main";
            this.btnCancel.UseMnemonic = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPkgName
            // 
            this.txtPkgName.Location = new System.Drawing.Point(113, 90);
            this.txtPkgName.MaxLength = 50;
            this.txtPkgName.Name = "txtPkgName";
            this.txtPkgName.ReadOnly = true;
            this.txtPkgName.Size = new System.Drawing.Size(187, 23);
            this.txtPkgName.TabIndex = 33;
            // 
            // lbo_prods
            // 
            this.lbo_prods.FormattingEnabled = true;
            this.lbo_prods.ItemHeight = 15;
            this.lbo_prods.Location = new System.Drawing.Point(476, 149);
            this.lbo_prods.Name = "lbo_prods";
            this.lbo_prods.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbo_prods.Size = new System.Drawing.Size(227, 214);
            this.lbo_prods.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(338, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 50;
            this.label5.Text = "Associated Products";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(25, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 51;
            this.label8.Text = "Dates";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(23, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 17);
            this.label9.TabIndex = 52;
            this.label9.Text = "Price Breakdown";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(27, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 17);
            this.label10.TabIndex = 53;
            this.label10.Text = "Details";
            // 
            // txtStarts
            // 
            this.txtStarts.Location = new System.Drawing.Point(113, 281);
            this.txtStarts.Name = "txtStarts";
            this.txtStarts.ReadOnly = true;
            this.txtStarts.Size = new System.Drawing.Size(147, 23);
            this.txtStarts.TabIndex = 54;
            // 
            // txtEnds
            // 
            this.txtEnds.Location = new System.Drawing.Point(113, 321);
            this.txtEnds.Name = "txtEnds";
            this.txtEnds.ReadOnly = true;
            this.txtEnds.Size = new System.Drawing.Size(147, 23);
            this.txtEnds.TabIndex = 55;
            // 
            // frmViewPkg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 431);
            this.Controls.Add(this.txtEnds);
            this.Controls.Add(this.txtStarts);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbo_prods);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_pkgID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComm);
            this.Controls.Add(this.txtBasePrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Base);
            this.Controls.Add(this.rt_PkgDes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPkgName);
            this.Name = "frmViewPkg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Package Details";
            this.Load += new System.EventHandler(this.frmViewPkg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_pkgID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComm;
        private System.Windows.Forms.TextBox txtBasePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Base;
        private System.Windows.Forms.RichTextBox rt_PkgDes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPkgName;
        private System.Windows.Forms.ListBox lbo_prods;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStarts;
        private System.Windows.Forms.TextBox txtEnds;
    }
}