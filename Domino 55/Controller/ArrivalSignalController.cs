using Domino_55.Views;
using Domino_55.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Controller
{
    public class ArrivalSignalController : TwoStepButtonController
    {
        private string name;
        Route? route = null;

        public ArrivalSignalController(TwoStepButtonView view) : base(view)
        {
            name += view.Name.ToCharArray().Last();
        }

        public override void Action(TwoStepButtonController otherButton)
        {
            if (route == null)
            {
                if (otherButton.GetType() == typeof(DepartureSignalController))
                {
                    route = new Route();
                    DepartureSignalController targetSignal = otherButton as DepartureSignalController;
                    if (this.name == "A")
                    {
                        if (targetSignal.name == "V2")
                        {
                            route.AddTurnoutAction(new TurnoutAction(2, Turnout.Direction.Straight));
                            route.AddTurnoutAction(new TurnoutAction(4, Turnout.Direction.Straight));

                            route.AddTrackSection(Domino55.Instance.trackSections[0]);
                            route.AddTrackSection(Domino55.Instance.trackSections[3]);
                        } 
                        else if (targetSignal.name == "V1")
                        {
                            route.AddTurnoutAction(new TurnoutAction(2, Turnout.Direction.Diverging));
                            route.AddTrackSection(Domino55.Instance.trackSections[0]);
                            route.AddTrackSection(Domino55.Instance.trackSections[2]);
                        }
                    }
                    route.Lock();
                }
            }
            else if (otherButton.GetType() == typeof(DeleteRouteButtonController))
            {
                route.Release();
                route = null;
            }
        }
    }
}
