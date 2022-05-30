using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Model
{
    public struct TurnoutAction
    {
        public Turnout turnout;
        public Turnout.Direction direction;

        public TurnoutAction(int number, Turnout.Direction direction)
        {
            turnout = Domino55.Instance.turnouts.Find(x => x.number == number);
            this.direction = direction;
        }

        public TurnoutAction(Turnout turnout, Turnout.Direction direction)
        {
            this.turnout = turnout;
            this.direction = direction;
        }
    }
}
