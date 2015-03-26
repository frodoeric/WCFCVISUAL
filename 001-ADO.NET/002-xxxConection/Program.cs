using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_xxxConection
{
    class Program
    {
        static void Main(string[] args)
        {

            var cs = @"Data Source=.\sqlexpress;Initial Catalog=DB;Integrated Security=true";

            //xxx.udl

            //using para usar um recurso externo, pelo fato de não ser ecrito em dot net
            //para liberação de memória, algumas classes montam a classe herdando do exposeble
            //c.dispose

            using (var c = new SqlConnection(cs))
            {
                c.StateChange += c_StateChange;

                c.Open();
                c.Close();
            }

            Console.ReadKey();
        }

        //evento disparado sempre que muda o estado da conexão. 
        static void c_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            Console.WriteLine("mudou de {0} para {1}", e.OriginalState, e.CurrentState);
        }
    }
}
