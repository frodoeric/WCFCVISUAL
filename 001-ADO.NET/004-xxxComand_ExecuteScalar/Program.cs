using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_xxxComand_ExecuteScalar
{
    class Program
    {
        static void Main(string[] args)
        {
            //retornar primeira coluna e primeira linha

            var cs = @"Data Source=.\sqlexpress;Initial Catalog=DB;Integrated Security=true";

            //xxx.udl

            //using para usar um recurso externo, pelo fato de não ser ecrito em dot net
            //para liberação de memória, algumas classes montam a classe herdando do exposeble
            //c.dispose

            using (var c = new SqlConnection(cs))
            {
                var cmd = "SELECT NOME_PESSOA FROM PESSOA WHERE COD_PESSOA = 1";

                using (var k = new SqlCommand(cmd, c))
                {

                    c.Open();

                    var nomePessoa = k.ExecuteScalar();

                    c.Close();

                    Console.WriteLine(nomePessoa);

                }

            }

            Console.ReadKey();
        }
    }
}
