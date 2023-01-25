--Siparişler tablosundan MusteriSirketAdi, CalisanAdiSoyadi, SiparisId, SiparisTarihi ve KargoSirketiAdi getiren sorgu

SELECT OrderID,OrderDate,
		(SELECT CompanyName FROM Customers C WHERE C.CustomerID = O.CustomerID) AS [Musteri Shirketi Adi],
		(SELECT FirstName   FROM Employees E WHERE E.EmployeeID = O.EmployeeID) AS [Chalisan adi],
		(SELECT LastName    FROM Employees E WHERE E.EmployeeID = O.EmployeeID) AS [Chalisan soyadi],
		(SELECT CompanyName FROM Shippers S  WHERE S.ShipperID = O.ShipVia)     AS [Kargo shirketi adi] 
		FROM Orders O
		ORDER BY OrderID

SELECT C.CompanyName AS [Musteri Shirketi Adi],
	   E.FirstName   AS [Chalisan adi],
	   E.LastName    AS [Chalisan soyadi],
	   O.OrderID, O.OrderDate,
	   S.CompanyName AS [Kargo shirketi adi]
	   FROM Orders O 
			LEFT JOIN Customers C ON O.CustomerID = C.CustomerID
			LEFT JOIN Employees E ON O.EmployeeID = E.EmployeeID
			LEFT JOIN Shippers  S ON O.ShipVia = S.ShipperID
       ORDER BY OrderID

--Çalışanların Adını, Soyadını, Doğum Tarihini ve Yaşını Getiren Sorgu Yazınız

SELECT FirstName AS Adi,LastName AS Soyadi,BirthDate AS [Dogum tarixi],DATEDIFF(YEAR,BirthDate,GETDATE()) AS Yashi FROM Employees


--Müşteriler tablosunda şirket adına Restaurant geçen şirketleri listeleyiniz.

SELECT CompanyName  FROM Customers WHERE CompanyName LIKE '%Restaurant%'

--Kategorilerine stoktaki ürün sayısını veren sorgu

SELECT CategoryID, SUM(UnitsInStock) AS [Stokdaki mehsul sayi] FROM Products
GROUP BY CategoryID

--Ürünler tablosuna, ürün ekleyiniz
--                    Ürün Adı : Kola
--                    Fiyat    : 5.00
--                    Stok     : 500
--                    Kategori : Beverages   => kategori adına göre bulup ekleyiniz. dinamik olacak
select * from Products
CREATE PROC sp_CategoryAdd
    @CategoryName NVARCHAR(50),
    @CategoryID INT OUT 
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM Categories WHERE CategoryName = @CategoryName)
    BEGIN
        INSERT INTO Categories (CategoryName)
        VALUES (@CategoryName)
        SET @CategoryID = @@IDENTITY;
    END
    ELSE
    BEGIN
        SELECT @CategoryID = CategoryID
          FROM Categories
         WHERE CategoryName = @CategoryName
    END
END


CREATE PROC sp_ProductAdd
    @CategoryName NVARCHAR(40),
    @ProductName NVARCHAR(50),
    @UnitsInStock SMALLINT,
    @UnitPrice MONEY = 10
AS
BEGIN
    DECLARE @CategoryID INT
    EXEC sp_CategoryAdd @CategoryName, @CategoryID OUT;
    INSERT INTO Products (ProductName,
                          UnitPrice,
                          UnitsInStock,
                          CategoryID)
    VALUES (@ProductName, @UnitPrice, @UnitsInStock, @CategoryID)
END

EXEC sp_ProductAdd  @CategoryName = 'Beverages', @ProductName = 'Kola' , @UnitsInStock= 100 , @UnitPrice = 3
select * from Products