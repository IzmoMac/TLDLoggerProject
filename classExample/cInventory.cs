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
        public string productName { get; set; }
        string region { get; set; }
        float condition { get; set; }
        int dayStored { get; set; }
        string place { get; set; }
        public int productKey { get; set; }
        int regionKey { get; set; }

        public void notworkingaswantedConstructor(string aProductname,string aRegion, float aCondition, int aDaystored, string aPlace)
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
        public void notoworkingAddProductToInventory()
        { //This funcntion is underconsrtuction

         
            /* What this function needs to do?
             * It needs to ask for ProductName, and Match ProductName with its prouctKey in database and return produtKey, 
             * If not found in database ask go to beginning
             * 
             */

            //productName = aProductname;
            //productKey = db.tGetProductKey(productName);
            Console.WriteLine(productKey);

            cn.Write("Region Name:");
            string aRegion = Console.ReadLine();
            
            cn.Write("How much conditon left ?");
            float aCondition = float.Parse(Console.ReadLine());
            
            cn.Write("What day it was stored?");
            int aDaystored = int.Parse(Console.ReadLine());
            
            cn.Write("Where is it? (detailed description allowed)");
            string aPlace = Console.ReadLine();

            region = aRegion;
            regionKey = db.GetRegionKeyFromName(region);
            condition = aCondition;
            dayStored = aDaystored;
            place = aPlace;

        db.InsertToInventory(productKey, regionKey, condition, dayStored, place);
        }
        public void AddItem()
        {
            
        }

        public void tWriteALlVariables()
        {
            Console.WriteLine($"{productName} +ProductKey {productKey} + {region} +RegionKey {regionKey} + {condition} + {dayStored} + {place}");
        }
    }
}
