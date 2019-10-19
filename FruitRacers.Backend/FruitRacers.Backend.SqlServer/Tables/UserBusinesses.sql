CREATE TABLE [dbo].[UserBusinesses]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    [VatNumber] NVARCHAR(16) NOT NULL UNIQUE, 
    [BusinessName] VARCHAR(100) NOT NULL, 
    [Sdi] NCHAR(7) NULL, 
    [Pec] NVARCHAR(60) NULL, 
    [LegalForm] NVARCHAR(10) NOT NULL, 
    [IsValid] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_UserBusinesses_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID])
)
