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
    }
}