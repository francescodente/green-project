CREATE TABLE [dbo].[Addresses]
(
	[AddressId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NVARCHAR(100) NOT NULL, 
    [Latitude] FLOAT NOT NULL, 
    [Longitude] FLOAT NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Addresses_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
