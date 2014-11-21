using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BungieBoggleTool
{
    /// <summary>
    /// Class representing the Boggle Board.  Can generate random boards.
    /// </summary>
    public class BoggleGrid
    {
        /// <summary>
        /// Unique set of letters found inside the boggleGrid.  Used for efficiency in populating a boggleGridFile.
        /// </summary>
        private HashSet<char> uniqueLetters;
        /// <summary>
        /// Grid of letters.
        /// </summary>
        private Dictionary<Coordinate, Letter> letters;

        private uint numRows;

        /// <summary>
        /// Number of Rows.
        /// </summary>
        public uint NumRows
        {
            get
            {
                return numRows;
            }
            private set
            {
                this.numRows = value;
            }
        }

        private uint numCols;

        /// <summary>
        /// Number of Rows.
        /// </summary>
        public uint NumCols
        {
            get
            {
                return numCols;
            }
            private set
            {
                this.numCols = value;
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
        /// Default constructor.  Generates default grid.
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
            if (null == boggleGridFile)
            {
                GenerateGrid();
                return;
            }

            string line = null;
            bool errorOccured = false;
            Letter letter = null;
            uint rowsRead = 0,
                colsRead = 0;

            NumRows = 0;
            NumCols = 0;

            do
            {
                //First line contains the row value
                if (errorOccured = (null == (line = boggleGridFile.ReadLine())))
                {
                    Console.WriteLine("FORMATTING ERROR: Missing BoggleGrid row value");
                    break;
                }
                if (errorOccured = !UInt32.TryParse(line, out rowsRead))
                {
                    Console.WriteLine("FORMATTING ERROR: Incorrect format for BoggleGrid row value: " + NumRows);
                    break;
                }
                NumRows = rowsRead;

                //Second line contains the column value
                if (errorOccured = (null == (line = boggleGridFile.ReadLine())))
                {
                    Console.WriteLine("FORMATTING ERROR: Missing BoggleGrid column value");
                    break;
                }
                if (errorOccured = !UInt32.TryParse(line, out colsRead))
                {
                    Console.WriteLine("FORMATTING ERROR: Incorrect format for BoggleGrid column value: " + NumCols);
                    break;
                }
                NumCols = colsRead;

                try
                {
                    letters = new Dictionary<Coordinate, Letter>(checked((int)NumRows * (int)NumCols));
                }
                catch(OverflowException oe)
                {
                    Console.WriteLine("FORMATTING ERROR: Dimensions are too large: " + NumRows + "X" + NumCols);
                    Console.WriteLine( oe.ToString() );
                    errorOccured = true;
                    break;
                }
                uniqueLetters = new HashSet<char>();
                for (uint i = 0; i < NumRows; ++i)
                {

                    // Read the ith row
                    if (errorOccured = (null == (line = boggleGridFile.ReadLine())))
                    {
                        Console.WriteLine("FORMATTING ERROR: Missing BoggleGrid row: " + i);
                        break;
                    }

                    // Column the incorrect length at row i
                    if (NumCols != line.Length)
                    {
                        Console.WriteLine("FORMATTING ERROR: Incorrect number of columns at row " + i + ": " + line);
                        break;
                    }

                    for (uint j = 0; j < NumCols; ++j)
                    {
                        // Read the char at the ith column
                        letters.Add(new Coordinate((int)i, (int)j), letter = new Letter(line[(int)j]));

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
        public void GenerateGrid(uint numRows, uint numCols)
        {
            Letter letter;

            NumRows = numRows;
            NumCols = numCols;

            try
            {
                letters = new Dictionary<Coordinate, Letter>(checked((int)NumRows * (int)NumCols));
            }
            catch(OverflowException oe)
            {
                Console.WriteLine("FORMATTING ERROR: Dimensions are too large: " + NumRows + "X" + NumCols);
                Console.WriteLine(oe.ToString());

                GenerateGrid();
                return;
            }

            uniqueLetters = new HashSet<char>();

            for (uint i = 0; i < NumRows; ++i)
            {
                for (uint j = 0; j < NumCols; ++j)
                {
                    letters.Add(new Coordinate((int)i, (int)j), letter = new Letter((uint)DateTime.Now.Ticks + (i + 1) * (j + 1)));
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

        /// <summary>
        /// String representation of the grid for saving onto files
        /// </summary>
        public string ToFileString()
        {
            string ret = "";

            ret += NumRows + "\r\n";
            ret += NumCols + "\r\n";

            for (uint i = 0; i < numRows; ++i)
            {
                for (uint j = 0; j < numCols; ++j)
                {
                    ret += letters[new Coordinate((int)i, (int)j)].Symbol;
                }
                ret += "\r\n";
            }

            return ret;
        }

        /// <summary>
        /// String representation of the grid
        /// </summary>
        public override string ToString()
        {
            string ret = "";

            for (uint i = 0; i < numRows; ++i)
            {
                for (uint j = 0; j < numCols; ++j)
                {
                    ret += letters[new Coordinate((int)i, (int)j)] + " ";
                }
                ret = ret.Substring(0, ret.Length - 1) + "\n";
            }

            return ret;
        }
    }
}
