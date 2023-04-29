CREATE PROCEDURE [dbo].[DeleteShelfById]
    @Id INT
AS
BEGIN
    DELETE FROM Shelves
    WHERE Id = @Id
END