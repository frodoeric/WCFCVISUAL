using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _016_WebAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //install-packeg-microsoft.AspNet.WebApi.Client

            Console.WriteLine("pressione qualquer tecla para continuar");

            Console.ReadKey();

            Console.Clear();

            Post().Wait();

            Console.ReadKey();

        }

        private static async Task Post()
        {
            Console.WriteLine("--- executando o metodo Post()--");

            using (var c = new HttpClient()) //System.net.http
            {
                var pessoa = new Pessoa { Id = 99, Nome = Guid.NewGuid().ToString(), Salario = 1000 };

                c.BaseAddress = new Uri("http://localhost:1527");

                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var r = await c.PostAsJsonAsync<Pessoa>("api/Pessoa", pessoa);

                if (r.IsSuccessStatusCode)
                {
                    Console.WriteLine(r.Headers.Location);
                }
                else
                {
                    Console.WriteLine(r.Content.ReadAsStringAsync().Result);
                }
            }
        }
    }

    class Pessoa
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public decimal? Salario { get; set; }

    }
}
