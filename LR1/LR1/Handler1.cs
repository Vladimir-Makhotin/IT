using System;
using System.Collections.Generic;
using System.Text;

namespace firstapp
{
    class Handler1
    {
        public void MessageDeleted()
        {
            Console.WriteLine("Книги удалены");
        }
        public void MessageAdded()
        {
            Console.WriteLine("Книга добавлена");
        }
    }
}
