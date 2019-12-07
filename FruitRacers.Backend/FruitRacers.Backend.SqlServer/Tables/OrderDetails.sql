CREATE TABLE [dbo].[OrderDetails]
(
	[OrderId] INT NOT NULL, 
    [UnitName] NVARCHAR(5) NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 1, 
    [Price] MONEY NULL, 
    [UnitMultiplier] DECIMAL(8, 4) NULL, 
    CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([OrderId]),
    CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([ProductId]), 
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderId], [ProductId])
)
