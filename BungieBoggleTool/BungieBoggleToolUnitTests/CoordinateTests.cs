using System;
using System.Collections.Generic;
using BungieBoggleTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BungieBoggleToolUnitTests
{
    [TestClass]
    public class CoordinateTests
    {
        [TestMethod]
        public void VerifyCoordinateEqualityHashSet()
        {
            HashSet<Coordinate> coordinateSet = new HashSet<Coordinate>();

            // Insert unique value
            coordinateSet.Add(new Coordinate(0, 0));

            // Try to insert value with the same coordinates.
            // No new item should have been added.
            coordinateSet.Add(new Coordinate(0, 0));
            Assert.AreEqual<int>(1, coordinateSet.Count);

            // Try to insert value with the new coordinates.
            // One new item should have been added.
            coordinateSet.Add(new Coordinate(2, 3));
            Assert.AreEqual<int>(2, coordinateSet.Count);

            // Try to insert value with the new coordinates twice.
            // One new item should have been added.
            coordinateSet.Add(new Coordinate(7, 5));
            coordinateSet.Add(new Coordinate(7, 5));
            Assert.AreEqual<int>(3, coordinateSet.Count);
        }

        [TestMethod]
        public void VerifyCoordinateEqualityDictionary()
        {
            Dictionary<Coordinate, bool> dictionary = new Dictionary<Coordinate, bool>();

            // Insert a kay/value
            dictionary.Add(new Coordinate(0, 0), true);

            // Find value inserted with key
            Assert.IsTrue(dictionary[new Coordinate(0, 0)]);

            // Try and find a value with invalid key
            try
            {
                bool temp = dictionary[new Coordinate(3, 5)];

                // If no exception generated, fail
                Assert.Fail();
            }
            catch (KeyNotFoundException)
            {
            }
        }
    }
}
