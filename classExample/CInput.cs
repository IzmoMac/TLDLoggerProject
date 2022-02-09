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

        public void Read()
        {
            cn.Write("Anna ensimmäinen luku:");
            int eka = cn.ReadInteger();

            cn.Write("Anna toinen luku:");
            int toka = cn.ReadInteger();

            new CCalculate(eka, toka).Result();
        }
    }
}
