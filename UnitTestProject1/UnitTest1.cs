using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day14;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void hexToBinaryConversionTest()
        {
            string result = Day14.Part1.convertToBinary("a0c20170");

            Assert.AreEqual("10100000110000100000000101110000", result);
        }
    }
}
