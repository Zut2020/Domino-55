using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Domino_55
{
    internal class Turnout
    {
        private readonly int dccAddress;
        public readonly int number;
        public enum Direction
        {
            Straight,
            Diverging,
            Common
        }

        private Direction direction;

        public async void allit(Direction newDirection)
        {
            if (this.direction != newDirection)
            {
                if (newDirection == Direction.Common)
                {
                    if (this.direction == Direction.Straight)
                        newDirection = Direction.Diverging;
                    else
                        newDirection = Direction.Straight;
                }
                //TODO send command to z21
                Thread.Sleep(2000);
                this.direction = newDirection;
                String msg = string.Format("{0} váltó {1} irányba állt", number, this.direction.ToString());
                MessageBox.Show(msg);
            }
        }

        public Turnout(int number, int dccAddress)
        {
            this.number = number;
            this.dccAddress = dccAddress;
            //TODO z21-nek egyenes irány
            direction = Direction.Straight;
        }
    }
}
