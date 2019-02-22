using System;
using System.Threading;

namespace Program02
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "A thread principal";
            ExibirThread(Thread.CurrentThread);

            //1. Task X Thread

            Thread thread1 = new Thread(Executar);
            thread1.Name = "1. Task X Thread";
            thread1.Start();
            thread1.Join();

            //2. Thread com expressão lambda

            Thread thread2 = new Thread(() => Executar());
            thread2.Name = "2. Thread com expressão lambda";
            thread2.Start();
            thread2.Join();
            //3. Passando parâmetro para thread

            ParameterizedThreadStart ps =
                new ParameterizedThreadStart((p) => 
                ExecutarComParametro(p));

            Thread thread3 = new Thread(ps);
            thread3.Name = "3. Passando parâmetro para thread";
            thread3.Start(123);
            thread3.Join();
            //4. Interrompendo um relógio

            bool relogioFuncionando = true;
            Thread thread4 = new Thread(() => 
            {
                ExibirThread(Thread.CurrentThread);
                while (relogioFuncionando)
                {
                    Console.WriteLine("tic");
                    Thread.Sleep(1000);
                    Console.WriteLine("tac");
                    Thread.Sleep(1000);
                }
            });
            thread4.Name = "4. Interrompendo um relógio";
            thread4.Start();
            
            Console.WriteLine("Tecle algo para interromper.");
            Console.ReadKey();
            relogioFuncionando = false;
            thread4.Join();

            //5. Sincronizando uma thread

            //6. Dados da Thread: Nome, cultura, prioridade, contexto, background, pool

            //7. Usando Thread Pool

            for (int i = 0; i < 50; i++)
            {
                int estadoDoItem = i;
                ThreadPool.QueueUserWorkItem((estado) 
                    => ExecutarComParametro(estadoDoItem));
            }

            Console.ReadLine();
        }

        static void Executar()
        {
            ExibirThread(Thread.CurrentThread);
            Console.WriteLine("Início da execução");
            Thread.Sleep(1000);
            Console.WriteLine("Fim da execução");
        }


        static void ExecutarComParametro(object param)
        {
            ExibirThread(Thread.CurrentThread);
            Console.WriteLine("Início da execução: {0}", param);
            Thread.Sleep(1000);
            Console.WriteLine("Fim da execução: {0}", param);
        }

        static void ExibirThread(Thread t)
        {
            //Dados da Thread: Nome, cultura, prioridade, contexto, background, pool
            Console.WriteLine();
            Console.WriteLine("Nome: {0}", t.Name);
            Console.WriteLine("Cultura: {0}", t.CurrentCulture);
            Console.WriteLine("Prioridade: {0}", t.Priority);
            Console.WriteLine("Contexto: {0}", t.ExecutionContext);
            Console.WriteLine("Está em background? {0}", t.IsBackground);
            Console.WriteLine("Está no pool de threads? {0}", t.IsThreadPoolThread);
            Console.WriteLine();
        }
    }
}
