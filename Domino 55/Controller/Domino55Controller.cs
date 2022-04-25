using Domino_55.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Controller
{
    internal class Domino55Controller
    {
        private bool turnoutFeedback = false;
        public List<TurnoutFeedbackController> TurnoutFeedbackControllers = new List<TurnoutFeedbackController>();
        Domino55 d55 = Domino55.Instance;
        public Domino55Controller()
        {
            d55.BindController(this);
        }

        public void BindTurnoutFeedbackControllers()
        {
            d55.BindTurnoutFeedbackControllers();
        }

        public void ToggleTurnoutFeedback()
        {
            if (turnoutFeedback)
            {
                turnoutFeedback = false;
                foreach (TurnoutFeedbackController contorller in TurnoutFeedbackControllers)
                {
                    contorller.FeedbackOFF();
                }
            }
            else
            {
                turnoutFeedback = true;
                foreach (TurnoutFeedbackController contorller in TurnoutFeedbackControllers)
                {
                    contorller.FeedbackON();
                }
            }
        }
    }
}
