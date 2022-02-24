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
        private string queryString { get; set; }
        private string address = "IZMO-PC-1EO7KE1\\SQLEXPRESS";
        private string database = "loggerTLD";
        private Boolean trustedConnection = true;

       
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

        public void AskForProductName()
        {
            productName = input.Read();
        }
        public void CompileQueryString()
        {
            queryString = $"select * from vProduct where Productname = '{productName}';";
        }
        public void QueryCommand()
        {
            CompileQueryString();
            SqlCommand cmd = new SqlCommand(queryString, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(reader[i]);
                }
            }
            else
            {
                Console.WriteLine("No data to read");
            }
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
                AskForProductName();
                OpenSqlConnection();
                QueryCommand();
                CloseSqlConnection();
            }
        }



    }
}



