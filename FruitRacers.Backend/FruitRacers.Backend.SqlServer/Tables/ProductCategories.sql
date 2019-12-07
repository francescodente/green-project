CREATE TABLE [dbo].[ProductCategories]
(
	[ProductId] INT NOT NULL,
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [PK_ProductCategories] PRIMARY KEY ([ProductId], [CategoryId]), 
    CONSTRAINT [FK_ProductCategories_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([ProductId]), 
    CONSTRAINT [FK_ProductCategories_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([CategoryId])
)
