CREATE TABLE [dbo].[Addresses]
(
	[AddressID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NVARCHAR(100) NOT NULL, 
    [Latitude] REAL NOT NULL, 
    [Longitude] REAL NOT NULL, 
    [UserID] INT NOT NULL, 
    CONSTRAINT [FK_Addresses_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID])
)
