using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Model
{
    internal class TurnoutStepper
    {
        private class TurnoutAction
        {
            Turnout turnout;
            Turnout.Direction direction;

            public TurnoutAction(Turnout turnout, Turnout.Direction direction)
            {
                this.turnout = turnout;
                this.direction = direction;
            }
        }

        List<TurnoutAction> actions = new List<TurnoutAction>();

        internal void SetTurnout(Turnout turnout, Turnout.Direction direction)
        {
            actions.Add(new TurnoutAction(turnout, direction));
        }
    }
}
