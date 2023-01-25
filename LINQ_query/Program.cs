using LINQ_query.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;

public class Proqram
{
    public static NorthwindContext context = new NorthwindContext();
    public static void Main()
    {

        //        //Linq to Entity
        //        /*SELECT OrderID,OrderDate,
        //		(SELECT CompanyName FROM Customers C WHERE C.CustomerID = O.CustomerID) AS [Musteri Shirketi Adi],
        //		(SELECT FirstName   FROM Employees E WHERE E.EmployeeID = O.EmployeeID) AS [Chalisan adi],
        //		(SELECT LastName    FROM Employees E WHERE E.EmployeeID = O.EmployeeID) AS [Chalisan soyadi],
        //		(SELECT CompanyName FROM Shippers S  WHERE S.ShipperID = O.ShipVia)     AS [Kargo shirketi adi] 
        //		FROM Orders O
        //		ORDER BY OrderID
        //         */
        //var orders = context.Orders
        //    .Join(context.Shippers, x => x.ShipVia, s => s.ShipperId, (x, s) => new
        //    {
        //        x.OrderId,
        //        x.OrderDate,
        //        x.Employee.FirstName,
        //        x.Employee.LastName,
        //        s.CompanyName
        //    });

        //foreach (var order in orders)
        //{
        //    foreach (var property in order.GetType().GetProperties())
        //    {
        //        Console.WriteLine($"{property.Name}-{property.GetValue(order)}");
        //    }
        //    Console.WriteLine(new String('-', 50));
        //}

        //        //SELECT FirstName AS Adi, LastName AS Soyadi, BirthDate AS[Dogum tarixi],DATEDIFF(YEAR, BirthDate, GETDATE()) AS Yashi FROM Employees

        //var empolyees = context.Employees
        //    .Select(x => new
        //    {
        //        x.FirstName,
        //        x.LastName,
        //        x.BirthDate,
        //        Age = DateTime.Today.Year - x.BirthDate.Value.Year
        //    });

        //foreach (var employee in empolyees)
        //{
        //    foreach (var property in employee.GetType().GetProperties())
        //    {
        //        Console.WriteLine($"{property.Name}-{property.GetValue(employee)}");
        //    }
        //    Console.WriteLine(new String('-', 50));
        //}

        //        //SELECT CompanyName FROM Customers WHERE CompanyName LIKE '%Restaurant%'

        //var custumers = context.Customers
        //   .Select(x => new
        //   {
        //       x.CompanyName
        //   })
        //   .Where(x => x.CompanyName.Contains("Restaurant"));

        //foreach (var customer in custumers)
        //{
        //    foreach (var property in customer.GetType().GetProperties())
        //    {
        //        Console.WriteLine($"{property.Name}-{property.GetValue(customer)}");
        //    }
        //    Console.WriteLine(new String('-', 50));
        //}


        //SELECT CategoryID, SUM(UnitsInStock) AS[Stokdaki mehsul sayi] FROM Products GROUP BY CategoryID

        //var products = context.Products
        //    .GroupBy(y => y.CategoryId)
        //    .Select(x => new
        //    {
        //        CategoryId =  x.Key,
        //        Cem = x.Sum(y => y.UnitsInStock),

        //    });

        //foreach (var product in products)
        //{
        //    foreach (var property in product.GetType().GetProperties())
        //    {
        //        Console.WriteLine($"{property.Name}-{property.GetValue(product)}");
        //    }
        //    Console.WriteLine(new String('-', 50));
        //}

        //var category = context.Categories
        //    .Where(x => x.CategoryName == "Baverages")
        //    .FirstOrDefault();
        //Product product = new Product()
        //{
        //    ProductName = "Koka-Kola",
        //    UnitsInStock = 300,
        //    UnitPrice = 4
        //};
        //category.Products.Add(product);
        ////context.Products.Add(product);
        //context.SaveChanges();






        //--------------------------------------------------------------------------------------------------------------------//
        //LINQ to sql
        /*SELECT OrderID,OrderDate,
       //		(SELECT CompanyName FROM Customers C WHERE C.CustomerID = O.CustomerID) AS [Musteri Shirketi Adi],
       //		(SELECT FirstName   FROM Employees E WHERE E.EmployeeID = O.EmployeeID) AS [Chalisan adi],
       //		(SELECT LastName    FROM Employees E WHERE E.EmployeeID = O.EmployeeID) AS [Chalisan soyadi],
       //		(SELECT CompanyName FROM Shippers S  WHERE S.ShipperID = O.ShipVia)     AS [Kargo shirketi adi] 
       //		FROM Orders O
       //		ORDER BY OrderID
       //         */

        //var orders = from o in context.Orders
        //             join s in context.Shippers on
        //             o.ShipVia equals s.ShipperId
        //             select new
        //             {
        //                 o.OrderId,
        //                 o.OrderDate,
        //                 o.Employee.FirstName,
        //                 o.Employee.LastName,
        //                 s.CompanyName

        //             };
        //foreach (var order in orders)
        //{
        //    foreach (var property in order.GetType().GetProperties())
        //    {
        //        Console.WriteLine($"{property.Name}-{property.GetValue(order)}");
        //    }
        //    Console.WriteLine(new String('-', 50));
        //}

        //SELECT FirstName AS Adi, LastName AS Soyadi, BirthDate AS[Dogum tarixi],DATEDIFF(YEAR, BirthDate, GETDATE()) AS Yashi FROM Employees

        //var empolyees = from e in context.Employees
        //                select new
        //                {
        //                    e.FirstName,
        //                    e.LastName,
        //                    e.BirthDate,
        //                    Age = DateTime.Now.Year - e.BirthDate.Value.Year
        //                };

        //        foreach (var employee in empolyees)
        //{
        //    foreach (var property in employee.GetType().GetProperties())
        //    {
        //        Console.WriteLine($"{property.Name}-{property.GetValue(employee)}");
        //    }
        //    Console.WriteLine(new String('-', 50));
        //}


        //SELECT CompanyName FROM Customers WHERE CompanyName LIKE '%Restaurant%'

        //var custumers = from c in context.Customers
        //                where c.CompanyName.Contains("Restaurant")
        //                select new
        //                {
        //                    c.CompanyName
        //                };


        //foreach (var customer in custumers)
        //{
        //    foreach (var property in customer.GetType().GetProperties())
        //    {
        //        Console.WriteLine($"{property.Name}-{property.GetValue(customer)}");
        //    }
        //    Console.WriteLine(new String('-', 50));
        //}



        //SELECT CategoryID, SUM(UnitsInStock) AS[Stokdaki mehsul sayi] FROM Products GROUP BY CategoryID

        //var products = from p in context.Products
        //               group p by new { p.CategoryId, p.Category.CategoryName,p.Category.Description } into g
        //               select new
        //               {
        //                   Description = g.Key,
        //                   CategoryName = g.Key,
        //                   CategoryId = g.Key,
        //                   Cem = g.Sum(p => p.UnitsInStock)
        //               };

        //foreach (var product in products)
        //{

        //    Console.WriteLine($"{product.CategoryId} {product.CategoryName} {product.Cem} {product.Description}");
        //    Console.WriteLine(new String('-', 50));
        //}





        //var category = context.Categories
        //    .Where(x => x.CategoryName == "Baverages")
        //    .FirstOrDefault();
        //Product product = new Product()
        //{
        //    ProductName = "Koka-Kola",
        //    UnitsInStock = 300,
        //    UnitPrice = 4
        //};
        //category.Products.Add(product);
        ////context.Products.Add(product);
        //context.SaveChanges();


    }
}
