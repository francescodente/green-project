CREATE TABLE [dbo].[People]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [CF] NCHAR(16) NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [BirthDate] DATE NULL, 
    CONSTRAINT [FK_UserPeople_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
