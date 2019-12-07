CREATE TABLE [dbo].[Categories]
(
	[CategoryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(30) NOT NULL, 
    [ParentCategoryId] INT NULL, 
    [ImageId] INT NULL, 
    CONSTRAINT [FK_Categories_Categories] FOREIGN KEY ([ParentCategoryId]) REFERENCES [Categories]([CategoryId]), 
    CONSTRAINT [FK_Categories_Images] FOREIGN KEY ([ImageId]) REFERENCES [Images]([ImageId])
)
