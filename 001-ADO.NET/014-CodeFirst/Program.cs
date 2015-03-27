using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;

namespace _014_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DBContext();

            foreach (var item in db.Pessoas)
            {
                Console.WriteLine(item.Nome);
            }

            Console.ReadKey();
        }
    }

    public class Pessoa //PESSOA
    {
        public int Id { get; set; } //COD_PESSOA
        public String Nome { get; set; } //NOME_PESSOA
        public decimal? Salario { get; set; } //SALARIO_PESSOA

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}",Id ,Nome ,Salario);
        }
    }

    public class PessoaMapping : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMapping()
        {

            //constraints

            this.HasKey(t => t.Id);

            this.Property(t => t.Nome).HasMaxLength(50);

            //mappings

            this.ToTable("PESSOA");

            this.Property(t => t.Id).HasColumnName("COD_PESSOA");

            this.Property(t => t.Nome).HasColumnName("NOME_PESSOA");

            this.Property(t => t.Salario).HasColumnName("SALARIO_PESSOA");

        }



    }

    public class DBContext : DbContext
    {
        static DBContext()
        {
            Database.SetInitializer<DBContext>(null);//usa o banco que já existe

            //Database.SetInitializer<DBContext>(new CreateDatabaseIfNotExists<DBContext>()); //cria se não existir
            //Database.SetInitializer<DBContext>(new DropCreateDatabaseAlways<DBContext>()); //sempre cria o banco independente se exista
            //Database.SetInitializer<DBContext>(new DropCreateDatabaseIfModelChanges<DBContext>()); //se existir dropa e cria, ou cria se não existe

        }

        public DBContext() : base(@"Data Source=.\sqlexpress;Initial Catalog=DB;Integrated Security=true;")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PessoaMapping());
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
