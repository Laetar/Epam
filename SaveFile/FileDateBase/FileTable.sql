CREATE TABLE [dbo].[FileTable]
(
	[FileId] INT IDENTITY(1,1) NOT NULL , 
    [File] VARBINARY(MAX) NOT NULL, 
    [UploadTime] DATETIME NOT NULL, 
    [FileName] NVARCHAR(MAX) NOT NULL ,
	CONSTRAINT [PK_FileTable] PRIMARY KEY ([FileId])
)
