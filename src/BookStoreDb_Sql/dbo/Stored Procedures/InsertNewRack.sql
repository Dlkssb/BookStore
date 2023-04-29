CREATE PROCEDURE [dbo].[InsertNewRack]
    @Code INT
AS
BEGIN
    INSERT INTO Racks(Code)
    VALUES(@Code)
END