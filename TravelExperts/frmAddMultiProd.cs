using TravelExperts;
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
    public partial class frmAddMultiProd : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); //DB Context object
       // private List<string> selected_sup = new List<string>();//keeps track of selected suppliers
       private List<int> selected_prod = new List<int>(); //keeps track of selected products
       private List<string> suppliers = new List<string>();//saving all suppliers
       private List<string> products = new List<string>(); // saving products for each supplier
       public List<int> prdSupIds = new List<int>();
       public List<string> currentProductSelections = new List<string>();

        public frmAddMultiProd()
        {
            InitializeComponent();
        }
        private void frmAddMultiProd_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            if (currentProductSelections.Count > 0)
            {
                //load previous product selections
                foreach (var product in currentProductSelections)
                {
                    //loading selections list box with previously selected products
                    lbo_Selections.Items.Add(product);

                    //updating selected products to save previous selections 
                    //unless otherwise decided by user
                    string[] prod_split = product.Split('|');
                    int id = Convert.ToInt32(prod_split[0].Trim());
                    selected_prod.Add(id);
                    this.Text = "Update Products in Package";

                }
                //update button text to display that this is an update
                btn_AddProds.Text = "Update Products";
               
            }
        }

       
        private void btn_ProdSelect_Click(object sender, EventArgs e)
        {
            //keeping track of selected suppliers

            foreach (var item in clb_Products.CheckedItems)
            {
                string[] sup_details = lbo_Suppliers.SelectedItem.ToString().Split('|');
                string[] prod_details = item.ToString().Split('|');

                int selected_ProdSupID = context.ProductsSuppliers
                   .SingleOrDefault(psID => psID.ProductId == Convert.ToInt32(prod_details[0])
               && psID.SupplierId == Convert.ToInt32(sup_details[0])).ProductSupplierId;

                var lbo_item_text = selected_ProdSupID + " | " + sup_details[1] + " " + prod_details[1] ;
                //    var selection_text_ids = lbo_Suppliers.SelectedItem.ToString() + "|" + item.ToString();


                if (!lbo_Selections.Items.Contains(lbo_item_text))
                {
                    lbo_Selections.Items.Add(lbo_item_text);
                    selected_prod.Add(selected_ProdSupID);
                }
                else
                    MessageBox.Show("Product already added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //clearing selections
            lbo_Suppliers.ClearSelected();
          

        }

        private void btn_ProdUnSelect_Click(object sender, EventArgs e)
        {
            if (lbo_Selections.SelectedIndex >= 0)
            {
                string[] selection = lbo_Selections.SelectedItem.ToString().Split('|');
                lbo_Selections.Items.Remove(lbo_Selections.SelectedItem);
                int id = Convert.ToInt32(selection[0]);
                selected_prod.Remove(id);
                //clearing selection
                lbo_Suppliers.ClearSelected();
                
            }

        }
        /// <summary>
        /// when a supplier is selected, relevant products are loaded in the check box
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbo_Suppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();

        }

        private void LoadSuppliers()
        {
            //on form load, show all suppliers
            suppliers = context.Suppliers // retrieve suppliers data
                        .OrderBy (s=> s.SupplierId)
                        .Select(s => s.SupplierId + " | "+ s.SupName)
                        .ToList();
            foreach (var item in suppliers)
                lbo_Suppliers.Items.Add(item);
        }

        private void LoadProducts()
        {
            //Query that retrieves products associated with each supplier
            products = (from p in context.Products
                        join ps in context.ProductsSuppliers on p.ProductId equals ps.ProductId
                        join s in context.Suppliers on ps.SupplierId equals s.SupplierId
                        where  s.SupplierId +" | " +s.SupName  == lbo_Suppliers.SelectedItem
                        select p.ProductId + " | " +p.ProdName).ToList();
            //Clearing the list to avoid products loaded from previous suppliers selected
            clb_Products.Items.Clear();
            //displaying product list associated with selected supplier
            foreach (var item in products)
                clb_Products.Items.Add(item);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AddProds_Click(object sender, EventArgs e)
        {

            //string[] id_values = item.Split('|');
            //var value =  (from p in context.Products
            //             join ps in context.ProductsSuppliers on p.ProductId equals ps.ProductId
            //             join s in context.Suppliers on ps.SupplierId equals s.SupplierId
            //             where s.SupplierId == Convert.ToInt32(id_values[0])
            //             && p.ProductId == Convert.ToInt32(id_values[2])
            //             select ps.ProductSupplierId).SingleOrDefault();
            //prdSupIds.Add(Convert.ToInt32(value));
            prdSupIds = selected_prod;


            //set dialog result to ok
            this.DialogResult = DialogResult.OK;
        }

        private void btnClearSelections_Click(object sender, EventArgs e)
        {
            selected_prod.Clear();
            lbo_Selections.Items.Clear();

        }
    }
}
