using System;
using System.Diagnostics;
using System.Threading;

namespace CASequential
{
    public class Program
    {
        static void Main(string[] args)
        {
            var wallet = new Wallet("Aya", 100000);
            wallet.RandomTransactions();
            Console.WriteLine("-----------------");
            Console.WriteLine($"{wallet}\n");

            wallet.RandomTransactions();
            Console.WriteLine("-----------------");
            Console.WriteLine($"{wallet}\n");

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
            BitCoins -= amount;
        }
        public void Credit(int amount)
        {
            BitCoins += amount;
        }
        public void RandomTransactions()
        {
            int[] amounts = { 10, 20, 30, -10, -20, -30 , 100};
            foreach (int amount in amounts)
            {
                int absVal = Math.Abs(amount);
                if(amount < 0)
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
