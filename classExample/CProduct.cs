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
        public float condition { get; set; }
        public int dayStored { get; set; }
        public string place { get; set; }

        public CProduct()
        {

        }
        public CProduct(int productKey, string productName, int regionKey, string regionName, double condition, int dayStored, string place)
        {

        }

            //db.InsertToInventory(productKey, regionKey, condition, dayStored, place);
    }
}
