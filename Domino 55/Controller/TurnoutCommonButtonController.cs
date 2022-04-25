using Domino_55.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Controller
{
    internal class TurnoutCommonButtonController : TwoStepButtonController
    {
        public TurnoutCommonButtonController(TwoStepButtonView view) : base(view)
        {
        }

        public override void Action(TwoStepButtonController otherButton)
        {
            otherButton.Action(this);
        }
    }
}
