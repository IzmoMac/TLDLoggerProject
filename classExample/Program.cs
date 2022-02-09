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
            /*
            new cinput().read();

            
            new ccalculate(10, 2).result();
            new ccalculate(7, 4).result();
            new ccalculate(73, 0).result();
            new ccalculate(73, 413).result();
            new ccalculate(54, 14).result();
            

            system.threading.thread.sleep(cwait);
            */

            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach (var name in names)
            {
                //Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            new List<string> { "kakku", "muffinssi", "Munkki" };

            new CMySqlConnection().Kakku();
            new CMySqlConnection().OpenSqlConnection();
            //new CMySqlConnection().CheckMySqlConnection();

        }
    }
}
