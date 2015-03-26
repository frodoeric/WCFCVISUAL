using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = @"Data Source=.\sqlexpress;Initial Catalog=DB;Integrated Security=true";

            Console.WriteLine(cs);

            //Cria uma string de conection para o SQL
            var sqlcsb = new SqlConnectionStringBuilder();

            sqlcsb.DataSource = @".\sqlexpress";
            sqlcsb.InitialCatalog = "DB";
            sqlcsb.IntegratedSecurity = false;
            sqlcsb.UserID = "agnaldo";
            sqlcsb.Password = "senhaDoAgnaldo";

            Console.WriteLine(sqlcsb.ConnectionString);

            var odbccsb = new OdbcConnectionStringBuilder();

            odbccsb.Dsn = "dsn do banco";

            Console.WriteLine(odbccsb.ConnectionString);

            var oledbcsb = new OleDbConnectionStringBuilder();

            oledbcsb.DataSource = @".\sqlexpress";
            oledbcsb.Provider = "SQLNCLI";


            Console.WriteLine(oledbcsb);
            Console.ReadKey();
        }
    }
}
