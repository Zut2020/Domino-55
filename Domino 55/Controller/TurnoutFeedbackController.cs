using Domino_55.Views;
using Domino_55.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.Tracing;
using System.Timers;

namespace Domino_55.Controller
{

    public class TurnoutFeedbackController
    {
        private static System.Timers.Timer _timer;
        private const int delayTime = 500;
        private const int switchTime = 2500;
        private TurnoutFeedbackView view;
        private Turnout turnout;
        private bool blinking = false;
        private bool feedback = false;
        private bool locked = false;

        public TurnoutFeedbackController(TurnoutFeedbackView view)
        {
            this.view = view;
            SetTimer();
        }
        public void SetTimer()
        {
            _timer = new System.Timers.Timer(delayTime);
            _timer.Elapsed += Blink;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }
        public void BindTurnout(Turnout turnout)
        {
            this.turnout = turnout;
        }
        public void Update()
        {
            if (locked)
            {
                if (turnout.direction == Turnout.Direction.Straight)
                    view.LockStraight();
                else
                    view.SetBranch();
            }
            else if (feedback)
            {
                if (turnout.direction == Turnout.Direction.Straight)
                    view.SetStraight();
                else
                    view.SetBranch();
            }
            else
                view.SetOff();
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

        public void Lock()
        {
            locked = true;
            Update();
        }

        public void Release()
        {
            locked = false;
            Update();
        }

        internal void AnimateSwitch(Turnout.Direction direction)
        {
            blinking = true;
            Thread.Sleep(switchTime);
            blinking = false;
            Update();
        }

        public void AntimateBlinkStart()
        {
            blinking = true;
        }

        public void AnimateBlinkStop()
        {
            blinking = false;
        }

        private bool blinkLight = false;
        private void Blink(object? sender, ElapsedEventArgs e)
        {
            if (blinking)
            {
                if (turnout.direction == Turnout.Direction.Straight)
                {
                    if (!blinkLight)
                    {
                        view.SetStraight();
                    }
                    else
                    {
                        view.SetOff();
                    }
                }
                else
                {
                    if (!blinkLight)
                    {
                        view.SetBranch();
                    }
                    else
                    {
                        view.SetOff();
                    }
                }
            }
            blinkLight = !blinkLight;
        }
    }
}
