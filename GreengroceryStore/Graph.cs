using System;
using System.Windows.Forms;

namespace GreengroceryStore
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            this.продуктTableAdapter1.Fill(this.greengrocery_storeDataSet1.Продукт);
        }
    }
}
