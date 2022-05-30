using Domino_55.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Controller
{
    public class DepartureSignalController : TwoStepButtonController
    {
        public string name;
        public DepartureSignalController(TwoStepButtonView view) : base(view)
        {
            char[] viewName = view.Name.ToCharArray();
            name += viewName[viewName.Length - 2];
            name += viewName[viewName.Length - 1];
            
        }

        public override void Action(TwoStepButtonController otherButton)
        {
            if (otherButton.GetType() == typeof(ArrivalSignalView))
            {
                otherButton.Action(this);
            }
        }
    }
}
