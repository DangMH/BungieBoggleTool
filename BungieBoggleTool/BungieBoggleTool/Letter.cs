using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BungieBoggleTool
{
    /// <summary>
    /// Class to represent a letter found on a Boggle Block
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// Original char representing the block.
        /// </summary>
        private char symbol;

        /// <summary>
        /// Original char representing the block.
        /// </summary>
        public char Symbol
        {
            get
            {
                return symbol;
            }
        }

        /// <summary>
        /// Character(s) in the Letter block.
        /// </summary>
        private string letters;

        /// <summary>
        /// Number of legal symbols.
        /// </summary>
        private static uint numSymbols = 27;

        /// <summary>
        /// Populates Letter with given string.
        /// </summary>
        /// <param name="symbol">Character(s) to Populate the Letter.</param>
        public Letter(char symbol)
        {
            if ('a' <= symbol && symbol <= 'z'
                || 'A' <= symbol && symbol <= 'Z')
            {
                this.symbol = symbol;
                letters = this.symbol.ToString();
            }
            else if ('#' == symbol)
            {
                this.symbol = symbol;
                letters = "Qu";
            }
            else
            {
                // Allow literal ToString of other symbols for now
                this.symbol = symbol;
                letters = this.symbol.ToString();
            }
        }

        /// <summary>
        /// Default constructor.  Generates a random Letter;
        /// </summary>
        public Letter()
            : this((uint)DateTime.Now.Ticks)
        {

        }

        /// <summary>
        /// Generates a randm Letter with the given seed;
        /// </summary>
        /// <param name="seed">Seed for random number generator.</param>
        public Letter(uint seed)
        {
            uint mSeed = unchecked((uint)(new Random((int)seed)).Next()) % numSymbols;

            if (26 > mSeed)
            {
                symbol = (char)('a' + mSeed);
                letters = symbol.ToString();
            }
            else if (26 == mSeed)
            {
                symbol = '#';
                letters = "Qu";
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
