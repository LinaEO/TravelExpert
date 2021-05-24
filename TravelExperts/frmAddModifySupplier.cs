using TravelExperts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PackagesGUI
{
    public partial class frmAddModifySupplier : Form
    {
        public Suppliers supplier = null;
        public List<int> selectedSuppliersIds; //selected  suppliers
        public bool isAdd; // to differentiate which operation to be performed

        public frmAddModifySupplier()
        {
            InitializeComponent();
        }

        private bool ValidateUserInput()
        {
        
            return Validator.IsPresent(txtSupplierName, "Supplier Name");
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (ValidateUserInput())
            {
                //load customer data
                if (isAdd)
                    supplier = new Suppliers();

                supplier.SupName = txtSupplierName.Text;

                //set dialog result to ok
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddModifySupplier_Load_1(object sender, EventArgs e)
        {
            //distinguish add or modify
            if (this.isAdd)//add
            {
                this.Text = "Add Supplier";
                lblSupplierID.Text = "TBD";
            }
            else//modify
            {
                this.Text = "Modify Supplier";
                lblSupplierID.Text = supplier.SupplierId.ToString();
                txtSupplierName.Text = supplier.SupName;
            }
        }
    }
}