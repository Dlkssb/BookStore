--CREATE Procedure to select all Books
CREATE PROCEDURE [dbo].[GetAllBooks]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT b.[Id], b.[Name], b.[Author], b.[IsAvailable], b.[Price], b.[ShelfId], s.[Id]
    FROM [dbo].[Books] b
    INNER JOIN [dbo].[Shelves] s ON b.[ShelfId] = s.Id;
END;