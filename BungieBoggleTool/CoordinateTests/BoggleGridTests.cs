using System;
using System.IO;
using System.Collections.Generic;
using BungieBoggleTool;
using BungieBoggleTool.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BungieBoggleToolUnitTests
{
    [TestClass]
    public class BoggleGridTests
    {
        [TestMethod]
        public void VerifyParseFile()
        {
            StreamReader boggleGridFile = null;

            // Open stream and initialize object
            try
            {
                boggleGridFile = new StreamReader(Resources.BOGGLEGRID1_FILEPATH);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
            BoggleGrid boggleGrid = new BoggleGrid(boggleGridFile);

            // Re-open stream and verify
            boggleGridFile.Close();
            try
            {
                boggleGridFile = new StreamReader(Resources.BOGGLEGRID1_FILEPATH);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }

            string expected = boggleGridFile.ReadToEnd().Trim();
            string actual = boggleGrid.ToFileString().Trim();
            Assert.AreEqual<String>(expected, actual);

            // Generate true set of unique letters and verify
            HashSet<char> expectedUniqueLetters = new HashSet<char>(expected.ToCharArray());
            Assert.IsTrue(expectedUniqueLetters.IsSupersetOf(boggleGrid.GetUniqueLetters()));
        }
    }
}
