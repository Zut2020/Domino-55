using Domino_55.Views;
using Domino_55.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Domino_55.Controller
{

    public class TurnoutFeedbackController
    {
        private TurnoutFeedbackView view;
        private Turnout turnout;

        CancellationTokenSource source;
        CancellationToken token;
        TaskFactory taskFactory;
        Task task;

        public void BindTurnout(Turnout turnout)
        {
            this.turnout = turnout;
        }

        private bool feedback = false;

        public TurnoutFeedbackController(TurnoutFeedbackView view)
        {
            this.view = view;
        }

        public void FeedbackON()
        {
            feedback = true;
            Update();
        }

        public void FeedbackOFF()
        {
            feedback = false;
            Update();
        }

        public void Update()
        {
            if (feedback)
            {
                if (turnout.direction == Turnout.Direction.Straight)
                    view.SetStraight();
                else
                    view.SetDivergent();
            }
            else
                view.SetOff();
        }

        private const int delayTime = 500;
        internal void AnimateSwitch(Turnout.Direction direction)
        {
            if (direction == Turnout.Direction.Straight)
            {
                for (int i = 0; i < 3; i++)
                {
                    view.SetOff();
                    Thread.Sleep(delayTime);
                    view.SetStraight();
                    Thread.Sleep(delayTime);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    view.SetOff();
                    Thread.Sleep(delayTime);
                    view.SetDivergent();
                    Thread.Sleep(delayTime);
                }
            }
            Update();
        }

        public void AntimateBlinkStart(Turnout.Direction direction)
        {
            source = new CancellationTokenSource();
            token = source.Token;
            taskFactory = new TaskFactory();
            task = taskFactory.StartNew(() =>
            {
                try
               {
                   if (direction == Turnout.Direction.Straight)
                   {
                       while (true)
                       {
                           view.SetOff();
                           Thread.Sleep(delayTime);
                           view.SetStraight();
                           Thread.Sleep(delayTime);
                           token.ThrowIfCancellationRequested();
                       }
                   }
                   else
                   {
                       while (true)
                       {
                           view.SetOff();
                           Thread.Sleep(delayTime);
                           view.SetDivergent();
                           Thread.Sleep(delayTime);
                           token.ThrowIfCancellationRequested();
                       }
                   }
               }
               catch (OperationCanceledException)
               {

               }
           }, source.Token);
        }

        public void AnimateBlinkStop()
        {
            if (task != null)
            {
                source.Cancel();
                source.Dispose();
            }
        }
    }
}
