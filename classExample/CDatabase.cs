using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace classExample
{
    class CDatabase
    {
        COutput cn = new COutput();

        SqlConnection connection = new SqlConnection();

        public string productName { get; set; }
        private string address = "IZMO-PC-1EO7KE1\\SQLEXPRESS";
        private string database = "loggerTLD";
        private Boolean trustedConnection = true;
        private string connectionString { get; set; }
        private string queryString { get; set; }
       
        public void CompileConnectionString()
        {
            connectionString = $"address={address};database={database};Trusted_Connection={trustedConnection}";
        }

        public void OpenSqlConnection()
        {
            CompileConnectionString();
            connection.ConnectionString = connectionString;
            connection.Open();
        }

        public void CloseSqlConnection()
        {
            connection.Close();    
        }

        public void AskForProductName()
        {
            Console.WriteLine("Product name: ");
            productName = Console.ReadLine();
        }

        public void CompileQueryString()
        {
            queryString = $"select ProductName,ProductWeight from tProduct where Productname = '{productName}';";
        }

        public void QueryProductFromdb()
        {
            OpenSqlConnection();
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
            CloseSqlConnection();
        }
        
        public void TestSqlConnection()
        {
            Console.WriteLine(connection.State);
        }


    }
}
