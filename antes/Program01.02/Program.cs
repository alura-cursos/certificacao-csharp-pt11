using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._02
{
    class Program
    {
        static void Main(string[] args)
        {
            //MUITAS TAREFAS EM PARALELO, COM PARÂMETRO
            //=========================================
            //Tarefa 1: processar 100 itens em série
            //Tarefa 2: processar 100 itens em paralelo - percorrendo uma faixa
            //Tarefa 3: processar 100 itens em paralelo - percorrendo uma coleção

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void Processar(object item)
        {
            Console.WriteLine("Começando a trabalhar com: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Terminando a trabalhar com: " + item);
        }
    }
}
