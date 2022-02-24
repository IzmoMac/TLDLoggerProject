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

            Boolean keepGoing = true;
            string input;
            while (keepGoing)
            {
                db.AskForProductName();
                db.QueryProductFromdb();
                Console.WriteLine("search again?");
                input = Console.ReadLine();
                if (input == "no")
                {
                    keepGoing = false;
                }
                else
                { }
                
            }
        }
    }
}



/*
 * 
 */