CREATE PROCEDURE [dbo].[GetAllShelves]
AS
BEGIN
    SELECT *
    FROM Shelves s
    INNER JOIN Racks r ON r.Id = s.RackId
END