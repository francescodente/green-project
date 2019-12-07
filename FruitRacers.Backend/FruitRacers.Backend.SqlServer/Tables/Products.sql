CREATE TABLE [dbo].[Products]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [IsEnabled] BIT NOT NULL DEFAULT 1, 
    [IsLegal] BIT NOT NULL DEFAULT 1, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [SupplierId] INT NOT NULL, 
    CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers]([UserId])
)
