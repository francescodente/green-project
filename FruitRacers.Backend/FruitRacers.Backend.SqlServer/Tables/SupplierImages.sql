CREATE TABLE [dbo].[SupplierImages]
(
	[SupplierId] INT NOT NULL, 
    [ImageId] INT NOT NULL, 
    [Order] INT NOT NULL, 
    CONSTRAINT [PK_SupplierImages] PRIMARY KEY ([SupplierId], [ImageId]), 
    CONSTRAINT [FK_SupplierImages_Suppliers] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers]([UserId]),
    CONSTRAINT [FK_SupplierImages_Images] FOREIGN KEY ([ImageId]) REFERENCES [Images]([ImageId])

)
