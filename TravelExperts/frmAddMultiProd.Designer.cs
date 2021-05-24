
namespace PackagesGUI
{
    partial class frmAddMultiProd
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
            this.lbo_Suppliers = new System.Windows.Forms.ListBox();
            this.btn_ProdSelect = new System.Windows.Forms.Button();
            this.btn_AddProds = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.clb_Products = new System.Windows.Forms.CheckedListBox();
            this.lbo_Selections = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ProdUnSelect = new System.Windows.Forms.Button();
            this.btnClearSelections = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbo_Suppliers
            // 
            this.lbo_Suppliers.FormattingEnabled = true;
            this.lbo_Suppliers.ItemHeight = 40;
            this.lbo_Suppliers.Location = new System.Drawing.Point(28, 71);
            this.lbo_Suppliers.Name = "lbo_Suppliers";
            this.lbo_Suppliers.Size = new System.Drawing.Size(351, 404);
            this.lbo_Suppliers.TabIndex = 0;
            this.lbo_Suppliers.SelectedIndexChanged += new System.EventHandler(this.lbo_Suppliers_SelectedIndexChanged);
            // 
            // btn_ProdSelect
            // 
            this.btn_ProdSelect.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_ProdSelect.Location = new System.Drawing.Point(660, 157);
            this.btn_ProdSelect.Name = "btn_ProdSelect";
            this.btn_ProdSelect.Size = new System.Drawing.Size(100, 50);
            this.btn_ProdSelect.TabIndex = 3;
            this.btn_ProdSelect.Text = ">>";
            this.btn_ProdSelect.UseVisualStyleBackColor = true;
            this.btn_ProdSelect.Click += new System.EventHandler(this.btn_ProdSelect_Click);
            // 
            // btn_AddProds
            // 
            this.btn_AddProds.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_AddProds.Location = new System.Drawing.Point(304, 500);
            this.btn_AddProds.Name = "btn_AddProds";
            this.btn_AddProds.Size = new System.Drawing.Size(292, 66);
            this.btn_AddProds.TabIndex = 4;
            this.btn_AddProds.Text = "Add to Package";
            this.btn_AddProds.UseVisualStyleBackColor = true;
            this.btn_AddProds.Click += new System.EventHandler(this.btn_AddProds_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(730, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 66);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // clb_Products
            // 
            this.clb_Products.FormattingEnabled = true;
            this.clb_Products.Location = new System.Drawing.Point(394, 71);
            this.clb_Products.Name = "clb_Products";
            this.clb_Products.Size = new System.Drawing.Size(249, 391);
            this.clb_Products.TabIndex = 9;
            // 
            // lbo_Selections
            // 
            this.lbo_Selections.FormattingEnabled = true;
            this.lbo_Selections.ItemHeight = 40;
            this.lbo_Selections.Location = new System.Drawing.Point(809, 71);
            this.lbo_Selections.Name = "lbo_Selections";
            this.lbo_Selections.Size = new System.Drawing.Size(502, 404);
            this.lbo_Selections.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 41);
            this.label1.TabIndex = 11;
            this.label1.Text = "1. Select Supplier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(389, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 41);
            this.label2.TabIndex = 12;
            this.label2.Text = "2. Select Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(809, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 41);
            this.label3.TabIndex = 13;
            this.label3.Text = "Current Selections";
            // 
            // btn_ProdUnSelect
            // 
            this.btn_ProdUnSelect.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_ProdUnSelect.Location = new System.Drawing.Point(660, 242);
            this.btn_ProdUnSelect.Name = "btn_ProdUnSelect";
            this.btn_ProdUnSelect.Size = new System.Drawing.Size(100, 58);
            this.btn_ProdUnSelect.TabIndex = 14;
            this.btn_ProdUnSelect.Text = "<<";
            this.btn_ProdUnSelect.UseVisualStyleBackColor = true;
            this.btn_ProdUnSelect.Click += new System.EventHandler(this.btn_ProdUnSelect_Click);
            // 
            // btnClearSelections
            // 
            this.btnClearSelections.Location = new System.Drawing.Point(660, 331);
            this.btnClearSelections.Name = "btnClearSelections";
            this.btnClearSelections.Size = new System.Drawing.Size(100, 69);
            this.btnClearSelections.TabIndex = 15;
            this.btnClearSelections.Text = "Clear Selections";
            this.btnClearSelections.UseVisualStyleBackColor = true;
            this.btnClearSelections.Click += new System.EventHandler(this.btnClearSelections_Click);
            // 
            // frmAddMultiProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1323, 600);
            this.Controls.Add(this.btnClearSelections);
            this.Controls.Add(this.btn_ProdUnSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbo_Selections);
            this.Controls.Add(this.clb_Products);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btn_AddProds);
            this.Controls.Add(this.btn_ProdSelect);
            this.Controls.Add(this.lbo_Suppliers);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmAddMultiProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Products to Package";
            this.Load += new System.EventHandler(this.frmAddMultiProd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbo_Suppliers;
        private System.Windows.Forms.Button btn_ProdSelect;
        private System.Windows.Forms.Button btn_AddProds;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckedListBox clb_Products;
        private System.Windows.Forms.ListBox lbo_Selections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ProdUnSelect;
        private System.Windows.Forms.Button btnClearSelections;
    }
}