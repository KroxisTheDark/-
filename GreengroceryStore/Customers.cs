using System;
using System.Collections;
using System.Windows.Forms;

namespace GreengroceryStore
{
    public partial class Customers : Form
    {
        DataAccessLayer dataAccessLayer = new DataAccessLayer();

        ArrayList allCustomers;

        public Customers()
        {
            InitializeComponent();

            allCustomers = dataAccessLayer.GetAllCustomers();

            dataGridView1.DataSource = allCustomers;

            textBox2.Text = Guid.NewGuid().ToString();

            Settings();
        }

        public void Settings() 
        {
            try
            {
                if (dataGridView1.Columns.Contains("ID_Покупателя"))
                {
                    dataGridView1.Columns["ID_Покупателя"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Столбцы 'ID_Покупателя' отсутствует в таблице.");
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
            if (dataAccessLayer.SaveNewCustomers(textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim()))
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ID_Покупателя = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (dataAccessLayer.UpdateCustomers(ID_Покупателя, textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim()))
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ID_Покупателя = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (dataAccessLayer.DeleteCustomer(ID_Покупателя))
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}