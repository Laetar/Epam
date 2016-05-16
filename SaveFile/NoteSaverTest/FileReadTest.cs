using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;

namespace NoteSaverTest
{
    [TestClass]
    public class FileReadTest
    {
        MyDAL myDal = new MyDAL();

        [TestMethod]
        public void ReadFileTest()
        {
            myDal.GetFile(7);
        }

        UserDAL myUserDAL = new UserDAL();

        [TestMethod]
        public void RegTest()
        {
            myUserDAL.RegistrationUser("TestName", "TestPasss");
        }

        [TestMethod]
        public void ChechAccTest()
        {
            var test = myUserDAL.CheckUser("TestName", "TestPass");
        }

    }
}
