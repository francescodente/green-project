CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NVARCHAR(60) NOT NULL UNIQUE, 
    [Password] NVARCHAR(256) NOT NULL, 
    [Salt] NVARCHAR(256) NOT NULL, 
    [Telephone] NVARCHAR(20) NULL, 
    [CookieConsent] BIT NOT NULL DEFAULT 0, 
    [MarketingConsent] BIT NOT NULL DEFAULT 0, 
    [IsEnabled] BIT NOT NULL DEFAULT 1, 
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
