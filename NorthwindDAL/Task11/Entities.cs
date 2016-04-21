using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    public class OrderClass
    {
        public enum Status {New, InWork, Compl}


        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public double Price { get; set; }
        public List<string> ProductsName { get; set; }
        public Status OrderStatus { get; set; }
        public int Freight { get; set; }
        public DateTime RequiredDate { get; set; }
        public int ShipVia { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public OrderClass() { OrderID = 0; ProductsName = new List<string>(); }


    }

    public class NewOrderClass
    {
        public int Freight { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
    }
}
