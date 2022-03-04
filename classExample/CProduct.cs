using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classExample
{
    public class CProduct : CDatabase
    {

        public int ProductKey { get; set; } = CtInt.ZERO;
        public string ProductName { get; set; } = string.Empty;
        public int RegionKey { get; set; } = CtInt.ZERO;
        public string RegionName { get; set; } = string.Empty;
        public decimal Condition { get; set; } = CtDec.ZERO;
        public int DayStored { get; set; } = CtInt.ZERO;
        public string PlaceName { get; set; } = string.Empty;
        public int PlaceKey { get; set; } = CtInt.ZERO;
        public int Quantity { get; set; } = CtInt.ZERO;

        static string[] arrayGetProductKey = { "ProductKey", "tProduct", "ProductName" };
        static string[] arrayGetRegionKey = { "RegionKey", "tRegion", "RegionName" };
        static string[] arrayGetPlaceKey = { "PlaceKey", "tPlace", "PlaceName" };

        public CProduct()
        {

        }
        private void GetProductKey()
        {
            CompileQueryString(arrayGetProductKey, ProductName);
            ProductKey = QuerySingleKey();
        }
        public bool IsProductKeyValid
        {
            get { return ProductKey > CtInt.ZERO; }
        }
        private void GetRegionKey()
        {
            CompileQueryString(arrayGetRegionKey, RegionName);
            RegionKey = QuerySingleKey();
        }
        public bool IsRegionKeyValid
        {
            get { return RegionKey > CtInt.ZERO;}
        }
        private void GetPlaceKey()
        {
            CompileQueryString(arrayGetPlaceKey, PlaceName);
            PlaceKey = QuerySingleKey();
        }
        public bool IsPlaceKeyValid
        {
            get { return PlaceKey > CtInt.ZERO;}
        }
        //private void GetCondition()
        //{
        //    askmsg = "How much condition left?";
        //    errormsg = "Give a valid condition amount";
        //    errormsg2 = "Condition cannot be higher than 100";
        //    string errormsg3 = "Condition cannot be lower than 0";
        //    correctmsg = "Valid condition amount";

        //    while (!ConditionValid)
        //    {
        //        cn.Write(askmsg);
        //        try
        //        {
        //            Condition = Math.Round(decimal.Parse(Console.ReadLine()), CtInt.PRCT_PRECISION);
        //            if (ConditionTooBig)
        //            {
        //                cn.Write(errormsg2);

        //            }
        //            else if (ConditionTooSmall)
        //            {
        //                cn.Write(errormsg3);
        //            }
        //        }
        //        catch
        //        {
        //            cn.Write(errormsg);
        //        }
        //    }
        //}
        public bool ConditionTooSmall
        {
            get { return Condition < CtInt.ZERO; }
        }
        public bool ConditionTooBig
        {
            get { return Condition > CtInt.PRCT_MAX; }
        }
        public bool ConditionValid
        {
            get { return !ConditionTooSmall && !ConditionTooBig; }
        }
        public void SetCondition(string s)
        {
            decimal.TryParse(s, out decimal d);
            Condition = d;
        }
        private void GetDayStored()
        {
            askmsg = "Which day stored?";
            errormsg2 = "Day cannot be lower than 1";
            DayStored = GetInt();
        }
        private void GetQuantity()
        {
            askmsg = "How many of current product?";
            errormsg2 = "Quantity cannot be lower than 1";
            Quantity = GetInt();
        }
        public bool QuantityBiggerThanOne
        {
            get { return Quantity > CtInt.INT_1; }
        }
        //This is temporary solution, I need to map all the Places in game and name them and then we can add them to 
        //private void GetPlace()
        //{
        //    askmsg = "Where is it stored? (Detailed description allowed)";
        //    errormsg = "Cannot be empty";
        //    errormsg2 = $"Has to be under {CtInt.NAME_MAX} characters";
        //    correctmsg = "Valid";
        //    while (Place.Equals(string.Empty))
        //    {
        //        cn.Write(askmsg);
        //        Place = Console.ReadLine();
        //        if (Place.Equals(string.Empty))
        //        {
        //            cn.Write(errormsg);
        //        }
        //        else if (Place.Length > CtInt.NAME_MAX)
        //        {
        //            cn.Write(errormsg2);
        //            Place = string.Empty;
        //        }
        //    }
        //}
        public bool OneConditionPerItem()
        {
            askmsg = "Do all the items have same condition?";
            return !GetBool();
        }
        public void Verify()
        {
            GetProductKey();
            GetRegionKey();
            GetPlaceKey();

        }
        public void Save()
        {
            finalInsertString = String.Join(string.Empty, insertString); // tee tästä vakio CtString space  " "
            NonQuery();
        }
        public void InsertStringAddToList(int iQuantity)
        {
            insertString.Add($"INSERT INTO tInventory VALUES (GETDATE(),GETDATE(),1,'{ProductKey}','{RegionKey}','{Condition}','{DayStored}','{PlaceName}','{iQuantity}');");
        }
        public void ViewInventory()
        {
            QueryString = "SELECT * FROM vInventory";
            QueryView();
        }
    }
}
