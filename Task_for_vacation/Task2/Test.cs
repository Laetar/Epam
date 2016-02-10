using System;
using Task1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestAsserArrList()
        {
            ArrList<int> A = new ArrList<int>();
            A.Append(1);
            A.Append(2);
            A.Append(3);
            A.Append(4);

            //Get
            //Стандартное решение
            int testnum = A.Get(1);
            Assert.AreEqual(2, testnum);

            //Граничное решение
            testnum = A.Get(A.collElem - 1);
            Assert.AreEqual(4, testnum);

            //Delete
            //Стандартное решение
            A.Delete(2);
            testnum = A.Get(2);
            Assert.AreEqual(4, testnum);

            //Граничное решение
            A.Delete(A.collElem - 1);
            testnum = A.Get(A.collElem - 1);
            Assert.AreEqual(2, testnum);

            //FindElem
            ArrList<int> B = new ArrList<int>();
            B.Append(1);
            B.Append(2);
            B.Append(3);
            B.Append(4);
            //Стандартное решение
            testnum = B.FindElem(3);
            Assert.AreEqual(2, testnum);

            //Исключительная ситуация
            testnum = B.FindElem(10);
            Assert.AreEqual(-1, testnum);

            //Insert
            //Стандартное решение
            B.Insert(42, 3);
            Assert.AreEqual(42, B.Get(3));
            //Граничное решение
            int index = B.collElem;
            B.Insert(42, index);
            Assert.AreEqual(42, B.Get(index));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestExceptionArrList()
        {
            ArrList<int> A = new ArrList<int>();
            A.Append(1);
            A.Append(2);
            A.Append(3);
            A.Append(4);

            //Get
            int testnum = A.Get(10);
            //Delete
            A.Delete(10);
            //Insert
            A.Insert(42, 42);
        }

        [TestMethod]
        public void TestAsserLinkList()
        {
            LinkList<int> A = new LinkList<int>();
            A.Append(1);
            A.Append(2);
            A.Append(3);
            A.Append(4);

            //Get
            //Стандартное решение
            int testnum = A.Get(1);
            Assert.AreEqual(2, testnum);

            //Граничное решение
            testnum = A.Get(A.collElem - 1);
            Assert.AreEqual(4, testnum);

            //Delete
            //Стандартное решение
            A.Delete(2);
            testnum = A.Get(2);
            Assert.AreEqual(4, testnum);

            //Граничное решение
            A.Delete(A.collElem - 1);
            testnum = A.Get(A.collElem - 1);
            Assert.AreEqual(2, testnum);

            //FindElem
            LinkList<int> B = new LinkList<int>();
            B.Append(1);
            B.Append(2);
            B.Append(3);
            B.Append(4);
            //Стандартное решение
            testnum = B.FindElem(3);
            Assert.AreEqual(2, testnum);

            //Исключительная ситуация
            testnum = B.FindElem(10);
            Assert.AreEqual(-1, testnum);

            //Insert
            //Стандартное решение
            B.Insert(42, 3);
            Assert.AreEqual(42, B.Get(3));
            //Граничное решение
            int index = B.collElem;
            B.Insert(42, index);
            Assert.AreEqual(42, B.Get(index));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestExceptionLinkList()
        {
            ArrList<int> A = new ArrList<int>();
            A.Append(1);
            A.Append(2);
            A.Append(3);
            A.Append(4);

            //Get
            int testnum = A.Get(10);
            //Delete
            A.Delete(10);
            //Insert
            A.Insert(42, 42);
        }

        [TestMethod]
        public void TestAsserArrQueue()
        {
            ArrQueue<int> A = new ArrQueue<int>();

            A.Add(1);
            A.Add(2);
            A.Add(3);
            A.Add(4);
            A.Add(5);

            //Take
            //Normal
            int testnum1 = A.Take(); //1-st
            int testnum2 = A.Take(); //2-st
            Assert.AreEqual(1, testnum1);
            Assert.AreEqual(2, testnum2);
            //Edge
            A.Take(); //3-st
            A.Take(); //4-st
            A.Take(); //5-st!
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestExceptionArrQueue()
        {
            ArrQueue<int> A = new ArrQueue<int>();

            A.Add(1);
            A.Add(2);
            A.Add(3);
            A.Add(4);
            A.Add(5);

            //Take
            int testnum1 = A.Take(); //1-st
            int testnum2 = A.Take(); //2-st
            A.Take(); //3-st
            A.Take(); //4-st
            A.Take(); //5-st!
            A.Take(); //Несуществующий 
        }

        [TestMethod]
        public void TestAsserLinkQueue()
        {
            LinkQueue<int> A = new LinkQueue<int>();

            A.Add(1);
            A.Add(2);
            A.Add(3);
            A.Add(4);
            A.Add(5);

            //Take
            //Normal
            int testnum1 = A.Take(); //1-st
            int testnum2 = A.Take(); //2-st
            Assert.AreEqual(1, testnum1);
            Assert.AreEqual(2, testnum2);
            //Edge
            A.Take(); //3-st
            A.Take(); //4-st
            A.Take(); //5-st!
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestExceptionLinkQueue()
        {
            ArrQueue<int> A = new ArrQueue<int>();

            A.Add(1);
            A.Add(2);
            A.Add(3);
            A.Add(4);
            A.Add(5);

            //Take
            int testnum1 = A.Take(); //1-st
            int testnum2 = A.Take(); //2-st
            A.Take(); //3-st
            A.Take(); //4-st
            A.Take(); //5-st!
            A.Take(); //Несуществующий 
        }

        [TestMethod]
        public void TestAsserArrStack()
        {
            ArrStack<int> A = new ArrStack<int>();

            A.Push(1);
            A.Push(2);
            A.Push(3);
            A.Push(4);
            A.Push(5);

            //Pop
            //Normal
            int testnum1 = A.Pop(); //1
            int testnum2 = A.Pop(); //2
            Assert.AreEqual(5, testnum1);
            Assert.AreEqual(4, testnum2);
            //Edge
            A.Pop(); //3
            A.Pop(); //4
            A.Pop(); //5
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestExceptionrArrStack()
        {
            ArrStack<int> A = new ArrStack<int>();

            A.Push(1);
            A.Push(2);
            A.Push(3);
            A.Push(4);
            A.Push(5);

            //Take
            int testnum1 = A.Pop(); //1-st
            int testnum2 = A.Pop(); //2-st
            A.Pop(); //3-st
            A.Pop(); //4-st
            A.Pop(); //5-st!
            A.Pop(); //Несуществующий 
        }

        [TestMethod]
        public void TestAsserLinkStack()
        {
            LinkStack<int> A = new LinkStack<int>();

            A.Push(1);
            A.Push(2);
            A.Push(3);
            A.Push(4);
            A.Push(5);

            //Pop
            //Normal
            int testnum1 = A.Pop(); //1
            int testnum2 = A.Pop(); //2
            Assert.AreEqual(5, testnum1);
            Assert.AreEqual(4, testnum2);
            //Edge
            A.Pop(); //3
            A.Pop(); //4
            A.Pop(); //5
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestExceptionLinkStack()
        {
            ArrStack<int> A = new ArrStack<int>();

            A.Push(1);
            A.Push(2);
            A.Push(3);
            A.Push(4);
            A.Push(5);

            //Take
            int testnum1 = A.Pop(); //1-st
            int testnum2 = A.Pop(); //2-st
            A.Pop(); //3-st
            A.Pop(); //4-st
            A.Pop(); //5-st!
            A.Pop(); //Несуществующий 
        }
    }
}
