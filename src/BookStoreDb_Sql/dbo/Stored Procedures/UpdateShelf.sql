CREATE PROCEDURE [dbo].[UpdateShelf]
    @Id INT,
    @Code INT,
    @RackId INT
AS
BEGIN
    UPDATE Shelf
    SET Code = @Code,
        RackId = @RackId
    WHERE Id = @Id
END