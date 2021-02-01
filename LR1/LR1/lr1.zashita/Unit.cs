using System;
using System.Collections.Generic;
using System.Text;

namespace lr1.zashita
{
    class Unit
    {
        public List<Worker> workers = new List<Worker> { };
        private string filterFio;
        private int filterYear;
        private int filterUnitid;
        private string newfio;
        private int newyears;
        private int newunitid;
        public delegate void MethodContainer();
        public event MethodContainer onAdd;
        public event MethodContainer warning;
        private bool PredicateWorker(Worker w)
        {
            if (w.unitid==filterUnitid)
                return true;
            else
                return false;
        }
        public Worker AddWorker(Worker person)
        {
            Console.WriteLine("Введите ФИО");
            newfio = Console.ReadLine();
            Console.WriteLine("Введите год рождения");
            newyears = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите код подразделения");
            newunitid = Convert.ToInt32(Console.ReadLine());
            person.fio = newfio;
            person.year = newyears;
            person.unitid = newunitid;
            Worker found = workers.Find(man => man.fio == person.fio && man.year == person.year);
            if (found != null)
            {
                warning();
                return null;
            }
            onAdd();
            return person;
        }
        public List<Worker> FindWorker(int uid)
        {
            filterUnitid = uid;
            List<Worker> res = workers.FindAll(PredicateWorker);
            return res;
        }
    }
}
