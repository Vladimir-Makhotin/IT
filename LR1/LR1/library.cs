using System;
using System.Collections.Generic;
using System.Text;

namespace firstapp
{
    class library
    {
        public List<Book> books = new List<Book> { };
        private string filterAuthor;
        public delegate void MethodContainer();
        public event MethodContainer onDel;
        public event MethodContainer onAdd;
        private string newname;
        public string newauthor;
        public int newyear;
        public List<Book> fnd(string author)
        {
            filterAuthor = author;
            List<Book> res = books.FindAll(PredicateAuthor);
            return res;
        }
        private bool PredicateAuthor(Book bk)
        {
            if (bk.author == filterAuthor)
                return true;

            else
                return false;
        }
        public Book add(Book book)
        {
            Console.WriteLine("Введите название книги");
            newname = Console.ReadLine();
            Console.WriteLine("Введите автора");
            newauthor = Console.ReadLine();
            Console.WriteLine("Введите год публикации");
            newyear = Convert.ToInt32(Console.ReadLine());
            book.name = newname;
            book.author = newauthor;
            book.year = newyear;
            Book found = books.Find(item => item.name == book.name && item.author== book.author && item.year==book.year);
            if(found!=null)
            {
                found.count++;
                onAdd();
                return null;
            }
            onAdd();
            return book;
        }
        public void del(string author)
        {
            filterAuthor = author;
            books.RemoveAll(PredicateAuthor);
            onDel();
        }
        public void delbook(string deleteauthor, string deletename)
        {
            Book found = books.Find(item => item.name == deletename && item.author == deleteauthor);
            books.Remove(found);
        }
    }
}
