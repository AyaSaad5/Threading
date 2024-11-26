using System;
using System.Threading;

namespace CARaceCondition
{
    public class Program
    {
        static void Main(string[] args)
        {
            var wallet = new Wallet("Aya", 1000);
            Console.ReadKey();

            Console.WriteLine("Hello World!");
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
            if(BitCoins >= amount)
            {
                Thread.Sleep(1000);
                BitCoins -= amount;
            }
        }
        public void Credit(int amount)
        {
            Thread.Sleep(1000);
            BitCoins += amount;
        }
        public override string ToString()
        {
            return $"[{Name} -> {BitCoins} BitCoins]";
        }
    }

}
