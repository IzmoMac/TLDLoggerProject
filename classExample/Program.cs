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
            CMySqlConnection con = new CMySqlConnection();

            //con.TestSqlConnection();

            //con.AskForProductName();

            //cn.Write(con.productName);
            //con.OpenSqlConnection();
            Boolean keepGoing = true;
            string input;
            while (keepGoing)
            {
                con.AskForProductName();
                con.QueryProductFromdb();
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