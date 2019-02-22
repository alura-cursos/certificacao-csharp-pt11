using System;
using System.Threading;
using System.Threading.Tasks;

namespace Program07._02
{
    //Lançando uma exceção quando a tarefa é cancelada
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tecle algo para parar o relógio");
            Task contagem = new Task(() => ContagemRegressiva());
            contagem.Start();
            Console.ReadKey();
            Console.WriteLine("A contagem foi completada.");
            Console.ReadLine();
        }

        static void ContagemRegressiva()
        {
            int contador = 7;
            while (contador > 0)
            {
                Console.WriteLine("contador: {0}", contador);
                Thread.Sleep(500);
                contador--;
            }
        }

    }
}