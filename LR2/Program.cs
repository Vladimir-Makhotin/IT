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
            Console.WriteLine("Найти(1) или Удалить(2)?");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice==1)
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
            if(choice==2)
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
    }
}
