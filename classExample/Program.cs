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

            db.QueryProductFromdb();

            
        }
    }
}



/*
 * 
 */