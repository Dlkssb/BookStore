CREATE PROCEDURE [dbo].[DeleteRackById]
    @Id INT
AS
BEGIN
    DELETE FROM Racks
    WHERE Id = @Id
END