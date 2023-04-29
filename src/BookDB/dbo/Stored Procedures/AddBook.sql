-- Batch submitted through debugger: dbo.Procedure.sql|0|0|MSSQL::/LAPTOP_KTMJ27DA/BookStore/True/SqlProcedure/dbo.Procedure.sql
CREATE PROCEDURE [dbo].[AddBook]
@Name NVARCHAR(50),
@Author NVARCHAR(50),
@IsAvailable BIT,
@Price DECIMAL(18, 2),
@ShelfId INT
AS
BEGIN
    INSERT INTO Books (Name, Author, IsAvailable, Price, ShelfId)
    VALUES (@Name, @Author, @IsAvailable, @Price, @ShelfId)
END