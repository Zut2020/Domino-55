using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Model
{
    internal class Turnout
    {
        public enum Direction
        {
            Straight, 
            Branch,
            Common
        }

        public readonly int number;
        private Direction direction;

        internal Direction DirectionProperty { get => direction; private set => direction = value; }

        public Turnout(int number)
        {
            this.number = number;
            this.direction = Direction.Straight;
        }

        internal void Switch()
        {
            if (direction == Direction.Branch)
                direction = Direction.Straight;
            else
                direction = Direction.Branch;
        }

        public Turnout(int number, Direction direction)
        {
            this.number = number;
            this.direction = direction;
        }
    }
}
