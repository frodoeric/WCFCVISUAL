using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {

            //Chamada Sincrona
            using (var c = new ProxySomadora.ISomadoraClient())
            {
                Console.WriteLine(c.Somar(10, 123));
                Console.WriteLine(c.Somar(100, 23));
            }

            Console.ReadKey();
        }
    }
}
