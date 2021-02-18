using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace LR3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\it\\LR2\\students1.mdf;Integrated Security=true";
            string connectionString1 = "Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\it\\LR2\\accounting.mdf;Integrated Security=True";
            Console.WriteLine("Выполнение(1) или защита(2)");
            int c = Convert.ToInt32(Console.ReadLine());
            if(c==1)
            {
                Console.WriteLine("Найти(1) или Удалить(2)?");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    string sqlExpression = "SELECT dbo.[Студенты].* FROM Студенты, Группы WHERE dbo.[Студенты].ГруппаId=dbo.[Группы].Id and dbo.[Группы].Название=@groupname";
                    Console.WriteLine("Введите название группы");
                    string GroupName = Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.Parameters.AddWithValue("@groupname", GroupName);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows) // если есть данные
                        {
                            // выводим названия столбцов
                            Console.WriteLine("{0}   \t{1}   \t{2}      \t{3}      \t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));
                            while (reader.Read()) // построчно считываем данные
                            {
                                object id = reader.GetValue(0);
                                object lastname = reader.GetValue(1);
                                object name = reader.GetValue(2);
                                object thirdname = reader.GetValue(3);
                                object groupid = reader.GetValue(4);

                                Console.WriteLine("{0}   \t{1}   \t{2}   \t{3}   \t{4}", id, lastname, name, thirdname, groupid);
                            }
                        }
                        reader.Close();
                    }
                }
                if (choice == 2)
                {
                    Console.WriteLine("Введите название группы");
                    string GroupName = Console.ReadLine();
                    string sqlExpression = "DELETE FROM dbo.[Группы] WHERE Название=@groupname";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.Parameters.AddWithValue("@groupname", GroupName);
                        int number = command.ExecuteNonQuery();
                        Console.WriteLine("Удалено объектов: {0}", number);
                    }
                }
            }
            if(c==2)
            {
                Console.WriteLine("Добавить(1), Обновить(2), Вывести(3), Удалить(4)?");
                int cc = Convert.ToInt32(Console.ReadLine());
                switch(cc)
                {
                    case 1:
                        Console.WriteLine("Введите наименование подразделения");
                        string unitname = Console.ReadLine();
                        int id = 1;
                        using (SqlConnection connection = new SqlConnection(connectionString1))
                        {
                            connection.Open();
                            string sqlExpression = "SELECT * FROM Подразделение";
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows) 
                            {
                                while (reader.Read())
                                {
                                    id++;
                                }
                            }
                            reader.Close();
                        }
                        using (SqlConnection connection = new SqlConnection(connectionString1))
                        {
                            connection.Open();
                            string sqlExpression = "INSERT INTO Подразделение (Id, НаименованиеПодразделения) VALUES (@id, @unitname)";
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@unitname", unitname);
                            int number = command.ExecuteNonQuery();
                            Console.WriteLine("Добавлено объектов: {0}", number);
                        }

                            break;
                    case 2:

                            break;
                    case 3:

                            break;
                    case 4:

                            break;
                    default:

                        break;
                }
            }

        }
    }
}
