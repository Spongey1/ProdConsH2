using System;
using System.Threading;

namespace ProdConsH2
{
    public class Work
    {
        static byte[] buffer = new byte[3];
        static bool sleepProd = false;
        static bool sleepCons = false;
        Random rnd = new Random();

        public void ThreadWork()
        {
            Thread p1 = new Thread(Producer);
            Thread c1 = new Thread(Consumer);

            p1.Start();
            c1.Start();

            p1.Name = "Producer";
            c1.Name = "Consumer";

            p1.Join();
            c1.Join();
        }

        public void Producer()
        {
            while (true)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] == 0)
                    {
                        buffer[i] = 1;
                        sleepCons = false;
                        Console.WriteLine("Producer | Add");
                    }
                    else
                    {
                        Console.WriteLine("Producer | failed");
                    }
                }
                if (rnd.Next(0, 3) == 0)
                {
                    Thread.Sleep(100 / 15);
                }
            }
        }
        public void Consumer()
        {
            while (true)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] == 1)
                    {
                        buffer[i] = 0;
                        Console.WriteLine("Consumer | Take");
                    }
                    else
                    {
                        Console.WriteLine("Consumer | failed");
                    }
                }
                if (rnd.Next(0, 3) == 0)
                {
                    Thread.Sleep(100 / 15);
                }
            }
        }
        public void Sleep(string name)
        {
            Console.WriteLine("{0} is sleeping", name);
            Thread.Sleep(rnd.Next(100, 1000));
        }
    }
}