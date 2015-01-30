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
        public bool Sleep { get; private set; }
        public int Street { get; private set; }
        public DateTime Birthday { get; private set; }

        public string Name { get; private set; }

        /*events and delegates*/

        public delegate void TamagotchiChange(object sender, TamagochiEventArgs args);
        public delegate void TamagotchiFeed(object sender, TamagochiFeedEventArgs args);
        public delegate void TamagotchiSleep(object sender, TamagochiSleepEventArgs args);
        public delegate void TamagotchiWalk(object sender, TamagochiGoWalkEventArgs args);
        public delegate void TamagotchiAskAge(object sender, TamagochiAskAgeEventArgs args);

        public event TamagotchiChange Change;
        public event TamagotchiFeed OnFeed;
        public event TamagotchiSleep OnSleep;
        public event TamagotchiWalk OnWalk;
        public event TamagotchiAskAge OnAskAge;

        public Tamagotchi(string name)
        {
            _rand = new Random();
            Name = name;
            Birthday = DateTime.Now;
        }

        public void DoSomething()
        {
            var type = (ActionType) _rand.Next(1, 5);
            switch (type)
            {
                case ActionType.Sleep: GoBed(); break;
                case ActionType.GoWalk: GoWalk(new Random().Next(1, 10)); break;
                case ActionType.Food: AskFood(); break;
                case ActionType.AskAge: Grow(); break;
            }
        }

        private void FireOnChange(string message, ActionType action)
        {
            if (Change != null)
                Change(this, new TamagochiEventArgs() {Message = string.Format(message), Action = action});
        }

        public void AskFood()
        {
            Food = _rand.Next(1, 10);
            FireOnChange("Food points is changed", ActionType.Food);
            if (OnFeed != null)
                OnFeed(this,
                    new TamagochiFeedEventArgs()
                    {
                        FoodPoint = Food,
                        Message = string.Format("I'm hungry for {0} points", Food)
                    });
        }

        public void GoBed()
        {
            Sleep = _rand.Next(1, 3) == 1;
            FireOnChange(Sleep ? "Go to sleep" : "Still active", ActionType.Sleep);
            if (OnSleep != null)
                OnSleep(this, new TamagochiSleepEventArgs()
                {
                    Sleep = Sleep, Message = Sleep ? "Go to sleep" : "I'm not want to sleep"
                });
        }

        public void GoWalk(int street)
        {
            Street = street;
            FireOnChange("Going walk", ActionType.GoWalk);
            if (OnWalk != null)
                OnWalk(this, new TamagochiGoWalkEventArgs()
                {
                    Message = string.Format("Going walk to {0} street", Street), Street = this.Street
                });
        }

        public void Grow()
        {
            var lifeTime = DateTime.Now - Birthday;
            FireOnChange("I grew up", ActionType.AskAge);
            if (OnAskAge != null)
                OnAskAge(this, new TamagochiAskAgeEventArgs()
                {
                    Message = string.Format("I live for {0} minutes and {1} seconds", lifeTime.Minutes, lifeTime.Seconds),
                    Age = lifeTime
                });
        }
    }
}
