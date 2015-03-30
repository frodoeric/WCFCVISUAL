using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_WCFClient_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assincrono (não terá ordem)
            using (var p = new ProxySomadora.ISomadoraClient())
            {
                Console.WriteLine("antes");

                Somar(p);

                Console.WriteLine("depois");
            }

            Console.ReadKey();
        }

        private async static void Somar(ProxySomadora.ISomadoraClient p)
        {
            Console.WriteLine(await p.SomarAsync(10, 3));
        }
    }
}
