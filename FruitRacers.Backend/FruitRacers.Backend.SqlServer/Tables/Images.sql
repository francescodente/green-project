CREATE TABLE [dbo].[Images]
(
	[ImageID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Path] NVARCHAR(100) NOT NULL, 
    [SupplierID] INT NULL, 
    [ProductID] INT NULL, 
    CONSTRAINT [FK_Images_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [UserBusinessSuppliers]([UserID]), 
    CONSTRAINT [FK_Images_Products] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ProductID]) 
)
