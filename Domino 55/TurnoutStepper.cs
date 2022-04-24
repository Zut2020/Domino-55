using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Domino_55
{
    internal class TurnoutStepper
    {
        private struct TurnoutAction
        {
            public Turnout turnout;
            public Turnout.Direction direction;

            public TurnoutAction(Turnout turnout, Turnout.Direction direction)
            {
                this.turnout = turnout;
                this.direction = direction;
            }
        }

        private static TurnoutStepper instance = null;
        private static readonly object instanceLock = new object();
        Queue<TurnoutAction> queue = new Queue<TurnoutAction>();
        public static TurnoutStepper Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TurnoutStepper();
                    }
                    return instance;
                }
            }
        }
        private List<Turnout> turnouts = new List<Turnout>();

        public void AddTurnout(Turnout turnout)
        {
            turnouts.Add(turnout);
        }

        public void SetTurnout(int number, Turnout.Direction direction)
        {
            Turnout turnout = turnouts.Find(x => x.number == number);
            TurnoutAction turnoutAction = new TurnoutAction(turnout, direction);
            if (turnout != null)
            {
                if (queue.Count > 0)
                    queue.Enqueue(turnoutAction);
                else
                {
                    queue.Enqueue(turnoutAction);
                    Work();
                }
            }
        }

        private async void Work()
        {
            while(queue.Count > 0)
            {
                TurnoutAction turnoutAction = queue.Peek();
                await Task.Run(() => turnoutAction.turnout.allit(turnoutAction.direction));
                queue.Dequeue();
            }
        }
    }
}
