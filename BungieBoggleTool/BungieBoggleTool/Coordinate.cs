using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungieBoggleTool
{
    /// <summary>
    /// Class representing an x and a y coordinate.
    /// </summary>
    public class Coordinate : IEquatable<Coordinate>
    {
        /// <summary>
        /// X coordinate.
        /// </summary>
        private int x;

        /// <summary>
        /// X coordinate.
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        private int y;

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Coordinate()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Equates two coordinates based on x and y value.
        /// </summary>
        /// <param name="obj">Coordinate to compare against.</param>
        public override bool Equals(System.Object obj)
        {
            Coordinate coordinate = obj as Coordinate;

            return Equals(coordinate);
        }

        /// <summary>
        /// Equates two coordinates based on x and y value.
        /// </summary>
        /// <param name="coordinate">Coordinate to compare against.</param>
        public bool Equals(Coordinate coordinate)
        {
            if (null == (object)coordinate)
            {
                return false;
            }

            return X == coordinate.X && Y == coordinate.Y;
        }

        /// <summary>
        /// Hash is derived from x and y coordinates.
        /// </summary>
        public override int GetHashCode()
        {
            return X * Y;
        }
    }
}
