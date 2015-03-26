using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_xxxCommand_ExecuteReader
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
                var cmd = "SELECT * FROM PESSOA";

                using (var k = new SqlCommand(cmd, c))
                {

                    c.Open();

                    var dr = k.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine(dr[0]);
                        Console.WriteLine((dr["NOME_PESSOA"]));
                        var indiceDaColuna = dr.GetOrdinal("SALARIO_PESSOA");
                        Console.WriteLine(dr.GetDecimal(indiceDaColuna));
                    }

                    c.Close();


                }

            }

            Console.ReadKey();
        }
    }
}
