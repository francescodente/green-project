CREATE TABLE [dbo].[OrderDetails]
(
	[OrderID] INT NOT NULL, 
    [UnitName] NVARCHAR(5) NULL, 
    [ProductID] INT NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 1, 
    [Price] MONEY NULL, 
    [UnitMultiplier] DECIMAL(8, 4) NULL, 
    CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY ([OrderID]) REFERENCES [Orders]([OrderID]),
    CONSTRAINT [FK_OrderDetails_MeasurementUnits] FOREIGN KEY ([UnitName]) REFERENCES [MeasurementUnits]([UnitName]),
    CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ProductID]), 
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderID], [ProductID])
)
