﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Domino_55.Model
{
    public class Turnout
    {
        private readonly byte dccAddress;
        public readonly int number;
        public enum Direction
        {
            Straight,
            Diverging,
            Common
        }

        private Direction direction;

        public void Set(Direction newDirection)
        {
            if (direction != newDirection)
            {
                if (newDirection == Direction.Common)
                {
                    if (direction == Direction.Straight)
                        newDirection = Direction.Diverging;
                    else
                        newDirection = Direction.Straight;
                }
                if (newDirection == Direction.Straight)
                    Z21.Instance.SetTurnoutStraight(dccAddress);
                else
                    Z21.Instance.SetTurnoutBranch(dccAddress);
                Thread.Sleep(2000);
                direction = newDirection;
            }
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