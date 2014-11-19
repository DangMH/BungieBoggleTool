using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BungieBoggleTool
{
    class Dictionary
    {
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
        /// <param name="boggleGridFile">File containing the list of words.</param>
        /// <param name="dictionaryFile">File containing the words to Populate the dictionary.</param>
        /// <param name="boggleGrid">grid to check possible words against.</param>
        public Dictionary(StreamReader dictionaryFile, BoggleGrid boggleGrid)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Constructs the dictionary with the words in the dictionary file.
        /// </summary>
        /// <param name="boggleGridFile">File containing the list of words.</param>
        /// <param name="dictionaryFile">File containing the words to Populate the dictionary.</param>
        public Dictionary(StreamReader dictionaryFile)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Dictionary()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Populates the dictionary from words listed in a dictionary file.
        /// </summary>
        /// <param name="boggleGridFile">File containing the list of words.</param>
        /// <param name="boggleGridFile">File containing the list of words.</param>
        /// <param name="dictionaryFile">File containing the words to Populate the dictionary.</param>
        public void Populate(StreamReader dictionaryFile)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Populates the dictionary from words listed in a dictionary file, but only ones containing letters found in the BoggleGrid.
        /// </summary>
        /// <param name="boggleGridFile">File containing the list of words.</param>
        /// <param name="dictionaryFile">File containing the words to Populate the dictionary.</param>
        /// <param name="boggleGrid">grid to check possible words against.</param>
        public void Populate(StreamReader dictionaryFile, BoggleGrid boggleGrid)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns true if the word is found within the dictionary, else false.
        /// </summary>
        /// <param name="word">Word to be found.</param>
        public bool contains(string word)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns true if the given prefix is found in this dictionary.
        /// </summary>
        /// <param name="prefix">Prefix to be found.</param>
        public bool containsPrefix(string prefix)
        {
            throw new System.NotImplementedException();
        }
    }
}
