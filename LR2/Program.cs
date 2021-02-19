using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace LR2
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
                        if (reader.HasRows)
                        { 
                            Console.WriteLine("{0}   \t{1}   \t{2}      \t{3}      \t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));
                            while (reader.Read())
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
                Console.WriteLine("Добавить(1), Обновить(2), Вывести(3), Удалить(4), Найти сотрудников(5)?");
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
                        Console.WriteLine("Введите ФИО работника для обновления");
                        string lastname = Console.ReadLine();
                        string name = Console.ReadLine();
                        string patronomyc = Console.ReadLine();
                        Console.WriteLine("Что хотите поменять?(Фамилия(1), Имя(2), Отчество(3), Должность(4), Все данные сотрудника(5))");
                        int ChoiceUpdate =Convert.ToInt32(Console.ReadLine());
                        switch(ChoiceUpdate)
                        {
                            case 1:
                                using (SqlConnection connection = new SqlConnection(connectionString1))
                                {
                                    connection.Open();
                                    Console.WriteLine("Введите Фамилию которая добавиться в бд");
                                    string newlastname = Console.ReadLine();
                                    string sqlExpression = "UPDATE Сотрудник SET LastName=@newlastname WHERE LastName=@lastname AND Name=@name AND Patronymic=@patronomyc";
                                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                                    command.Parameters.AddWithValue("@newlastname", newlastname);
                                    command.Parameters.AddWithValue("@lastname", lastname);
                                    command.Parameters.AddWithValue("@name", name);
                                    command.Parameters.AddWithValue("@patronomyc", patronomyc);
                                    int number = command.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов: {0}", number);
                                }
                                    break;
                            case 2:
                                using (SqlConnection connection = new SqlConnection(connectionString1))
                                {
                                    connection.Open();
                                    Console.WriteLine("Введите имя которое добавиться в бд");
                                    string newname = Console.ReadLine();
                                    string sqlExpression = "UPDATE Сотрудник SET Name=@newname WHERE LastName=@lastname AND Name=@name AND Patronymic=@patronomyc";
                                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                                    command.Parameters.AddWithValue("@newname", newname);
                                    command.Parameters.AddWithValue("@lastname", lastname);
                                    command.Parameters.AddWithValue("@name", name);
                                    command.Parameters.AddWithValue("@patronomyc", patronomyc);
                                    int number = command.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов: {0}", number);
                                }
                                break;
                            case 3:
                                using (SqlConnection connection = new SqlConnection(connectionString1))
                                {
                                    connection.Open();
                                    Console.WriteLine("Введите Отчество которое добавиться в бд");
                                    string newpatronomyc = Console.ReadLine();
                                    string sqlExpression = "UPDATE Сотрудник SET Patronymic=@newpatronomyc WHERE LastName=@lastname AND Name=@name AND Patronymic=@patronomyc";
                                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                                    command.Parameters.AddWithValue("@newpatronomyc", newpatronomyc);
                                    command.Parameters.AddWithValue("@lastname", lastname);
                                    command.Parameters.AddWithValue("@name", name);
                                    command.Parameters.AddWithValue("@patronomyc", patronomyc);
                                    int number = command.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов: {0}", number);
                                }
                                break;
                            case 4:
                                using (SqlConnection connection = new SqlConnection(connectionString1))
                                {
                                    connection.Open();
                                    Console.WriteLine("Введите должность которая добавиться в бд");
                                    string newunitid = Console.ReadLine();
                                    string sqlExpression = "UPDATE Сотрудник SET UnitId=Подразделение.Id FROM Сотрудник, Подразделение WHERE LastName=@lastname AND Name=@name AND Patronymic=@patronomyc AND Подразделение.НаименованиеПодразделения=@newunitid";
                                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                                    command.Parameters.AddWithValue("@newunitid", newunitid);
                                    command.Parameters.AddWithValue("@lastname", lastname);
                                    command.Parameters.AddWithValue("@name", name);
                                    command.Parameters.AddWithValue("@patronomyc", patronomyc);
                                    int number = command.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов: {0}", number);
                                }
                                break;
                            case 5:
                                using (SqlConnection connection = new SqlConnection(connectionString1))
                                {
                                    connection.Open();
                                    Console.WriteLine("Введите Фамилию которая добавиться в бд");
                                    string newlastname = Console.ReadLine();
                                    Console.WriteLine("Введите имя которое добавиться в бд");
                                    string newname = Console.ReadLine();
                                    Console.WriteLine("Введите Отчество которое добавиться в бд");
                                    string newpatronomyc = Console.ReadLine();
                                    Console.WriteLine("Введите должность которая добавиться в бд");
                                    string newunitid = Console.ReadLine();
                                    string sqlExpression = "UPDATE Сотрудник SET UnitId=Подразделение.Id, LastName=@newlastname, Name=@newname, Patronymic=@newpatronomyc  FROM Сотрудник, Подразделение WHERE LastName=@lastname AND Name=@name AND Patronymic=@patronomyc AND Подразделение.НаименованиеПодразделения=@newunitid";
                                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                                    command.Parameters.AddWithValue("@newpatronomyc", newpatronomyc);
                                    command.Parameters.AddWithValue("@newlastname", newlastname);
                                    command.Parameters.AddWithValue("@newname", newname);
                                    command.Parameters.AddWithValue("@newunitid", newunitid);
                                    command.Parameters.AddWithValue("@lastname", lastname);
                                    command.Parameters.AddWithValue("@name", name);
                                    command.Parameters.AddWithValue("@patronomyc", patronomyc);
                                    int number = command.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов: {0}", number);
                                }
                                break;
                            default:
                                break;
                        }
                            break;
                    case 3:
                        Console.WriteLine("Кого выввести? Сотрудники(1), подразделения(2)");
                        int choiceread = Convert.ToInt32(Console.ReadLine());
                        if (choiceread == 1)
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString1))
                            {
                                connection.Open();
                                string sqlExpression = "SELECT * FROM Сотрудник";
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                SqlDataReader reader = command.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    Console.WriteLine("{0}   \t{1}   \t{2}      \t{3}    \t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));
                                    while (reader.Read())
                                    {
                                        object idread = reader.GetValue(0);
                                        object lastnameread = reader.GetValue(1);
                                        object nameraed = reader.GetValue(2);
                                        object thirdnameread = reader.GetValue(3);
                                        object unitidread = reader.GetValue(4);
                                        Console.WriteLine("{0}   \t{1}   \t{2}     \t{3}   \t{4}", idread, lastnameread, nameraed, thirdnameread, unitidread);
                                    }
                                }
                                reader.Close();
                            }
                        }
                        if(choiceread==2)
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString1))
                            {
                                connection.Open();
                                string sqlExpression = "SELECT * FROM Подразделение";
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                SqlDataReader reader = command.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    Console.WriteLine("{0}   \t{1}   ", reader.GetName(0), reader.GetName(1));
                                    while (reader.Read())
                                    {
                                        object idread = reader.GetValue(0);
                                        object nameraed = reader.GetValue(1);
                                        Console.WriteLine("{0}   \t{1}   ", idread, nameraed);
                                    }
                                }
                                reader.Close();
                            }
                        }
                            break;
                    case 4:
                        Console.WriteLine("Кого удалить? Сотрудник(1), Подразделение(2)");
                        int choicedel = Convert.ToInt32(Console.ReadLine());
                        if(choicedel==1)
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString1))
                            {
                                Console.WriteLine("Введите Фамилию");
                                string newlastname = Console.ReadLine();
                                Console.WriteLine("Введите имя");
                                string newname = Console.ReadLine();
                                Console.WriteLine("Введите Отчество");
                                string newpatronomyc = Console.ReadLine();
                                string sqlExpression = "DELETE FROM dbo.[Сотрудник] WHERE LastName=@lastname AND Name=@name AND Patronymic=@patronomyc";
                                connection.Open();
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                command.Parameters.AddWithValue("@lastname", newlastname);
                                command.Parameters.AddWithValue("@name", newname);
                                command.Parameters.AddWithValue("@patronomyc", newpatronomyc);
                                int number = command.ExecuteNonQuery();
                                Console.WriteLine("Удалено объектов: {0}", number);
                            }
                        }
                        if(choicedel==2)
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString1))
                            {
                                Console.WriteLine("Введите название подразделения");
                                string unitdel = Console.ReadLine();
                                string sqlExpression = "DELETE FROM dbo.[Подразделение] WHERE НаименованиеПодразделения=@unitdel";
                                connection.Open();
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                command.Parameters.AddWithValue("@unitdel", unitdel);
                                int number = command.ExecuteNonQuery();
                                Console.WriteLine("Удалено объектов: {0}", number);
                            }
                        }
                        break;
                    case 5:
                        
                        Console.WriteLine("Введите название подразделения");
                        string unitsearch = Console.ReadLine();
                        using (SqlConnection connection = new SqlConnection(connectionString1))
                        {
                            connection.Open();
                            string sqlExpression = "SELECT dbo.[Сотрудник].* FROM Сотрудник, Подразделение WHERE dbo.[Сотрудник].UnitId=dbo.[Подразделение].Id and dbo.[Подразделение].НаименованиеПодразделения=@unitname";
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.Parameters.AddWithValue("@unitname", unitsearch);
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                Console.WriteLine("{0}   \t{1}   \t{2}      \t{3}    \t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));
                                while (reader.Read())
                                {
                                    object idsearch = reader.GetValue(0);
                                    object lastnamesearch = reader.GetValue(1);
                                    object namesearch = reader.GetValue(2);
                                    object thirdnamesearch = reader.GetValue(3);
                                    object groupidsearch = reader.GetValue(4);

                                    Console.WriteLine("{0}   \t{1}   \t{2}     \t{3}      \t{4}", idsearch, lastnamesearch, namesearch, thirdnamesearch, groupidsearch);
                                }
                            }
                            reader.Close();
                        }
                            break;
                    default:
                        break;
                }
            }

        }
    }
}
