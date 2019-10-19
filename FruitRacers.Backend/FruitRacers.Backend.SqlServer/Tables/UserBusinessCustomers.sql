CREATE TABLE [dbo].[UserBusinessCustomers]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_UserBusinessCustomers_UserBusinesses] FOREIGN KEY ([UserID]) REFERENCES [UserBusinesses]([UserID])
)
