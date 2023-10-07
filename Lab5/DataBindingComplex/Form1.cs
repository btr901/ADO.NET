using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBindingComplex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBindingGrid_Click(object sender, EventArgs e)
        {
            productsTableAdapter1.Fill(northwndDataSet1.Products);
            BindingSource bsProducts = new BindingSource(northwndDataSet1, "Products");
            gdvProducts.DataSource = bsProducts;
            bindingNavigator1.BindingSource = bsProducts;
        }
    }
}
