using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Program05_01
{
    //Gerenciar dados usando coleções simultâneas
    class Program
    {
        static void Main()
        {
            int NUMERO_ITENS = 30;

            Dictionary<int, int> dicionario =
                new Dictionary<int, int>();

            Console.WriteLine("Inicializando dicionário...");
            for (int i = 0; i < NUMERO_ITENS; i++)
            {
                dicionario[i] = 0;
            }
            ImprimirItens(dicionario);

            Console.WriteLine("Incrementando valores...");

            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < NUMERO_ITENS; i++)
                {
                    dicionario[i]++;
                    Thread.Sleep(i);
                }
            });
            thread1.Start();




            thread1.Join();

            ImprimirItens(dicionario);

            Console.WriteLine("Tecle [ENTER] para continuar");
            Console.ReadLine();
        }

        private static void ImprimirItens(IDictionary<int, int> cd)
        {
            for (int i = 0; i < cd.Count; i++)
            {
                Console.WriteLine("dicionario[{0}] = {1}", i, cd[i]);
            }
        }
    }
}
