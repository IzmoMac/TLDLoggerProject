using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classExample
{
    class CInventory
    {
        CDatabase db = new CDatabase();
        string productName { get; set; }
        string region { get; set; }
        float condition { get; set; }
        int dayStored { get; set; }
        string place { get; set; }
        int productKey { get; set; }
        int regionKey { get; set; }

        public CInventory(string aProductname,string aRegion, float aCondition, int aDaystored, string aPlace)
        {
            //NEEDS: Place checks to check that everything is correct format?
            productName = aProductname;
            //This has to return valid product key, now it does not, same for region key, also if invalid do exepction handler/cathers
            productKey = db.GetProductKeyFromName(productName);
            region = aRegion;
            regionKey = db.GetRegionKeyFromName(region);
            condition = aCondition;
            dayStored = aDaystored;
            place = aPlace;
        }
        public void AddItem()
        {
            db.InsertToInventory(productKey, regionKey, condition, dayStored, place);
        }

        public void tWriteALlVariables()
        {
            Console.WriteLine($"{productName} +ProductKey {productKey} + {region} +RegionKey {regionKey} + {condition} + {dayStored} + {place}");
        }
    }
}
