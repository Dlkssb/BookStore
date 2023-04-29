--CREATE Procedure to insert a Shelf
CREATE PROCEDURE [dbo].[InsertShelf]
@Code int,
@RackId int
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[Shelves] ([Code], [RackId])
    VALUES (@Code, @RackId);
END;
