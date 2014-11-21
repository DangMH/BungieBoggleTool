using System;
using BungieBoggleTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BungieBoggleToolUnitTests
{
    [TestClass]
    public class LetterTests
    {
        private static int CONSTRUCTOR_ATTEMPTS = 27;

        [TestMethod]
        public void VerifyDefaultConstructor()
        {
            Letter letter;

            for (int i = 0; i < CONSTRUCTOR_ATTEMPTS; ++i)
            {
                letter = new Letter();

                // Verify letter falls in generated range
                Assert.IsTrue(0 >= "a".CompareTo(letter.ToString())
                    || 0 <= "z".CompareTo(letter.ToString())
                    || "Qu" == letter.ToString());
            }
        }

        [TestMethod]
        public void VerifyParameterizedConstructor()
        {
            // Verify letter create for A-Z, a-z, and #
            for (char i = 'A'; i <= 'Z'; ++i)
            {
                Assert.AreEqual<string>(i.ToString(), (new Letter(i)).ToString());
            }

            for (char i = 'a'; i <= 'z'; ++i)
            {
                Assert.AreEqual<string>(i.ToString(), (new Letter(i)).ToString());
            }

            Assert.AreEqual<string>("Qu", (new Letter('#')).ToString());
        }
    }
}
