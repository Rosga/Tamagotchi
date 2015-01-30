using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tamagochi
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new Tamagotchi(ConsoleColor.Yellow);
            var second = new Tamagotchi(ConsoleColor.Green);
            first.Change += OnChange;
            second.Change += OnChange;
            var rand = new Random();

            for (int i = 0; i < 20; i++)
            {
                first.DoSomething(rand.Next(1, 4));
                Thread.Sleep(500);
                second.DoSomething(rand.Next(1, 4));
                Thread.Sleep(500);
            }
            Console.ReadLine();
        }

        private static void OnChange(object sender, TamagochiEventArgs args)
        {
            var tamagotchi = sender as Tamagotchi;
            if (tamagotchi != null)
            {
                Console.ForegroundColor = tamagotchi.ConsoleColor;
                Console.WriteLine(args.Message);
                Console.ResetColor();
            }
        }
    }
}
