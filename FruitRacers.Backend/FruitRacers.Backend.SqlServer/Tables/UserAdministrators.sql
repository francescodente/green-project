CREATE TABLE [dbo].[UserAdministrators]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_UserAdministrators_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID])
)
