using System;
using System.Collections.Generic;
using System.Text;

namespace firstapp
{
    class Book
    {
        public string name;
        public string author;
        public int year;
        public int count;
        public Book(string name, string author, int year, int count)
        {
            this.name = name;
            this.author = author;
            this.year = year;
            this.count = 1;
        }
        public Book()
        {
            name = "Евгений Онегин";
            author = "А.С. Пушкин";
            year = 1833;
            count = 1;
        }
        public void GetInformation()
        {
            Console.WriteLine("книга '{0}' автор {1} была издана в {2} году в библиотеке имеется {3} шт", name,
            author, year, count);
        }
    }
}
