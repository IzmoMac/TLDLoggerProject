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

        //private CMySqlConnection()
        //{
        //}

        SqlConnection connection = new SqlConnection();

        public string Server { get; set; }
        public string dbName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        string address = "IZMO-PC-1EO7KE1S/QLEXPRESS";
        string database = "loggerTLD";
        int timeout = 15;

        readonly string connectionstring = "address=IZMO-PC-1EO7KE1\\SQLEXPRESS;database=loggerTLD;Trusted_Connection=True";
        //public void checkmysqlconnection()
        //{
        //    new cmysqlconnection().opensqlconnection();
        //    cn.result((int)connection.state);
        //    console.writeline(connection.state);
        //}
        public void OpenSqlConnection()
        {
            //SqlConnection connection = new SqlConnection();

            connection.ConnectionString = connectionstring;
            connection.Open();
            int conn = (int)connection.State;
            if (conn == 1)
                cn.Write("Connection Succesfull");
            else
                cn.Write("Connection failed");
            //Console.WriteLine(connection.ClientConnectionId);
        

        }
        
        

        static private string GetConnectionString()
        {
            string Server = "hgh";
            return "tää palaa";

        }




        public void Kakku()
        {
            
            cn.Write(database);
            cn.Write(address);
            cn.Write("tää toimii");
            
            
        }
    }
}
