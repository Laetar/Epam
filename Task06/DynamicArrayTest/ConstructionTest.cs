using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task03;

namespace DynamicArrayTest
{
    [TestClass]
    public class ConstructionTest
    {
        [TestMethod]
        public void StandartConstrucTest()
        {
            DynamicArray<int> testArr = new DynamicArray<int>();
            Assert.AreEqual(testArr.Length, 8);
        }

        [TestMethod]
        public void ConstrucTest1()
        {
            DynamicArray<int> testArr = new DynamicArray<int>(10);
            Assert.AreEqual(testArr.Length, 10);
        }

        [TestMethod]
        public void ConstrucTest2()
        {
            List<int> A = new List<int> { 1, 2, 3, 4 };
            DynamicArray<int> testArr = new DynamicArray<int>(A);
            Assert.AreEqual(testArr.Length, 4);
            Assert.AreEqual(testArr[0], 1);
            Assert.AreEqual(testArr[1], 2);
            Assert.AreEqual(testArr[2], 3);
            Assert.AreEqual(testArr[3], 4);
        }
    }
}
