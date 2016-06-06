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
                command.CommandText = "select OrderID, CustomerID,EmployeeID,OrderDate,ShippedDate,Freight from Northwind.Orders";
                command.CommandType = CommandType.Text; ;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var Order = new OrderClass();
                        Order.OrderID = reader.GetInt32(0);
                        if (!reader.IsDBNull(1)) Order.CustomerID = reader.GetString(1);
                        if (!reader.IsDBNull(2)) Order.EmployeeID = reader.GetInt32(2);
                        if (!reader.IsDBNull(3)) Order.OrderDate = reader.GetDateTime(3);
                        if (reader.IsDBNull(3))
                        {
                            Order.OrderStatus = OrderClass.Status.New;
                        }
                        else if (reader.IsDBNull(4))
                        {
                            Order.OrderStatus = OrderClass.Status.InWork;
                        }
                        else
                        {
                            Order.OrderStatus = OrderClass.Status.Compl;
                        }
                        if (!reader.IsDBNull(5)) Order.Freight = (int)reader.GetSqlMoney(5);
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
                     "ShippedDate,ProductName,Northwind.[Order Details].UnitPrice,Quantity,Discount," +
                     "RequiredDate, ShipVia, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry from Northwind.Orders " +
                     "LEFT JOIN Northwind.[Order Details] ON Northwind.Orders.OrderID = Northwind.[Order Details].OrderID " +
                     "LEFT JOIN Northwind.Products ON Northwind.[Order Details].ProductID = Northwind.Products.ProductID", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) == id)
                        {
                            if (!reader.IsDBNull(0)) Order.OrderID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))  Order.CustomerID = reader.GetString(1);
                            if (!reader.IsDBNull(2))  Order.EmployeeID = reader.GetInt32(2);
                            if (!reader.IsDBNull(3))  Order.OrderDate = reader.GetDateTime(3);
                            if (reader.IsDBNull(3))
                            {
                                Order.OrderStatus = OrderClass.Status.New;
                            }
                            else if (reader.IsDBNull(4))
                            {
                                Order.OrderDate = reader.GetDateTime(3);
                                Order.OrderStatus = OrderClass.Status.InWork;
                            }
                            else
                            {
                                Order.ShippedDate = reader.GetDateTime(4);
                                Order.OrderStatus = OrderClass.Status.Compl;
                            }
                            if (!reader.IsDBNull(5)) Order.ProductsName.Add(reader.GetString(5));
                            if (!reader.IsDBNull(6)&&(!reader.IsDBNull(7))&&(!reader.IsDBNull(8)))
                                Order.Price = (double)reader.GetSqlMoney(6).ToSqlInt32() * reader.GetInt16(7) - 
                                (double)reader.GetSqlMoney(6).ToSqlInt32() * reader.GetInt16(7) * (double)reader.GetSqlSingle(8).ToSqlDouble();
                            if (!reader.IsDBNull(9)) Order.RequiredDate = reader.GetDateTime(9);
                            if (!reader.IsDBNull(10)) Order.ShipVia = reader.GetInt32(10);
                            if (!reader.IsDBNull(11)) Order.ShipName = reader.GetString(11);
                            if (!reader.IsDBNull(12)) Order.ShipAddress = reader.GetString(12);
                            if (!reader.IsDBNull(13)) Order.ShipCity = reader.GetString(13);
                            if (!reader.IsDBNull(14)) Order.ShipRegion = reader.GetString(14);
                            if (!reader.IsDBNull(15)) Order.ShipPostalCode = reader.GetString(15);
                            if (!reader.IsDBNull(16)) Order.ShipCountry = reader.GetString(16);
                        }
                    }
                }
            }
            return Order;
        }

        public int AddOrder(NewOrderClass NewOrder)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                int OrderID = 0;

                var command1 = new SqlCommand(
                    "INSERT INTO Northwind.Orders (Freight,OrderDate,ShippedDate) VALUES (@Freight,@OrderDate,@ShippedDate)", connection);

                var command2 = new SqlCommand("SELECT OrderID FROM Northwind.Orders WHERE OrderID = (SELECT MAX(OrderID) FROM Northwind.Orders)", connection);

                
            
                command1.Parameters.AddWithValue("@Freight", NewOrder.Freight);
                if (NewOrder.OrderDate == DateTime.MinValue)
                    command1.Parameters.AddWithValue("@OrderDate", DBNull.Value);
                else command1.Parameters.AddWithValue("@OrderDate", NewOrder.OrderDate);
                if (NewOrder.ShippedDate == DateTime.MinValue)
                    command1.Parameters.AddWithValue("@ShippedDate", DBNull.Value);
                else
                    command1.Parameters.AddWithValue("@ShippedDate", NewOrder.ShippedDate);

                connection.Open();

                bool check = (command1.ExecuteNonQuery() == 1);

                if (check)
                {
                    using (var reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderID = reader.GetInt32(0);
                        }
                    }
                }

                return OrderID;
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

        public int ChangeColumn(int id,string columnName, string columnValue)
        {
            DateTime _date;
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "update Northwind.Orders SET @columnName = @columnValue WHERE OrderID = @OrderID", connection);
                command.Parameters.AddWithValue("@OrderID", id);
                command.Parameters.AddWithValue("@columnName", columnName);
                if (DateTime.TryParse(columnValue, out _date))
                {
                    command.Parameters.AddWithValue("@columnValue", _date);
                }
                else command.Parameters.AddWithValue("@columnValue", columnValue);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) return id;
                else return 0;
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

}
