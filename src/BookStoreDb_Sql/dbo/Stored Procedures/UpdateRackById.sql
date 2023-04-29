CREATE PROCEDURE [dbo].[UpdateRackById]
    @Id INT,
    @Code INT
AS
BEGIN
    UPDATE Racks
    SET Code = @Code
    WHERE Id = @Id
END