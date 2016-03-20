using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    public class DAL : IDAL
    {
        string ConnectionString = @"Data Source=(localdb)\ProjectsV12;Database=Northwind;Integrated Security=True;";

        public IEnumerable<OrderClass> ViewOrders()
        {
            var result = new List<OrderClass>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "select OrderID, CustomerID,EmployeeID,OrderDate,ShippedDate from Northwind.Orders";
                command.CommandType = CommandType.Text; ;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var Order = new OrderClass();
                        Order.OrderID = reader.GetInt32(0);
                        Order.CustomerID = reader.GetString(1);
                        Order.EmployeeID = reader.GetInt32(2);
                        //Order.ShippedDate = reader.GetSqlDateTime(4).ToString();
                        if (reader.GetSqlDateTime(3).ToString() == "Null")
                        {
                            Order.OrderStatus = OrderClass.Status.New;
                        }
                        else if (reader.GetSqlDateTime(4).ToString() == "Null")
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
                    "select Northwind.Orders.OrderID, Northwind.Orders.CustomerID,Northwind.Orders.EmployeeID,OrderDate," +
                     "ShippedDate,ProductName,Northwind.[Order Details].UnitPrice,Quantity,Discount from Northwind.Orders " +
                     "INNER JOIN Northwind.[Order Details] ON Northwind.Orders.OrderID = Northwind.[Order Details].OrderID " +
                     "INNER JOIN Northwind.Products ON Northwind.[Order Details].ProductID = Northwind.Products.ProductID", connection);
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
                            if (reader.GetSqlDateTime(3).ToString() == "Null")
                            {
                                Order.OrderStatus = OrderClass.Status.New;
                            }
                            else if (reader.GetSqlDateTime(4).ToString() == "Null")
                            {
                                Order.OrderDate = reader.GetDateTime(3);
                                Order.OrderStatus = OrderClass.Status.InWork;
                            }
                            else
                            {
                                Order.ShippedDate = reader.GetDateTime(4);
                                Order.OrderStatus = OrderClass.Status.Compl;
                            }
                            Order.ProductName = Order.ProductName + reader.GetString(5);
                            Order.Price = (double)reader.GetSqlMoney(6).ToSqlInt32() * reader.GetInt16(7) - (double)reader.GetSqlMoney(6).ToSqlInt32() * reader.GetInt16(7) * (double)reader.GetSqlSingle(8).ToSqlDouble();
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
                    "SET IDENTITY_INSERT Northwind.Orders ON insert into Northwind.Orders (OrderID) values(@OrderID) SET IDENTITY_INSERT Northwind.Orders OFF ", connection);

                command.Parameters.AddWithValue("@OrderID", Order.OrderID);
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
