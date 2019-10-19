CREATE TABLE [dbo].[UserDeliveryCompanies]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_UserDeliveryCompanies_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID])
)
