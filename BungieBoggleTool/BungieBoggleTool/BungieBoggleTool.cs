using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BungieBoggleTool
{
    /// <summary>
    /// Console Application that finds all words within a Boggle Grid.
    /// </summary>
    public class BungieBoggleTool
    {
        /// <summary>
        /// Main program that runs the console application.
        /// </summary>
        /// <param name="args">
        /// Application arguments:
        /// 1. Dictionary file name
        /// 2. Grid file name
        /// If no grid file name is designnated, a random grid will be generated.
        /// </param>
        static void Main(string[] args)
        {
            StreamReader dictionaryFileStream = null;
            StreamReader gridFileStream = null;
            BoggleGrid toolBoggleGrid = null;
            Dictionary toolDictionary = null;

            if (args.Length == 0)
            {
                Console.WriteLine("ERROR: Not enough arguments.  Please enter full dictionary file path and then full grid file path.");
            }

            if (args.Length >= 1)
            {
                try
                {
                    dictionaryFileStream = new StreamReader(args[0]);
                }
                catch (FileNotFoundException fnfe)
                {
                    Console.WriteLine(fnfe.ToString());
                    return;
                }
            }

            if (args.Length >= 2)
            {
                try
                {
                    gridFileStream = new StreamReader(args[1]);
                }
                catch (FileNotFoundException fnfe)
                {
                    Console.WriteLine(fnfe.ToString());
                    return;
                }
            }

            toolBoggleGrid = new BoggleGrid(gridFileStream);
            toolDictionary = new Dictionary(dictionaryFileStream, toolBoggleGrid);

            Console.WriteLine("The grid contains the following words: ");
            foreach (string str in FindAllWords(toolDictionary, toolBoggleGrid))
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Returns a set of all possible words found within a BoggleGrid according to the given dictionary
        /// </summary>
        /// <param name="boggleGrid">File containing the BoggleGrid.</param>
        /// <param name="dictionary">File containing the list of possible words.</param>
        public static HashSet<string> FindAllWords(Dictionary dictionary, BoggleGrid boggleGrid)
        {
            HashSet<string> words = new HashSet<string>();

            for (int i = 0; i < boggleGrid.NumRows; ++i)
            {
                for (int j = 0; j < boggleGrid.NumCols; ++j)
                {
                    words.UnionWith(DoDFS(boggleGrid, dictionary, i, j));
                }
            }

            return words;
        }

        /// <summary>
        /// Recursive DFS function to search grid for all possible strings smartly.
        /// </summary>
        private static HashSet<string> DoDFS(BoggleGrid grid, Dictionary dictionary, int i, int j)
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
            tempCoordinate = new Coordinate(i, j);
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
                    words.Add(currentNode.ToString().ToLower());
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
                    tempCoordinate = new Coordinate(currentNode.Peek().Item1.X + df.X, currentNode.Peek().Item1.Y + df.Y);

                    if ((-1 < tempCoordinate.X)                     // Check boundaries of direction
                        && (tempCoordinate.X < grid.NumRows)
                        && (-1 < tempCoordinate.Y)
                        && (tempCoordinate.Y < grid.NumCols)
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
