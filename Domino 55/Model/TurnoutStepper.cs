using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Domino_55.Model
{
    internal class TurnoutStepper
    {
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

        public void AddTurnouts(List<Turnout> addedturnouts)
        {
            turnouts.AddRange(addedturnouts);
        }


        public void SetTurnout(int number, Turnout.Direction direction)
        {
            Turnout turnout = turnouts.Find(x => x.number == number);
            TurnoutAction turnoutAction = new TurnoutAction(turnout, direction);
            if (turnout != null)
            {
                turnoutAction.turnout.controller.AntimateBlinkStart();
                if (queue.Count > 0)
                {
                    queue.Enqueue(turnoutAction);
                }
                else
                {
                    queue.Enqueue(turnoutAction);
                    Work();
                }
            }
        }

        public void SetTurnoutAndLock(Turnout turnout, Turnout.Direction direction)
        {
            SetTurnout(turnout.number, direction);
            turnout.Lock();
        }

        private void Work()
        {
            while (queue.Count > 0)
            {
                TurnoutAction turnoutAction = queue.Peek();
                turnoutAction.turnout.controller.AnimateBlinkStop();
                turnoutAction.turnout.Set(turnoutAction.direction);
                queue.Dequeue();
            }

        }
    }
}
