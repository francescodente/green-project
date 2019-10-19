CREATE TABLE [dbo].[ProductCategories]
(
	[ProductID] INT NOT NULL,
    [CategoryID] INT NOT NULL, 
    CONSTRAINT [PK_ProductCategories] PRIMARY KEY ([ProductID], [CategoryID]), 
    CONSTRAINT [FK_ProductCategories_Products] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ProductID]), 
    CONSTRAINT [FK_ProductCategories_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [Categories]([CategoryID])
)
