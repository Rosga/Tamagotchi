using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
    public class Tamagotchi
    {
        private Random _rand;
        public int Food { get; private set; }
        public int Sleep { get; private set; }
        public int Street { get; private set; }
        public int Years { get; private set; }
        public ConsoleColor ConsoleColor { get; private set; }

        /*events and delegates*/

        public delegate void TamagotchiChange(object sender, TamagochiEventArgs args);

        public event TamagotchiChange Change;

        public Tamagotchi(ConsoleColor color)
        {
            _rand = new Random();
            this.ConsoleColor = color;
        }

        public void DoSomething(int method)
        {
            switch (method)
            {
                case 1:
                    Eat();break;
                case 2:
                    GoBed();break;
                case 3:
                    GoWalk();break;
                case 4:
                    Grow();break;
                default: return;
            }
        }

        public void Eat()
        {
            Food = _rand.Next(1, 10);
            if (Change != null)
                Change(this, new TamagochiEventArgs() {Message = string.Format("I have eat {0} points of food", Food)});
        }

        public void GoBed()
        {
            Sleep = _rand.Next(1, 10);
            if (Change != null)
                Change(this, new TamagochiEventArgs() {Message = string.Format("I have slept {0} hours", Sleep)});
        }

        public void GoWalk()
        {
            Street = _rand.Next(1, 10);
            if (Change != null)
                Change(this, new TamagochiEventArgs() {Message = string.Format("I go to the {0} street", Food)});
        }

        public void Grow()
        {
            Years = _rand.Next(1, 10);
            if (Change != null)
                Change(this, new TamagochiEventArgs() {Message = string.Format("I'm {0} years old", Years)});
        }
    }
}
