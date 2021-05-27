using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace TravelExperts
{
    public partial class frmProdSupp : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); //DB Context object
        private ProductsSuppliers selectedProductsSupplier;//the current productsSupplier
        private List<int> selectedProductsSupplierIds;
        private int selected_ProductsSupplierID; // keeps track of selected productsSupplier for modifying/deleting

        public frmProdSupp()
        {
            InitializeComponent();
        }

        private void frmProdSupp_Load(object sender, EventArgs e)
        {
            //disabling modify and remove
            ManageControls(false);
            //displaying suppliers
            DisplayLVProductsSuppliers();
        }

        // <summary>
        ///  this function manages disabling/enabling modify and delete buttons
        /// </summary>
        /// <param name="status">true to enable buttons, false to disable</param>
        private void ManageControls(bool status)
        {
            btnModify.Enabled = status;
            btnRemove.Enabled = status;
        }

        //-------------------DISPLAY--------------------------------------------------

        private void DisplayLVProductsSuppliers()
        {
            //first clear the list view
            listViewProdSupp.Clear();

            //setting width of listview
            listViewProdSupp.Width = 1100;
            // Declare and construct the ColumnHeader objects.
            ColumnHeader header1, header2, header3;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            header3 = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            header1.Text = "Products Supplier ID";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 250;

            header2.Text = "Product ID";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width =300;

            header3.Text = "Supplier ID";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 300;

            // Add the headers to the ListView control.
            listViewProdSupp.Columns.Add(header1);
            listViewProdSupp.Columns.Add(header2);
            listViewProdSupp.Columns.Add(header3);

            // Specify that each item appears on a separate line.
            listViewProdSupp.View = View.Details;

            //create a list of suppliers to save retrieved productsSupplier from data base
            var productsSuppliersList = context.ProductsSuppliers.ToList();
            int i = 0;
            foreach (var p in productsSuppliersList)
            {
                listViewProdSupp.Items.Add(p.ProductSupplierId.ToString());
                listViewProdSupp.Items[i].SubItems.Add(p.ProductSupplierId.ToString());

               listViewProdSupp.Items.Add(p.ProductId.ToString());
                listViewProdSupp.Items[i].SubItems.Add(p.ProductId.ToString());

                 listViewProdSupp.Items.Add(p.SupplierId.ToString());
                listViewProdSupp.Items[i].SubItems.Add(p.SupplierId.ToString());

                
               
                i++;
            }
        }
 //-------------------SELECT productsSupplier-------------------------------------------------
        /// <summary>
        /// This function keeps track of the change in list view item selection changes, and saves
        /// it to be used in modify and delete functions
        /// when selection changes, modify and remove button's are enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> retrieving the selected item from the e argument</param>
        private void listViewProdSupp_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // enabling modify and delete buttons only if a row is selected
            if (e.IsSelected)
            {
                ManageControls(true);//if a supplier is selected, enable modify/remove buttons
                selected_ProductsSupplierID = Convert.ToInt32(e.Item.Text);
            }
            else
            {
                ManageControls(false);//disable modify/remove buttons otherwise
            }


        }
        //-------------------ADD productsSupplier--------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //create second form
            frmAddModifyProdSupp addModifySupplier = new frmAddModifyProdSupp();

            addModifySupplier.isAdd = true;
            addModifySupplier.productsSupplier = null;

            DialogResult result = addModifySupplier.ShowDialog();//accept returns ok

            //if dialogresult is ok, save productsSupplier, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedProductsSupplier = addModifySupplier.productsSupplier;
                selectedProductsSupplierIds = addModifySupplier.selectedProductsSupplierIds;
               
                try
                {
                    var newProductsSupplier = context.ProductsSuppliers.Add(selectedProductsSupplier);

                    context.SaveChanges();

                    DisplayLVProductsSuppliers();
                }
                //catch (DbUpdateConcurrencyException ex)
                //{
                //    HandleConcurrencyError(ex);
                //}
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

        private void btnModify_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
          
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

        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

            var state = context.Entry(selectedProductsSupplier).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted that Product Supplier.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that Product Supplier.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayLVProductsSuppliers();
        }
        //-------------------MODIFY productsSupplier --------------------------------------------------
        private void btnModify_Click_1(object sender, EventArgs e)
        {
            //create second form
            frmAddModifyProdSupp secondForm = new frmAddModifyProdSupp();

            secondForm.isAdd = false;

            secondForm.productsSupplier = context.ProductsSuppliers.Find(selected_ProductsSupplierID);

            DialogResult result = secondForm.ShowDialog();//accept returns ok

            if (result == DialogResult.OK)
            {
                selectedProductsSupplier = secondForm.productsSupplier;
                try
                {
                    context.SaveChanges();
                    DisplayLVProductsSuppliers();
                }
                //catch (DbUpdateConcurrencyException ex)
                //{
                //    HandleConcurrencyError(ex);
                //}
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
        //-------------------REMOVE OR DELETE ProductsSupplier --------------------------------------------------

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            selectedProductsSupplier = context.ProductsSuppliers.Find(selected_ProductsSupplierID);
         
           

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedProductsSupplier.ProductSupplierId}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {

                    context.ProductsSuppliers.Remove(selectedProductsSupplier);
                    context.SaveChanges(true);
                    DisplayLVProductsSuppliers();
                }
                //catch (DbUpdateConcurrencyException ex)
                //{
                //    HandleConcurrencyError(ex);
                //}
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

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
