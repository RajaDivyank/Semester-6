CREATE PROCEDURE [dbo].[PR_LOC_Hotel_SelectAll]
AS
BEGIN
		SELECT  [dbo].[MST_Hotel].[HotelID],
				[dbo].[MST_Hotel].[HotelName],
				[dbo].[MST_Hotel].[OwnerName],
				[dbo].[MST_Hotel].[HotelEmail],
				[dbo].[MST_Hotel].[HotelAddress],
				[dbo].[MST_Hotel].[HotelPhoneNumber],
				[dbo].[MST_Hotel].[Rating],
				[dbo].[MST_Hotel].[Modified],
				[dbo].[MST_Hotel].[Created]
FROM [dbo].[MST_Hotel]
ORDER BY [dbo].[MST_Hotel].[HotelName],
		 [dbo].[MST_Hotel].[OwnerName]
END

--================================================================

CREATE PROCEDURE [dbo].[PR_LOC_Hotel_SelectByHotelID]
	@HotelID int
AS
BEGIN
		SELECT	[dbo].[MST_Hotel].[HotelID],
				[dbo].[MST_Hotel].[HotelName],
				[dbo].[MST_Hotel].[OwnerName],
				[dbo].[MST_Hotel].[HotelEmail],
				[dbo].[MST_Hotel].[HotelAddress],
				[dbo].[MST_Hotel].[HotelPhoneNumber],
				[dbo].[MST_Hotel].[Rating],
				[dbo].[MST_Hotel].[Modified],
				[dbo].[MST_Hotel].[Created]
FROM [dbo].[MST_Hotel]
WHERE [dbo].[MST_Hotel].[HotelID]= @HotelID
ORDER BY [dbo].[MST_Hotel].[HotelName],
		 [dbo].[MST_Hotel].[OwnerName]
END

--================================================================

CREATE PROCEDURE [dbo].[PR_LOC_Hotel_DeleteByHotelID]
	@HotelID int
AS
BEGIN	
	DELETE FROM [dbo].[MST_Hotel]
	WHERE [dbo].[MST_Hotel].[HotelID] = @HotelID
END

--================================================================

CREATE PROCEDURE [dbo].[PR_LOC_Hotel_Insert_Record]
	@HotelName			varchar(100),
	@OwnerName			varchar(100),
	@HotelAddress		varchar(200),
	@HotelEmail			varchar(100),
	@HotelPhoneNumber	varchar(100),
	@Rating				decimal(3,2)
AS
BEGIN
INSERT INTO [dbo].[MST_Hotel]
(
	[dbo].[MST_Hotel].[HotelName],
	[dbo].[MST_Hotel].[OwnerName],
	[dbo].[MST_Hotel].[HotelPhoneNumber],
	[dbo].[MST_Hotel].[HotelAddress],
	[dbo].[MST_Hotel].[HotelEmail],
	[dbo].[MST_Hotel].[Rating]
)
VALUES
(
	@HotelName,
	@OwnerName,
	@HotelPhoneNumber,
	@HotelAddress,
	@HotelEmail,
	@Rating
)
END

--================================================================

CREATE PROCEDURE [dbo].[PR_LOC_Hotel_UpdateByHotelID]
	@HotelID			int,
	@HotelName			varchar(100),
	@OwnerName			varchar(100),
	@HotelPhoneNumber	varchar(100),
	@HotelAddress		varchar(200),
	@HotelEmail			varchar(100),
	@Rating				decimal(3,2)
AS
BEGIN
UPDATE [dbo].[MST_Hotel]
	
	SET [dbo].[MST_Hotel].[HotelName] = @HotelName,
		[dbo].[MST_Hotel].[OwnerName] = @OwnerName,
		[dbo].[MST_Hotel].[HotelPhoneNumber] = @HotelPhoneNumber,
		[dbo].[MST_Hotel].[HotelAddress] = @HotelAddress,
		[dbo].[MST_Hotel].[HotelEmail] = @HotelEmail,
		[dbo].[MST_Hotel].[Rating] = @Rating

	WHERE [dbo].[MST_Hotel].[HotelID] = @HotelID
END