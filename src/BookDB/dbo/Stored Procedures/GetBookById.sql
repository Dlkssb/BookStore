--CREATE Procedure to select a Book by ID
CREATE PROCEDURE [dbo].[GetBookById]
@Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT b.[Id], b.[Name], b.[Author], b.[IsAvailable], b.[Price], b.[ShelfId]
    FROM [dbo].[Books] b
    INNER JOIN [dbo].[Shelves] s ON b.[ShelfId] = s.Id 
	where b.Id=@Id ;
	
END;