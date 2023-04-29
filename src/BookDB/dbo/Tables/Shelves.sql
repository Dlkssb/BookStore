CREATE TABLE [dbo].[Shelves] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [Code]    INT NOT NULL,
    [RackId]  INT NOT NULL,
    [RackId1] INT NULL,
    CONSTRAINT [PK_Shelves] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Shelves_Racks_RackId] FOREIGN KEY ([RackId]) REFERENCES [dbo].[Racks] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Shelves_Racks_RackId1] FOREIGN KEY ([RackId1]) REFERENCES [dbo].[Racks] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Shelves_RackId]
    ON [dbo].[Shelves]([RackId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Shelves_RackId1]
    ON [dbo].[Shelves]([RackId1] ASC);

