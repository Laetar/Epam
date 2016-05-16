CREATE TABLE [dbo].[TagTable]
(
	[FileId] INT NOT NULL , 
    [Tag] NCHAR(30) NOT NULL, 
	CONSTRAINT [FK_FileTable_TagTable] FOREIGN KEY ([FileId]) REFERENCES [FileTable] ([FileId]), 
    CONSTRAINT [PK_TagTable] PRIMARY KEY ([FileId], [Tag])
)
