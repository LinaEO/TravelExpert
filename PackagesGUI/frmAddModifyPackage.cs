using PackagesData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PackagesGUI
{
    public partial class frmAddModifyPackage : Form
    {
        public Packages package = null;
        public List<int> updated_Product_Selections; //selected package products
        public List<string> Original_Product_selections = new List<string>();
        public bool isAdd; // to differentiate which operation to be performed
        
        public frmAddModifyPackage()
        {
            InitializeComponent();
        }

    
        //Form load event hander, depending on the value of isAdd, loads add or modify form
        private void frmAddModifyPackage_Load(object sender, EventArgs e)
        {
           
            //distinguish add or modify
            if (this.isAdd)//add
            {
                this.Text = "Add Package";
                btnAddProducts.Text = "Click to Add Products";
                lbl_pkgID.Text = "TBD";
            }
            else//modify
            {
                this.Text = "Update Package";
                btnAddProducts.Text = "Click to Update Products";
                lbl_pkgID.Text = package.PackageId.ToString();

                txtPkgName.Text = package.PkgName;
                dtp_pkgStartDate.Value = (DateTime)package.PkgStartDate;
                dtp_pkgEndDate.Value = (DateTime)package.PkgEndDate;
                rt_PkgDes.Text = package.PkgDesc;
                txtBasePrice.Text = package.PkgBasePrice.ToString();
                txtComm.Text = package.PkgAgencyCommission.ToString();

               // prdForm.currentProductSelections = Original_Product_selections;
                
            }
        }
        //Accepting Adding/Modifying changes

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput()) 
            {
                //load customer data
                if (isAdd)
                    package = new Packages();

                //if modify, the package object is already there

                //load package data
                //packageID automatically generated and is not modified
                package.PkgName = txtPkgName.Text;
                package.PkgDesc = rt_PkgDes.Text;
                package.PkgStartDate = dtp_pkgStartDate.Value;
                package.PkgEndDate = dtp_pkgEndDate.Value;
                package.PkgBasePrice = Convert.ToDecimal(txtBasePrice.Text);
                package.PkgAgencyCommission = Convert.ToDecimal(txtComm.Text);

                
                //set dialog result to ok
                this.DialogResult = DialogResult.OK;
               
            }

        }

        private bool ValidateUserInput()
        {
            return Validator.IsPresent(txtPkgName, "Package Name") &&
                    Validator.IsPresent(rt_PkgDes, "Package Description") &&
                    Validator.IsValidDate(dtp_pkgStartDate, "Package Start Date") &&
                    Validator.IsValidDate(dtp_pkgEndDate, "Package End Date") &&
                    Validator.IsValidDuration(dtp_pkgStartDate, dtp_pkgEndDate) &&
                    Validator.IsPresent(txtBasePrice, "Base Price") &&
                    Validator.IsNonNegativeDecimal(txtBasePrice, "Base Price") &&
                    Validator.IsPresent(txtComm, "Commission Price") &&
                    Validator.IsNonNegativeDecimal(txtComm, "Commission Price") &&
                    Validator.IsValidPricing(txtBasePrice, txtComm);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            //creating the products form
            frmAddMultiProd prdForm = new frmAddMultiProd();
            if (!isAdd)
            {
                //if it is a modify, display original product selections
                prdForm.currentProductSelections = Original_Product_selections;
            }


            this.Visible = false;
            //show it modal
            DialogResult result = prdForm.ShowDialog();//accept returns ok
            updated_Product_Selections = prdForm.prdSupIds;
            if (result == DialogResult.OK || result == DialogResult.Cancel)
            {
                this.Visible = true;
            }

        }
    }
}
