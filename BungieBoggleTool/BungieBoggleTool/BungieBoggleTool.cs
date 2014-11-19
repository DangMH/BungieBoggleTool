using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BungieBoggleTool
{
    class BungieBoggleTool
    {
        public Dictionary dictionary
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public BoggleGrid grid
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Returns a set of all possible words found within a BoggleGrid according to the given dictionary
        /// </summary>
        /// <param name="boggleGridFile">File containing the BoggleGrid.</param>
        /// <param name="dictionaryFile">File containing the list of possible words.</param>
        public HashSet<string> FindAllWords(StreamReader boggleGridFile, StreamReader dictionaryFile)
        {
            throw new System.NotImplementedException();
        }
    }


}
