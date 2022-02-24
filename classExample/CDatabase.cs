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
        COutput cn = new COutput();
        CInput input = new CInput();
        SqlConnection connection = new SqlConnection();

        public string productName { get; set; }
        private string connectionString { get; set; }
        public string queryString { get; set; }
        private string address = "IZMO-PC-1EO7KE1\\SQLEXPRESS";
        private string database = "loggerTLD";
        private Boolean trustedConnection = true;
        private string userInput;
        private int returnValue;
        public CDatabase()
        {
            connectionString = $"address={address};database={database};Trusted_Connection={trustedConnection}";
        }

        public void OpenSqlConnection()
        {
            connection.ConnectionString = connectionString;
            connection.Open();
        }

        public void TestSqlConnection()
        {
            Console.WriteLine(connection.State);
        }

        public void CloseSqlConnection()
        {
            connection.Close();    
        }

        public string AskForProductName()
        {
            return input.Read();
        }
        public void vProduct(string _Input)
        {
            if (_Input.Contains("."))
                queryString = $"select * from vProduct where ProductWeight = '{_Input}';";
            else
            {
                queryString = $"select * from vProduct where ProductName = '{_Input}';";
            }
        }
        public void ProductKey(string _Input)
        {
            queryString = $"select ProductKey from tProduct where ProductName = '{_Input}';";
        }
        public void tQueryCommand()
        {
            SqlCommand cmd = new SqlCommand(queryString, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = reader.FieldCount;
                while (reader.Read())
                {   
                    for (int j = 0; j < i; j++)
                    {
                        Console.WriteLine(reader[j]);
                    }
                }
            Console.WriteLine("No more data to read");
            reader.Close();
        }
        public void QueryCommand()
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

        //public void QueryProductFromdb()
        //{
        //    AskForProductName();
        //    OpenSqlConnection();
        //    QueryCommand();
        //    CloseSqlConnection();
        //}
        public void tQueryProductFromdb(int i = 1)
        {
            for (int j = 0; j < i; j++)
            {
                ProductKey(AskForProductName());
                OpenSqlConnection();
                QueryCommand();
                CloseSqlConnection();
            }
        }
        public int getProductKey()
        {
            ProductKey(AskForProductName());
            OpenSqlConnection();
            QueryCommand();
            CloseSqlConnection();
            return returnValue;
        }
        public int QueryProductKey()
        {
            OpenSqlConnection();
            QueryCommand();
            CloseSqlConnection();
            return returnValue;
        }

    }
}



