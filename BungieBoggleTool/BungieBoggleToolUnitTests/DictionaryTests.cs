using System;
using System.IO;
using BungieBoggleTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BungieBoggleToolUnitTests
{
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void VerifyParseFile()
        {
            StreamReader ospdFile = null;

            // Verify stream and initialize object
            try
            {
                ospdFile = new StreamReader(Resources.OSPD_FILEPATH);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
            Dictionary dictionary = new Dictionary(ospdFile);

            // Re-open stream and verify
            ospdFile.Close();
            try
            {
                ospdFile = new StreamReader(Resources.OSPD_FILEPATH);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }

            string line, temp;

            // Verify individual words and prefixes
            while (null != (line = ospdFile.ReadLine()))
            {
                if (Dictionary.MIN_WORD_LENGTH > line.Length)
                {
                    continue;
                }

                Assert.IsTrue(dictionary.Contains(line));

                temp = "";
                foreach (char c in line)
                {
                    temp += c;
                    Assert.IsTrue(dictionary.ContainsPrefix(temp));
                }
            }
        }
    }
}
