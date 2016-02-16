using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task01;

namespace UnitTestTask1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] AccesArr1;
            string[] AccesArr2;
            string[] TestArr1 = new string[] { "Abc", "Bb", "Bavjj", "Gdjjjs", "Eajs", "jGHf", "Ttr", "Kjgkjd", "EEqkjjjjjjf", "Qasjdfg", "Bdsa", "Wfda", "Avvd", "Yttf", "Sa", "P" };
            string[] TestArr2 = new string[] { "q", "a", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h" };
            AccesArr1 = StrComp.SortStr(TestArr1, StrComp.CompareStr);
            AccesArr2 = StrComp.SortStr(TestArr2, StrComp.CompareStr);
        }
    }
}
