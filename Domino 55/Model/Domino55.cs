using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Model
{
    internal class Domino55
    {
        private static Domino55 instance = null;
        private static readonly object instanceLock = new object();
        public static Domino55 Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new Domino55();
                    }
                    return instance;
                }
            }
        }

        TurnoutStepper turnoutStepper = TurnoutStepper.Instance;
        List<Turnout> turnouts = new List<Turnout>();

        public Domino55()
        {
            turnouts.Add(new Turnout(2, 1));
            turnouts.Add(new Turnout(4, 2));
            turnouts.Add(new Turnout(1, 3));
            turnoutStepper.AddTurnouts(turnouts);
        }
        public void SetTurnout(int number, Turnout.Direction direction)
        {
            turnoutStepper.SetTurnout(number, direction);
        }
    }
}
