using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task03;

namespace DynamicArrayTest
{
    [TestClass]
    public class CriticalMetodTest
    {
        [TestMethod]
        public void CritAddTest()
        {
            DynamicArray<int> testArr = new DynamicArray<int>(4);
            testArr.Add(0);
            testArr.Add(1);
            testArr.Add(2);
            testArr.Add(3);
            testArr.Add(4);
            Assert.AreEqual(testArr[0], 0);
            Assert.AreEqual(testArr[1], 1);
            Assert.AreEqual(testArr[2], 2);
            Assert.AreEqual(testArr[3], 3);
            Assert.AreEqual(testArr[4], 4);
            Assert.AreEqual(testArr.Length, 8);
        }

        [TestMethod]
        public void AddRangeTest()
        {
            int i;
            DynamicArray<int> testArr = new DynamicArray<int>(4);
            int[] A = new int[] { 1, 2, 3, 4, 5 };
            testArr.AddRange(A);
            for (i = 0; i < 5; i++)
            {
                Assert.AreEqual(testArr[i], i + 1);
            }
            Assert.AreEqual(testArr.Length, 5);
        }

        [TestMethod]
        public void CritInsertTest()
        {
            DynamicArray<int> testArr = new DynamicArray<int>();
            testArr.Insert(1, 0);
            Assert.AreEqual(testArr[0], 1);
        }
    }
}
