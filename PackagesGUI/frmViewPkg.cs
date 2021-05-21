using PackagesData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PackagesGUI
{
    public partial class frmViewPkg : Form
    {
        public Packages package = null;
        public List<string> prodlist = new List<string>(); 
        public frmViewPkg()
        {
            InitializeComponent();
        }

        private void frmViewPkg_Load(object sender, EventArgs e)
        {
            //loading package data
            lbl_pkgID.Text = package.PackageId.ToString();
            txtPkgName.Text = package.PkgName;
            txtBasePrice.Text = package.PkgBasePrice.ToString();
            txtComm.Text = package.PkgAgencyCommission.ToString();
            dtp_pkgStartDate.Value = (DateTime)package.PkgStartDate;
            dtp_pkgEndDate.Value = (DateTime)package.PkgEndDate;
            rt_PkgDes.Text = package.PkgDesc;
            foreach (var prod in prodlist)
                lbo_prods.Items.Add(prod);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
