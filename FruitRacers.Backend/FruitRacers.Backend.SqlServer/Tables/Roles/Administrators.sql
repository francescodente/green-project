CREATE TABLE [dbo].[Administrators]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_UserAdministrators_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
