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
        public int Price { get; set; }
        public string ProductName { get; set; }
        public Status OrderStatus { get; set; }

        public OrderClass() { OrderID = 0; }


    }
}
