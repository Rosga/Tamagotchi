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
            var tamagotchies = new List<Tamagotchi>()
            {
                new Tamagotchi("First"),
                new Tamagotchi("Second"),
            };
            foreach (var tamagotchy in tamagotchies)
            {
                tamagotchy.Change += OnChange;
                if (tamagotchy.Name == "First")
                    tamagotchy.OnWalk += OnChange;
                else
                    tamagotchy.OnAskAge += OnChange;
            }
            var rand = new Random();

            while (true)
            {
                foreach (var tamagotchy in tamagotchies)
                {
                    tamagotchy.DoSomething();
                    Thread.Sleep(1000);
                }
            }
             
        }

        private static void OnChange(object sender, TamagochiEventArgs args)
        {
            var tamagotchi = sender as Tamagotchi;
            if (tamagotchi != null)
            {
                ChangeConsoleColor(tamagotchi.Name);
                DisplayEventMessage(args.Message);
            }
        }

        private static void ChangeConsoleColor(string name)
        {
            switch (name)
            {
                case "First":
                    Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "Second":
                    Console.ForegroundColor = ConsoleColor.Green; break;
                default: Console.ResetColor(); break;
            }
        }

        private static void DisplayEventMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
