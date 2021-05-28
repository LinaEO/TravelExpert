using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TravelExperts
{
    public partial class frmAddModifyProdSupp : Form
    {
       
        private TravelExpertsContext context = new TravelExpertsContext(); //DB Context object

        //private List<string> suppliers = new List<string>();//saving all suppliers
        //private List<string> products = new List<string>(); // saving all products

        public ProductsSuppliers productsSupplier = null;
        public List<int> selectedProductsSupplierIds; //selected  productsSupplier
        public bool isAdd; // to differentiate which operation to be performed

        public frmAddModifyProdSupp()
        {
            InitializeComponent();
        }

        private void frmAddModifyProdSupp_Load(object sender, EventArgs e)
        {
            this.LoadProductComboBox();
            this.LoadSupplierComboBox();

            //distinguish add or modify
            if (this.isAdd)//add
            {
                this.Text = "Add Product Supplier";
                lblProductSupplierID.Text = "TBD";
                cboSupplier.SelectedIndex = -1;
                cboProduct.SelectedIndex = -1;
            }
            else//modify
            {
                this.Text = "Modify Product Supplier";
                lblProductSupplierID.Text = productsSupplier.ProductSupplierId.ToString();
                cboSupplier.SelectedValue = productsSupplier.SupplierId;
                cboProduct.SelectedValue = productsSupplier.ProductId;
            }
        }

        private void LoadSupplierComboBox()
        {
            try
            {
                cboSupplier.DataSource = context.Suppliers.OrderBy(s => s.SupName).ToList();
                cboSupplier.DisplayMember = "SupName";
                cboSupplier.ValueMember = "SupplierId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void LoadProductComboBox()
        {
            try
            {
                cboProduct.DataSource = context.Products.OrderBy(p => p.ProdName).ToList();
                cboProduct.DisplayMember = "ProdName";
                cboProduct.ValueMember = "ProductId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //load productsSupplier data
            if (isAdd)
                productsSupplier = new ProductsSuppliers();

            //packageproductsSupplierID automatically generated and is not modified

            var selectedProduct = cboProduct.SelectedValue.ToString();
            var selectedSupplier = cboSupplier.SelectedValue.ToString();

            productsSupplier.SupplierId = Convert.ToInt32(selectedSupplier);
            productsSupplier.ProductId = Convert.ToInt32(selectedProduct);
            //set dialog result to ok
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}