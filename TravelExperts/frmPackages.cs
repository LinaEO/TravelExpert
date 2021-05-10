using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts
{
    public partial class frmPackages : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); //DB Context object
        private Packages selectedPackage;//the current package
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

        /// <summary>
        ///  this function manages disabling/enabling modify and delete buttons
        /// </summary>
        /// <param name="status">true to enable buttons, false to disable</param>
        private void ManageControls(bool status)
        {
            btnModify.Enabled = status;
            btnRemove.Enabled = status;
        }

        private void DisplayLVPackages()
        {
            //first clear the list view
            lvPackages.Clear();

            //setting width of listview 
            lvPackages.Width = 800;
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
            header1.Width = 50;

            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 150;

            header3.Text = "Starts";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 150;

            header4.Text = "Ends";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 250;

            header5.Text = "Base Price";
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Width = 100;

            header6.Text = "Commission";
            header6.TextAlign = HorizontalAlignment.Left;
            header6.Width = 100;

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
                lvPackages.Items[i].SubItems.Add(p.PkgStartDate.ToString());
                lvPackages.Items[i].SubItems.Add(p.PkgEndDate.ToString());
                lvPackages.Items[i].SubItems.Add(p.PkgBasePrice.ToString());
                lvPackages.Items[i].SubItems.Add(p.PkgAgencyCommission.ToString());

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
            //create second form
            frmAddModifyPackage secondForm = new frmAddModifyPackage();

            // setting isAdd to true to pass it to the second form
            secondForm.isAdd = true;
            secondForm.package = null; //no package

            //show it modal
            DialogResult result = secondForm.ShowDialog();//accept returns ok

            //if dialogresult is ok, save package, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedPackage = secondForm.package;
                try
                {
                    context.Packages.Add(selectedPackage);
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

        }

        //Modifying existing product
        private void btnModify_Click(object sender, EventArgs e)
        {
            //create second form
            frmAddModifyPackage secondForm = new frmAddModifyPackage();

            // setting isAdd to false to pass it to the second form
            secondForm.isAdd = false;

            /*retrieving the selected product
             * selected_package code is retrieved from the lvPackages_ItemSelectionChanged
            event handler*/
            secondForm.package = context.Packages.Find(selected_packageID);

            //show it modal
            DialogResult result = secondForm.ShowDialog();//accept returns ok

            //if dialogresult is ok, save product, and display items in list view
            if (result == DialogResult.OK)
            {
                selectedPackage = secondForm.package;
                try
                {
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
            ManageControls(false);

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // retrieving product through user selection from lvProducts_ItemSelectionChange event handler
            //int ID = Convert.ToInt32(selected_packageID);
            
            selectedPackage = context.Packages.Find(selected_packageID);
            //get confirmation from the user 
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedPackage.PkgName}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //remove the customer 
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

       
    }
}
