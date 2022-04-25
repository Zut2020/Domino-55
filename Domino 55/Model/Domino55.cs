using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Model
{
    internal class Domino55
    {
        TurnoutStepper turnoutStepper = TurnoutStepper.Instance;
        List<Turnout> turnouts = new List<Turnout>();

        public Domino55(TurnoutStepper turnoutStepper)
        {
            turnouts.Add(new Turnout(2, 1));
            turnouts.Add(new Turnout(4, 2));
            turnouts.Add(new Turnout(1, 3));
        }
        public void SetTurnout(int number, Turnout.Direction direction)
        {
            turnoutStepper.SetTurnout(number, direction);
        }
    }
}
