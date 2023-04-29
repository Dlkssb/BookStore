CREATE PROCEDURE [dbo].[DeleteBook]
    @Id INT
AS
BEGIN
    DELETE FROM Books
    WHERE Id = @Id
END