using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Domino_55
{
    internal class TurnoutButton : DominoButton
    {
        private int number;

        public override void Action(DominoButton otherButton)
        {
            char chnum = Name.ToCharArray()[3];
            int number = int.Parse(chnum.ToString());
            
            //base.Action(otherButton);
            if (otherButton.GetType() == typeof(TurnoutCommonButton))
                TurnoutStepper.Instance.SetTurnout(number, Turnout.Direction.Common);
        }
    }
}
