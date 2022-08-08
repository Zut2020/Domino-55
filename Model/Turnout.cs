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
            Diverging,
            Common
        }

        public readonly int number;
        private Direction direction;

        internal Direction DirectionProperty { get => direction; private set => direction = value; }

        public Turnout(int number, Direction direction)
        {
            this.number = number;
            this.direction = direction;
        }
    }
}
