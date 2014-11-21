using System;
using System.IO;
using BungieBoggleTool;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BungieBoggleToolUnitTests
{
    [TestClass]
    public class BungieBoggleToolTests
    {
        private BoggleGrid boggleGrid = null;
        private Dictionary dictionary = null;
        private HashSet<string> foundWords = null;
        private HashSet<string> wordsToFind = null;

        public BungieBoggleToolTests()
        {
            boggleGrid = new BoggleGrid();
            dictionary = new Dictionary();
            foundWords = new HashSet<string>();
            wordsToFind = new HashSet<string>();
        }

        [TestMethod]
        public void VerifyBungieBoard()
        {
            Initialize(Resources.OSPD_FILEPATH, Resources.BOGGLEGRID1_FILEPATH);

            foundWords = BungieBoggleTool.BungieBoggleTool.FindAllWords(dictionary, boggleGrid);
            wordsToFind.ExceptWith(foundWords);

            Assert.AreEqual<int>(0, wordsToFind.Count);
        }

        [TestMethod]
        public void VerifySimpleBoard()
        {
            Initialize(Resources.OSPD_FILEPATH, Resources.BOGGLEGRID2_FILEPATH);

            foundWords = BungieBoggleTool.BungieBoggleTool.FindAllWords(dictionary, boggleGrid);
            wordsToFind.ExceptWith(foundWords);

            Assert.AreEqual<int>(0, wordsToFind.Count);
        }

        // 6 x 6 board from http://www.hanginghyena.com/solvers/6x6-boggle-solver
        // Solutions parsed from ospd.txt file
        [TestMethod]
        public void VerifyGeneratedBoard0()
        {
            Initialize(Resources.OSPD_FILEPATH, Resources.GenerateGeneratedGridFilePath(0));

            foundWords = BungieBoggleTool.BungieBoggleTool.FindAllWords(dictionary, boggleGrid);
            wordsToFind.ExceptWith(foundWords);

            Assert.AreEqual<int>(0, wordsToFind.Count);
        }

        // 6 x 6 board from http://www.hanginghyena.com/solvers/6x6-boggle-solver
        // Solutions parsed from ospd.txt file
        [TestMethod]
        public void VerifyGeneratedBoard1()
        {
            Initialize(Resources.OSPD_FILEPATH, Resources.GenerateGeneratedGridFilePath(1));

            foundWords = BungieBoggleTool.BungieBoggleTool.FindAllWords(dictionary, boggleGrid);
            wordsToFind.ExceptWith(foundWords);

            Assert.AreEqual<int>(0, wordsToFind.Count);
        }

        // 6 x 6 board from http://www.hanginghyena.com/solvers/6x6-boggle-solver
        // Solutions parsed from ospd.txt file
        [TestMethod]
        public void VerifyGeneratedBoard2()
        {
            Initialize(Resources.OSPD_FILEPATH, Resources.GenerateGeneratedGridFilePath(1));

            foundWords = BungieBoggleTool.BungieBoggleTool.FindAllWords(dictionary, boggleGrid);
            wordsToFind.ExceptWith(foundWords);

            Assert.AreEqual<int>(0, wordsToFind.Count);
        }

        // 10 x 10 Board from http://www.wordsolver.co.uk/
        // Solutions parsed from ospd.txt file
        [TestMethod]
        public void VerifyGeneratedBoard3()
        {
            Initialize(Resources.OSPD_FILEPATH, Resources.GenerateGeneratedGridFilePath(3));

            foundWords = BungieBoggleTool.BungieBoggleTool.FindAllWords(dictionary, boggleGrid);
            wordsToFind.ExceptWith(foundWords);

            Assert.AreEqual<int>(0, wordsToFind.Count);
        }

        private void Initialize(string dictionaryFilePath, string gridFilePath)
        {
            StreamReader solutionFile = null;
            String line = null;

            try
            {
                boggleGrid = new BoggleGrid(new StreamReader(gridFilePath));
                dictionary = new Dictionary(new StreamReader(dictionaryFilePath));
                solutionFile = new StreamReader(Resources.GenerateGridSolutionFilePath(gridFilePath));
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }

            while (null != (line = solutionFile.ReadLine()))
            {
                if (Dictionary.MIN_WORD_LENGTH <= line.Length)
                {
                    wordsToFind.Add(line.ToLower().Trim());
                }
            }
        }
    }
}
