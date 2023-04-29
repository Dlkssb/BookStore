-- Batch submitted through debugger: dbo.Procedure.sql|0|0|MSSQL::/LAPTOP_KTMJ27DA/BookStore/True/SqlProcedure/dbo.Procedure.sql
--CREATE Procedure to insert Book
CREATE PROCEDURE [dbo].[InsertBook]
@Name nvarchar(50),
@Author nvarchar(50),
@IsAvailable bit,
@Price decimal(18,2),
@ShelfId int
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[Books] ([Name], [Author], [IsAvailable], [Price], [ShelfId])
    VALUES (@Name, @Author, @IsAvailable, @Price, @ShelfId);
END;