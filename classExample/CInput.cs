using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classExample
{
    public class CInput
    {
        readonly COutput cn = new COutput();

        public void ReadInt()
        {
            cn.Write("Anna ensimmäinen luku:");
            int eka = cn.ReadInteger();

            cn.Write("Anna toinen luku:");
            int toka = cn.ReadInteger();

            new CCalculate(eka, toka).Result();
        }

        public string Read()
        {
            cn.Write("What is the product name?");
            string s = Console.ReadLine();
            return s;
        }
    }
}
