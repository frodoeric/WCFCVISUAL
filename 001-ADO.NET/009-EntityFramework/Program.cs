using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DBEntities();

            var pessoas = db.PessoaSet.Include("Filhos");

            foreach (var item in db.PessoaSet)
            {
                Console.WriteLine(item);

                var filhos = item.Filhos;

                foreach (var itemFilho in filhos)
                {
                    Console.WriteLine("\t{0}", itemFilho);

                }
            }

            Console.ReadKey();
        }
    }

    partial class Pessoa
    {
        public override string ToString()
        {
            return String.Format("{0} -> {1} recebe {2:c}", Id, Nome, Salario);
        }
    }

    partial class Filho
    {
        public override string ToString()
        {
            return String.Format("{0} -> {1} do sexo {2} é filho do {3}", Id, Nome, Sexo, Pessoa.Nome );
        }
    }
}
