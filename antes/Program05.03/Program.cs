using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Program05._03
{
    // Este exemplo constrói uma Pilha Concorrente (ConcurrentStack).
    class Program
    {
        static async Task Main()
        {
            int itens = 10000;
            ConcurrentStack<int> pilha = new ConcurrentStack<int>();

            // Cria uma ação para empilhar itens
            Action empilhador = () =>
            {
                for (int i = 0; i < itens; i++)
                {
                    pilha.Push(i);
                }
            };

            // Executa a pilha uma vez
            empilhador();

            if (pilha.TryPeek(out int result))
            {
                Console.WriteLine($"TryPeek() retornou {result} no topo da filha.");
            }
            else
            {
                Console.WriteLine("Não foi possível obter o item adicionado por último.");
            }

            // Esvazia a pilha
            pilha.Clear();

            if (pilha.IsEmpty)
            {
                Console.WriteLine("A pilha foi esvaziada.");
            }

            // Cria uma ação para empilhar e desempilhar itens
            Action adiona_e_remove = () =>
            {
                Console.WriteLine($"Tarefa começou no item: {Task.CurrentId}");

                int item;
                for (int i = 0; i < itens; i++)
                    pilha.Push(i);
                for (int i = 0; i < itens; i++)
                    pilha.TryPop(out item);

                Console.WriteLine($"Tarefa terminou no item: {Task.CurrentId}");
            };

            // escala 4 tarefas simultâneas da action
            var tarefas = new Task[5];
            for (int i = 0; i < tarefas.Length; i++)
                tarefas[i] = Task.Factory.StartNew(adiona_e_remove);

            // Aguarda o término de todas as tarefas
            await Task.WhenAll(tarefas);

            if (!pilha.IsEmpty)
            {
                Console.WriteLine("Não removeu todos os itens da pilha.");
            }

            Console.ReadLine();
        }
    }
}
