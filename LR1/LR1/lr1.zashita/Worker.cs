using System;
using System.Collections.Generic;
using System.Text;

namespace lr1.zashita
{
    class Worker
    {
        public string fio;
        public int year;
        public int unitid;
        public Worker(string Fio, int Year, int Unitid)
        {
            this.fio = Fio;
            this.year = Year;
            this.unitid = Unitid;
        }
        public Worker()
        {
            fio = "New worker";
            year = 0;
            unitid = 0;
        }
        public void GetInfo()
        {
            Console.WriteLine("ФИО: '{0}', Год рождения: '{1}', Код подразделения: '{2}'", fio, year, unitid);
        }
    }
}
