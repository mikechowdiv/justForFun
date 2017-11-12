

USE ShackUp
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name = 'Contacts')
DROP TABLE  Contacts
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name = 'Favorites')
DROP TABLE  Favorites
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name = 'Listings')
DROP TABLE  Listings
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name = 'States')
DROP TABLE States
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name = 'BathroomTypes')
DROP TABLE  BathroomTypes
GO

CREATE TABLE States(
	StateId char(2) not null PRIMARY KEY,
	StateName VARCHAR(15) NOT NULL
)



CREATE TABLE BathroomTypes(
	BathroomTypeId int identity(1,1) not null PRIMARY KEY,
	BathroomTypeName VARCHAR(15) NOT NULL
)




CREATE TABLE Listings(
	ListingId int identity(1,1) not null PRIMARY KEY,
	UserId NVARCHAR(128) not null,
	StateId CHAR(2) not null FOREIGN KEY REFERENCES States(StateId),
	BathroomTypeId int null FOREIGN KEY REFERENCES BathroomTypes(BathroomTypeId),
	Nichname NVARCHAR(50) not null,
	City NVARCHAR(50) not null,
	Rate DECIMAL(7,2) not null,
	SquareFootage DECIMAL(7,2) not null,
	HasElectric BIT not null,
	HasHeat BIT not null,
	ImageFileName VARCHAR(50),
	CreateDate DATETIME2 not null DEFAULT(GETDATE())
)





CREATE TABLE Contacts(
	ListingId INT not null FOREIGN KEY REFERENCES Listings(ListingId),
	UserId NVARCHAR(128) not null,
	PRIMARY KEY(ListingId, UserId)
)




CREATE TABLE Favorites(
	ListingId INT not null FOREIGN KEY REFERENCES Listings(ListingId),
	UserId NVARCHAR(128) not null,
	PRIMARY KEY(ListingId, UserId)
)










