using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
    public enum ActionType
    {
        Food = 1,
        Sleep = 2,
        GoWalk = 3,
        AskAge = 4,
    }
    public class TamagochiEventArgs : EventArgs
    {
        public string Message { get; set; }
        public virtual ActionType Action { get; set; }
    }

    public class TamagochiFeedEventArgs : TamagochiEventArgs
    {
        public override ActionType Action { get { return ActionType.Food; } }

        public int FoodPoint { get; set; }
    }
    public class TamagochiSleepEventArgs : TamagochiEventArgs
    {
        public override ActionType Action { get { return ActionType.Sleep; } }
        public bool Sleep { get; set; }
    }

    public class TamagochiGoWalkEventArgs : TamagochiEventArgs
    {
        public override ActionType Action { get { return ActionType.GoWalk; } }
        public int Street { get; set; }
    }

    public class TamagochiAskAgeEventArgs : TamagochiEventArgs
    {
        public override ActionType Action { get { return ActionType.AskAge; } }
        public TimeSpan Age { get; set; }
    }
}
