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
            var TestList = NewDal.GetAll();
        }

        //[TestMethod]
        //public void TestGetOrdersById()
        //{
           // var TestOrder = NewDal.GetOrdersById(11039);
       // }

        /*[TestMethod]
        public void TestAddOrder()
        {
            OrderClass Order = new OrderClass();
            Order.OrderID = 10000;
            NewDal.AddOrder(Order);
        }

        [TestMethod]
        public void ChangeOrderDate()
        {
            DateTime OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            NewDal.ChangeOrderDate(OrderDate);
        }

        [TestMethod]
        public void ChangeShippedDate()
        {
            DateTime OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            NewDal.ChangeShippedDate(OrderDate);
        }*/

    }
}
