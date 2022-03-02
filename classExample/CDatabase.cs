using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

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
    public class CDatabase
    {
        SqlConnection connection = new SqlConnection();
        public COutput cn = new COutput();
        public string QueryString { get; set; }
        private string address = "IZMO-PC-1EO7KE1\\SQLEXPRESS";
        private string database = "loggerTLD";
        private bool trustedConnection = true;
        public string finalInsertString;
        public List<string> insertString = new List<string>();

        public string askmsg;
        public string errormsg;
        public string errormsg2;
        public string correctmsg = "Success";



        // Initializes connectionString and sets it. Also resets other values so they are not left hanging and used accidentaly
        /*
         *         // THIS IS TEST REMOVE 'TIMEOUT=2' ON LINE             connectionString = $"address={address};database={database};Trusted_Connection={trustedConnection};timeout=2";
         */
        public CDatabase()
        {
            connection.ConnectionString = $"address={address};database={database};Trusted_Connection={trustedConnection};timeout=2";
            QueryString = string.Empty;
            insertString.Clear();
        }
        //Self Explanatory, Opens Sql Connection...
        private bool OpenConnection()
        {
            string msg = "Connecting to Database...";
            try
            {
                Console.WriteLine(msg);
                SetPos();
                Console.WriteLine(new String(CtChar.SPACE, msg.Length));
                SetPos();
                connection.Open();
            }
            catch (Exception ex)
            {
                CloseConnection();
                Console.WriteLine(ex.Message);
            }
            return connection.State.Equals(ConnectionState.Open);
        }
        private void SetPos() { Console.SetCursorPosition(CtInt.ZERO, Console.CursorTop + CtInt.INT_MINUS_1); }

        //Self Explanatory, Closes Sql Connection...
        private void CloseConnection()
        {

            if (!connection.State.Equals(ConnectionState.Open))
            {
                return;
            }
            connection.Close();
        }
        // Compiles SELECT QueryString based on given inputs
        public void CompileQueryString(string[] a, string Condition)
        {
            QueryString = $"SELECT \"{a[0]}\" FROM \"{a[1]}\" WHERE \"{a[2]}\" = '{Condition}';";

        }
        public int QuerySingleKey(string input)
        {
            if (!OpenConnection()) { return CtInt.ZERO; }

            string returnValue = String.Empty;
            SqlCommand cmd = new SqlCommand(QueryString, connection);
            var result = cmd.ExecuteScalar();
            if (result == null)
            {
                cn.Write($"{errormsg} ({input})");
            }
            else
            {
                returnValue = result.ToString();
                cn.Write(correctmsg);
            }
            cmd.Dispose();
            CloseConnection();
            Int32.TryParse(returnValue, out int i);
            return i;
        }
        public int GetInt()
        {
            errormsg = "Give a valid number";
            int returnValue = CtInt.ZERO;
            while (returnValue < CtInt.INT_1)
            {
                cn.Write(askmsg);
                Int32.TryParse(Console.ReadLine(), out returnValue);
                if (returnValue.Equals(CtInt.ZERO))
                {
                    cn.Write(errormsg);
                }
                else if (returnValue < CtInt.INT_1)
                {
                    cn.Write(errormsg2);
                }

            }
            return returnValue;
        }
        public bool GetBool()
        {
            errormsg = "Please type Yes or No";
            correctmsg = "Valid";
            bool keepGoing = true;
            while (keepGoing)
            {
                cn.Write(askmsg);
                switch (Console.ReadLine().ToLower())
                {

                    case "yes": return true;
                    case "no": return false;
                    default:
                        cn.Write(errormsg);
                        break;
                }
            }
            return false;
        }
        //Exectues a non query string to database
        public void NonQuery()
        {
            if (!OpenConnection()) { return; }

            SqlCommand cmd = new SqlCommand(finalInsertString, connection);
            int rowsAdded = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rowsAdded} rows added");
            cmd.Dispose();
            CloseConnection();
        }
        public void QueryView()
        {
            if (!OpenConnection()) { return; }
            Query();
            CloseConnection();
        }
        public void Query()
        {
            SqlCommand cmd = new SqlCommand(QueryString, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = CtInt.ZERO; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i]} ;  ");
                }
                Console.Write(Environment.NewLine);
            }
            reader.Close();
            cmd.Dispose();
        }
    }
}



