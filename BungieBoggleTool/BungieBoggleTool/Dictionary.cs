using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BungieBoggleTool
{
    /// <summary>
    /// Class to represent a Dictionary to verify words found in the boggle grid.  Can be parsed according to the uniqueletters found on the grid.
    /// </summary>
    public class Dictionary
    {
        /// <summary>
        /// Minimum word size for dictionary validation.
        /// </summary>
        public static int MIN_WORD_LENGTH = 4;

        /// <summary>
        /// Set of words in the dictionary.
        /// </summary>
        private HashSet<string> words;
        /// <summary>
        /// Set of prefixes leading to available words.
        /// </summary>
        private HashSet<string> prefixes;

        /// <summary>
        /// Constructs the dictionary with the words in the dictionary file against those possible according to the boggleGrid.
        /// </summary>
        /// <param name="dictionaryFile">File containing the words to Populate the dictionary.</param>
        /// <param name="boggleGrid">grid to check possible words against.</param>
        public Dictionary(StreamReader dictionaryFile, BoggleGrid boggleGrid)
        {
            Populate(dictionaryFile, boggleGrid);
        }

        /// <summary>
        /// Constructs the dictionary with the words in the dictionary file.
        /// </summary>
        /// <param name="dictionaryFile">File containing the words to Populate the dictionary.</param>
        public Dictionary(StreamReader dictionaryFile)
            : this(dictionaryFile, null)
        {
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Dictionary()
            : this(null, null)
        {
        }

        /// <summary>
        /// Populates the dictionary from words listed in a dictionary file, but only ones containing letters found in the BoggleGrid.
        /// </summary>
        /// <param name="dictionaryFile">File containing the words to Populate the dictionary.</param>
        /// <param name="boggleGrid">grid to check possible words against.</param>
        private void Populate(StreamReader dictionaryFile, BoggleGrid boggleGrid)
        {
            HashSet<char> uniqueLetters = null;
            string line = null, prefix = null;
            bool wordPossible = true;

            words = new HashSet<string>();
            prefixes = new HashSet<string>();

            if (null == dictionaryFile)
            {
                // Return with empty dictionary
                return;
            }
            else if (null != boggleGrid)
            {
                uniqueLetters = boggleGrid.GetUniqueLetters();
            }

            while (null != (line = dictionaryFile.ReadLine()))
            {
                line = line.ToLower();
                wordPossible = true;

                // Check word against set of unique letters found in the grid
                if (MIN_WORD_LENGTH > line.Length)
                {
                    wordPossible = false;
                }
                else if (null != uniqueLetters)
                {
                    foreach (char c in line)
                    {
                        if (!uniqueLetters.Contains(c))
                        {
                            wordPossible = false;
                            break;
                        }
                    }
                }

                // Add word and prefixes
                if (wordPossible)
                {
                    words.Add(line);

                    prefix = "";
                    foreach (char c in line)
                    {
                        prefixes.Add(prefix += c);
                    }
                }
            }
        }

        /// <summary>
        /// Returns true if the word is found within the dictionary, else false.
        /// </summary>
        /// <param name="word">Word to be found.</param>
        public bool Contains(string word)
        {
            return words.Contains(word.ToLower());
        }

        /// <summary>
        /// Returns true if the given prefix is found in this dictionary.
        /// </summary>
        /// <param name="prefix">Prefix to be found.</param>
        public bool ContainsPrefix(string prefix)
        {
            return prefixes.Contains(prefix.ToLower());
        }
    }
}
