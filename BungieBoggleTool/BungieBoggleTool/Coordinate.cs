using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungieBoggleTool
{
    class Coordinate : IEquatable<Coordinate>
    {
        /// <summary>
        /// X coordinate.
        /// </summary>
        public int x
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public int y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Coordinate()
            : this(0, 0)
        {
        }

        public override bool Equals(System.Object obj)
        {
            Coordinate coordinate = obj as Coordinate;

            return Equals(coordinate);
        }

        public bool Equals( Coordinate coordinate )
        {
            if( null == (object)coordinate )
            {
                return false;
            }

            return x == coordinate.x && y == coordinate.y;
        }

        public override int GetHashCode()
        {
            return x * y;
        }
    }
}
