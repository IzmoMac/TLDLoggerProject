using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

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
        private string connectionString { get; set; }
        public string queryString { get; set; }
        private string address = "IZMO-PC-1EO7KE1\\SQLEXPRESS";
        private string database = "loggerTLD";
        private bool trustedConnection = true;

        public string finalInsertString;
        List<string> insertString = new List<string>();

        public string productName;
        private int productKey;
        static string[] arrayGetProductKey = { "ProductKey", "tProduct", "ProductName" };

        public string regionName;
        private int regionKey;
        static string[] arrayGetRegionKey = { "RegionKey", "tRegion", "RegionName" };

        public double condition;
        public int quantity;

        private bool keepGoing;

        private string askmsg;
        private string errormsg;
        private string errormsg2;
        private string correctmsg = "Success";



        // Initializes connectionString and sets it. Also resets other values so they are not left hanging and used accidentaly
        /*
         *         // THIS IS TEST REMOVE 'TIMEOUT=2' ON LINE             connectionString = $"address={address};database={database};Trusted_Connection={trustedConnection};timeout=2";
         */
        public CDatabase()
        {
            connectionString = $"address={address};database={database};Trusted_Connection={trustedConnection};timeout=2";
            connection.ConnectionString = connectionString;
            queryString = "";
            insertString.Clear();
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

        // Compiles SELECT QueryString based on given inputs
        private void CompileQueryString(string[] a,string Condition)
        {
            queryString = $"SELECT \"{a[0]}\" FROM \"{a[1]}\" WHERE \"{a[2]}\" = '{Condition}';";

        }

        // Asks User for ProductName and sets ProductKey to corresponding ProductKey
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
        
        //Asks User for RegionName and sets RegionKey to corresponding RegionName
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

        public double GetCondition()
        { 
            askmsg = "How much condition left?";
            errormsg = "Give a valid condition amount";
            errormsg2 = "Condition cannot be higher than 100";
            string errormsg3 = "Condition cannot be lower than 0";
            correctmsg = "Valid condition amount";

            string tempCondition;

            bool keepGoing = true;
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
            return condition;
        }
        public int GetDayStored()
        {
            askmsg = "Which day stored?";
            errormsg2 = "Day cannot be lower than 1";
            return GetInt(); 
        }
        public int GetQuantity()
        {
            askmsg = "How many of current product?";
            errormsg2 = "Quantity cannot be lower than 1";
            return GetInt();
        }
        public int GetInt()
        {
            errormsg = "Give a valid number";
            string tempInt;
            int returnValue = -1;
            bool keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                tempInt = Console.ReadLine();
                try
                {
                    returnValue = int.Parse(tempInt);
                    if (returnValue < 1)
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
            return returnValue;
        }

        //This is temporary solution, I need to map all the Places in game and name them and then we can add them to 
        public string GetPlace()
        {
            askmsg = "Where is it stored? (Detailed description allowed)";
            errormsg = "Cannot be empty";
            errormsg2 = "Has to be under 50 characters";
            correctmsg = "Valid";
            string place = "";
            bool keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                place = Console.ReadLine();
                if(place.Length < 1)
                {
                    cn.Write(errormsg);
                }
                else if(place.Length > 50)
                {
                    cn.Write(errormsg2);
                }
                else
                {
                    keepGoing= false;
                }
            }
            return place;
        }
        public bool OneConditionForAll()
        {
            return GetBool();
        }
        public bool GetBool()
        {
            askmsg = "Do all the items have same condition?";
            errormsg = "Please type Yes or No";
            correctmsg = "Valid";
            string tempAnswer = "";
            bool answer = true;
            bool keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                tempAnswer = Console.ReadLine();
                if (tempAnswer == "Yes")
                {
                    keepGoing = false;
                }
                else if (tempAnswer == "No")
                {
                    keepGoing = false;
                    answer = false;
                }
                else
                {
                    cn.Write(errormsg);
                }
            }
            return answer;
        }

        public void CreateNewProduct()
        {
            //It creates it in this class for later use. (For example we can ask to check if informartion is correct?)
            CProduct p = new CProduct(GetProductKey(), productName, GetRegionKey(), regionName, GetDayStored(), GetPlace());

            quantity = GetQuantity();
            
            bool oneForAll = false; //Herjaa jos ei anna value...
            bool questionAsked = false; 
            bool keepGoing = true;
            while (keepGoing)
            {
                if (quantity > 1)
                {
                    // If question is not ask, asks a question once.
                    if (!questionAsked)
                    {
                        oneForAll = OneConditionForAll();
                        questionAsked = true;
                    }
                    if (oneForAll == false)
                    {
                        condition = GetCondition();
                        insertString.Add($"INSERT INTO tInventory VALUES (GETDATE(),GETDATE(),1,'{p.productKey}','{p.regionKey}','{condition}','{p.dayStored}','{p.place}','1');"); //Tähän voi olla parempi ratkaisu, mieti
                        quantity--;
                    }
                    else
                    {
                        keepGoing=false;
                    }
                }
                else
                {
                    keepGoing = false;
                }
                condition = GetCondition();
                insertString.Add($"INSERT INTO tInventory VALUES (GETDATE(),GETDATE(),1,'{p.productKey}','{p.regionKey}','{condition}','{p.dayStored}','{p.place}','{quantity}');"); //Tähän voi olla parempi ratkaisu, mieti
            }
            finalInsertString = String.Join(" ", insertString);
            //Clears insertString list
            insertString.Clear();
            NonQuery();
        }

        //Exectues a non query string to database
        public void NonQuery()
        {
            OpenConnetion();
            SqlCommand cmd = new SqlCommand(finalInsertString, connection);
            int rowsAdded = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rowsAdded} rows added");
            cmd.Dispose();
            CloseConnection();
        }



        public void QueryView()
        {
            OpenConnetion();
            Query();
            CloseConnection();
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

        public void ViewInventory()
        {
            queryString = "SELECT * FROM vInventory";
            QueryView();
        }       
        
    }
}



