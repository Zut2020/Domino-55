using Domino_55.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino_55.Views;

namespace Domino_55.Controller
{
    public class TurnoutButtonContorller : TwoStepButtonController
    {
        private int number;


        public TurnoutButtonContorller(int number, TwoStepButtonView twoStepButtonView) : base(twoStepButtonView)
        {
            this.number = number;
        }

        public override void Action(TwoStepButtonController otherButton)
        {
            //base.Action(otherButton);
            if (otherButton.GetType() == typeof(TurnoutCommonButtonController))
                TurnoutStepper.Instance.SetTurnout(number, Turnout.Direction.Common);
        }
    }
}
