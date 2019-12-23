CREATE TABLE [dbo].[Suppliers]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [Description] NVARCHAR(1000) NULL, 
	[VatNumber] NVARCHAR(16) NOT NULL UNIQUE, 
    [BusinessName] NVARCHAR(100) NOT NULL, 
    [Sdi] NCHAR(7) NULL, 
    [Pec] NVARCHAR(60) NULL, 
    [LegalForm] NVARCHAR(10) NOT NULL, 
    [IsValid] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Suppliers_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
