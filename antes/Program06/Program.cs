using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Program06
{
    class Program
    {
        static long somaGeral;
        static object somaGeralObject = new object();
        static int[] items = Enumerable.Range(0, 100001).ToArray();

        static void AdicionaFaixaDeValores(int inicial, int final)
        {
            long subtotal = 0;

            while (inicial < final)
            {
                subtotal = subtotal + items[inicial];
                inicial++;
            }

            //lock (somaGeralObject)
            //{
            //    somaGeral = somaGeral + subtotal;
            //}

            Monitor.Enter(somaGeralObject);
            try
            {
                somaGeral = somaGeral + subtotal;
            }
            finally
            {
                Monitor.Exit(somaGeralObject);
            }

        }

        static void Main(string[] args)
        {
            while (true)
            {
                Executar();
                Thread.Sleep(1000);
            }
        }

        static void Executar()
        {
            somaGeral = 0;
            List<Task> tarefas = new List<Task>();
            int tamanhoFaixa = 1000;
            int inicioFaixa = 0;

            while (inicioFaixa < items.Length)
            {
                int fimFaixa = inicioFaixa + tamanhoFaixa;
                if (fimFaixa > items.Length)
                    fimFaixa = items.Length;

                // cria uma cópia local dos parâmetros
                int i = inicioFaixa;
                int f = fimFaixa;
                tarefas.Add(Task.Run(() => AdicionaFaixaDeValores(i, f)));
                inicioFaixa = fimFaixa;
            }
            Task.WaitAll(tarefas.ToArray());
            Console.WriteLine("A soma geral é: {0}", somaGeral);
        }
    }
}
