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

            ConcurrentDictionary<int, int> dicionario =
                new ConcurrentDictionary<int, int>();

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
                    int valor;
                    do
                    {
                        valor = dicionario[i];
                    } while (!dicionario.TryUpdate(i, valor + 1, valor));
                    Thread.Sleep(i);
                }
            });
            thread1.Start();

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < NUMERO_ITENS; i++)
                {
                    int valor;
                    do
                    {
                        valor = dicionario[i];
                    } while (!dicionario.TryUpdate(i, valor + 1, valor));
                    Thread.Sleep(i);
                }
            });
            thread2.Start();


            thread1.Join();
            thread2.Join();

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
