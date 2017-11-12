IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'StatesSelectAll')
DROP PROCEDURE StatesSelectAll
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StateId, StateName
	FROM States
END

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'BathroomTypesSelectAll')
DROP PROCEDURE BathroomTypesSelectAll
GO

CREATE PROCEDURE BathroomTypesSelectAll AS
BEGIN
	SELECT [BathroomTypeId], [BathroomTypeName]
	FROM [dbo].[BathroomTypes]
	ORDER BY [BathroomTypeName]
END

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'ListingsInsert')
DROP PROCEDURE ListingsInsert
GO

CREATE PROCEDURE ListingsInsert (
	@ListingId INT output,
	@UserId NVARCHAR(128),
	@StateId CHAR(2),
	@BathroomTypeId INT,
	@Nickname NVARCHAR(50),
	@City NVARCHAR(50),
	@Rate DECIMAL(7,2),
	@SquareFootage DECIMAL(7,2),
	@HasElectric BIT,
	@HasHeat BIT,
	@ImageFileName VARCHAR(50)
) AS
BEGIN
	INSERT INTO Listings(UserId, StateId, BathroomTypeId, Nickname, City, Rate, SquareFootage, HasElectric, HasHeat, ImageFileName)
	VALUES(@UserId,@StateId,@BathroomTypeId,@Nickname,@City,@Rate,@SquareFootage,@HasElectric,@HasHeat,@ImageFileName);

	SET @ListingId = SCOPE_IDENTITY();
END

GO




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'ListingsUpdate')
DROP PROCEDURE ListingsUpdate
GO

CREATE PROCEDURE ListingsUpdate (
	@ListingId INT,
	@UserId NVARCHAR(128),
	@StateId CHAR(2),
	@BathroomTypeId INT,
	@Nickname NVARCHAR(50),
	@City NVARCHAR(50),
	@Rate DECIMAL(7,2),
	@SquareFootage DECIMAL(7,2),
	@HasElectric BIT,
	@HasHeat BIT,
	@ImageFileName VARCHAR(50)
) AS
BEGIN
	UPDATE Listings SET
		UserId = @UserId, 
		StateId = @StateId,
		BathroomTypeId = @BathroomTypeId, 
		Nickname = @Nickname, 
		City = @City, 
		Rate = @Rate, 
		SquareFootage = @SquareFootage, 
		HasElectric = @HasElectric, 
		HasHeat = @HasHeat, 
		ImageFileName = @ImageFileName
	WHERE ListingId = @ListingId
END

GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'ListingsDelete')
DROP PROCEDURE ListingsDelete
GO

CREATE PROCEDURE ListingsDelete (
	@ListingId INT
	) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Contacts WHERE ListingId = @ListingId;
	DELETE FROM Favorites WHERE ListingId = @ListingId;
	DELETE FROM Listings WHERE ListingId = @ListingId;

	COMMIT TRANSACTION
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'ListingsSelect')
DROP PROCEDURE ListingsSelect
GO

CREATE PROCEDURE ListingsSelect (
	@ListingId INT
	) AS
BEGIN
	SELECT ListingId, UserId, StateId, [BathroomTypeId], [Nickname], [City], [Rate], [SquareFootage], [HasElectric], [HasHeat], [ImageFileName]
	FROM Listings
	WHERE ListingId = @ListingId 
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'ListingSelectRecent')
DROP PROCEDURE ListingSelectRecent
GO

CREATE PROCEDURE ListingSelectRecent AS
BEGIN
	SELECT TOP 5 [ListingId], [UserId], [Rate],[City] , [StateId],[ImageFileName]
	FROM [dbo].[Listings]
	ORDER BY [CreateDate] DESC
END

GO
