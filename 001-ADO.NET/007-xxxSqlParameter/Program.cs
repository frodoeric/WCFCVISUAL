using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_xxxSqlParameter
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
                String nomePessoaParcial = "CA";

                //Resolve o problema do InJection
                var cmd = "SELECT * FROM PESSOA WHERE NOME_PESSOA LIKE @NOME_PESSOA";

                using (var k = new SqlCommand(cmd, c))
                {
                    k.Parameters.AddWithValue("@NOME_PESSOA", "%" + nomePessoaParcial + "%");

                    c.Open();

                    var dr = k.ExecuteReader();

                    while (dr.Read())
                    {
                        //for (int i = 0; i < dr.FieldCount; i++)//{}

                        Console.WriteLine(dr[0]);
                        Console.WriteLine(dr[1]);
                        Console.WriteLine(dr[2]);

                        Console.WriteLine();

                    }

                    c.Close();

                    Console.ReadKey();


                }

            }

            Console.ReadKey();
        }
    }
}
