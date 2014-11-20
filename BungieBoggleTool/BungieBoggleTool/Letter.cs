using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BungieBoggleTool
{
    class Letter
    {
        /// <summary>
        /// Original char representing the block.
        /// </summary>
        private char symbol;

        /// <summary>
        /// Character(s) in the Letter block.
        /// </summary>
        private string letters;
        /// <summary>
        /// Number of legal symbols.
        /// </summary>
        private static int numSymbols = 27;

        /// <summary>
        /// Populates Letter with given string.
        /// </summary>
        /// <param name="symbol">Character(s) to Populate the Letter.</param>
        public Letter(char symbol)
        {
            if ('a' < symbol && symbol < 'z')
            {
                this.symbol = symbol;
                letters = this.symbol.ToString();
            }
            else if ('A' < symbol && symbol < 'Z')
            {
                // Convert to lower case
                this.symbol = (char)(symbol + ('a' - 'A'));
                letters = this.symbol.ToString();
            }
            else if ('#' == symbol)
            {
                this.symbol = symbol;
                letters = "qu";
            }
            else
            {
                // Allow literal ToString of other symbols for now
                this.symbol = symbol;
                letters = this.symbol.ToString();
            }
        }

        /// <summary>
        /// Default constructor.  Generates a random Letter
        /// </summary>
        public Letter()
        {
            int seed = (new Random((int)DateTime.Now.Ticks & 0x0000FFFF)).Next() % numSymbols;

            if (26 > seed)
            {
                symbol = (char)('a' + seed);
                letters = symbol.ToString();
            }
            else if (27 == seed)
            {
                symbol = '#';
                letters = "qu";
            }
        }

        /// <summary>
        /// Returns the string representation of the Letter.
        /// </summary>
        public override string ToString()
        {
            return letters;
        }
    }
}
