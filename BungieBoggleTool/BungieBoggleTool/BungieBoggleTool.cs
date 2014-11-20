using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BungieBoggleTool
{
    class BungieBoggleTool
    {
        public Dictionary dictionary
        {
            get
            {
                return dictionary;
            }
            set
            {
            }
        }

        public BoggleGrid grid
        {
            get
            {
                return grid;
            }
            set
            {
            }
        }

        static void Main(string[] args)
        {

        }

        /// <summary>
        /// Returns a set of all possible words found within a BoggleGrid according to the given dictionary
        /// </summary>
        /// <param name="boggleGridFile">File containing the BoggleGrid.</param>
        /// <param name="dictionaryFile">File containing the list of possible words.</param>
        public HashSet<string> FindAllWords(StreamReader dictionaryFile, StreamReader boggleGridFile)
        {
            HashSet<string> words = new HashSet<string>();

            grid = new BoggleGrid(boggleGridFile);
            dictionary = new Dictionary(dictionaryFile, grid);

            for (int i = 0; i < grid.numRows; ++i)
            {
                for (int j = 0; j < grid.numCols; ++j)
                {
                    words.Union(DoDFS(grid, dictionary, i, j));
                }
            }

            return words;
        }

        /// <summary>
        /// Recursive DFS function to search grid for all possible strings smartly.
        /// </summary>
        private HashSet<string> DoDFS(BoggleGrid grid, Dictionary dictionary, int i, int j)
        {
            HashSet<string> words = new HashSet<string>();
            Stack<PrefixStackSet> prefixes = new Stack<PrefixStackSet>();
            PrefixStackSet currentNode = null, tempNode = null;
            Coordinate[] diff = { new Coordinate(0,-1),     // Coordinate differential for possible directions {left, up-left, up, up-right, right, down-right, down, down-left}
                                     new Coordinate(1, -1),
                                     new Coordinate(1, 0),
                                     new Coordinate(1, 1),
                                     new Coordinate(0, 1),
                                     new Coordinate(-1, 1),
                                     new Coordinate(-1, 0),
                                     new Coordinate(-1, -1)};
            Coordinate tempCoordinate = null;

            // Seed the search
            currentNode = new PrefixStackSet();
            tempCoordinate = new Coordinate(0, 0);
            currentNode.Push(Tuple.Create<Coordinate, Letter>(tempCoordinate, grid.Get(tempCoordinate)));
            prefixes.Push(currentNode);

            // Start DFS
            while (0 != prefixes.Count)
            {
                // Process current node
                currentNode = prefixes.Pop();

                // Add word if word is found
                if (dictionary.Contains(currentNode.ToString()))
                {
                    words.Add(currentNode.ToString());
                }

                // Stop branching if prefix is not found.
                // Remove traversed grid item
                // Remove string from current prefix
                if (!dictionary.ContainsPrefix(currentNode.ToString()))
                {
                    continue;
                }


                foreach (Coordinate df in diff)
                {
                    tempCoordinate = new Coordinate(currentNode.Peek().Item1.x + df.x, currentNode.Peek().Item1.y + df.y);

                    if ((-1 < tempCoordinate.x)                     // Check boundaries of direction
                        && (tempCoordinate.x < grid.numRows)
                        && (-1 < tempCoordinate.y)
                        && (tempCoordinate.y < grid.numCols)
                        && !currentNode.Contains(tempCoordinate))   // Check if node has been traversed
                    {
                        // Push in next item
                        tempNode = new PrefixStackSet(currentNode);
                        tempNode.Push(Tuple.Create<Coordinate, Letter>(tempCoordinate, grid.Get(tempCoordinate)));
                        prefixes.Push(tempNode);
                    }
                }
            }

            return words;
        }
    }
}
