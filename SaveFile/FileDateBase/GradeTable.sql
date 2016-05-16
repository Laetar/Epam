CREATE TABLE [dbo].[GradeTable]
(
	[FileId] INT NOT NULL , 
    [UserId] INT NOT NULL, 
    [CheckGrade] BIT NULL DEFAULT NULL, 
    CONSTRAINT [PK_GradeTable] PRIMARY KEY ([FileId], [UserId]), 
    CONSTRAINT [FK_GradeTable_ToFileTable] FOREIGN KEY ([FileId]) REFERENCES [FileTable]([FileId]), 
    CONSTRAINT [FK_GradeTable_ToUserTable] FOREIGN KEY ([UserId]) REFERENCES [UserTable](UserId)
)
