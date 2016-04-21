using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Task13.Controllers
{
    public class OrderChangeViewModel
    {
        public int OrderID { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }

        public OrderChangeViewModel(int id) { OrderID = id; }
        public OrderChangeViewModel() { OrderID = 0; }
    }
}