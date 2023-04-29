CREATE TABLE [dbo].[Books] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX)  NOT NULL,
    [Author]      NVARCHAR (MAX)  NOT NULL,
    [IsAvailable] BIT             NOT NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [ShelfId]     INT             NOT NULL,
    [ShelfId1]    INT             NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Books_Shelves_ShelfId] FOREIGN KEY ([ShelfId]) REFERENCES [dbo].[Shelves] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Books_Shelves_ShelfId1] FOREIGN KEY ([ShelfId1]) REFERENCES [dbo].[Shelves] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Books_ShelfId]
    ON [dbo].[Books]([ShelfId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Books_ShelfId1]
    ON [dbo].[Books]([ShelfId1] ASC);

