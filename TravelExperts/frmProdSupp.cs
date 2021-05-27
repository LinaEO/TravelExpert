using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}