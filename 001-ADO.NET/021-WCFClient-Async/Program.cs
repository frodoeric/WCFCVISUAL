using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_WCFClient_Async
{
    class Program
    {
        static ProxySomadora.ISomadoraClient p = new ProxySomadora.ISomadoraClient();

        static void Main(string[] args)
        {
            Console.WriteLine("antes");

            p.BeginSomar(10, 3, SomarCompleted, new String[] { "abc", "xyz" });// new String[]{"abc", "xyz"}
            p.BeginSomar(100, 30, iar => { Console.WriteLine(p.EndSomar(iar)); }, null);

            Console.WriteLine("depois");

            Console.ReadKey();
        }

        static void SomarCompleted(IAsyncResult iar)
        {
            var strings = (String[])iar.AsyncState;

            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(p.EndSomar(iar));
        }
    }
}