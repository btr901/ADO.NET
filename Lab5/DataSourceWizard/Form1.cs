using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceWizard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsNorthwind);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ordersTableAdapter.Fill(this.dsNorthwind.Orders);
            this.customersTableAdapter.Fill(this.dsNorthwind.Customers);

        }
    }
}
