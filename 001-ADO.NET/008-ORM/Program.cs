using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            //tipo genérico <>
            var pessoas = DBHelper.GetData<Pessoa>().Where(p => p.NomePessoa.Equals("agnaldo", StringComparison.CurrentCultureIgnoreCase));

            foreach (var item in pessoas)
            {
                Console.WriteLine(item);
            }

            var filhos = DBHelper.GetData<Filho>();

            foreach (var item in filhos)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }
    }

    [DB(Name = "FILHO")]
    class Filho
    {
        [DB(Name = "COD_FILHO")]
        [DBGenerated]
        public int CodFilho { get; set; }

        [DB(Name = "NOME_FILHO")]
        [DBRequired]
        public String NomeFilho { get; set; }

        [DB(Name = "SEXO_FILHO")]
        public String SexoFilho { get; set; }

        [DB(Name = "COD_PESSOA")]
        public int CodPessoa { get; set; }

        public override string ToString()
        {
            return String.Format("{0} -> {1} sexo {2}, filho do {3}", CodFilho, NomeFilho, SexoFilho, CodPessoa);
        }
    }


    class DBHelper
    {
        static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=DB;Integrated Security=true");
        }


        public static List<T> GetData<T>() where T : class, new() //onde T é uma classe e new
        {
            //Reflection

            var retorno = new List<T>();

            var cmd = GetSelectCommand<T>();

            using (var c = GetSqlConnection())
            {
                using (var k = new SqlCommand(cmd, c))
                {
                    c.Open();

                    var dr = k.ExecuteReader();

                    while (dr.Read())
                    {
                        var obj = new T();

                        var t = obj.GetType();

                        var properties = t.GetProperties();

                        foreach (var p in properties)
                        {
                            var attributes = p.GetCustomAttributes(typeof(DBAttribute), true);

                            if (attributes.Length != 0)
                            {
                                var nomeColuna = ((DBAttribute)attributes[0]).Name;

                                p.SetValue(obj, Convert.ChangeType(dr[nomeColuna], p.PropertyType));
                            }
                        }

                        retorno.Add(obj);
                        //for (int i = 0; i < dr.FieldCount; i++)
                        //{
                        //    Console.WriteLine(dr.GetName(i));
                        //}
                    }

                    c.Close();

                }

            }

            return retorno;
        }

        public static String GetSelectCommand<T>()
        {
            //StringBuilder para usar só um espaço na string
            var cmd = new StringBuilder("SELECT ");

            var properties = typeof(T).GetProperties();

            Object[] attributes = null;

            foreach (var p in properties)
            {
                attributes = p.GetCustomAttributes(typeof(DBAttribute), true);

                if (attributes.Length != 0)
                {
                    cmd.Append(((DBAttribute)attributes[0]).Name);
                    cmd.Append(", ");
                }
            }

            cmd.Append(" FROM ");


            //se o atributo for derivado vai ser true
            //se fosse falso pegaria somente se fosse da base (própria classe)
            attributes = typeof(T).GetCustomAttributes(typeof(DBAttribute), true);


            if (attributes.Length != 0)
            {
                cmd.Append(((DBAttribute)attributes[0]).Name);
            }

            return cmd.ToString().Replace(",  ", " ");
        }


    }

    #region classes de atributos

    [DB(Name = "PESSOA")]
    class Pessoa
    {
        [DB(Name = "COD_PESSOA")]
        [DBGenerated]
        public int CodPessoa { get; set; }

        [DB(Name = "NOME_PESSOA")]
        [DBRequired]
        public String NomePessoa { get; set; }

        [DB(Name = "SALARIO_PESSOA")]
        public Decimal SalarioPessoa { get; set; }

        public override string ToString()
        {
            return String.Format("{0} -> {1} recebe {2:c}", CodPessoa, NomePessoa, SalarioPessoa);
        }
    }

    class DBAttribute : Attribute
    {
        public String Name { get; set; }
    }

    class DBGeneratedAttribute : Attribute
    {
    }

    class DBRequiredAttribute : Attribute
    {
    }

    #endregion




    ////generic usa para saber qual é o tipo do conteúdo
    //struct Fracao<T> where T: struct //ex: contrant só para quando T for estrutura
    //{
    //    public T num;
    //    public T den;
    //}
}
