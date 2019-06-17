CREATE TABLE [dbo].[Authors] (
    [FirstName]   NVARCHAR (MAX) NULL,
    [LastName]    NVARCHAR (MAX) NULL,
    [DateOfBirth] DATETIME2 (7)  NOT NULL,
    [Nationality] NVARCHAR (MAX) NULL,
    [MiddleName]  NVARCHAR (MAX) NULL, 
    [Id] INT NOT NULL
);

