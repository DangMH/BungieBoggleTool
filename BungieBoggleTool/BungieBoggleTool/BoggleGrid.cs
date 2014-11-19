using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BungieBoggleTool
{
    public class BoggleGrid
    {
        /// <summary>
        /// Unique set of letters found inside the boggleGrid.  Used for efficiency in populating a boggleGridFile.
        /// </summary>
        private HashSet<char> uniqueLetters;
        /// <summary>
        /// Grid of Letters.
        /// </summary>
        private Dictionary<Tuple<int, int>, Letter> letters;

        /// <summary>
        /// Accessor method for uniqueLetters.
        /// </summary>
        public HashSet<char> getUniqueLetters()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Parses Boggle BoggleGrid from the BoggleGrid file.
        /// </summary>
        /// <param name="boggleGridFile">File to populate the BoggleGrid.</param>
        public void populate(System.IO.File boggleGridFile)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Accessor method to the Letter at (row, col).
        /// </summary>
        /// <param name="row">Row of the Letter.</param>
        /// <param name="col">Column of the Letter.</param>
        public Letter get(int row, int col)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Generates a BoggleGrid with the given dimensions.
        /// </summary>
        /// <param name="numRows">Number of rows in the boggleGrid.</param>
        /// <param name="numCols">Number of columns in the boggleGrid.</param>
        public void generateGrid(int numRows, int numCols)
        {
            throw new System.NotImplementedException();
        }
    }
}
