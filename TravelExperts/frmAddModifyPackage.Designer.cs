
namespace PackagesGUI
{
    //Nancy 
    partial class frmAddModifyPackage
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtPkgName = new System.Windows.Forms.TextBox();
            this.rt_PkgDes = new System.Windows.Forms.RichTextBox();
            this.Base = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBasePrice = new System.Windows.Forms.TextBox();
            this.txtComm = new System.Windows.Forms.TextBox();
            this.dtp_pkgStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_pkgEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_pkgID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddProducts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(19, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 41);
            this.label4.TabIndex = 19;
            this.label4.Text = "Package Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(19, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 41);
            this.label3.TabIndex = 18;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(19, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 41);
            this.label2.TabIndex = 17;
            this.label2.Text = "Starts on";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(366, 617);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 91);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOk.Location = new System.Drawing.Point(104, 617);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(124, 91);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtPkgName
            // 
            this.txtPkgName.Location = new System.Drawing.Point(252, 79);
            this.txtPkgName.MaxLength = 50;
            this.txtPkgName.Name = "txtPkgName";
            this.txtPkgName.Size = new System.Drawing.Size(331, 46);
            this.txtPkgName.TabIndex = 13;
            // 
            // rt_PkgDes
            // 
            this.rt_PkgDes.Location = new System.Drawing.Point(205, 143);
            this.rt_PkgDes.MaxLength = 50;
            this.rt_PkgDes.Name = "rt_PkgDes";
            this.rt_PkgDes.Size = new System.Drawing.Size(378, 108);
            this.rt_PkgDes.TabIndex = 21;
            this.rt_PkgDes.Text = "";
            // 
            // Base
            // 
            this.Base.AutoSize = true;
            this.Base.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Base.Location = new System.Drawing.Point(19, 396);
            this.Base.Name = "Base";
            this.Base.Size = new System.Drawing.Size(159, 41);
            this.Base.TabIndex = 22;
            this.Base.Text = "Base Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(22, 457);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 41);
            this.label6.TabIndex = 23;
            this.label6.Text = "Commission";
            // 
            // txtBasePrice
            // 
            this.txtBasePrice.Location = new System.Drawing.Point(205, 391);
            this.txtBasePrice.Name = "txtBasePrice";
            this.txtBasePrice.Size = new System.Drawing.Size(376, 46);
            this.txtBasePrice.TabIndex = 24;
            // 
            // txtComm
            // 
            this.txtComm.Location = new System.Drawing.Point(207, 457);
            this.txtComm.Name = "txtComm";
            this.txtComm.Size = new System.Drawing.Size(376, 46);
            this.txtComm.TabIndex = 25;
            // 
            // dtp_pkgStartDate
            // 
            this.dtp_pkgStartDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtp_pkgStartDate.Location = new System.Drawing.Point(207, 257);
            this.dtp_pkgStartDate.Name = "dtp_pkgStartDate";
            this.dtp_pkgStartDate.Size = new System.Drawing.Size(376, 46);
            this.dtp_pkgStartDate.TabIndex = 27;
            // 
            // dtp_pkgEndDate
            // 
            this.dtp_pkgEndDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtp_pkgEndDate.Location = new System.Drawing.Point(207, 320);
            this.dtp_pkgEndDate.Name = "dtp_pkgEndDate";
            this.dtp_pkgEndDate.Size = new System.Drawing.Size(376, 46);
            this.dtp_pkgEndDate.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 41);
            this.label1.TabIndex = 28;
            this.label1.Text = "Ends";
            // 
            // lbl_pkgID
            // 
            this.lbl_pkgID.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_pkgID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_pkgID.Location = new System.Drawing.Point(252, 14);
            this.lbl_pkgID.Name = "lbl_pkgID";
            this.lbl_pkgID.Size = new System.Drawing.Size(331, 54);
            this.lbl_pkgID.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(22, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 41);
            this.label7.TabIndex = 31;
            this.label7.Text = "Package ID";
            // 
            // btnAddProducts
            // 
            this.btnAddProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddProducts.Location = new System.Drawing.Point(104, 531);
            this.btnAddProducts.Name = "btnAddProducts";
            this.btnAddProducts.Size = new System.Drawing.Size(403, 71);
            this.btnAddProducts.TabIndex = 32;
            this.btnAddProducts.Text = "Click to Add Products";
            this.btnAddProducts.UseVisualStyleBackColor = true;
            this.btnAddProducts.Click += new System.EventHandler(this.btnAddProducts_Click);
            // 
            // frmAddModifyPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(629, 739);
            this.Controls.Add(this.btnAddProducts);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_pkgID);
            this.Controls.Add(this.dtp_pkgEndDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_pkgStartDate);
            this.Controls.Add(this.txtComm);
            this.Controls.Add(this.txtBasePrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Base);
            this.Controls.Add(this.rt_PkgDes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPkgName);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmAddModifyPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModifyPackage";
            this.Load += new System.EventHandler(this.frmAddModifyPackage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtPkgName;
        private System.Windows.Forms.RichTextBox rt_PkgDes;
        private System.Windows.Forms.Label Base;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBasePrice;
        private System.Windows.Forms.TextBox txtComm;
        private System.Windows.Forms.DateTimePicker dtp_pkgStartDate;
        private System.Windows.Forms.DateTimePicker dtp_pkgEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_pkgID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddProducts;
    }
}