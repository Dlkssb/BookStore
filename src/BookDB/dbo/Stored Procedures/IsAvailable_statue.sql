--CREATE Procedure to update a Book by ID
CREATE PROCEDURE [dbo].[IsAvailable_statue]
@Id INT

AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [dbo].[Books]
    SET [IsAvailable] = 0
    WHERE [Id] = @Id;
END;