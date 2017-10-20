CREATE TABLE [dbo].[CommonAccounts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccountName] NVARCHAR(50) NULL, 
    [Entry Date] DATETIME NOT NULL DEFAULT GETDATE()
)
