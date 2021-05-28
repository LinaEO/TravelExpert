
namespace TravelExperts
{
    partial class frmProdSupp
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listBoxProdSupp = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(981, 714);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(186, 91);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemove.Location = new System.Drawing.Point(536, 718);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(189, 83);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click_1);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModify.Location = new System.Drawing.Point(287, 714);
            this.btnModify.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(188, 83);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "Update";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Location = new System.Drawing.Point(68, 714);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(176, 83);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listBoxProdSupp
            // 
            this.listBoxProdSupp.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBoxProdSupp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxProdSupp.FormattingEnabled = true;
            this.listBoxProdSupp.ItemHeight = 41;
            this.listBoxProdSupp.Location = new System.Drawing.Point(68, 44);
            this.listBoxProdSupp.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBoxProdSupp.Name = "listBoxProdSupp";
            this.listBoxProdSupp.Size = new System.Drawing.Size(1095, 578);
            this.listBoxProdSupp.TabIndex = 12;
            this.listBoxProdSupp.SelectedIndexChanged += new System.EventHandler(this.listBoxProdSupp_SelectedIndexChanged);
            // 
            // frmProdSupp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1211, 840);
            this.Controls.Add(this.listBoxProdSupp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmProdSupp";
            this.Text = "frmProdSupp";
            this.Load += new System.EventHandler(this.frmProdSupp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox listBoxProdSupp;
    }
}