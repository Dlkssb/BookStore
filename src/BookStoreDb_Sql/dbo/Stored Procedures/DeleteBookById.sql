--CREATE Procedure to delete a Book by ID
CREATE PROCEDURE [dbo].[DeleteBookById]
@Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM [dbo].[Books]
    WHERE [Id] = @Id;
END;