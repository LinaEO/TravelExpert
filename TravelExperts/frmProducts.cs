using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices;


namespace TravelExperts
{
    public partial class frmProducts : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext();

        private Products selectedProduct;
        private Products searchedProduct;
        public frmProducts()
        {
            InitializeComponent();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //LOAD EVENTS ----------------------------------------

        private void frmProducts_Load(object sender, EventArgs e)
        {
            DisplayProducts();
        }
        //   CREATE UPDATE READ DELETE PRODUCT------------------------------------------

        private void DeleteProduct()
        {
            DialogResult result =
              MessageBox.Show($"Delete {selectedProduct.ProductId}?",
              "Confirm Delete", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (result == DialogResult.Yes)// user confirmed
            {
                try
                {
                    context.Products.Remove(selectedProduct);
                    context.SaveChanges(true);
                    DisplayProducts();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void DisplayProducts()
        {
            dgvProducts.Columns.Clear();
            var products = context.Products // retrieve products data
                .OrderBy(p => p.ProdName) // ordered alpabetically by name
                .Select(p => new { p.ProductId, p.ProdName }) // only two columns
                .ToList();

            dgvProducts.DataSource = products;

            // add column for modify button
            var modifyColumn = new DataGridViewButtonColumn()
            { // object initializer
                UseColumnTextForButtonValue = true,
                HeaderText = "", // header on the top
                Text = "Modify"
            };

            dgvProducts.Columns.Add(modifyColumn);// add new column to the grid view

            // add column for delete button
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };

            dgvProducts.Columns.Add(deleteColumn);

            // format the column header
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Black; // black background on headers
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // white text on headers

            // format the odd numbered rows
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue; //light green alternate rows

            // format the first column
            dgvProducts.Columns[0].HeaderText = "Product Id";
            dgvProducts.Columns[0].Width = 80;

            // format the second column
            dgvProducts.Columns[1].HeaderText = "Product Name";
            dgvProducts.Columns[1].Width = 330;

            // format the third and fourth column
            dgvProducts.Columns[2].Width = 150;
            dgvProducts.Columns[3].Width = 150;
        }

        private void ModifyProduct()
        {
            var addModifyProductForm = new frmAddModifyProduct()
            { // object initializer
                AddProduct = false,
                Product = selectedProduct
            };
            DialogResult result = addModifyProductForm.ShowDialog();// display modal
            if (result == DialogResult.OK)// user clicked Accept on the second form
            {
                try
                {
                    selectedProduct = addModifyProductForm.Product; // new data
                    context.SaveChanges();
                    DisplayProducts();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addModifyProductForm = new frmAddModifyProduct()
            {
                AddProduct = true
            };

            DialogResult result = addModifyProductForm.ShowDialog();

            if (result == DialogResult.OK)// user clicked on Accept on the second form
            {
                try
                {
                    selectedProduct = addModifyProductForm.Product;// record product from the second form as the current product
                    context.Products.Add(selectedProduct);
                    context.SaveChanges();
                    DisplayProducts();
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
            //   CLICK EVENTS-----------------------------
        }
            private void btnExit_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                // e object carries information about the click
                // like e.ColumnIndex and e.RowIndex
                {
                    // store index values for Modify and Delete button columns
                    const int ModifyIndex = 2; // Modify buttins are column 2
                    const int DeleteIndex = 3; // Delete buttons are column 3

                    if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex) // is it a button?
                    {
                        // get the product code:
                        // grid view has properties (collection) Rows and Columns
                        // product code is cell number 0 in the current row
                        // need to trim white spaces from char(10) column
                        int productId = (int)dgvProducts.Rows[e.RowIndex].Cells[0].Value;

                        selectedProduct = context.Products.Find(productId);// find by PK value
                    }

                    if (e.ColumnIndex == ModifyIndex) // user clicked on Modify
                    {
                        ModifyProduct();
                    }
                    else if (e.ColumnIndex == DeleteIndex) // user clicked on Delete
                    {
                        DeleteProduct();
                    }
                }
            }
            // ERRORS-----------------------------------------------------
            private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();

                var state = context.Entry(selectedProduct).State;
                if (state == EntityState.Detached)
                {
                    MessageBox.Show("Another user has deleted that product.",
                        "Concurrency Error");
                }
                else
                {
                    string message = "Another user has updated that product.\n" +
                        "The current database values will be displayed.";
                    MessageBox.Show(message, "Concurrency Error");
                }
                this.DisplayProducts();
            }

            private void HandleDatabaseError(DbUpdateException ex)
            {
                string errorMessage = "";
                var sqlException = (SqlException)ex.InnerException;
                foreach (SqlError error in sqlException.Errors)
                {
                    errorMessage += "ERROR CODE:  " + error.Number + " " +
                                    error.Message + "\n";
                }
                MessageBox.Show(errorMessage);
            }

            private void HandleGeneralError(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        //private void txtSearchBar_KeyUp(object sender, KeyEventArgs e)
        //{
        //    // get search
        //    string search = txtSearchBar.Text.Trim();    //!!how to connect the main dashboard's searchbar to the products form？

        //    searchedProduct = context.Products.Find(search);
        //    // context is like the entry point
        //    if (searchedProduct == null) // no such product name
        //    {
        //        MessageBox.Show("No Product found ");

        //    }
        //    else // we have the selected customer; make sure that State is loaded
        //    {
        //        // public virtual States StateNavigation { get; set; }
        //        // [InverseProperty("Customer")]
        //        if (!context.Entry(searchedProduct)
        //            .Reference("StateNavigation").IsLoaded)// if State not loaded
        //        {
        //            context.Entry(searchedProduct)
        //            .Reference("StateNavigation").Load(); // load it
        //        }
        //        DisplayProducts();
        //    }
        //}
    }
}
