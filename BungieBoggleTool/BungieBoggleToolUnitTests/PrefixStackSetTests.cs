using System;
using BungieBoggleTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BungieBoggleToolUnitTests
{
    [TestClass]
    public class PrefixStackSetTests
    {
        [TestMethod]
        public void VerifySetFunctionality()
        {
            PrefixStackSet prefixStackSet = new PrefixStackSet();

            // Insert unique value
            Assert.IsTrue(prefixStackSet.Push(Tuple.Create<Coordinate, Letter>(new Coordinate(0, 0), new Letter('A'))));
            Assert.AreEqual<string>("A", prefixStackSet.ToString());
            Assert.AreEqual<int>(1, prefixStackSet.Count);

            // Try to insert value with the same coordinates.
            // No new item should have been added.
            Assert.IsFalse(prefixStackSet.Push(Tuple.Create<Coordinate, Letter>(new Coordinate(0, 0), new Letter('B'))));
            Assert.AreEqual<string>("A", prefixStackSet.ToString());
            Assert.AreEqual<int>(1, prefixStackSet.Count);

            // Try to insert value with the new coordinates.
            // One new item should have been added.
            Assert.IsTrue(prefixStackSet.Push(Tuple.Create<Coordinate, Letter>(new Coordinate(2, 3), new Letter('c'))));
            Assert.AreEqual<string>("Ac", prefixStackSet.ToString());
            Assert.AreEqual<int>(2, prefixStackSet.Count);

            // Try to insert value with the new coordinates twice.
            // One new item should have been added.
            Assert.IsTrue(prefixStackSet.Push(Tuple.Create<Coordinate, Letter>(new Coordinate(7, 5), new Letter('#'))));
            Assert.AreEqual<string>("AcQu", prefixStackSet.ToString());
            Assert.AreEqual<int>(3, prefixStackSet.Count);

            Assert.IsFalse(prefixStackSet.Push(Tuple.Create<Coordinate, Letter>(new Coordinate(7, 5), new Letter('#'))));
            Assert.AreEqual<string>("AcQu", prefixStackSet.ToString());
            Assert.AreEqual<int>(3, prefixStackSet.Count);
        }

        [TestMethod]
        public void VerifyStackFunctionality()
        {
            PrefixStackSet prefixStackSet = new PrefixStackSet();
            Tuple<Coordinate, Letter> node;

            // Insert the word 'A','#','U','I','T'-> "AQuIT"
            Assert.IsTrue(prefixStackSet.Push(Tuple.Create<Coordinate, Letter>(new Coordinate(0, 0), new Letter('A'))));
            Assert.IsTrue(prefixStackSet.Push(Tuple.Create<Coordinate, Letter>(new Coordinate(0, 1), new Letter('#'))));
            Assert.IsTrue(prefixStackSet.Push(Tuple.Create<Coordinate, Letter>(new Coordinate(0, 2), new Letter('I'))));
            Assert.IsTrue(prefixStackSet.Push(Tuple.Create<Coordinate, Letter>(new Coordinate(0, 3), new Letter('T'))));
            Assert.AreEqual<string>("AQuIT", prefixStackSet.ToString());
            Assert.AreEqual<int>(4, prefixStackSet.Count);

            // Peek and verify "AQuIT"
            node = prefixStackSet.Peek();
            Assert.AreEqual<Coordinate>(new Coordinate(0, 3), node.Item1);
            Assert.AreEqual<string>("T", node.Item2.ToString());
            Assert.AreEqual<string>("AQuIT", prefixStackSet.ToString());
            Assert.AreEqual<int>(4, prefixStackSet.Count);

            // Pop and verify "AQuI"
            node = prefixStackSet.Pop();
            Assert.AreEqual<Coordinate>(new Coordinate(0, 3), node.Item1);
            Assert.AreEqual<string>("T", node.Item2.ToString());
            Assert.AreEqual<string>("AQuI", prefixStackSet.ToString());
            Assert.AreEqual<int>(3, prefixStackSet.Count);

            // Pop and verify "AQu"
            node = prefixStackSet.Pop();
            Assert.AreEqual<Coordinate>(new Coordinate(0, 2), node.Item1);
            Assert.AreEqual<string>("I", node.Item2.ToString());
            Assert.AreEqual<string>("AQu", prefixStackSet.ToString());
            Assert.AreEqual<int>(2, prefixStackSet.Count);

            // Pop and verify "A"
            node = prefixStackSet.Pop();
            Assert.AreEqual<Coordinate>(new Coordinate(0, 1), node.Item1);
            Assert.AreEqual<string>("Qu", node.Item2.ToString());
            Assert.AreEqual<string>("A", prefixStackSet.ToString());
            Assert.AreEqual<int>(1, prefixStackSet.Count);

            // Pop and verify "A"
            node = prefixStackSet.Pop();
            Assert.AreEqual<Coordinate>(new Coordinate(0, 0), node.Item1);
            Assert.AreEqual<string>("A", node.Item2.ToString());
            Assert.AreEqual<string>("", prefixStackSet.ToString());
            Assert.AreEqual<int>(0, prefixStackSet.Count);
        }
    }
}
