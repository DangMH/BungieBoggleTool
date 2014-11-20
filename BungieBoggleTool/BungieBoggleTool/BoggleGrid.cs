using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BungieBoggleTool
{
    class BoggleGrid
    {
        /// <summary>
        /// Unique set of letters found inside the boggleGrid.  Used for efficiency in populating a boggleGridFile.
        /// </summary>
        private HashSet<char> uniqueLetters;
        /// <summary>
        /// Grid of letters.
        /// </summary>
        private Dictionary<Coordinate, Letter> letters;
        /// <summary>
        /// Number of Rows.
        /// </summary>
        public int numRows
        {
            get
            {
                return numRows;
            }
            private set
            {
                numRows = value;
            }
        }
        /// <summary>
        /// Number of Rows.
        /// </summary>
        public int numCols
        {
            get
            {
                return numCols;
            }
            private set
            {
                numCols = value;
            }
        }


        /// <summary>
        /// Constructs BoggleGrid from the BoggleGrid file.
        /// </summary>
        /// <param name="boggleGridFile">File to Populate the BoggleGrid.</param>
        public BoggleGrid(StreamReader boggleGridFile)
        {
            Populate(boggleGridFile);
        }

        /// <summary>
        /// Default constrcutor.  Generates default grid.
        /// </summary>
        public BoggleGrid()
        {
            GenerateGrid();
        }

        /// <summary>
        /// Accessor method for uniqueLetters.
        /// </summary>
        public HashSet<char> GetUniqueLetters()
        {
            return uniqueLetters;
        }

        /// <summary>
        /// Parses BoggleGrid from the BoggleGrid file.
        /// </summary>
        /// <param name="boggleGridFile">File to Populate the BoggleGrid.</param>
        private void Populate(StreamReader boggleGridFile)
        {
            string line = null;
            bool errorOccured = false;
            Letter letter = null;
            int rowsRead = 0,
                colsRead = 0;

            numRows = 0;
            numCols = 0;

            do
            {
                //First line contains the row value
                if (errorOccured = (null == (line = boggleGridFile.ReadLine())))
                {
                    Console.WriteLine("FORMATTING ERROR: Missing BoggleGrid row value");
                    break;
                }
                if (errorOccured = !Int32.TryParse(line, out rowsRead))
                {
                    Console.WriteLine("FORMATTING ERROR: Incorrect format for BoggleGrid row value: " + numRows);
                    break;
                }
                numRows = rowsRead;

                //Second line contains the column value
                if (errorOccured = (null == (line = boggleGridFile.ReadLine())))
                {
                    Console.WriteLine("FORMATTING ERROR: Missing BoggleGrid column value");
                    break;
                }
                if (errorOccured = !Int32.TryParse(line, out colsRead))
                {
                    Console.WriteLine("FORMATTING ERROR: Incorrect format for BoggleGrid column value: " + numCols);
                    break;
                }
                numCols = colsRead;

                letters = new Dictionary<Coordinate, Letter>(numRows * numCols);
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
                        letters.Add(new Coordinate(i, j), letter = new Letter(line[j]));

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
        /// <param name="coordinate">Row and column indices of the Letter.</param>
        public Letter Get(Coordinate coordinate)
        {
            return letters[coordinate];
        }

        /// <summary>
        /// Generates a BoggleGrid with the given dimensions.
        /// </summary>
        /// <param name="numRows">Number of rows in the boggleGrid.</param>
        /// <param name="numCols">Number of columns in the boggleGrid.</param>
        public void GenerateGrid(int numRows, int numCols)
        {
            Letter letter;

            letters = new Dictionary<Coordinate, Letter>(numRows * numCols);
            uniqueLetters = new HashSet<char>();

            for (int i = 0; i < numRows; ++i)
            {
                for (int j = 0; j < numCols; ++j)
                {
                    letters.Add(new Coordinate(i, j), letter = new Letter());
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
