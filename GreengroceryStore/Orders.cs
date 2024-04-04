using System;
using System.Collections;
using System.Windows.Forms;

namespace GreengroceryStore
{
    public partial class Orders : Form
    {
        DataAccessLayer dataAccessLayer = new DataAccessLayer();

        ArrayList allOrders;
        ArrayList allCustomers;
        ArrayList allTraders;
        ArrayList allProducts;
        ArrayList allBasket;

        public Orders()
        {
            InitializeComponent();

            allOrders = dataAccessLayer.GetAllOrders();

            allCustomers = dataAccessLayer.GetAllCustomers();

            allTraders = dataAccessLayer.GetAllTraders();

            allProducts = dataAccessLayer.GetAllProducts();

            allBasket = dataAccessLayer.GetAllBaskets();    

            textBox1.Text = Guid.NewGuid().ToString();

            comboBox1.DataSource = allCustomers;

            comboBox2.DataSource = allTraders;

            dataGridView1.DataSource = allOrders;

            dataGridView2.DataSource = allProducts;

            dataGridView3.DataSource = allBasket;

            Settings();
        }

        public void Settings()
        {
            try
            {
                if (dataGridView1.Columns.Contains("ID_Заказа") && dataGridView1.Columns.Contains("ID_Сотрудника") && dataGridView1.Columns.Contains("ID_Покупателя"))
                {
                    dataGridView1.Columns["ID_Заказа"].Visible = false;
                    dataGridView1.Columns["ID_Сотрудника"].Visible = false;
                    dataGridView1.Columns["ID_Покупателя"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Столбцы 'ID_Заказа' и 'ID_Сотрудника' и 'ID_Покупателя' отсутствуют в таблице.");
                }

                if (dataGridView2.Columns.Contains("ID_продукта") && dataGridView2.Columns.Contains("ID_Категории"))
                {
                    dataGridView2.Columns["ID_продукта"].Visible = false;
                    dataGridView2.Columns["ID_Категории"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Столбцы 'ID_продукта' и 'ID_Категории' отсутствуют в таблице.");
                }

                if (dataGridView3.Columns.Contains("ID_Корзины") && dataGridView3.Columns.Contains("ID_продукта") && dataGridView3.Columns.Contains("ID_Заказа"))
                {
                    dataGridView3.Columns["ID_Корзины"].Visible = false;
                    dataGridView3.Columns["ID_продукта"].Visible = false;
                    dataGridView3.Columns["ID_Заказа"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Столбцы 'ID_Корзины' и 'ID_продукта' и 'ID_Заказа' отсутствуют в таблице.");
                }

                if (dataGridView1.TopLeftHeaderCell != null && dataGridView2.TopLeftHeaderCell != null && dataGridView3.TopLeftHeaderCell != null)
                {
                    dataGridView1.TopLeftHeaderCell.Value = "#";
                    dataGridView2.TopLeftHeaderCell.Value = "#";
                    dataGridView3.TopLeftHeaderCell.Value = "#";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataAccessLayer.SaveNewOrders(textBox1.Text.Trim(), comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), dateTimePicker1.Value.ToString(), textBox2.Text.Trim()))
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
            string ID_Заказа = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (dataAccessLayer.UpdateOrders(ID_Заказа, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), dateTimePicker1.Value.ToString(), textBox2.Text.Trim()))
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
            string ID_Заказа = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (dataAccessLayer.DeleteOrder(ID_Заказа))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        //private void Orders_Load(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dataGridView2.Columns.Count; i++)
        //    {
        //        dataGridView2.Columns.Add(dataGridView2.Columns[i].Name.ToString(), dataGridView2.Columns[i].Name.ToString());
        //    }

        //    dataGridView2.Columns.Add("Количество", "Количество");

        //    dataGridView2.Columns.Add("ЦенаНаМоментПродажи", "ЦенаНаМоментПродажи");

        //    dataGridView2.Columns.Add("ВремяОплаты", "ВремяОплаты");
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        // Тут начинается "Корзина"

        int n = 0;
        int v = 0;

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Add();

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView3[i, n].Value = dataGridView2[i, dataGridView2.CurrentRow.Index].Value.ToString();
            }
            n++;

            dataGridView3["ВремяОплаты", v].Value = dateTimePicker1.Value.ToString();
            dataGridView3["ЦенаНаМоментПродажи", v].Value = ((Int32.Parse(dataGridView2["Цена", v].Value.ToString())) * 0.02).ToString();
            dataGridView3["Количество", v].Value = textBox3.Text;
            v++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataAccessLayer.SaveNewBasket(dataGridView2["ID_Продукта", 0].Value.ToString(), dataGridView2["ВремяОплаты", 0].Value.ToString(),
                textBox1.Text.Trim(), dataGridView2["ЦенаНаМоментПродажи", 0].Value.ToString(), dataGridView2["Количество", 0].Value.ToString()))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}