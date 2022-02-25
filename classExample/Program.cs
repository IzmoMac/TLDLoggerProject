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
            COutput cn = new COutput();
            CDatabase db = new CDatabase();
            CInput ci = new CInput();
            //CInventory ci = new CInventory();
            //CInventory p1 = new CInventory("Fork", 3339.1435443);
            //Console.WriteLine(db.GetProductKey("cloth"));

            //new CInventory("cloth", "mystery lake", 100, 1, "hunters cabin").AddItem();
            //db.DeleteAllClothFromInventory();

            //ci.AddProductToInventory();
            //db.ViewInventory();
            //db.OpenSqlConnection();
            db.tGetProductKeyFromProductNameFromDatabase("Cloth");
        }
    }
}



/*
 * 
 */