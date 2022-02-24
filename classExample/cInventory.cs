using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classExample
{
    class CInventory
    {
        string ProductName;
        string Region;
        float Condition;
        int DayStored;
        string Place;
        public CInventory(string aProductName,string aRegion, float aCondition, int aDaystored, string aPlace)
        {
            //Place checks to everything is correct format?
            ProductName = aProductName;
            Region = aRegion;
            Condition = aCondition;
            DayStored = aDaystored;
            Place = aPlace;

        }

    
}
}
