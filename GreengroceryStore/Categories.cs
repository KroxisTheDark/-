using System;
using System.Collections;
using System.Windows.Forms;

namespace GreengroceryStore
{
    public partial class Categories : Form
    {
        DataAccessLayer dataAccessLayer = new DataAccessLayer();

        ArrayList allCategories;

        public Categories()
        {
            InitializeComponent();

            allCategories = dataAccessLayer.GetAllCategories();
            dataGridView1.DataSource = allCategories;

            textBox1.Text = Guid.NewGuid().ToString();

            Settings();
        }

        public void Settings() 
        {
            try
            {
                if (dataGridView1.Columns.Contains("ID_Категории"))
                { 
                    dataGridView1.Columns["ID_Категории"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Столбец'ID_Категории' отсутствует в таблице.");
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
            if (dataAccessLayer.SaveNewCategories(textBox1.Text.Trim(), textBox2.Text.Trim()))
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
            string ID_Категории = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (dataAccessLayer.UpdateCategories(ID_Категории, textBox2.Text.Trim()))
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
            string ID_Категории = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (dataAccessLayer.SaveNewCategories(ID_Категории, textBox2.Text.Trim()))
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
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
