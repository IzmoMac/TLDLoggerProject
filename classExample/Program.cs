using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

namespace classExample
{
    class Program
    {
        private const int cWait = 3000; //milliseconds
        [STAThread]
        static void Main(string[] args)
        {
            COutput cn = new COutput();
            CDatabase db = new CDatabase();
            CInput ci = new CInput();
            CInventory inventory = new CInventory();
            CProduct p = new CProduct();
            //CInventory ci = new CInventory();
            //CInventory p1 = new CInventory("Fork", 3339.1435443);
            //Console.WriteLine(db.GetProductKey("cloth"));

            //new CInventory("cloth", "mystery lake", 100, 1, "hunters cabin").AddItem();
            //db.DeleteAllClothFromInventory();

            //inventory.notoworkingAddProductToInventory();
            //inventory.notoworkingAddProductToInventory();
            //db.GetProductKey();
            //db.GetRegionKey();
            //db.ttGetProductKey();
            //db.ViewInventory();
            //db.OpenSqlConnection();
            //db.GetCondition();
            //Console.WriteLine(db.GetDayStored());
            //Console.WriteLine(db.GetBool());

            //db.CreateNewProduct();
            //p.CreateNewProduct();
            p.ViewInventory();
            //Console.WriteLine(CProduct().test);

            //Console.WriteLine(db.GetProductKey());
            //Console.WriteLine(db.GetRegionKey());
            //Console.WriteLine(db.GetCondition());
            //Console.WriteLine(db.GetDayStored());
            //Console.WriteLine(db.GetPlace());
            bool testbool1 = false;
            if(testbool1 == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new form_addItem());
            }
       
            

        }
    }
}



/*
 * 
 */