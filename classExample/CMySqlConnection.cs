using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace classExample
{
    class CMySqlConnection
    {
        COutput cn = new COutput();

        SqlConnection connection = new SqlConnection();

        public string Server { get; set; }
        public string dbName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        string address = "IZMO-PC-1EO7KE1S/QLEXPRESS";
        string database = "loggerTLD";

        readonly string connectionstring = "address=IZMO-PC-1EO7KE1\\SQLEXPRESS;database=loggerTLD;Trusted_Connection=True";
        

        public string productName { get; set; }

        string queryString;
       
        public void OpenSqlConnection()
        {

            connection.ConnectionString = connectionstring;
            connection.Open();
            
        }

        public void AskForProductName()
        {
            Console.WriteLine("Product name: ");
            productName = Console.ReadLine();

        }

        public void QueryProductFromdb()
        {
            queryString = $"select ProductName,ProductWeight from tProduct where Productname = '{productName}';";
            OpenSqlConnection();
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
            CloseSqlConnection();

        }
        public void CloseSqlConnection()
        {
            connection.Close();

        }
        public void TestSqlConnection()
        {
            Console.WriteLine(connection.State);
        }


        // create input for user query terms as string
        // create result from database string/table

        // kesken, tavoite, avaa sql yhteys
        // kysy haku ehto käyttäjältä
        // lähetä hakuehto eteenpäin
        // vastaan ota tulos
        // näytä haku käyttäjälle
        //public void QuerySqlConnection(string queryString)
        //{
        //    OpenSqlConnection();
        //    SqlCommand command = new SqlCommand(queryString);
        //    command.ExecuteReader();
       
        //}


        /*
         * 
         */
        public void Kakku()
        {
            cn.DrawLine();
            cn.Write(database);
            cn.Write(address);
            cn.Write(connectionstring);
            cn.DrawLine();

        }

       

    }
}
