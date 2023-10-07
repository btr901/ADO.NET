using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadDataSetXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataSet dsNorthwind = new DataSet();

        private void btnLoadSchema_Click(object sender, EventArgs e)
        {
            dsNorthwind.ReadXmlSchema("Northwind.xsd");
            gdvCustomers.DataSource = dsNorthwind.Tables["Customers"];
            gdvOrders.DataSource = dsNorthwind.Tables["Orders"];

        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            dsNorthwind.ReadXml("Northwind.xml");
        }
    }
}
