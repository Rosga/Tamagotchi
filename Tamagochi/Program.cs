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

            for (int i = 0; i < 20; i++)
            {
                foreach (var tamagotchy in tamagotchies)
                {
                    DoSomething((ActionType)rand.Next(1,5), tamagotchy);
                    Thread.Sleep(1000);
                }
            }
            Console.ReadLine();
        }

        private static void DoSomething(ActionType type, Tamagotchi tamagotchi)
        {
            switch (type)
            {
                    case ActionType.Sleep: tamagotchi.GoBed(); break;
                    case ActionType.GoWalk: tamagotchi.GoWalk(new Random().Next(1, 10)); break;
                    case ActionType.Food: tamagotchi.AskFood(); break;
                    case ActionType.AskAge: tamagotchi.Grow();break;
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
