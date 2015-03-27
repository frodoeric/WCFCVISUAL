using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _017_WindowsService
{
    partial class Monitor : ServiceBase
    {
        Timer timer = new Timer();

        public Monitor()
        {
            InitializeComponent();

            timer.Interval = 15000;//a cada 1,5mls roda a tarefa se startado

            timer.Elapsed += timer_Elapsed; //tempo q vai passando

            
        }



        protected override void OnStart(string[] args)
        {
            Logar("Start");
            timer.Start();
        }

        protected override void OnStop()
        {
            Logar("Stop");
            timer.Stop();
        }

        protected override void OnContinue()
        {
            Logar("Continue");
            base.OnContinue();
            timer.Start();
        }

        protected override void OnPause()
        {
            Logar("Pause");
            base.OnPause();
            timer.Stop();
        }

        private void Logar(string s)
        {
            using (var arquivo = new StreamWriter(@"C:\50minutos\log.txt", true, Encoding.UTF8))
            {
                arquivo.WriteLine("{0} -> {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), s);

                arquivo.Close();
            }
        }

        private void Logar(int qtd)
        {
            Logar(qtd.ToString());
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {


            try
            {
                var cs = @"Data Source=.\sqlexpress;Integrated Security=true;Initial Catalog=DB;";

                int qtd = -1;

                using (var c = new SqlConnection(cs))
                {
                    var cmd = "SELECT COUNT(*) AS 'QTD' FROM PESSOA";

                    using (var k = new SqlCommand(cmd, c))
                    {
                        c.Open();
                        qtd = (int)k.ExecuteScalar();
                        c.Close();
                    }
                }

                Logar(qtd);
            }
            catch (Exception ex)
            {

                Logar(ex.ToString());
            }
        }


    }
}
