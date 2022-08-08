using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domino_55.Model
{
    internal class TurnoutStepper
    {
        internal class TurnoutAction
        {
            internal Turnout turnout;
            internal Turnout.Direction direction;

            public TurnoutAction(Turnout turnout, Turnout.Direction direction)
            {
                this.turnout = turnout;
                this.direction = direction;
            }
        }

        List<TurnoutAction> actions = new List<TurnoutAction>();
        private bool working = false;

        internal void SetTurnout(Turnout turnout, Turnout.Direction direction)
        {
            actions.Add(new TurnoutAction(turnout, direction));
            UI.UI.Instance.mainWindow.StartTurnoutBlink(turnout.number);
            if (actions.Count == 1)
                Work();
        }

        private void Work()
        {
            working = true;
            Turnout turnout = actions[0].turnout;
            turnout.Switch();
            if (turnout.DirectionProperty == Turnout.Direction.Branch)
                Z21.Z21.Instance.SetTurnoutBranch((byte)turnout.number);
            else
                Z21.Z21.Instance.SetTurnoutStraight((byte)turnout.number);
            Thread.Sleep(2500);
            UI.UI.Instance.mainWindow.StopTurnoutBlink(turnout.number);
            actions.RemoveAt(0);
            if (actions.Count > 0)
                Work();
        }
    }
}
