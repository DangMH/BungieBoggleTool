using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BungieBoggleTool
{
    public class BoggleGrid
    {
        /// <summary>
        /// Unique set of letters found inside the boggleGrid.  Used for efficiency in populating a boggleGridFile.
        /// </summary>
        private HashSet<char> uniqueLetters;
        /// <summary>
        /// grid of letters.
        /// </summary>
        private Dictionary<Tuple<int, int>, Letter> letters;

        /// <summary>
        /// Accessor method for uniqueLetters.
        /// </summary>
        public HashSet<char> GetUniqueLetters()
        {
            return uniqueLetters;
        }

        /// <summary>
        /// Parses Boggle BoggleGrid from the BoggleGrid file.
        /// </summary>
        /// <param name="boggleGridFile">File to Populate the BoggleGrid.</param>
        public void Populate(StreamReader boggleGridFile)
        {
            string line = null;
            bool errorOccured = false;
            int numRows, numCols;
            Letter letter;

            do
            {
                //First line contains the row value
                if (errorOccured = (null == (line = boggleGridFile.ReadLine())))
                {
                    Console.WriteLine("FORMATTING ERROR: Missing BoggleGrid row value");
                    break;
                }
                if (errorOccured = !Int32.TryParse(line, out numRows))
                {
                    Console.WriteLine("FORMATTING ERROR: Incorrect format for BoggleGrid row value: " + numRows);
                    break;
                }

                //Second line contains the column value
                if (errorOccured = (null == (line = boggleGridFile.ReadLine())))
                {
                    Console.WriteLine("FORMATTING ERROR: Missing BoggleGrid column value");
                    break;
                }
                if (errorOccured = !Int32.TryParse(line, out numCols))
                {
                    Console.WriteLine("FORMATTING ERROR: Incorrect format for BoggleGrid column value: " + numCols);
                    break;
                }

                letters = new Dictionary<Tuple<int, int>, Letter>(numRows * numCols);
                uniqueLetters = new HashSet<char>();

                for (int i = 0; i < numRows; ++i)
                {

                    // Read the ith row
                    if (errorOccured = (null == (line = boggleGridFile.ReadLine())))
                    {
                        Console.WriteLine("FORMATTING ERROR: Missing BoggleGrid row: " + i);
                        break;
                    }

                    // Column the incorrect length at row i
                    if (numCols != line.Length)
                    {
                        Console.WriteLine("FORMATTING ERROR: Incorrect number of columns at row " + i + ": " + line);
                        break;
                    }

                    for (int j = 0; j < numCols; ++j)
                    {
                        // Read the char at the ith column
                        letters.Add(Tuple.Create<int, int>(i, j), letter = new Letter(line[j]));

                        // Add letters to the uniqueLetter set
                        foreach (char c in letter.ToString())
                        {
                            uniqueLetters.Add(c);
                        }
                    }
                }

                // Optimization if further parsing is added
                //if( errorOccured )
                //{
                //    break;
                //}

            } while (false);

            if (errorOccured)
            {
                Console.WriteLine("FORMATTING ERROR DETECTED: Default grid generated");
                GenerateGrid();
            }
        }

        /// <summary>
        /// Accessor method to the Letter at (row, col).
        /// </summary>
        /// <param name="row">Row of the Letter.</param>
        /// <param name="col">Column of the Letter.</param>
        public Letter Get(int row, int col)
        {
            return letters[Tuple.Create<int, int>(row, col)];
        }

        /// <summary>
        /// Generates a BoggleGrid with the given dimensions.
        /// </summary>
        /// <param name="numRows">Number of rows in the boggleGrid.</param>
        /// <param name="numCols">Number of columns in the boggleGrid.</param>
        public void GenerateGrid(int numRows, int numCols)
        {
            Letter letter;

            letters = new Dictionary<Tuple<int, int>, Letter>(numRows * numCols);
            uniqueLetters = new HashSet<char>();

            for (int i = 0; i < numRows; ++i)
            {
                for (int j = 0; j < numCols; ++j)
                {
                    letters.Add(Tuple.Create<int, int>(i, j), letter = new Letter());
                    foreach (char c in letter.ToString())
                    {
                        uniqueLetters.Add(c);
                    }
                }
            }
        }

        /// <summary>
        /// Generates a default Grid.
        /// </summary>
        public void GenerateGrid()
        {
            GenerateGrid(3, 3);
        }
    }
}
