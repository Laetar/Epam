using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    public class DAL : IDAL
    {
        string ConnectionString = @"Data Source=(localdb)\ProjectsV12;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<OrderClass> ViewOrders()
        {
            var result = new List<OrderClass>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "select OrderID, CustomerID,EmployeeID,OrderDate,ShippedDate from Northwind.Orders", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var Order = new OrderClass();
                        Order.OrderID = reader.GetInt32(0);
                        Order.CustomerID = reader.GetString(1);
                        Order.EmployeeID = reader.GetInt32(2);
                        if (reader.GetDateTime(3) == null)
                        {
                            Order.OrderStatus = OrderClass.Status.New;
                        }
                        else if(reader.GetDateTime(4) == null)
                        {
                            Order.OrderStatus = OrderClass.Status.InWork;
                        }
                        else
                        {
                            Order.OrderStatus = OrderClass.Status.Compl;
                        }
                        result.Add(Order);
                    }
                }
            }
            return result;
        }

        public OrderClass GetOrdersById(int id)
        {
            OrderClass Order = new OrderClass();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "select O.OrderID, O.CustomerID,O.EmployeeID,OrderDate,"+
                     "ShippedDate,ProductName,OD.UnitPrice,Quantity,Discount from Northwind.Orders O" +
                     "INNER JOIN Northwind.[Order Details] OD ON O.OrderID = OD.OrderID" +
                     "INNER JOIN Northwind.Products P ON OD.ProductID = P.ProductID", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) == id)
                        {
                            Order.OrderID = reader.GetInt32(0);
                            Order.CustomerID = reader.GetString(1);
                            Order.EmployeeID = reader.GetInt32(2);
                            if (reader.GetDateTime(3) == null)
                            {
                                Order.OrderStatus = OrderClass.Status.New;
                            }
                            else if (reader.GetDateTime(4) == null)
                            {
                                Order.OrderStatus = OrderClass.Status.InWork;
                            }
                            else
                            {
                                Order.OrderStatus = OrderClass.Status.Compl;
                            }
                            Order.ProductName = Order.ProductName + reader.GetString(5);
                            Order.Price = reader.GetInt32(6) * reader.GetInt32(7) - reader.GetInt32(6) * reader.GetInt32(7) * reader.GetInt32(8);
                        }
                    }
                }
            }
            return Order;
        }

        public bool AddOrder(OrderClass Order)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "insert into Northwind.Orders (OrderID, OrderDate, ShippedDate) values(@OrderID, @OrderDate, @ShippedDate)", connection);

                command.Parameters.AddWithValue("@OrderID", Order.OrderID);
                command.Parameters.AddWithValue("@OrderDate", Order.OrderDate);
                command.Parameters.AddWithValue("@ShippedDate", Order.ShippedDate);

                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool ChangeOrderDate(DateTime OrderDate)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "insert into Northwind.Orders (OrderDate) values(@OrderDate)", connection);
                command.Parameters.AddWithValue("@OrderDate", OrderDate);
                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool ChangeShippedDate(DateTime ShippedDate)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "insert into Northwind.Orders (ShippedDate) values(@ShippedDate)", connection);
                command.Parameters.AddWithValue("@ShippedDate", ShippedDate);
                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }


    }

    // Не понял чего от меня требуют в 5 пункте

}
