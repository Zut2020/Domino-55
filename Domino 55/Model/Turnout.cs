using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Domino_55.Controller;

namespace Domino_55.Model
{
    public class Turnout
    {
        public TurnoutFeedbackController controller;
        public void BindController(TurnoutFeedbackController controller) => this.controller = controller;
        private readonly byte dccAddress;
        public readonly int number;
        private bool locked;
        public enum Direction
        {
            Straight,
            Diverging,
            Common
        }

        public Direction direction;

        public void Set(Direction newDirection)
        {
            if (!locked)
            {
                controller.Update();
                if (direction != newDirection)
                {
                    if (newDirection == Direction.Common)
                    {
                        if (direction == Direction.Straight)
                            newDirection = Direction.Diverging;
                        else
                            newDirection = Direction.Straight;
                    }
                    direction = newDirection;
                    if (newDirection == Direction.Straight)
                    {
                        Z21.Instance.SetTurnoutStraight(dccAddress);
                    }
                    else
                        Z21.Instance.SetTurnoutBranch(dccAddress);
                    controller.AnimateSwitch(direction);
                }
            }
            controller.Update();
        }

        internal void Release()
        {
            controller.Release();
            locked = false;
        }

        internal void Lock()
        {
            controller.Lock();
            locked = true;
        }

        public Turnout(int number, byte dccAddress)
        {
            this.number = number;
            this.dccAddress = dccAddress;
            Z21.Instance.SetTurnoutStraight(dccAddress);
            direction = Direction.Straight;
        }
    }
}
