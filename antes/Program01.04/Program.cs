using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace Program01
{
    //PLINQ = Parallel LINQ
    class Program
    {
        public class Filme
        {
            public string Titulo { get; set; }
            public decimal Faturamento { get; set; }
            public decimal Orcamento { get; set; }
            public string Distribuidor { get; set; }
            public string Genero { get; set; }
            public string Diretor { get; set; }
            public decimal Lucro { get; set; }
            public decimal LucroPorcentagem { get; set; }

            public int CompareTo(object obj)
            {
                Filme outro = obj as Filme;
                return Titulo.CompareTo(outro.Titulo);
            }
        }

        static void Main(string[] args)
        {

            IEnumerable<Filme> filmes =
                JsonConvert.DeserializeObject<IEnumerable<Filme>>
                (File.ReadAllText("filmes.json"));

            var consulta =
                from f in filmes
                select new Filme
                {
                    Titulo = f.Titulo,
                    Faturamento = f.Faturamento,
                    Orcamento = f.Orcamento,
                    Distribuidor = f.Distribuidor,
                    Genero = f.Genero,
                    Diretor = f.Diretor,
                    Lucro = f.Faturamento - f.Orcamento,
                    LucroPorcentagem = (f.Faturamento - f.Orcamento) / f.Orcamento
                };

            filmes = consulta;

            //Tarefa 1: obter a lista de filmes de Aventura 

            //Tarefa 2: obter a lista de filmes de Aventura, executando em PARALELO

            //Tarefa 3: obter a lista de filmes de Aventura, executando em PARALELO com modo de execução default

            //Tarefa 4: obter a lista de filmes de Aventura, executando em PARALELO forçando paralelismo

            //Tarefa 5: obter a lista de filmes de Aventura, executando em PARALELO forçando paralelismo e com grau de paralelismo = 4

            //Tarefa 6: obter a lista de filmes de Aventura, executando em PARALELO e preservando a ordem

            //Tarefa 7: obter os 4 filmes de Aventura de maior faturamento, executando em PARALELO

            //Tarefa 8: Imprimir somente os títulos dos filmes, de aventura, consultando em PARALELO e usando uma ação em PARALELO

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        private static void GeraRelatorio(string tituloRelatorio, IEnumerable<Filme> resultado)
        {
            Console.WriteLine("Relatório: {0}", tituloRelatorio);

            Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    "Item",
                    "Faturamento",
                    "Orcamento",
                    "Lucro",
                    "% Lucro");
            Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    new string('=', 30),
                    new string('=', 20),
                    new string('=', 20),
                    new string('=', 20),
                    new string('=', 10));

            foreach (var item in resultado)
            {
                Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    item.Titulo,
                    item.Faturamento,
                    item.Orcamento,
                    item.Lucro,
                    item.LucroPorcentagem);
            }
            Console.WriteLine();
            Console.WriteLine("FIM DO RELATÓRIO: {0}", tituloRelatorio);
        }
    }
}

