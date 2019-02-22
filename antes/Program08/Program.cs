using System;
using System.Threading;
using System.Threading.Tasks;

namespace Program07_01
{
    //Cancelar uma tarefa de execução longa
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tecle algo para parar o relógio");
            Task relogio = Task.Run(() => Relogio());
            Console.ReadKey();
            Console.WriteLine("O relógio parou.");
            Console.ReadLine();
        }

        static void Relogio()
        {
            while (true)
            {
                Console.WriteLine("Tic");
                Thread.Sleep(500);
                Console.WriteLine("Tac");
                Thread.Sleep(500);
            }
        }

    }
}
