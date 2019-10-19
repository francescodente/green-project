CREATE TABLE [dbo].[Categories]
(
	[CategoryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(30) NOT NULL, 
    [ParentCategoryID] INT NULL, 
    [ImageID] INT NULL, 
    CONSTRAINT [FK_Categories_Categories] FOREIGN KEY ([ParentCategoryID]) REFERENCES [Categories]([CategoryID]), 
    CONSTRAINT [FK_Categories_Images] FOREIGN KEY ([ImageID]) REFERENCES [Images]([ImageID])
)
