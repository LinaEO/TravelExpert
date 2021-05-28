using TravelExperts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PackagesGUI
{//Tamika
    public partial class frmAddModifyProduct : Form
    {
        public Products product = null;
        public List<int> selectedProductsIds; //selected package products
        public bool isAdd; // to differentiate which operation to be performed

        public frmAddModifyProduct()
        {
            InitializeComponent();
        }

        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {
            //distinguish add or modify
            if (this.isAdd)//add
            {
                this.Text = "Add Product";
                lblProductID.Text = "TBD";
            }
            else//modify
            {
                this.Text = "Modify Product";
                lblProductID.Text = product.ProductId.ToString();

                txtProductName.Text = product.ProdName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput())
            {
                //load customer data
                if (isAdd)
                    product = new Products();

                //if modify, the package object is already there

                //load package data
                //packageID automatically generated and is not modified
                product.ProdName = txtProductName.Text;

                //set dialog result to ok
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool ValidateUserInput()
        {
            return Validator.IsPresent(txtProductName, "Product Name");
        }
    }
}