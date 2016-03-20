using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    interface IDAL
    {
        IEnumerable<OrderClass> ViewOrders();
        OrderClass GetOrdersById(int id);
        bool AddOrder(OrderClass Order);
        bool ChangeOrderDate(DateTime OrderDate);
        bool ChangeShippedDate(DateTime ShippedDate);
    }
}
