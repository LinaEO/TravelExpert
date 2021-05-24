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
    public partial class frmSuppliers : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); //DB Context object
        private Suppliers selectedSupplier;//the current Supplier
        private List<int> selectedSuppliersIds;
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

        private void DisplayLVSuppliers()
        {
            //first clear the list view
            listViewSuppliers.Clear();

            //setting width of listview
            listViewSuppliers.Width = 800;
            // Declare and construct the ColumnHeader objects.
            ColumnHeader header1, header2;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            header1.Text = "ID";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 50;

            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 300;

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

        //-------------------SELECT SUPPLIER-------------------------------------------------
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

        //-------------------ADD SUPPLIER--------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //create second form
            frmAddModifySupplier addModifySupplier = new frmAddModifySupplier();

            addModifySupplier.isAdd = true;
            addModifySupplier.supplier = null;

            DialogResult result = addModifySupplier.ShowDialog();//accept returns ok

            //if dialogresult is ok, save supplier, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedSupplier = addModifySupplier.supplier;
                selectedSuppliersIds = addModifySupplier.selectedSuppliersIds;
                //selectedSupplierIds = addModifySupplier.selectedSupplierIds;
                try
                {
                    var newSupplier = context.Suppliers.Add(selectedSupplier);

                    context.SaveChanges();

                    DisplayLVSuppliers();
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

        //-------------------MODIFY SUPPLIER --------------------------------------------------
        private void btnModify_Click(object sender, EventArgs e)
        {
            //create second form
            frmAddModifySupplier secondForm = new frmAddModifySupplier();

            secondForm.isAdd = false;

            secondForm.supplier = context.Suppliers.Find(selected_supplierID);

            DialogResult result = secondForm.ShowDialog();//accept returns ok

            if (result == DialogResult.OK)
            {
                selectedSupplier = secondForm.supplier;
                try
                {
                    context.SaveChanges();
                    DisplayLVSuppliers();
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

        //-------------------REMOVE OR DELETE SUPPLIER --------------------------------------------------
        private void btnRemove_Click(object sender, EventArgs e)
        {
            selectedSupplier = context.Suppliers.Find(selected_supplierID);

            var ProductsSuppliers = context.ProductsSuppliers
                  .Where(s => s.SupplierId == selected_supplierID);

            var SupplierContacts = context.SupplierContacts
                 .Where(s => s.SupplierId == selected_supplierID);

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedSupplier.SupName}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    context.Suppliers.Remove(selectedSupplier);
                    foreach (var item in ProductsSuppliers)
                    {
                        context.ProductsSuppliers.Remove(item);
                    }

                    context.Suppliers.Remove(selectedSupplier);
                    foreach (var item in SupplierContacts)
                    {
                        context.SupplierContacts.Remove(item);
                    }

                    context.SaveChanges(true);
                    DisplayLVSuppliers();
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

        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

            var state = context.Entry(selectedSupplier).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted that Supplier.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that Supplier.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayLVSuppliers();
        }
    }
}