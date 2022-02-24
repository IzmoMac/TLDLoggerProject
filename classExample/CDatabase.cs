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

        private string connectionString { get; set; }
        public string queryString { get; set; }
        private string address = "IZMO-PC-1EO7KE1\\SQLEXPRESS";
        private string database = "loggerTLD";
        private Boolean trustedConnection = true;
        private int returnValue;
        public CDatabase()
        {
            connectionString = $"address={address};database={database};Trusted_Connection={trustedConnection}";
            connection.ConnectionString = connectionString;
            queryString = "";
        }
        public void OpenSqlConnection()
        {
            connection.Open();
        }
        public void CloseSqlConnection()
        {
            connection.Close();    
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
            OpenSqlConnection();
            SqlCommand cmd = new SqlCommand(queryString, connection);
            int rowsAdded = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rowsAdded} rows added");
            CloseSqlConnection();
        }
        public int QueryKey()
        {
            OpenSqlConnection();
            QueryInt();
            CloseSqlConnection();
            return returnValue;
        }
        public void QueryView()
        {
            OpenSqlConnection();
            Query();
            CloseSqlConnection ();
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



