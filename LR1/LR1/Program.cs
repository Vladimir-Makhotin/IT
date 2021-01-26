using System;
using System.Collections.Generic;
using System.Text;

namespace firstapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("Война и мир", "Л.Н. Толстой", 1869, 1);
            Book b2 = new Book();
            Book b3 = new Book("Филипок", "Л.Н. Толстой", 1875, 1);
            library bibl1 = new library();
            Handler1 h1 = new Handler1();
            bibl1.onDel += h1.MessageDeleted;
            bibl1.onAdd += h1.MessageAdded;
            bibl1.books.Add(b1);
            bibl1.books.AddRange(new Book[] { b2, b3 });
            Console.WriteLine("Удалить или добавить книгу?(удалить:1, добавить:2)");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Удалить все книги автора(1) или удалить книгу(2)? ");
                int c = Convert.ToInt32(Console.ReadLine());
                if (c == 1)
                {
                    Console.WriteLine("Введите автора");
                    string deleteauthor = Console.ReadLine();
                    List<Book> res = bibl1.fnd(deleteauthor);
                    bibl1.del(deleteauthor);
                }
                if (c == 2)
                {
                    Console.WriteLine("Введите название книги");
                    string deletename = Console.ReadLine();
                    Console.WriteLine("Введите автора");
                    string deleteauthor = Console.ReadLine();
                    bibl1.delbook(deleteauthor, deletename);
                }
            }
            if (choice == 2)
            {
                Console.WriteLine("Сколько книг хотите добавить?");
                int n = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Book b4 = new Book();
                    b4 = bibl1.add(b4);
                    if (b4 != null)
                    {
                        bibl1.books.Add(b4);
                    }
                }
            }
            foreach (Book b in bibl1.books)
            {
                if (b == null) { continue; }
                b.GetInformation();
            }
            Console.ReadKey();
        }
    }
}
