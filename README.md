base de datos se realizo las consultas por cada una se creo un procedimiento almacenado los cuales se deja una copia acontinuacion:

ALTER PROCEDURE [dbo].[AddNewOrder] 
	   @empid INT, 
	   @shipperid INT, 
	   @shipname NVARCHAR(40), 
	   @shipaddress NVARCHAR(60), 
	   @shipcity NVARCHAR(15),
       @orderdate DATETIME, 
	   @requireddate DATETIME, 
	   @shippeddate DATETIME, 
	   @freight MONEY, 
	   @shipcountry NVARCHAR(15),
	   @orderid INT,
       @productid INT,
       @unitprice MONEY,
       @qty SMALLINT,
       @discount NUMERIC(4,3)
AS
BEGIN
	
	INSERT INTO [Sales].[Orders]
           ([custid]
           ,[empid]
           ,[orderdate]
           ,[requireddate]
           ,[shippeddate]
           ,[shipperid]
           ,[freight]
           ,[shipname]
           ,[shipaddress]
           ,[shipcity]
           ,[shippostalcode]
           ,[shipcountry])
     VALUES
           (1
           ,@empid
           ,@orderdate
           ,@requireddate
           ,@shippeddate
           ,@shipperid
           ,@freight
           ,@shipname
           ,@shipaddress
           ,@shipcity
           ,'10342'
           ,'France')

	 INSERT INTO [Sales].[OrderDetails]
           ([orderid]
           ,[productid]
           ,[unitprice]
           ,[qty]
           ,[discount])
     VALUES
           (@orderid
           ,@productid
           ,@unitprice
           ,@qty
           ,@discount)
END

ALTER PROCEDURE [dbo].[GetClientOrders]
 
AS
BEGIN
	
	SELECT [orderid]
      ,[requireddate]
      ,[shippeddate]
      ,[shipname]
      ,[shipaddress]
      ,[shipcity]
	FROM [StoreSample].[Sales].[Orders]

END

ALTER PROCEDURE [dbo].[GetEmployees]
 
AS
BEGIN
	
	SELECT  [empid]
      ,CONCAT([lastname],' ',[firstname]) [FullName]
	FROM [StoreSample].[HR].[Employees]

END

ALTER PROCEDURE [dbo].[GetProducts]
 
AS
BEGIN
	
	SELECT [productid]
      ,[productname]
	FROM [StoreSample].[Production].[Products]

END

ALTER PROCEDURE [dbo].[GetShippers]
 
AS
BEGIN
	
	SELECT [shipperid]
      ,[companyname]
  FROM [StoreSample].[Sales].[Shippers]

END

ALTER PROCEDURE [dbo].[SalesDatePrediction] 
AS
BEGIN
	
	DROP TABLE IF EXISTS #predict
	SELECT customer.custid, customer.companyname [CustomerName], MAX(orders.orderdate) [LastOrderDate]
	INTO #predict
	FROM [StoreSample].[Sales].[Customers] AS customer
	INNER JOIN [StoreSample].[Sales].[Orders]AS orders ON customer.custid = orders.custid
	group by customer.custid, customer.companyname

	DROP TABLE IF EXISTS #prom
	SELECT custid, DATEDIFF(DAY,MIN([orderdate]), MAX([orderdate])) /count(custid) [dias]
	INTO #prom FROM [StoreSample].[Sales].[Orders]AS orders 
	GROUP BY custid

	SELECT A.CustomerName, A.LastOrderDate, A.LastOrderDate+B.dias AS NextPredictedOrder 
	FROM #predict A INNER JOIN #prom B ON A.custid = B.custid

END

3. se realiza web api en .Netcore Version 8
4. se realiza web app en angular version 18
