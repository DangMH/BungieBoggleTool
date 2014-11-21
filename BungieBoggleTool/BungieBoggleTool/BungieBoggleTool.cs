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
        private enum COMMANDS
        {
            EXIT = 0,
            LOAD_GRID = 1,
            PRINT_GRID_TO_FILE = 2,
            LOAD_DICTIONARY = 3,
            PRINT_DICTIONARY_TO_FILE = 4,
            PRINT_GRID = 5,
            PRINT_DICTIONARY = 6,
            FIND_ALL_WORDS = 7,
            PRINT_SOLUTION_TO_FILE = 8
        }

        private static StreamReader dictionaryFileStream = null;
        private static StreamReader gridFileStream = null;
        private static BoggleGrid toolBoggleGrid = new BoggleGrid();
        private static Dictionary toolDictionary = new Dictionary();
        private static HashSet<string> foundWords = new HashSet<string>();

        /// <summary>
        /// Main Console Application method that runs the console application.
        /// </summary>
        /// <param name="args">
        /// Application arguments, not used
        /// </param>
        public static void Main(string[] args)
        {
            Console.WriteLine("BUNGIE BOGGLE SOLVER\n");

            while (true)
            {
                PrintMenu();

                string line = ReadLine();
                int command = -1;

                if (!Int32.TryParse(line, out command))
                {
                    Console.WriteLine("ERROR: Unrecognized command");
                    continue;
                }

                switch ((COMMANDS)command)
                {
                    case COMMANDS.EXIT:
                        Console.WriteLine("PRESS ANY KEY TO EXIT\n");
                        ReadLine();
                        return;
                    case COMMANDS.LOAD_DICTIONARY:
                        LoadDictionary();
                        break;
                    case COMMANDS.LOAD_GRID:
                        LoadGrid();
                        break;
                    case COMMANDS.PRINT_DICTIONARY:
                        PrintDictionary();
                        break;
                    case COMMANDS.PRINT_GRID:
                        PrintGrid();
                        break;
                    case COMMANDS.FIND_ALL_WORDS:
                        FindAllWords();
                        break;
                    case COMMANDS.PRINT_GRID_TO_FILE:
                        PrintGridToFile();
                        break;
                    case COMMANDS.PRINT_DICTIONARY_TO_FILE:
                        PrintDictionaryToFile();
                        break;
                    case COMMANDS.PRINT_SOLUTION_TO_FILE:
                        PrintFoundWordsToFile();
                        break;
                    default:
                        Console.WriteLine("ERROR: Unrecognized command");
                        break;
                }
            }
        }

        /// <summary>
        /// Console Application method that loads the dictionary.
        /// </summary>
        public static void PrintMenu()
        {
            Console.WriteLine("--------------------------------\n");
            foreach (COMMANDS command in Enum.GetValues(typeof(COMMANDS)).Cast<COMMANDS>())
            {
                Console.WriteLine(command.ToString("G") + " = " + command.ToString("D"));
            }
            Console.WriteLine("--------------------------------\n");
        }

        /// <summary>
        /// Console Application method that loads the dictionary.
        /// </summary>
        public static void LoadDictionary()
        {
            Console.WriteLine("Enter full dictionary file path: ");

            try
            {
                dictionaryFileStream = new StreamReader(ReadLine());
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.ToString() + "\n"
                    + "\tDefault dictionary will be used");
                dictionaryFileStream = null;
                toolDictionary = new Dictionary();
            }

            Console.Write("Parse dictionary with currently loaded grid? (Y/N): ");

            if ("y" == ReadLine().Trim().ToLower())
            {
                toolDictionary = new Dictionary(dictionaryFileStream, toolBoggleGrid);
            }
            else
            {
                Console.Write("Load a new grid to parse dictionary? (Y/N): ");
                if ("y" == ReadLine().Trim().ToLower())
                {
                    LoadGrid();
                    toolDictionary = new Dictionary(dictionaryFileStream, toolBoggleGrid);
                }
                else
                {
                    toolDictionary = new Dictionary(dictionaryFileStream, null);
                }
            }

            Console.Write("Print loaded dictionary? (Y/N): ");

            if ("y" == ReadLine().Trim().ToLower())
            {
                PrintDictionary();
            }
        }

        /// <summary>
        /// Console Application method that prints the loaded dictionary.
        /// </summary>
        public static void PrintDictionary()
        {
            Console.WriteLine("\nDictionary generated: \n"
                + toolDictionary.ToString());
        }

        /// <summary>
        /// Console Application method that prints the loaded dictionary to a file.
        /// </summary>
        public static void PrintDictionaryToFile()
        {
            Console.WriteLine("\nInput full file path for dictionary: \n");

            try
            {
                StreamWriter sw = new StreamWriter(ReadLine());
                sw.Write(toolDictionary.ToString());
                sw.Close();

                Console.WriteLine( "File Created Successfully" );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Console Application method that loads the grid.
        /// </summary>
        public static void LoadGrid()
        {
            Console.WriteLine("\nEnter full grid file path: ");
            try
            {
                gridFileStream = new StreamReader(ReadLine());
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.ToString() + "\n"
                    + "\tDefault grid will be used");
                gridFileStream = null;
                toolBoggleGrid = new BoggleGrid();
            }

            toolBoggleGrid = new BoggleGrid(gridFileStream);

            Console.Write("Print loaded grid? (Y/N): ");

            if ("y" == ReadLine().Trim().ToLower())
            {
                PrintGrid();
            }
        }

        /// <summary>
        /// Console Application method that prints the loaded grid.
        /// </summary>
        public static void PrintGrid()
        {
            Console.WriteLine("\nGrid generated: \n"
                + toolBoggleGrid.ToString());
        }

        /// <summary>
        /// Console Application method that prints the loaded grid to a file.
        /// </summary>
        public static void PrintGridToFile()
        {
            Console.WriteLine("\nInput full file path for grid: \n");

            try
            {
                StreamWriter sw = new StreamWriter(ReadLine());
                sw.Write(toolBoggleGrid.ToString());
                sw.Close();

                Console.WriteLine("File Created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Console Application method that find all the words.
        /// </summary>
        public static void FindAllWords()
        {
            Console.WriteLine("\nThe grid contains the following words: ");
            foreach (string str in foundWords = FindAllWords(toolDictionary, toolBoggleGrid))
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Console Application method that prints the latest found words to a file.
        /// </summary>
        public static void PrintFoundWordsToFile()
        {
            Console.WriteLine("\nInput full file path for latest found words: \n");

            try
            {
                StreamWriter sw = new StreamWriter(ReadLine());
                foreach (string str in foundWords)
                {
                    sw.WriteLine(str);
                }
                sw.Close();

                Console.WriteLine("File Created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Console Application to read an input.
        /// </summary>
        public static string ReadLine()
        {
            Console.Write("> ");
            return Console.ReadLine();
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
