using System;
using System.Collections;
using System.Windows.Forms;

namespace GreengroceryStore
{
    public partial class Products : Form
    {
        DataAccessLayer dataAccessLayer = new DataAccessLayer();
            
        ArrayList allProducts;
        ArrayList allCategories;

        public Products()
        {
            InitializeComponent();

            allProducts = dataAccessLayer.GetAllProducts();
            allCategories = dataAccessLayer.GetAllCategories();

            dataGridView1.DataSource = allProducts;

            textBox2.Text = Guid.NewGuid().ToString();

            comboBox1.DataSource = allCategories;
           
            Settings();
        }

        public void Settings()
        {
            try
            {
                if (dataGridView1.Columns.Contains("ID_Продукта") && dataGridView1.Columns.Contains("ID_Категории"))
                {
                    dataGridView1.Columns["ID_Продукта"].Visible = false;
                    dataGridView1.Columns["ID_Категории"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Столбцы 'ID_Продукта' и 'ID_Категории' отсутствуют в таблице.");
                }

                if (dataGridView1.TopLeftHeaderCell != null)
                {
                    dataGridView1.TopLeftHeaderCell.Value = "#";
                }
                else
                {
                    MessageBox.Show("Не удалось установить значение ячейки вверху слева.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (dataAccessLayer.SaveNewProduct(textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim(), comboBox1.SelectedValue.ToString()))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ID_Продукта = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (dataAccessLayer.UpdateProducts(ID_Продукта, textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim(), comboBox1.SelectedValue.ToString()))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ID_Продукта = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (dataAccessLayer.DeleteProducts(ID_Продукта))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
