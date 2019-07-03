CREATE DATABASE SportShopDataBase_;
GO

USE [C:\Users\Алексей Ефимов\source\repos\SportShopDB\SportShopDB\SportShopDB.mdf];

CREATE TABLE [dbo].[Employees] 
(
  [IdEmployee] INT NOT NULL PRIMARY KEY IDENTITY,
  [FullNameEmp] NVARCHAR(100) NOT NULL, 
  [Position] NVARCHAR(35) NULL,
  [Birthday] NVARCHAR(12) NOT NULL,
  [PhoneNumberEmp] VARCHAR(14) NOT NULL
);

CREATE TABLE [dbo].[Customers]
(
  [IdCustomer] INT NOT NULL PRIMARY KEY IDENTITY,
  [FullNameCust] NVARCHAR(100) NOT NULL, 
  [PhoneNumberCust] VARCHAR(14) NOT NULL
);

CREATE TABLE [dbo].[Providers]
(
  [IdProvider] INT NOT NULL PRIMARY KEY IDENTITY,
  [NameProvider] NVARCHAR(50) NOT NULL, 
  [Representative] NVARCHAR(100) NOT NULL,
  [PhoneNumberProv] VARCHAR(14) NOT NULL
);

CREATE TABLE [dbo].[Supplies]
(
  [IdSupply] INT NOT NULL PRIMARY KEY IDENTITY,
  [IdProv] INT,
  [dateSupply] NVARCHAR(12),
  CONSTRAINT FK1 FOREIGN KEY(IdProv)
  REFERENCES [Providers] (IdProvider)
);

CREATE TABLE [dbo].[Products]
(
  [IdProduct] INT NOT NULL PRIMARY KEY IDENTITY,
  [IdSupp] INT,
  [NameProduct] NVARCHAR(40) NOT NULL,
  [TypeProduct] NVARCHAR(35) NOT NULL,
  [CostPurchase] INT,
  [CostSale] INT,
  [Availability] BIT,
  [Quantity] INT,
  CONSTRAINT FK2 FOREIGN KEY(IdSupp)
  REFERENCES [Supplies] (IdSupply)
);

CREATE TABLE [dbo].[Orders]
(
  [IdOrder] INT NOT NULL PRIMARY KEY IDENTITY,
  [IdProd] INT,
  [IdEmpl] INT,
  [IdCust] INT,
  [DateOrder] NVARCHAR(12),

  CONSTRAINT FK3 FOREIGN KEY(IdProd)
  REFERENCES [Products] (IdProduct),

  CONSTRAINT FK4 FOREIGN KEY(IdEmpl)
  REFERENCES [Employees] (IdEmployee),

  CONSTRAINT FK5 FOREIGN KEY(IdCust)
  REFERENCES [Customers] (IdCustomer)
);

GO