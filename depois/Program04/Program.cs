using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Program04
{
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

        static async Task Main(string[] args)
        {
            //TAREFA 1: Executar o código
            //TAREFA 2: Testar com nome de arquivo inexistente
            //TAREFA 3: Ler o conteúdo do arquivo de forma ASSÍNCRONA
            //TAREFA 4: Testar novamente com nome de arquivo inexistente

            try
            {
                await Executar("filmes123.json");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            Console.ReadLine();
        }

        private static async Task Executar(string nomeArquivo)
        {
            string json = await LerArquivoJson(nomeArquivo);
            IEnumerable<Filme> filmes =
                JsonConvert.DeserializeObject<IEnumerable<Filme>>(json);
            GeraRelatorio(filmes);
        }

        private static async Task<string> LerArquivoJson(string nomeArquivo)
        {
            return await File.ReadAllTextAsync(nomeArquivo);
        }

        private static void GeraRelatorio(IEnumerable<Filme> filmes)
        {
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

            foreach (var item in filmes)
            {
                Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    item.Titulo,
                    item.Faturamento,
                    item.Orcamento,
                    item.Lucro,
                    item.LucroPorcentagem);
            }
            Console.WriteLine();
        }

    }
}
