using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

/* Kommentteja
Aloitetaan siitä että:
Funktio getspecificitemfromdatabase
  Funktio Kysytään käyttäjältä tavaran nimi
  Funktio luodaan yhteys tietokantaan
  Funktio kysytään tavara tietokannasta
  Funktio lue tietokannnan vastaus
  Funktio suljetaan yhteys tietokannasta
  Funktio Näytetään kysytyn tavaran tiedot käyttäjälle

Funktio kysytään käyttäjältä tavaran nimi
Create a variable userInputproductname type string
ask for input "Product name: " and set userInputproductname

Funktio luodan yhteys tietokantaan
create a variable connectionString type string initVal "a valid connectionstring"
Connect to database using connectionString

Funktio kysytään tavara tietokannasta
create a variable queryString type "string"
queryString = "select userInputproductname from tProduct"
send command to db using queryString

Funktio lue tietokannnan vastaus
create a variable dbResult type "string"
read database result
dbResult = read result from database

Funktio suljetaan yhteys tietokantaan
Close connection with database

Funktio Näytetään kysytyn tavaran tiedot käyttäjälle
if dbResult == userInputProductName
    Say "Success"
else
    Say "Failure"

Print dbResult



 */


namespace classExample
{
    class CDatabase
    {
        SqlConnection connection = new SqlConnection();
        COutput cn = new COutput();
        //CInventory inventory = new CInventory();
        private string connectionString { get; set; }
        public string queryString { get; set; }
        private string address = "IZMO-PC-1EO7KE1\\SQLEXPRESS";
        private string database = "loggerTLD";
        private bool trustedConnection = true;
        //private int returnValue;
        private bool ErrorOccurred;

        public string productName;
        private int productKey;
        static string[] arrayGetProductKey = { "ProductKey", "tProduct", "ProductName" };

        public string regionName;
        private int regionKey;
        static string[] arrayGetRegionKey = { "RegionKey", "tRegion", "RegionName" };

        public double condition;

        public int dayStored;

        private bool keepGoing;
        private string askmsg;
        private string errormsg;
        private string correctmsg;


        // Initializes connectionString and sets it. Also resets other values so they are not left hanging and used accidentaly
        /*
         *          THIS IS TEST 'EMOVE 'TIMEOUT=2' ON LINE             connectionString = $"address={address};database={database};Trusted_Connection={trustedConnection};timeout=2";
         */
        public CDatabase()
        {
            connectionString = $"address={address};database={database};Trusted_Connection={trustedConnection};timeout=2";
            connection.ConnectionString = connectionString;
            queryString = "";
            ErrorOccurred = false;
        }
        public void AddItem()
        {
            GetProductKey();
            GetRegionKey();

        }
        //Self Explanatory, Opens Sql Connection...
        private void OpenConnetion()
        {
            try
            {
                Console.WriteLine("Connecting to Database...");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("                         ");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                connection.Open();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw;
            }
        }
        //Self Explanatory, Closes Sql Connection...
        private void CloseConnection()
        {
            connection.Close();    
        }
        private void CompdileQueryString()
        {

        }
        // Compiles SELECT QueryString based on given inputs
        private void CompileQueryString(string[] a,string Condition)
        {
            queryString = $"SELECT \"{a[0]}\" FROM \"{a[1]}\" WHERE \"{a[2]}\" = '{Condition}';";

        }
        /* Asks User for ProductName and sets ProductKey to corresponding ProductKey
         */
        public int GetProductKey()
        {
            askmsg = "What is product name?";
            errormsg = "Given Product Name not valid.";
            correctmsg = "Product is Valid";
            string tempProductKey = "";
            keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                productName = Console.ReadLine();
                CompileQueryString(arrayGetProductKey, productName);
                tempProductKey = QuerySingleKey(productName);
                
            }
            productKey = int.Parse(tempProductKey);
            return productKey;
        }
        /* Asks User for RegionName and sets RegionKey to corresponding RegionName
         */
        public int GetRegionKey()
        {
            askmsg = "What is Region name?";
            errormsg = "Given Region do not exist.";
            correctmsg = "Region is Valid";
            string tempRegionKey = "";
            keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                regionName = Console.ReadLine();
                CompileQueryString(arrayGetRegionKey, regionName);
                tempRegionKey = QuerySingleKey(regionName);

            }

            regionKey = int.Parse(tempRegionKey);
            return regionKey;
        }
        private string QuerySingleKey(string input)
        {
            string returnValue = "";
            OpenConnetion();
            SqlCommand cmd = new SqlCommand(queryString, connection);
            var result = cmd.ExecuteScalar();
            if (result == null)
            {
                cn.Write($"{errormsg} ({input})");
            }
            else
            {
                returnValue = result.ToString();
                cn.Write(correctmsg);
                keepGoing = false;
            }
            cmd.Dispose();
            CloseConnection();
            return returnValue;
        }
        //public void GetCondition(string tempCondition)
        public void GetCondition()
        { 
            askmsg = "How much condition left?";
            errormsg = "Give a valid condition amount";
            string errormsg2 = "Condition cannot be higher than 100";
            string errormsg3 = "Condition cannot be lower than 0";
            correctmsg = "Valid condition amount";

            string tempCondition;

            keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                tempCondition = Console.ReadLine();
                try
                {
                    condition = double.Parse(tempCondition);
                    if (condition > 100)
                    {
                        cn.Write(errormsg2);
                    }
                    else if(condition < 0)
                    {
                        cn.Write(errormsg3);
                    }
                    else
                    {
                        keepGoing = false;
                    }
                }
                catch (FormatException ex)
                {
                    cn.Write(errormsg);
                }
            }
            condition = Math.Round(condition, 3);
        }
        public void GetDayStored()
        {
            askmsg = "Which day stored?";
            errormsg = "Give a valid number";
            string errormsg2 = "Day cannot be lower than 0";
            correctmsg = "Valid condition amount";
            string tempDayStored = "";
            //double con;
            keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                tempDayStored = Console.ReadLine();
                try
                {
                    dayStored = int.Parse(tempDayStored);
                    if (dayStored < 0)
                    {
                        cn.Write(errormsg2);
                    }
                    else
                    {
                        keepGoing = false;
                    }
                }
                catch (FormatException ex)
                {
                    cn.Write(errormsg);
                }
            }
            
        }










        public void tGetProductKey(string _productName)
        {
            queryString = $"select ProductKey from tProduct where ProductName = '{_productName}';";
            OpenConnetion();
            SqlCommand cmd = new SqlCommand(queryString, connection);
            var result = cmd.ExecuteScalar();
                if (result == null)
                {
                    Console.WriteLine($"Given Product Name not valid. ({_productName})");
                }
                else
                {
                    productKey = int.Parse(result.ToString());
                    Console.WriteLine("Product is Valid");
                    keepGoing = false;
                }
                cmd.Dispose();
                CloseConnection();
        }
        public void dnotoworkingAddProductToInventory()
        { //This funcntion is underconsrtuction
            /* What this function(algorithm) needs to do?
             
             * Ask for ProductName and Store it in variable productName (this makes seperate function)
             
             * Ask database for corresponding ProductKey and return productKey 
             * If key not found in database, go to behinning
             */
            keepGoing = true;
            while (keepGoing)
            {
                cn.Write("What is product name?");
                productName = Console.ReadLine();
                tGetProductKey(productName);
            }
            Console.WriteLine(productKey);



        }
        public void TryQueryForAnyKey()
        {
            int returnValue; //this is temporary, probabpy just delete whole function
            OpenConnetion();
            SqlCommand cmd = new SqlCommand(queryString, connection);
            try
            {
                var result = cmd.ExecuteReader();
                if (result == null)
                {
                    Console.WriteLine("No Product Found, Check your Product Name");
                }
                else
                {
                    returnValue = int.Parse(result.ToString());
                    Console.WriteLine("ProductKeyFound");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd.Dispose ();
                CloseConnection ();
            }
        }
        public int tGetProductKeyFromName(string _productName)
        {
            int returnValue = 0; //this is temporary, probabpy just delete whole function

            try
            {
                queryString = $"select ProductKey from tProduct where ProductName = '{_productName}';";
                TryQueryForAnyKey();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine("Ottikiinnni tgpkf");
                Console.WriteLine(ex.Message);
                returnValue = 0;
            }
            return returnValue;

        }
        public int ManualQueryForProductKey()
        {
            int returnValue = 0; //this is temporary, probabpy just delete whole function

            OpenConnetion();
            QueryInt();
            SqlCommand cmd = new SqlCommand(queryString, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = reader.FieldCount;
            while (reader.Read())
            {
                for (int j = 0; j < i; j++)
                {
                    returnValue = (int)reader[j];
                }
            }
            //cn.Write("No product found");

            reader.Close();
            cmd.Dispose();
            CloseConnection();
            return returnValue;

        }
        public void QueryInt()
        {
            int returnValue; //this is temporary, probabpy just delete whole function

            SqlCommand cmd = new SqlCommand(queryString, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = reader.FieldCount;
                while (reader.Read())
                {
                    for (int j = 0; j < i; j++)
                    {
                        returnValue = (int)reader[j];
                    }
                }
                //cn.Write("No product found");
                reader.Close();
        }
        public void Query()
        {
            SqlCommand cmd = new SqlCommand(queryString, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = reader.FieldCount;
            while (reader.Read())
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($"{reader[j]} ;  ");
                }
                Console.Write("\n");
            }
            //cn.Write("No product found");
            reader.Close();
        }
        public void NonQuery()
        {
            OpenConnetion();
            SqlCommand cmd = new SqlCommand(queryString, connection);
            int rowsAdded = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rowsAdded} rows added");
            cmd.Dispose();
            CloseConnection();
        }
        public int QueryKey()
        {
            int returnValue = 0; //this is temporary, probabpy just delete whole function

            OpenConnetion();
            QueryInt();
            CloseConnection();
            return returnValue;
        }
        public void QueryView()
        {
            OpenConnetion();
            Query();
            CloseConnection();
        }
        public void ViewInventory()
        {
            queryString = "SELECT * FROM vInventory";
            QueryView();
        }
        public void DeleteAllClothFromInventory()
        {
            queryString = "delete from tInventory where ProductKey = 50";
            NonQuery();
        }
        public void InsertToInventory(int productKey, int regionKey, double condition, int dayStored, string place)
        {
            queryString = $"INSERT INTO tInventory VALUES (GETDATE(),GETDATE(),1,'{productKey}','{regionKey}','{condition}','{dayStored}','{place}');";
            NonQuery();
        }
        public int GetProductKeyFromName(string _productName)
        {
            queryString = $"select ProductKey from tProduct where ProductName = '{_productName}';";
            return QueryKey();
        }
        public int GetRegionKeyFromName(string _regionName)
        {
            queryString = $"select RegionKey from tRegion where RegionName = '{_regionName}';";
            return QueryKey();
        }
       
    }
}



