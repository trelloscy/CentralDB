CREATE TABLE [dbo].[SearchTerms]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Search Term] NVARCHAR(100) NOT NULL, 
    [System version] NVARCHAR(100) NULL, 
    [Phone Type] NVARCHAR(100) NULL, 
    [Network] NVARCHAR(100) NULL, 
	[Metadata] NVARCHAR(MAX) NULL,
    [Entry Date] DATETIME NOT NULL DEFAULT GETDATE()
)
