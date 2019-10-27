CREATE TABLE [dbo].[UserBusinessSuppliers]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    [Description] NVARCHAR(1000) NULL, 
    CONSTRAINT [FK_UserBusinessSuppliers_UserBusinesses] FOREIGN KEY ([UserID]) REFERENCES [UserBusinesses]([UserID])
)
