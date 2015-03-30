using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _023_SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var sh = new ServiceHost(typeof(Calculadora));

            sh.AddServiceEndpoint
            (
                typeof(ICalculadora),
                new NetTcpBinding(),
                "net.tcp://localhost:8080/calculadora"
            );

            sh.Open();

            Console.WriteLine("Servidor online\n\nPressione algo para fechar...");
            Console.ReadKey();

            sh.Close();
        }
    }

    [ServiceContract]
    public interface ICalculadora
    {
        [OperationContract]
        int Somar(int x, int y);

        [OperationContract]
        int Subtrair(int x, int y);
    }

    public class Calculadora : ICalculadora
    {

        public int Somar(int x, int y)
        {
            return x + y;
        }

        public int Subtrair(int x, int y)
        {
            return x - y;

        }
    }
}
