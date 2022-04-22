using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55
{
    internal class Turnout
    {
        private readonly int dccAddress;
        public enum Direction
        {
            Straight,
            Diverging
        }

        private Direction direction;

        public void allit(Direction direciton)
        {
            if (this.direction != direciton) {
                //TODO send command to z21
                //TODO wait for movement
                this.direction = direciton;
            }
        }

        public Turnout(int dccAddress)
        {
            this.dccAddress = dccAddress;
            //TODO z21-nek egyenes irány
            direction = Direction.Straight;
        }
    }
}
