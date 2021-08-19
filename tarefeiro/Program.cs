using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarefeiro
{
    class Program
    {
        static void Main(string[] comandos)
        {
            if (comandos[0].ToUpper().Equals("NOVA"))
            {
                tarefa tarefaCriada = criarTarefa(comandos.ToArray());
            }

            if (comandos[0].ToUpper().Equals("VER"))
            {
                lerTarefa();
            }

        }

        public class tarefa
        {
            public string dataCriacao { get; set; }
            public string dataFinalizacao { get; set; }
            public string descricao { get; set; }
            public string prioridade { get; set; }
            public string previsaoEntrega { get; set; }

        }

        public static tarefa criarTarefa(string[] comandos)
        {
            tarefa novaTarefa = new tarefa
            {
                descricao = comandos[1],
                previsaoEntrega = comandos[2],
                prioridade = comandos[3]
            };

            registrarTarefa(novaTarefa);

            return novaTarefa;
        }

        public static void lerTarefa()
        {
            string line;

            try
            {
                StreamReader leitor = new StreamReader(@"./tarefas.txt");

                line = leitor.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = leitor.ReadLine();
                }

                leitor.Close();
                Console.ReadLine();
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static void modificarTarefa()
        {

        }

        public static void removerTarefa()
        {

        }

        public static void registrarTarefa(tarefa tarefa)
        {
            StreamWriter escritor = new StreamWriter(@"./tarefas.txt", append: true);
            escritor.WriteLine(tarefa.descricao + " " + tarefa.previsaoEntrega);
            escritor.Close();
        }
    }
}
