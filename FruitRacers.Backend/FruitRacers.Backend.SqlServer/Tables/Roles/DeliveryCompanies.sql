CREATE TABLE [dbo].[DeliveryCompanies]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_UserDeliveryCompanies_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
