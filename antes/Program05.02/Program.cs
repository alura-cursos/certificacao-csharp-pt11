using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Program05._02
{
    // Este exemplo constrói uma Fila Concorrente (ConcurrentQueue).
    class Program
    {
        static void Main()
        {
            ConcurrentQueue<int> fila = new ConcurrentQueue<int>();

            // Popula a fila.
            for (int i = 0; i < 30000; i++)
            {
                //Enfileira um valor
                fila.Enqueue(i);
            }

            // TryPeek: tenta consultar o primeiro elemento.
            int resultado;
            if (!fila.TryPeek(out resultado))
            {
                Console.WriteLine("CQ: TryPeek falhou!");
            }
            else if (resultado != 0)
            {
                Console.WriteLine("CQ: TryPeek deveria retornar 0, mas retornou {0}", resultado);
            }

            int somaGeral = 0;
            // Uma ação para ler a ConcurrentQueue.
            Action action = () =>
            {
                int somaLocal = 0;
                int valorLocal;
                while (fila.TryDequeue(out valorLocal)) somaLocal += valorLocal;
                Interlocked.Add(ref somaGeral, somaLocal);
            };

            // Inicia 4 actions simultâneas.
            Parallel.Invoke(action, action, action, action);

            Console.WriteLine("somaGeral:\t{0}" +
                "\ndeveria ser:\t449985000", somaGeral);
            Console.ReadLine();

        }
    }
}
