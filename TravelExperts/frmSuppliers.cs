using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelExperts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PackagesGUI
{
    public partial class frmSuppliers : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); //DB Context object
        private Suppliers selectedSupplier;//the current package
        private List<int> selectedSuppliersIds; //selected package suppliers
        private int selected_supplierID; // keeps track of selected supplier for modifying/deleting

        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            //disabling modify and remove
            ManageControls(false);
            //displaying suppliers
            DisplayLVSuppliers();
        }

        /// <summary>
        ///  this function manages disabling/enabling modify and delete buttons
        /// </summary>
        /// <param name="status">true to enable buttons, false to disable</param>
        private void ManageControls(bool status)
        {
            btnModify.Enabled = status;
            btnRemove.Enabled = status;
        }

        private void DisplayLVSuppliers()
        {
            //first clear the list view
            listViewSuppliers.Clear();

            //setting width of listview
            listViewSuppliers.Width = 1000;
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
            header2.Width = 750;

            // Add the headers to the ListView control.
            listViewSuppliers.Columns.Add(header1);
            listViewSuppliers.Columns.Add(header2);

            // Specify that each item appears on a separate line.
            listViewSuppliers.View = View.Details;

            //create a list of suppliers to save retrieved suppliers from data base
            var supplierList = context.Suppliers.ToList();
            int i = 0;
            foreach (var p in supplierList)
            {
                listViewSuppliers.Items.Add(p.SupplierId.ToString());
                listViewSuppliers.Items[i].SubItems.Add(p.SupName.ToString());

                i++;
            }
        }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //create second form
            frmAddModifySupplier addModifySupplier = new frmAddModifySupplier();

            // setting isAdd to true to pass it to the second form
            addModifySupplier.isAdd = true;
            addModifySupplier.supplier = null; //no package

            //show it modal
            DialogResult result = addModifySupplier.ShowDialog();//accept returns ok

            //if dialogresult is ok, save package, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedSupplier = addModifySupplier.supplier;
                selectedSuppliersIds = addModifySupplier.selectedSuppliersIds;
                try
                {
                    var newSupplier = context.Suppliers.Add(selectedSupplier);
                    context.SaveChanges();
                    //adding associated suppliers

                    DisplayLVSuppliers();
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

        private void btnModify_Click(object sender, EventArgs e)
        {
            //create second form
            frmAddModifySupplier secondForm = new frmAddModifySupplier();

            // setting isAdd to false to pass it to the second form
            secondForm.isAdd = false;

            /*retrieving the selected supplier
             * selected_package code is retrieved from the lvPackages_ItemSelectionChanged
            event handler*/
            secondForm.supplier = context.Suppliers.Find(selected_supplierID);

            //show it modal
            DialogResult result = secondForm.ShowDialog();//accept returns ok

            //if dialogresult is ok, save supplier, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedSupplier = secondForm.supplier;
                try
                {
                    context.SaveChanges();
                    DisplayLVSuppliers();
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // retrieving supplier through user selection from lvSuppliers_ItemSelectionChange event handler
            //int ID = Convert.ToInt32(selected_packageID);

            selectedSupplier = context.Suppliers.Find(selected_supplierID);
            var suppliers = context.ProductsSuppliers
                 .Where(s => s.SupplierId == selected_supplierID);
            //get confirmation from the user
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedSupplier.SupName}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //remove the package
                    context.Suppliers.Remove(selectedSupplier);
                    //remove every PackagesSupplierSupplier entry associated with the package
                    foreach (var item in suppliers)
                        context.ProductsSuppliers.Remove(item);
                    
                    context.SaveChanges();

                    //display updated listview
                    DisplayLVSuppliers();
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

        private void listViewSuppliers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // enabling modify and delete buttons only if a row is selected
            if (e.IsSelected)
            {
                ManageControls(true);//if a supplier is selected, enable modify/remove buttons
                selected_supplierID = Convert.ToInt32(e.Item.Text);
            }
            else
            {
                ManageControls(false);//disable modify/remove buttons otherwise
            }
        }
    }
}