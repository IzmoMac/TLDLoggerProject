using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classExample
{
    public class CProduct
    {
        public int productKey { get; set; }
        public string productName { get; set; }
        public int regionKey { get; set; }
        public string regionName { get; set; }
        public double condition { get; set; }
        public int dayStored { get; set; }
        public string place { get; set; }
        public int quantity { get; set; }

        public CProduct()
        {

        }
        public CProduct(int aproductKey, string aproductName, int aregionKey, string aregionName, int adayStored, string aplace)
        {
            productKey = aproductKey;
            productName = aproductName;
            regionKey = aregionKey;
            regionName = aregionName;
            //condition = acondition;
            dayStored = adayStored;
            place = aplace;
            //quantity = aquantity;
        }
        public void addItem()
        {

        }

        //public void tims
        //    //db.InsertToInventory(productKey, regionKey, condition, dayStored, place);
    }
}
