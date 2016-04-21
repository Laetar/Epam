using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task11;

namespace Task13.Controllers
{
    public class HomeController : Controller
    {

        DAL _newDal = new DAL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrdersView()
        {
            var orderList = _newDal.ViewOrders();
            return View(orderList);
        }

        public ActionResult OrdersDetails(int id)
        {
            var orderDetails = _newDal.GetOrdersById(id);
            return View(orderDetails);
        }

        public ActionResult AddNewOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckAddNewOrder(Task11.NewOrderClass newOrder)
        {
            int checkID;
            checkID = _newDal.AddOrder(newOrder);
            return View(checkID);
        }

        
        public ActionResult AddDetails(int id)
        {
            OrderChangeViewModel updOrder = new OrderChangeViewModel(id);
            return View(updOrder);
        }

        [HttpPost]
        public ActionResult ChangeDetails (OrderChangeViewModel updOrder)
        {
            var checkIDResult = _newDal.ChangeColumn(updOrder.OrderID, updOrder.ColumnName, updOrder.ColumnValue);
            return View("CheckChangeDetails", checkIDResult);
        }

        public ActionResult CheckChangeDetails (bool checkIDResult)
        {
            return View(checkIDResult);
        }
    }
}