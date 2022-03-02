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
        public string Place { get; set; } = string.Empty;
        public int Quantity { get; set; } = CtInt.ZERO;

        static string[] arrayGetProductKey = { "ProductKey", "tProduct", "ProductName" };
        static string[] arrayGetRegionKey = { "RegionKey", "tRegion", "RegionName" };

        public CProduct()
        {
            
        }
        // Asks User for ProductName and sets ProductKey to corresponding ProductKey
        private int GetProductKey()
        {
            askmsg = "What is product name?";
            errormsg = "Given Product Name not valid.";
            correctmsg = "Product is Valid";
            while (ProductKey.Equals(CtInt.ZERO))
            {
                cn.Write(askmsg);
                ProductName = Console.ReadLine();

                CompileQueryString(arrayGetProductKey, ProductName);

                ProductKey = QuerySingleKey(ProductName);
            }
            return ProductKey;
        }

        //Asks User for RegionName and sets RegionKey to corresponding RegionName
        private int GetRegionKey()
        {
            askmsg = "What is Region name?";
            errormsg = "Given Region do not exist.";
            correctmsg = "Region is Valid";
            int regionKey = CtInt.ZERO;
            while (regionKey.Equals(CtInt.ZERO))
            {
                cn.Write(askmsg);
                RegionName = Console.ReadLine();

                CompileQueryString(arrayGetRegionKey, RegionName);

                regionKey = QuerySingleKey(RegionName);
            }
            return regionKey;
        }
        private void GetCondition()
        {
            askmsg = "How much condition left?";
            errormsg = "Give a valid condition amount";
            errormsg2 = "Condition cannot be higher than 100";
            string errormsg3 = "Condition cannot be lower than 0";
            correctmsg = "Valid condition amount";
            
            while (!ConditionValid)
            {
                cn.Write(askmsg);
                try
                {  
                    Condition = Math.Round(decimal.Parse(Console.ReadLine()), CtInt.PRCT_PRECISION);
                    if (ConditionTooBig)
                    {
                        cn.Write(errormsg2);
                    }
                    else if (ConditionTooSmall)
                    {
                        cn.Write(errormsg3);
                    }
                }
                catch (FormatException ex)
                {
                    cn.Write(errormsg);
                }
            }
        }
        private bool ConditionTooSmall
        {
            get { return Condition < CtInt.ZERO; }
        }
        private bool ConditionTooBig
        {
            get { return Condition > CtInt.PRCT_MAX; }
        }
        private bool ConditionValid
        {
            get { return !ConditionTooSmall && !ConditionTooBig; }
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
        //This is temporary solution, I need to map all the Places in game and name them and then we can add them to 
        private void GetPlace()
        {
            askmsg = "Where is it stored? (Detailed description allowed)";
            errormsg = "Cannot be empty";
            errormsg2 = $"Has to be under {CtInt.NAME_MAX} characters";
            correctmsg = "Valid";
            while (Place.Equals(string.Empty))
            {
                cn.Write(askmsg);
                Place = Console.ReadLine();
                if (Place.Equals(string.Empty))
                {
                    cn.Write(errormsg);
                }
                else if (Place.Length > CtInt.NAME_MAX)
                {
                    cn.Write(errormsg2);
                    Place = string.Empty;
                }
            }
        }
        public bool OneConditionPerItem()
        {
            askmsg = "Do all the items have same condition?";
            return !GetBool();
        }
        public void CreateNewProduct()
        {
            GetProductKey();
            GetRegionKey();
            GetDayStored();
            GetPlace();
            GetQuantity();

            bool oneForOne = true;
            bool questionAsked = false;
            while (Quantity > CtInt.INT_1 && oneForOne)
            {
                // If question is not ask, asks a question once.
                if (!questionAsked)
                {
                    oneForOne = OneConditionPerItem();
                    questionAsked = true;
                }
                if (oneForOne)
                {
                    GetCondition();
                    InsertStringAddToList(CtInt.INT_1);
                    Quantity--;
                }
            }
            GetCondition();
            InsertStringAddToList(Quantity);
            finalInsertString = String.Join(string.Empty, insertString); // tee tästä vakio CtString sapce
            NonQuery();
        }
        public void InsertStringAddToList(int iQuantity)
        {
            insertString.Add($"INSERT INTO tInventory VALUES (GETDATE(),GETDATE(),1,'{ProductKey}','{RegionKey}','{Condition}','{DayStored}','{Place}','{iQuantity}');");
        }
        public void ViewInventory()
        {
            QueryString = "SELECT * FROM vInventory";
            QueryView();
        }
    }
}
