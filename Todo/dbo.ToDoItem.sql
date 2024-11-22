CREATE TABLE [dbo].[ToDoItem] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Title]          NVARCHAR (50)    NULL,
    [Description]    NVARCHAR (MAX)   NULL,
    [IsDone]         BIT              NULL,
    [CompletionDate] DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

