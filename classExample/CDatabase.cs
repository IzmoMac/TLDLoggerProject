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
        private int returnValue;
        private bool ErrorOccurred;

        private string productName;
        private int productKey;
        private bool keepGoing;
        static string[] arrayGetProductKey = { "ProductKey", "tProduct", "ProductName" };
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
            returnValue = 0;
            ErrorOccurred = false;
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
        private void CompileQueryString(string[] a,string Condition)
        {
            queryString = $"SELECT \"{a[0]}\" FROM \"{a[1]}\" WHERE \"{a[2]}\" = '{Condition}';";

        }
        public void ttGetProductKey()
        {
            askmsg = "What is product name?";
            errormsg = "Given Product Name not valid.";
            correctmsg = "Product is Valid";
            keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                productName = Console.ReadLine();
                CompileQueryString(arrayGetProductKey, productName);
                QuerySingleKey(productName);
                
            }
            Console.WriteLine(productKey);
        }
        public void ttGetProductKey()
        {
            askmsg = "What is product name?";
            errormsg = "Given Product Name not valid.";
            correctmsg = "Product is Valid";
            keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                productName = Console.ReadLine();
                CompileQueryString(arrayGetProductKey, productName);
                QuerySingleKey(productName);

            }
            Console.WriteLine(productKey);
        }
        private void QuerySingleKey(string s)
        {
            OpenConnetion();
            SqlCommand cmd = new SqlCommand(queryString, connection);
            var result = cmd.ExecuteScalar();
            if (result == null)
            {
                cn.Write($"{errormsg} ({productName})");
            }
            else
            {
                productKey = int.Parse(result.ToString());
                cn.Write(correctmsg);
                keepGoing = false;
            }
            cmd.Dispose();
            CloseConnection();
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
        public void notoworkingAddProductToInventory()
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
        public void InsertToInventory(int productKey, int regionKey, float condition, int dayStored, string place)
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



