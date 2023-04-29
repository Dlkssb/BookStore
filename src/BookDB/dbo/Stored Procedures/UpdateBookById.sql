--CREATE Procedure to update a Book by ID
CREATE PROCEDURE [dbo].[UpdateBookById]
@Id INT,
@Name nvarchar(50),
@Author nvarchar(50),
@IsAvailable bit,
@Price decimal(18,2),
@ShelfId int
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [dbo].[Books]
    SET [Name] = @Name, [Author] = @Author, [IsAvailable] = @IsAvailable, [Price] = @Price, [ShelfId] = @ShelfId
    WHERE [Id] = @Id;
END;