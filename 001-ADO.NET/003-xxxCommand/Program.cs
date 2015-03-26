using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_xxxCommandExecuteNonQuery
{
    //http://www.connectionstrings.com/

    class Program
    {
        static void Main(string[] args)
        {
            //ExecuteNonQuery
            //Comando no Banco de dados que não tenham pesquisa

            var cs = @"Data Source=.\sqlexpress;Initial Catalog=DB;Integrated Security=true";

            //xxx.udl

            //using para usar um recurso externo, pelo fato de não ser ecrito em dot net
            //para liberação de memória, algumas classes montam a classe herdando do exposeble
            //c.dispose

            using (var c = new SqlConnection(cs))
            {
                var cmd = "INSERT PESSOA VALUES(NEWID(), RAND() * 1000)";

                using(var k = new SqlCommand(cmd, c))
	            {

                    c.Open();

                    var qtdLinhas = k.ExecuteNonQuery();

                    c.Close();

                    Console.WriteLine(qtdLinhas);
		 
	            }

            }

            Console.ReadKey();
        }

    }
}
