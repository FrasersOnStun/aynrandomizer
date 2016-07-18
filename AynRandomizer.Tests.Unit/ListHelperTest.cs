using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using CryptographicRandomGenerator.Helpers;

namespace AynRandomizer.Tests.Unit
{
    [TestFixture]
    public class ListHelpersTest
    {
        [Test]
        public void ShuffleULong_equallyRepresentsAllPermutations()
        {
            Dictionary<string, int> tally = new Dictionary<string, int>
            {
                {"123",0},
                {"132",0},
                {"213",0},
                {"231",0},
                {"312",0},
                {"321",0},
            };

            for (var count = 0; count < 1000000; count++)
            {
                List<int> testList = new List<int> { 1, 2, 3 };
                ListHelpers.ShuffleULong(testList);
                string key = "";
                foreach (var i in testList)
                {
                    key += i;
                }
                tally[key]++;
            }

            Assert.That((tally.Values.Max() - tally.Values.Min()) / tally.Values.Average(), Is.LessThan(0.01));
        }
    }
}
