CREATE TABLE [dbo].[Books] (
    [Isbn]             NVARCHAR (10)  NULL,
    [Title]            NVARCHAR (32)  NULL,
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CreatedTimeStamp] DATETIME2 (7)  DEFAULT (getdate()) NOT NULL,
    [AuthorId]         INT NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IsbnIndex]
    ON [dbo].[Books]([Isbn] ASC) WHERE ([Isbn] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [IX_Books_AuthorId1]
    ON [dbo].[Books]([AuthorId] ASC);

