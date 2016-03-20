using System;
using Task11;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DALModulTest
{
    [TestClass]
    public class UnitTest1
    {
        DAL NewDal = new DAL();

        [TestMethod]
        public void TestViewOrders()
        {
            var TestList = NewDal.ViewOrders();
        }

        [TestMethod]
        public void TestGetOrdersById()
        {
            var TestOrder = NewDal.GetOrdersById(1223);
        }
        
        //Не смог найти решение проблемы. Ридер не видет таблицу Orders
    }
}
