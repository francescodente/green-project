CREATE TABLE [dbo].[ProductImages]
(
	[ProductId] INT NOT NULL, 
    [ImageId] INT NOT NULL, 
    [Order] INT NOT NULL, 
    CONSTRAINT [PK_ProductImages] PRIMARY KEY ([ProductId], [ImageId]),
    CONSTRAINT [FK_ProductImages_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([ProductId]),
    CONSTRAINT [FK_ProductImages_Images] FOREIGN KEY ([ImageId]) REFERENCES [Images]([ImageId])
)
