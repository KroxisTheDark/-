using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GreengroceryStore
{
    public partial class MainForm : Form
    {
        DataAccessLayer dataAccessLayer = new DataAccessLayer();

        ArrayList allProducts;
        ArrayList allCustomers;
        ArrayList allTraders;
        ArrayList allOrders;
        ArrayList allCategories;
        ArrayList allBasket;

        public MainForm()
        {
            InitializeComponent();

            allProducts = dataAccessLayer.GetAllProducts();

            allCustomers = dataAccessLayer.GetAllCustomers();

            allTraders = dataAccessLayer.GetAllTraders();

            allOrders = dataAccessLayer.GetAllOrders();

            allCategories = dataAccessLayer.GetAllCategories();

            allProducts = dataAccessLayer.GetAllProducts();

            allBasket = dataAccessLayer.GetAllBaskets();

            dataGridView1.DataSource = allProducts;

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

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> searchResults = new List<DataGridViewRow>();

            string productName = textBox1.Text.Trim();

            foreach (DataGridViewRow dataGridRow in dataGridView1.Rows)
            {
                if (dataGridRow.Cells["Название"].Value.ToString().Contains(productName))
                {
                    searchResults.Add(dataGridRow);
                }
            }

            if (searchResults.Count == 0)
            {
                MessageBox.Show("По данному запросу не найдено записей");
                return;
            }

            MessageBox.Show("Найдено " + searchResults.Count + " записей");

            int currentRow = 0;

            if (currentRow == searchResults.Count - 1)
            {
                currentRow = 0;
            }
            else
            {
                currentRow++;
            }

            dataGridView1.CurrentCell = searchResults[currentRow].Cells[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Products newProductsForm = new Products();

            if (newProductsForm.ShowDialog() == DialogResult.OK)
            {
                allProducts = dataAccessLayer.GetAllProducts();

                ShowProductMessage("Новый продукт успешно добавлен/изменён");
                dataGridView1.DataSource = allProducts;
            }
            else
            {
                ShowProductMessage("Новый продукт не добавлен/изменён");
            }
        }

        private void ShowProductMessage(string message)
        {
            MessageBox.Show(message, "Магазин Росток", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customers newCustomersForm = new Customers();

            if (newCustomersForm.ShowDialog() == DialogResult.OK)
            {
                allCustomers = dataAccessLayer.GetAllCustomers();

                allCustomers.Clear();

                ShowCustomersMessage("Новый покупатель добавлен/изменен");
            }
            else 
            {
                ShowCustomersMessage("Новый покупатель не добавлен/изменен");
            }   
        }

        private void ShowCustomersMessage(string message) 
        {
            MessageBox.Show(message, "Магазин Росток", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Traders newTradersForm = new Traders();

            if (newTradersForm.ShowDialog() == DialogResult.OK)
            {
                allTraders = dataAccessLayer.GetAllTraders();

                ShowSellersMessage("Новый продавец добавлен/изменен");
            }
            else
            {
                ShowSellersMessage("Новый продавец не добавлен/изменен");
            }    
        }

        private void ShowSellersMessage(string message) 
        {
            MessageBox.Show(message, "Магазин Росток", MessageBoxButtons.OK);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Categories newCategoriesForm = new Categories();

            if (newCategoriesForm.ShowDialog() == DialogResult.OK)
            {
                allCategories = dataAccessLayer.GetAllCategories();

                ShowCategoriesMessage("Новая категория успешно добавлена/изменена");
            }
            else 
            {
                ShowCategoriesMessage("Новая категория не добавлена/изменена");
            }
        }

        private void ShowCategoriesMessage(string message) 
        {
            MessageBox.Show(message, "Магазин Росток", MessageBoxButtons.OK);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Orders newOrdersForm = new Orders();

            if (newOrdersForm.ShowDialog() == DialogResult.OK)
            {
                allOrders = dataAccessLayer.GetAllOrders();

                ShowOrdersMessage("Новый заказ успешно добавлен/изменён");
            }
            else
            {
                ShowOrdersMessage("Новый заказ не добавлен/изменён");
            }    
        }

        private void ShowOrdersMessage(string message)
        {
            MessageBox.Show(message, "Магазин Росток", MessageBoxButtons.OK);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            graph.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool success = dataAccessLayer.SaveDBtoLocalFile();

            string message;
            string title;
            MessageBoxIcon icon;
            MessageBoxButtons buttons;

            if (success)
            {
                message = "Отчеты были успешно сохранены в локальных файлах";
                title = "Успех";
                icon = MessageBoxIcon.Information;
                buttons = MessageBoxButtons.OK;
            }
            else
            {
                message = "Отчеты не были сохранены в локальных файлах";
                title = "Ошибка";
                icon = MessageBoxIcon.Error;
                buttons = MessageBoxButtons.OK;
            }

            MessageBox.Show(message, title, buttons, icon, MessageBoxDefaultButton.Button1);
        }
    }
}