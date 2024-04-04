using System;
using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace GreengroceryStore
{
    internal class DataAccessLayer
    {
        string connectionString = @"Data Source=KROXISPC\SQLEXPRESS;Initial Catalog=greengrocery_store;Integrated Security=True;";

        public ArrayList GetAllProducts()
        {
            ArrayList allProducts = new ArrayList();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Продукт", connection);
                try
                {
                    connection.Open();

                    SqlDataReader data_reader = command.ExecuteReader();
                    if (data_reader.HasRows)
                    {
                        foreach (DbDataRecord result in data_reader) 
                        {
                            allProducts.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            return allProducts;
        }

        public ArrayList GetAllCustomers()
        {
            ArrayList allCustomers = new ArrayList();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Покупатель", connection);
                try
                {
                    connection.Open();

                    SqlDataReader data_reader = command.ExecuteReader();
                    if (data_reader.HasRows)
                    {
                        foreach (DbDataRecord result in data_reader)
                        {
                            allCustomers.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return allCustomers;
        }

        public ArrayList GetAllTraders()
        {
            ArrayList allTraders = new ArrayList();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Сотрудник", connection);
                try
                {
                    connection.Open();

                    SqlDataReader data_reader = command.ExecuteReader();
                    if (data_reader.HasRows)
                    {
                        foreach (DbDataRecord result in data_reader)
                        {
                            allTraders.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return allTraders;
        }

        public ArrayList GetAllOrders()
        {
            ArrayList allOrders = new ArrayList();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Заказы", connection);
                try
                {
                    connection.Open();

                    SqlDataReader data_reader = command.ExecuteReader();
                    if (data_reader.HasRows)
                    {
                        foreach (DbDataRecord result in data_reader)
                        {
                            allOrders.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return allOrders;
        }

        public ArrayList GetAllCategories()
        {
            ArrayList allCategories = new ArrayList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Категория", connection);
                try
                {
                    connection.Open();

                    SqlDataReader data_reader = command.ExecuteReader();
                    if (data_reader.HasRows)
                    {
                        foreach (DbDataRecord result in data_reader)
                        {
                            allCategories.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return allCategories;
        }

        public ArrayList GetAllBaskets()
        {
            ArrayList allBasket = new ArrayList();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = string.Format("SELECT * FROM Корзина");

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    SqlDataReader data_reader = command.ExecuteReader();
                    if (data_reader.HasRows)
                    {
                        foreach (DbDataRecord result in data_reader)
                        {
                            allBasket.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return allBasket;
        }

        public bool SaveNewBasket(string ID_продукта, string ID_Заказа,string ВремяОплаты, string ЦенаНаМоментПродажи, string Количество)
        {
            ЦенаНаМоментПродажи = ЦенаНаМоментПродажи.Replace(",", ".");

            string query = string.Format("INSERT INTO Корзина (ID_Корзины, ID_продукта, ID_Заказа, ВремяОплаты, ЦенаНаМоментПродажи, Количество) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                 Guid.NewGuid(), ID_продукта, ВремяОплаты, ID_Заказа, ЦенаНаМоментПродажи, Количество);

            bool flagResult = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() == 1) 
                    {
                        flagResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;
        }

        public bool SaveNewProduct(string ID_продукта, string Название, string Цена, string Состояние, string КоличествоНаСкладе, string ID_Категории)
        {
            bool flagResult = false;

            string query = string.Format("INSERT INTO Продукт ([ID_продукта], [Название], [Цена], [Состояние], [КоличествоНаСкладе], [ID_Категории]) " +
                "Values ('{0}', '{1}', {2}, '{3}', {4}, {5})", ID_продукта, Название, Цена, Состояние, КоличествоНаСкладе, ID_Категории);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() == 1) 
                    {
                        flagResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;
        }

        public bool SaveNewTrader(string ID_Сотрудника, string ФИО, string ДатаРождения, string Должность, string НомерТелефона)
        {
            bool flagResult = false;

            string query = string.Format("Insert into Сотрудник ([ID_Сотрудника], [ФИО], [ДатаРождения], [Должность]," +
            "[НомерТелефона])" + "Values ('{0}','{1}','{2}','{3}','{4}')", ID_Сотрудника, ФИО, ДатаРождения, Должность, НомерТелефона);

            MessageBox.Show(query);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() == 1) 
                    {
                        flagResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;
        }

        public bool SaveNewOrders(string ID_Заказа, string ID_Сотрудника, string ID_Покупателя, string ДатаПрибытия, string МестоПрибытия)
        {
            bool flagResult = false;

            string query = string.Format("Insert into Заказы ([ID_Заказа], [ID_Сотрудника],[ID_Покупателя], [ДатаПрибытия]," +
            "[МестоПрибытия])" +
            "Values ('{0}','{1}','{2}','{3}','{4}')", ID_Заказа, ID_Сотрудника, ID_Покупателя, ДатаПрибытия, МестоПрибытия);

            MessageBox.Show(query);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        flagResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;
        }

        public bool SaveNewCustomers(string ID_Покупателя, string ФИО, string ДатаРождения, string НомерТелефона, string Адрес)
        {
            bool flagResult = false;

            string query = string.Format("INSERT INTO Покупатель ([ID_Покупателя], [ФИО], [ДатаРождения] , [НомерТелефона]," +
                "[Адрес])" +
            "Values ('{0}','{1}','{2}','{3}','{4}')", ID_Покупателя, ФИО, ДатаРождения, НомерТелефона, Адрес);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        flagResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;
        }
        public bool SaveNewCategories(string ID_Категории, string НазваниеКатегории)
        {
            bool flagResult = false;

            string query = string.Format("INSERT INTO Категория ([ID_Категории], [НазваниеКатегории])" +
            "Values ({0},'{1}')", ID_Категории, НазваниеКатегории);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            flagResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return flagResult;
        }

        public bool UpdateProducts(string ID_продукта, string Название, string Цена, string Состояние, string КоличествоНаСкладе, string ID_Категории)
        {
            bool flagResult = false;

            string query = string.Format("UPDATE Продукт set [Название] = '{1}', [Цена] = {2}," +
                " [Состояние] = '{3}' ,[КоличествоНаСкладе] = {4}, [ID_Категории] = {5} where [ID_продукта] = '{0}'",
            ID_продукта, Название, Цена, Состояние, КоличествоНаСкладе, ID_Категории);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            flagResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return flagResult;
        }

        public bool UpdateTrader(string ID_Сотрудника, string ФИО, string ДатаРождения, string Должность, string НомерТелефона)
        {
            bool flagResult = false;

            string query = string.Format("UPDATE Сотрудник set [ФИО] = '{1}', [ДатаРождения] = '{2}', [Должность] = '{3}'," +
                " [НомерТелефона] = '{4}' where [ID_Сотрудника] = '{0}'",
                ID_Сотрудника, ФИО, ДатаРождения, Должность, НомерТелефона);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            flagResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return flagResult;
        }
        public bool UpdateCustomers(string ID_Покупателя, string ФИО, string ДатаРождения, string НомерТелефона, string Адрес)
        {
            bool flagResult = false;

            string query = string.Format("Update Покупатель set [ФИО] = '{1}', [ДатаРождения] = '{2}', [НомерТелефона] = '{3}'," +
                " [Адрес] = '{4}' where [ID_Покупателя] = '{0}'",
                ID_Покупателя, ФИО, ДатаРождения, НомерТелефона, Адрес);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            flagResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return flagResult;
        }

        public bool UpdateOrders(string ID_Заказа, string ID_Сотрудника, string ID_Покупателя, string ДатаПрибытия, string МестоПрибытия)
        {
            bool flagResult = false;

            string query = string.Format("Update Заказы set [ID_Сотрудника] = '{1}', [ID_Покупателя] = '{2}', [ДатаПрибытия] = '{3}'," +
                " [МестоПрибытия] = '{4}' where [ID_Заказа] = '{0}'",
                ID_Заказа, ID_Сотрудника, ID_Покупателя, ДатаПрибытия, МестоПрибытия);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            flagResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return flagResult;
        }

        public bool UpdateCategories(string ID_Категории, string НазваниеКатегории)
        {
            bool flagResult = false;

            string query = string.Format("Update Категория set [НазваниеКатегории] = '{1}' where [ID_Категории] = {0}", ID_Категории, НазваниеКатегории);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            flagResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return flagResult;
        }

        public bool DeleteProducts(string ID_продукта)
        {
            bool flagResult = false;

            string query = string.Format("Delete FROM Продукт Where ID_продукта = '{0}'", ID_продукта);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            flagResult = true;
                        } 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return flagResult;
        }

        public bool DeleteCustomer(string ID_Покупателя)
        {
            bool flagResult = false;

            string query = string.Format("Delete FROM Покупатель Where ID_Покупателя = '{0}'", ID_Покупателя);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            flagResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return flagResult;
        }

        public bool DeleteTrader(string ID_Сотрудника)
        {
            bool flagResult = false;

            string query = string.Format("Delete FROM Сотрудник Where ID_Сотрудника = '{0}'", ID_Сотрудника);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        flagResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;
        }

        public bool DeleteCategories(string ID_Категории)
        {
            bool flagResult = false;

            string query = string.Format("Delete FROM Категория Where ID_Категории = {0}", ID_Категории);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        flagResult = true;
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;
        }

        public bool DeleteOrder(string ID_Заказа)
        {
            bool flagResult = false;

            string query = string.Format("Delete FROM Заказы Where ID_Заказа = '{0}'", ID_Заказа);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        flagResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;
        }

        internal bool SaveDBtoLocalFile()
        {
            bool result = true;

            StreamWriter file;

            string query;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    file = new StreamWriter(new FileStream("Products.csv", FileMode.Create), Encoding.GetEncoding(1251));

                    query = "Select * From Продукт";

                    SqlCommand com = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader data_reader = com.ExecuteReader();

                    file.WriteLine(@"""ID_Продукта"";""Название"";""Цена"";""Оценка"";""КоличествоНаскладе"";""ID_Категории""");

                    if (data_reader.HasRows)
                    {
                        while (data_reader.Read())
                        {
                            file.WriteLine(@"""" + data_reader.GetValue(0).ToString() + @""";""" +
                                data_reader.GetString(1) + @""";""" +
                                data_reader[2].ToString() + @""";""" +
                                data_reader[3].ToString() + @""";""" +
                                data_reader[4].ToString() + @""";""" +
                                data_reader[5].ToString() + @"""", Encoding.ASCII);
                        }
                    }
                    else
                    {
                        file.WriteLine("Нечего сохранить");
                    }

                    file.WriteLine("Конец файла");

                    result = true;

                    file.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    result = false;
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    file = new StreamWriter(new FileStream("Orders.csv", FileMode.Create), Encoding.GetEncoding(1251));

                    query = "Select * From Заказы";

                    SqlCommand com = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader data_reader = com.ExecuteReader();

                    file.WriteLine(@"""ID_Заказа"";""ID_Сотрудника"";""ID_Покупателя"";""ДатаПрибытия"";""МестоПрибытия""");
                    if (data_reader.HasRows)
                    {
                        while (data_reader.Read())
                        {
                            file.WriteLine(@"""" + data_reader.GetValue(0).ToString() + @""";""" +
                                data_reader.GetValue(1).ToString() + @""";""" +
                                data_reader.GetValue(2).ToString() + @""";""" +
                                data_reader[3].ToString() + @""";""" +
                                data_reader[4].ToString() + @"""", Encoding.ASCII);
                        }
                    }
                    else
                    {
                        file.WriteLine("Нечего сохранять");
                    }

                    file.WriteLine("Конец файлы");

                    result = true;

                    file.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    result = false;
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    file = new StreamWriter(new FileStream("Trader.csv", FileMode.Create), Encoding.GetEncoding(1251));

                    query = "Select * From Сотрудник";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader data_reader = command.ExecuteReader();

                    file.WriteLine(@"""ID_Сотрудника"";""ФИО"";""ДатаРождения"";""Должность"";""НомерТелефона""");

                    if (data_reader.HasRows)
                    {
                        while (data_reader.Read())
                        {
                            file.WriteLine(@"""" + data_reader.GetValue(0).ToString() + @""";""" +
                                data_reader[1].ToString() + @""";""" +
                                data_reader[2].ToString() + @""";""" +
                                data_reader[3].ToString() + @""";""" +
                                data_reader[4].ToString() + @"""", Encoding.ASCII);
                        }
                    }
                    else
                    {
                        file.WriteLine("Нечего сохранить");
                    }

                    file.WriteLine("Конец файлы");

                    result = true;

                    file.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    result = false;
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    file = new StreamWriter(new FileStream("Byers.csv", FileMode.Create), Encoding.GetEncoding(1251));

                    query = "Select * From Покупатель";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader data_reader = command.ExecuteReader();

                    file.WriteLine(@"""ID_Покупателя"";""ФИО"";""ДатаРождения"";""НомерТелефона"";""Адрес""");

                    if (data_reader.HasRows)
                    {
                        while (data_reader.Read())
                        {
                            file.WriteLine(@"""" + data_reader.GetValue(0).ToString() + @""";""" +
                                data_reader[1].ToString() + @""";""" +
                                data_reader[2].ToString() + @""";""" +
                                data_reader[3].ToString() + @""";""" +
                                data_reader[4].ToString() + @"""", Encoding.ASCII);
                        }
                    }
                    else
                    {
                        file.WriteLine("Нечего сохранить");
                    }

                    file.WriteLine("Конец файла");

                    result = true;

                    file.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    result = false;
                }
                return result;
            }
        }
    }
}