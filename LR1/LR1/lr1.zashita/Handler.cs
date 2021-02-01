using System;
using System.Collections.Generic;
using System.Text;

namespace lr1.zashita
{
    class Handler
    {
        public void MessageAdded()
        {
            Console.WriteLine("Работник добавлен");
        }
        public void MessegeWarning()
        {
            Console.WriteLine("Данный работник уже есть в базе");        
        }
    }
}
