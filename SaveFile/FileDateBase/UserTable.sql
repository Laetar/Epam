CREATE TABLE [dbo].[UserTable]
(
	[UserId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserName] NCHAR(10) UNIQUE NOT NULL,
    [UserPassword] NCHAR(10) NOT NULL
)
