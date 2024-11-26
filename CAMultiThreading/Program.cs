using System;
using System.Threading;

namespace CAMultiThreading
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine(Thread.CurrentThread.Name);

            var wallet = new Wallet("Aya", 1000);

            Thread t1 = new Thread(wallet.RandomTransactions);
            t1.Name = "T1";

            Console.WriteLine($"T1 ia Background Thread {t1.IsBackground}");
            Console.WriteLine($"after declaration T1 state {t1.ThreadState}");
            t1.Start();
            t1.Join();

            Console.WriteLine($"after start T1 state {t1.ThreadState}");

            Thread t2 = new Thread(new ThreadStart(wallet.RandomTransactions));
            t2.Name = "T2";
            Console.WriteLine($"after declaration T2 state {t2.ThreadState}");

            t2.Start();
            Console.WriteLine($"after start T2 state {t2.ThreadState}");

            Console.ReadKey();
        }
    }
    public class Wallet
    {
        public Wallet(string name, int bitCoins)
        {
            Name = name;
            BitCoins = bitCoins;
        }

        public string Name { get; set; }
        public int BitCoins { get; set; }

        public void Debit(int amount)
        {
            Thread.Sleep(1000);
            BitCoins -= amount;
            Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name} Processor Id: {Thread.GetCurrentProcessorId()}, -{amount}");

        }
        public void Credit(int amount)
        {
            Thread.Sleep(1000);
            BitCoins += amount;
            Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name} Processor Id: {Thread.GetCurrentProcessorId()}, +{amount}");

        }
        public void RandomTransactions()
        {
            int[] amounts = { 10, 20, 30, -10, -20, -30, 100 };
            foreach (int amount in amounts)
            {
                int absVal = Math.Abs(amount);
                if (amount < 0)
                    Debit(absVal);
                else
                    Credit(absVal);
                Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId} Processor Id: {Thread.GetCurrentProcessorId()}, {amount}");
            }
        }
        public override string ToString()
        {
            return $"[{Name} -> {BitCoins} BitCoins]";
        }
    }

}
