using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TravelExperts
{
    public partial class frmProdSupp : Form
    {
        private List<string> productsSuppliersList = new List<string>();//saving all productSuppliers
        private List<string> products = new List<string>(); // saving products for each supplier
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

            productsSuppliersList = context.ProductsSuppliers
                .OrderBy(p => p.ProductSupplierId)
                .Select(p => p.ProductSupplierId + "  |  " + p.Supplier.SupName + "  |  " + p.Product.ProdName )
                .ToList();

            //Clearing the list to avoid products loaded from previous suppliers selected
            listBoxProdSupp.Items.Clear();
            //displaying product list associated with selected supplier
            foreach (var item in productsSuppliersList)
                listBoxProdSupp.Items.Add(item);

           
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

        private void listBoxProdSupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            var prodsuprow = Convert.ToString(listBoxProdSupp.SelectedItem);


            string[] prodsuplist = prodsuprow.Split(" ");
            int id = Convert.ToInt32(prodsuplist[0].Trim());


            ManageControls(true);//if a supplier is selected, enable modify/remove buttons
            selected_ProductsSupplierID = id;
            
          
            
        }
    }
}