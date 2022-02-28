using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classExample
{
    class CInventory
    {
        COutput cn = new COutput();
        CDatabase db = new CDatabase();
        private string productName;
        private string regionName;
        string region { get; set; }
        double condition { get; set; }
        int dayStored { get; set; }
        string place { get; set; }
        private int productKey;
        private int regionKey;

        public void notoworkingAddProductToInventory()
        { //This funcntion is underconsrtuction
            /* What this function needs to do?
             * It needs to ask for ProductName, and Match ProductName with its prouctKey in database and return produtKey, 
             * If not found in database ask go to beginning
             */
            productKey = db.GetProductKey();
            productName = db.productName;
            regionKey = db.GetRegionKey();
            regionName = db.regionName;
            cn.Write("How much conditon left?");
            double aCondition = double.Parse(Console.ReadLine());
            
            cn.Write("What day it was stored?");
            int aDaystored = int.Parse(Console.ReadLine());
            
            cn.Write("Where is it? (detailed description allowed)");
            string aPlace = Console.ReadLine();

            condition = aCondition;
            dayStored = aDaystored;
            place = aPlace;

            Console.Write("Is the information corret? ");
        }
    }
}
