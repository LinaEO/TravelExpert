using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TravelExperts;

namespace PackagesGUI
{
    public partial class frmProducts : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); //DB Context object
        private Products selectedProduct;//the current product
        private List<int> selectedProductsIds; //selected product
        private int selected_productID; // keeps track of selected product for modifying/deleting


        //LOADING---------------------------------
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            //disabling modify and remove
            ManageControls(false);
            //displaying products
            DisplayLVProducts();
        }
        //-------------------CONTROLS--------------------------------------------------
        /// <summary>
        ///  this function manages disabling/enabling modify and delete buttons
        /// </summary>
        /// <param name="status">true to enable buttons, false to disable</param>
        private void ManageControls(bool status)
        {
            btnModify.Enabled = status;
            btnRemove.Enabled = status;
        }
        //-------------------DISPLAY--------------------------------------------------
        private void DisplayLVProducts()
        {
            //first clear the list view
            listViewProducts.Clear();

            //setting width of listview
            listViewProducts.Width = 1000;
            // Declare and construct the ColumnHeader objects.
            ColumnHeader header1, header2;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            header1.Text = "ID";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 250;

            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 550;

            // Add the headers to the ListView control.
            listViewProducts.Columns.Add(header1);
            listViewProducts.Columns.Add(header2);

            // Specify that each item appears on a separate line.
            listViewProducts.View = View.Details;

            //create a list of products to save retrieved products from data base
            var productList = context.Products.ToList();
            int i = 0;
            foreach (var p in productList)
            {
                listViewProducts.Items.Add(p.ProductId.ToString());
                listViewProducts.Items[i].SubItems.Add(p.ProdName.ToString());

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
        private void listViewProducts_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //enabling modify and delete buttons only if a row is selected
            if (e.IsSelected)
            {
                ManageControls(true);//if a product is selected, enable modify/remove buttons
                selected_productID = Convert.ToInt32(e.Item.Text);
            }
            else
            {
                ManageControls(false);//disable modify/remove buttons otherwise
            }
        }


        //-------------------ADD SUPPLIER--------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //create second form
            frmAddModifyProduct addModifyProduct = new frmAddModifyProduct();

            // setting isAdd to true to pass it to the second form
            addModifyProduct.isAdd = true;
            addModifyProduct.product = null; //no product

            //show it modal
            DialogResult result = addModifyProduct.ShowDialog();//accept returns ok

            //if dialogresult is ok, save product, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedProduct = addModifyProduct.product;
                selectedProductsIds = addModifyProduct.selectedProductsIds;
                try
                {
                    var newProduct = context.Products.Add(selectedProduct);
                    context.SaveChanges();
                    //adding associated products

                    DisplayLVProducts();
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
        }
        //-------------------REMOVE OR DELETE PRODUCT --------------------------------------------------
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // retrieving product through user selection from lvProducts_ItemSelectionChange event handler
            //int ID = Convert.ToInt32(selected_productID);

            selectedProduct = context.Products.Find(selected_productID);
            var products = context.ProductsSuppliers
                .Where(p => p.ProductId == selected_productID);
            //get confirmation from the user
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedProduct.ProdName}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //remove the product
                    context.Products.Remove(selectedProduct);
                    //remove every PackagesProductSupplier entry associated with the product
                    foreach (var item in products)
                        context.ProductsSuppliers.Remove(item);
                    context.SaveChanges();

                    //display updated listview
                    DisplayLVProducts();
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

        //-------------------MODIFY PRODUCT --------------------------------------------------
        private void btnModify_Click(object sender, EventArgs e)
        {
            //create second form
            frmAddModifyProduct secondForm = new frmAddModifyProduct();

            // setting isAdd to false to pass it to the second form
            secondForm.isAdd = false;

            /*retrieving the selected product
             * selected_product code is retrieved from the lvPackages_ItemSelectionChanged
            event handler*/
            secondForm.product = context.Products.Find(selected_productID);

            //show it modal
            DialogResult result = secondForm.ShowDialog();//accept returns ok

            //if dialogresult is ok, save product, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedProduct = secondForm.product;
                try
                {
                    context.SaveChanges();
                    DisplayLVProducts();
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

        //-------------------ERRORHANDLING --------------------------------------------------
        //displays error message of unknown (any)error

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
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
    }
}