using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task03;

namespace DynamicArrayTest
{
    [TestClass]
    public class MetodTest
    {
        [TestMethod]
        public void AddTest()
        {
            DynamicArray<int> testArr = new DynamicArray<int>(4);
            testArr.Add(0);
            testArr.Add(1);
            testArr.Add(2);
            testArr.Add(3);
            Assert.AreEqual(testArr[0], 0);
            Assert.AreEqual(testArr[1], 1);
            Assert.AreEqual(testArr[2], 2);
            Assert.AreEqual(testArr[3], 3);
        }

        [TestMethod]
        public void AddRangeTest()
        {
            int i;
            int[] A = new int[] { 1, 2, 3, 4 };
            int[] B = new int[] { 5, 6, 7, 8 , 9};
            DynamicArray<int> testArr = new DynamicArray<int>(A);
            testArr.AddRange(B);
            for (i = 0; i < 9; i++)
            {
                Assert.AreEqual(testArr[i], i+1);
            }
            Assert.AreEqual(testArr.Length, 9);
        }

        [TestMethod]
        public void RemoveTest()
        {
            int[] A = new int[] { 1, 2, 3, 4 };
            DynamicArray<int> testArr = new DynamicArray<int>(A);
            testArr.Remove(2);
            bool testBool = testArr.Remove(10);
            Assert.AreEqual(testArr[1], 3);
            Assert.AreEqual(testBool, false);
        }

        [TestMethod]
        public void InsertTest()
        {
            int[] A = new int[] { 1, 2, 3, 4 };
            DynamicArray<int> testArr = new DynamicArray<int>(A);
            testArr.Insert(42, 3);
            Assert.AreEqual(testArr[3], 42);
            testArr.Insert(42, testArr.Capacity);
            Assert.AreEqual(testArr[testArr.Capacity - 1], 42);
        }
    }
}
