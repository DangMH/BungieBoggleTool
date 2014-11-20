using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungieBoggleTool
{
    class PrefixStackSet
    {
        /// <summary>
        /// Set of coordinates.
        /// </summary>
        private HashSet<Coordinate> prefixCoordinatesSet;
        /// <summary>
        /// Stack of coordinates and letters.
        /// </summary>
        private Stack<Tuple<Coordinate, Letter>> prefixCoordinatesStack;
        /// <summary>
        /// String representation of the current prefix.
        /// </summary>
        private string prefix;

        /// <summary>
        /// Parameterized constructor that creates a copy of the prefixStackSet.  Only creates new instances of the Stack, Set and string members, but still references the items in them (excluding the string).
        /// </summary>
        /// <param name="prefixStackSet">PrefixStackSet to be copied.</param>
        public PrefixStackSet(PrefixStackSet prefixStackSet)
        {
            prefixCoordinatesSet = new HashSet<Coordinate>(prefixStackSet.prefixCoordinatesSet);
            prefixCoordinatesStack = new Stack<Tuple<Coordinate, Letter>>(prefixStackSet.prefixCoordinatesStack);
            prefix = String.Copy(prefixStackSet.prefix);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PrefixStackSet()
        {
            prefixCoordinatesSet = new HashSet<Coordinate>();
            prefixCoordinatesStack = new Stack<Tuple<Coordinate, Letter>>();
            prefix = "";
        }

        public bool Push(Tuple<Coordinate, Letter> block)
        {
            if (prefixCoordinatesSet.Contains(block.Item1))
            {
                {
                    return false;
                }
            }
            else
            {
                prefixCoordinatesSet.Add(block.Item1);
                prefixCoordinatesStack.Push(Tuple.Create<Coordinate, Letter>(block.Item1, block.Item2));
                prefix += block.Item2.ToString();

                return true;
            }
        }

        /// <summary>
        /// Removes and returns the last element in the PrefixStackSet.
        /// </summary>
        public Tuple<Coordinate, Letter> Pop()
        {
            Tuple<Coordinate, Letter> ret = null;

            ret = prefixCoordinatesStack.Pop();
            prefixCoordinatesSet.Remove(ret.Item1);
            prefix.Substring(0, prefix.Length - ret.Item2.ToString().Length);

            return ret;
        }

        /// <summary>
        /// Returns the last element in the PrefixStackSet but does not remove it.
        /// </summary>
        public Tuple<Coordinate, Letter> Peek()
        {
            return prefixCoordinatesStack.Peek();
        }

        /// <summary>
        /// Returns true if it contains the coordinate, else returns false;
        /// </summary>
        public bool Contains(Coordinate coordinate)
        {
            return prefixCoordinatesSet.Contains(coordinate);
        }

        /// <summary>
        /// Returns prefix string representation.
        /// </summary>
        public override string ToString()
        {
            return prefix;
        }
    }
}
