using System;
using System.Threading;

namespace Program08
{
    //Implementar métodos thread-safe
    class Program
    {
        static void Main(string[] args)
        {
            var contador = new Contador();

            Console.WriteLine("contador: {0}", contador.Numero);

            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    contador.Incrementar();
                    Thread.Sleep(i);
                }
            });
            thread1.Start();
            //thread1.Join();

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    contador.Incrementar();
                    Thread.Sleep(i);
                }
            });
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("contador: {0}", contador.Numero);

            Console.ReadLine();
        }

        static object ContadorObject = new object();
        class Contador
        {
            public int Numero { get; private set; } = 0;

            public void Incrementar()
            {
                lock(ContadorObject)
                {
                    Numero++;
                }
            }
        }
    }
}
