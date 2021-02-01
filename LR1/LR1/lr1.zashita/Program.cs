using System;
using System.Collections.Generic;

namespace lr1.zashita
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit u1 = new Unit();
            Handler h = new Handler();
            u1.onAdd += h.MessageAdded;
            u1.warning += h.MessegeWarning;
            bool choice = true;
            while(choice==true)
            {
                Console.WriteLine("Добавить работников(1), найти работника(2), найти подразделение(3), показать всех работников(4), выйти(5)?");
                int c = Convert.ToInt32(Console.ReadLine());
                if(c==1)
                {
                    Console.WriteLine("Сколько работников хотите добавить?");
                    int n = Convert.ToInt32(Console.ReadLine());
                    for(int i=0;i<n;i++)
                    {
                        Worker workman = new Worker();
                        workman = u1.AddWorker(workman);
                        if(workman!=null)
                        {
                            u1.workers.Add(workman);
                        }
                    }
                }
                if(c==2)
                {
                    Console.WriteLine("Введите ФИО работника");
                    string newFio = Console.ReadLine();
                    Console.WriteLine("Введите год рождения");
                    int newYear = Convert.ToInt32(Console.ReadLine());
                    Worker found = u1.workers.Find(man => man.fio == newFio && man.year == newYear);
                    if(found!=null)
                    {
                        found.GetInfo();
                    }
                    else
                        Console.WriteLine("Работника нету в базе");
                }
                if(c==3)
                {
                    Console.WriteLine("Введите номер подразделения");
                    int UnitNumber = Convert.ToInt32(Console.ReadLine());
                    List<Worker> result = u1.FindWorker(UnitNumber);
                    foreach(Worker i in result)
                    {
                        i.GetInfo();
                    }
                }
                if(c==4)
                {
                    foreach(Worker w in u1.workers)
                    {
                        w.GetInfo();
                    }
                }
                if (c == 5) { break; }
            }
            Console.ReadKey();
        }
    }
}
