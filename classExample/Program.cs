using System;
using System.Text;
using System.Collections.Generic;

namespace classExample
{
    class Program
    {
        private const int cWait = 3000; //milliseconds
        static void Main(string[] args)
        {
            COutput cn = new COutput();
            CDatabase db = new CDatabase();
            CInventory ci = new CInventory();
            //CInventory p1 = new CInventory("Fork", 3339.1435443);
            Console.WriteLine(ci.ProductKey("cloth"));
        }
    }
}



/*
 * 
 */