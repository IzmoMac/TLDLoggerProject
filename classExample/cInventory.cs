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
        string ProductName { get; set; }
        string Region { get; set; }
        float Condition { get; set; }
        int DayStored { get; set; }
        string Place { get; set; }


        public CInventory(string aProductName,string aRegion, float aCondition, int aDaystored, string aPlace)
        {
            //NEEDS: Place checks to check that everything is correct format?
            ProductName = aProductName;
            Region = aRegion;
            Condition = aCondition;
            DayStored = aDaystored;
            Place = aPlace;
        }
        public CInventory()
        {

        }
        public void InventoryAdd()
        {
            
        }

        public int GetProductKey(string _productName)
        {
            db.queryString = $"select ProductKey from tProduct where ProductName = '{_productName}';";
            return db.QueryProductKey();
        }
    }
}
