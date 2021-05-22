using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PackagesData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackagesGUI
{
    public partial class frmPackages : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); //DB Context object
        private Packages selectedPackage;//the current package
        private List<int> selectedProductsIds; //selected package products 
        private int selected_packageID; // keeps track of selected product for modifying/deleting


        public frmPackages()
        {
            InitializeComponent();
        }
        private void frmPackages_Load(object sender, EventArgs e)
        {
            //disabling modify and remove
            ManageControls(false);
            //displaying products
            DisplayLVPackages();
        }

        private void DisplayLVPackages()
        {
            //first clear the list view
            lvPackages.Clear();

            //setting width of listview 
            lvPackages.Width = 1150;
            // Declare and construct the ColumnHeader objects.
            ColumnHeader header1, header2, header3, header4, header5, header6;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            header3 = new ColumnHeader();
            header4 = new ColumnHeader();
            header5 = new ColumnHeader();
            header6 = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            header1.Text = "ID";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 70;

            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 300;

            header3.Text = "Starts";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 200;

            header4.Text = "Ends";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 200;

            header5.Text = "Base Price";
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Width = 180;

            header6.Text = "Commission";
            header6.TextAlign = HorizontalAlignment.Left;
            header6.Width = 180;

            // Add the headers to the ListView control.
            lvPackages.Columns.Add(header1);
            lvPackages.Columns.Add(header2);
            lvPackages.Columns.Add(header3);
            lvPackages.Columns.Add(header4);
            lvPackages.Columns.Add(header5);
            lvPackages.Columns.Add(header6);

            // Specify that each item appears on a separate line.
            lvPackages.View = View.Details;

            //create a list of products to save retrieved products from data base
            var packageList = context.Packages.ToList();
            int i = 0;
            foreach (var p in packageList)
            {
                lvPackages.Items.Add(p.PackageId.ToString());
                lvPackages.Items[i].SubItems.Add(p.PkgName.ToString());
                DateTime start = (DateTime)p.PkgStartDate;
                lvPackages.Items[i].SubItems.Add(start.ToString("dd/MMM/yyyy"));
                DateTime end = (DateTime)p.PkgEndDate;
                lvPackages.Items[i].SubItems.Add(end.ToString("dd/MMM/yyyy"));
                lvPackages.Items[i].SubItems.Add(p.PkgBasePrice.ToString("c0"));
                decimal com = (decimal)p.PkgAgencyCommission;
                lvPackages.Items[i].SubItems.Add(com.ToString("c0"));

                i++;
            }

        }

        /// <summary>
        /// This function keeps track of the change in list view item selection changes, and saves
        /// it to be used in modify and delete functions
        /// when selection changes, modify and remove button's are enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> retrieving the selected item from the e argument</param>
        private void lvPackages_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //enabling modify and delete buttons only if a row is selected
            if (e.IsSelected)
            {
                ManageControls(true);//if a product is selected, enable modify/remove buttons
                selected_packageID = Convert.ToInt32(e.Item.Text);
            }
            else
            {
                ManageControls(false);//disable modify/remove buttons otherwise
            }
        }
        //Adding new package
        private void btnAdd_Click(object sender, EventArgs e)
        {
            HideForm();
            //create second form
            frmAddModifyPackage addModPkg = new frmAddModifyPackage();

            //create products form
            frmAddMultiProd addProd = new frmAddMultiProd();

            // setting isAdd to true to pass it to the second form
            addModPkg.isAdd = true;
            addModPkg.package = null; //no package

            //show it modal
            DialogResult result = addModPkg.ShowDialog();//accept returns ok

            //if dialogresult is ok, save package, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedPackage = addModPkg.package;
                selectedProductsIds = addModPkg.updated_Product_Selections;
                try
                {
                    var newPackage = context.Packages.Add(selectedPackage);
                    context.SaveChanges();
                    //adding associated products only if added
                    if (selectedProductsIds != null)
                    {
                        foreach (var item in selectedProductsIds)
                        {
                            //creating the corresponding entry for each selected product
                            //in the PackagesProductsSuppliers table
                            PackagesProductsSuppliers pkgProdsup = new PackagesProductsSuppliers();
                            pkgProdsup.ProductSupplierId = item;
                            int id = selectedPackage.PackageId;
                            pkgProdsup.PackageId = id;
                            context.PackagesProductsSuppliers.Add(pkgProdsup);
                        }
                        context.SaveChanges();
                    }
                    
                    
                    DisplayLVPackages();
                }
                catch (DbUpdateException ex)
                {
                    HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
                
            }
            ShowForm();
            ClearSelection();

        }

        //Modifying existing product
        private void btnModify_Click(object sender, EventArgs e)
        {
            HideForm();
            //create second form
            frmAddModifyPackage addModPkg = new frmAddModifyPackage();
            // setting isAdd to false to pass it to the second form
            addModPkg.isAdd = false;

            /*retrieving the selected product
             * selected_package code is retrieved from the lvPackages_ItemSelectionChanged
            event handler*/
            addModPkg.package = context.Packages.Find(selected_packageID);
            addModPkg.Original_Product_selections = ProductsByPackage(selected_packageID);
            
            //show it modal
            DialogResult result = addModPkg.ShowDialog();//accept returns ok

            //if dialogresult is ok, save product, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedPackage = addModPkg.package;
                var updated = addModPkg.updated_Product_Selections;
                var original = GetProdSuppId_Selections(selected_packageID);
                if (updated!=null)
                    selectedProductsIds = updated;
                else
                    selectedProductsIds = original;
                try
                {
                  
                    //remove old selections
                    var pkgProdSuppliers = context.PackagesProductsSuppliers
                    .Where(p => p.PackageId == selected_packageID);
                    

                    foreach (var item in pkgProdSuppliers)
                        context.PackagesProductsSuppliers.Remove(item);

                    context.SaveChanges();

                    //add new selections

                    foreach (var item in selectedProductsIds)
                    {
                        //creating the corresponding entry for each selected product
                        //in the PackagesProductsSuppliers table
                        PackagesProductsSuppliers pkgProdsup = new PackagesProductsSuppliers();
                        pkgProdsup.ProductSupplierId = item;
                        int id = selectedPackage.PackageId;
                        pkgProdsup.PackageId = id;
                        context.PackagesProductsSuppliers.Add(pkgProdsup);
                    }

                    context.SaveChanges();
                    DisplayLVPackages();


                }



                catch (DbUpdateException ex)
                {
                    HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
            ShowForm();
            ClearSelection();
            ManageControls(false);

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            HideForm();
            //create second form
            frmViewPkg secondForm = new frmViewPkg();

            /*retrieving the selected product
             * selected_package code is retrieved from the lvPackages_ItemSelectionChanged
            event handler*/
            secondForm.package = context.Packages.Find(selected_packageID);
            //retrieving a list of the ProductSupplierID for the selected package
            secondForm.prodlist = ProductsByPackage(selected_packageID);

            this.Visible = false;
            //show it modal
            DialogResult result = secondForm.ShowDialog();//accept returns ok
            this.Visible = true;

            ShowForm();
            ClearSelection();
            ManageControls(false);

        }

        

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // retrieving product through user selection from lvProducts_ItemSelectionChange event handler
            //int ID = Convert.ToInt32(selected_packageID);
            
            selectedPackage = context.Packages.Find(selected_packageID);
            var pkgProdSuppliers = context.PackagesProductsSuppliers
                .Where(p=> p.PackageId == selected_packageID);
            //get confirmation from the user 
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedPackage.PkgName}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    
                    //remove every PackagesProductSupplier entry associated with the package
                    foreach(var item in pkgProdSuppliers)
                        context.PackagesProductsSuppliers.Remove(item);
                    context.SaveChanges();

                    //remove the package 
                    context.Packages.Remove(selectedPackage);
                    context.SaveChanges();

                    //display updated listview
                    DisplayLVPackages();
                }
                catch (DbUpdateException ex)
                {
                    HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }

            ManageControls(false);
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //displays error message of Database update error
        private void HandleDataError(DbUpdateException ex)
        {
            var sqlException = (SqlException)ex.InnerException;
            string message = "";
            foreach (SqlError error in sqlException.Errors)
            {
                message += "Error Code: " + error.Number + " - " + error.Message + "\n";
            }
            MessageBox.Show(message, "Data Error(s)");
        }

        //displays error message of unknown (any)error
        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void HideForm()
        {
            this.Visible = false;
        }

        private void ShowForm()
        {
            this.Visible = true;
        }

        /// <summary>
        ///  this function manages disabling/enabling modify and delete buttons
        /// </summary>
        /// <param name="status">true to enable buttons, false to disable</param>
        private void ManageControls(bool status)
        {
            btnModify.Enabled = status;
            btnRemove.Enabled = status;
            btnView.Enabled = status;
        }

        private void ClearSelection()
        {
            lvPackages.SelectedItems.Clear();
        }
        private List<string> ProductsByPackage(int selected_packageID)
        {
            List<string> productsList = new List<string>();
            List<int> PkgProdSups = GetProdSuppId_Selections(selected_packageID);
            //looping through all ProductSupplierIds to retrieve 
            // supplier name and product name associated with each product
            foreach (var pkgProdSupID in PkgProdSups)
            {
                var ps = context.ProductsSuppliers
                    .SingleOrDefault(ps => pkgProdSupID == ps.ProductSupplierId);

                var sup = context.Suppliers.Find(ps.SupplierId);
                var prod = context.Products.Find(ps.ProductId);

                productsList.Add(pkgProdSupID + " | " + sup.SupName + " " + prod.ProdName);

            }
            return productsList;

        }

        private List<int> GetProdSuppId_Selections(int selected_packageID)
        {
            return context.PackagesProductsSuppliers.
                Where(p => p.PackageId == selected_packageID).
                Select(psID => psID.ProductSupplierId).ToList();
        }
    }
}
