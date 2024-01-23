CREATE OR ALTER PROCEDURE [dbo].[PR_Room_SelectAll]
AS
BEGIN
	SELECT 
		[dbo].[MST_Room].[RoomID],
		[dbo].[MST_Room].[HotelID],
		[dbo].[MST_Room].[UserID],
		[dbo].[MST_Room].[RoomTypeID],
		[dbo].[MST_Room].[StatusID],
		[dbo].[MST_Room].[RoomImage],
		[dbo].[MST_Room].[ChildCapacity],
		[dbo].[MST_Room].[AdultCapacity],
		[dbo].[MST_Room].[CheckInDate],
		[dbo].[MST_Room].[CheckOutDate],
		[dbo].[MST_Room].[Created],
		[dbo].[MST_Room].[Modified],
		[dbo].[MST_RoomType].[TypeName],
		[dbo].[MST_RoomStatus].[Status],
		[dbo].[MST_User].[UserName],
		[dbo].[MST_Hotel].[HotelName]
	FROM [dbo].[MST_Room]

	INNER JOIN [dbo].[MST_RoomType]
	on [dbo].[MST_Room].[RoomTypeID] = [dbo].[MST_RoomType].[RoomTypeID]

	INNER JOIN [dbo].[MST_RoomStatus]
	on [dbo].[MST_Room].[StatusID] = [dbo].[MST_RoomStatus].[StatusID]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_Room].[UserID] = [dbo].[MST_User].[UserID]

	INNER JOIN [dbo].[MST_Hotel]
	on [dbo].[MST_Room].[HotelID] = [dbo].[MST_Hotel].[HotelID]

	ORDER BY [dbo].[MST_Room].[RoomID]
END

--=============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Room_DeleteByRoomID]
@RoomID int
AS
BEGIN
	Delete from [dbo].[MST_Room]
	where [dbo].[MST_Room].[RoomID] = @RoomID
END

--==============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Room_InsertRecord]
	@RoomTypeID		int,
	@StatusID		int,
	@RoomImage		varchar(500),
	@AdultCapacity	int,
	@ChildCapacity	int,
	@CheckInDate	datetime,
	@CheckOutDate	datetime
AS
BEGIN
INSERT INTO [dbo].[MST_Room]
(
	[dbo].[MST_Room].[RoomTypeID]
   ,[dbo].[MST_Room].[StatusID]
   ,[dbo].[MST_Room].[RoomImage]
   ,[dbo].[MST_Room].[AdultCapacity]
   ,[dbo].[MST_Room].[ChildCapacity]
   ,[dbo].[MST_Room].[CheckInDate]
   ,[dbo].[MST_Room].[CheckOutDate]
   ,[dbo].[MST_Room].[Created]
   ,[dbo].[MST_Room].[Modified]
)
VALUES
(
	@RoomTypeID,
	@StatusID,
	@RoomImage,
	@AdultCapacity,
	@ChildCapacity,
	@CheckInDate,
	@CheckOutDate,
	GETDATE(),
	GETDATE()
)
END

--==========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Room_UpdateRecord]
	@RoomID  int,
	@RoomTypeID		int,
	@StatusID		int,
	@RoomImage		varchar(500),
	@AdultCapacity	int,
	@ChildCapacity	int,
	@CheckInDate	datetime,
	@CheckOutDate	datetime
AS
BEGIN
	UPDATE [dbo].[MST_Room]
	SET
		[dbo].[MST_Room].[RoomTypeID] = @RoomTypeID,
		[dbo].[MST_Room].[StatusID] = @StatusID,
		[dbo].[MST_Room].[RoomImage] = @RoomImage,
		[dbo].[MST_Room].[AdultCapacity] = @AdultCapacity,
		[dbo].[MST_Room].[ChildCapacity] = @ChildCapacity,
		[dbo].[MST_Room].[CheckInDate] = @CheckInDate,
		[dbo].[MST_Room].[CheckOutDate] = @CheckOutDate,
		[dbo].[MST_Room].[Created] = (Select [dbo].[MST_Room].[Created] from [dbo].[MST_Room] where [dbo].[MST_Room].[RoomID] = @RoomID),
		[dbo].[MST_Room].[Modified] = GETDATE()
	WHERE [dbo].[MST_Room].[RoomID] = @RoomID
END

--===============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Room_Filter]
@TypeName	varchar(100) = null,
@Status		varchar(100) = null,
@child		int = null,
@Adult		int = null
AS
BEGIN
	SELECT 
		[dbo].[MST_Room].[RoomID],
		[dbo].[MST_Room].[HotelID],
		[dbo].[MST_Room].[UserID],
		[dbo].[MST_Room].[RoomTypeID],
		[dbo].[MST_Room].[StatusID],
		[dbo].[MST_Room].[RoomImage],
		[dbo].[MST_Room].[ChildCapacity],
		[dbo].[MST_Room].[AdultCapacity],
		[dbo].[MST_Room].[CheckInDate],
		[dbo].[MST_Room].[CheckOutDate],
		[dbo].[MST_Room].[Created],
		[dbo].[MST_Room].[Modified],
		[dbo].[MST_RoomType].[TypeName],
		[dbo].[MST_RoomStatus].[Status],
		[dbo].[MST_User].[UserName],
		[dbo].[MST_Hotel].[HotelName]
	FROM [dbo].[MST_Room]

	INNER JOIN [dbo].[MST_RoomType]
	on [dbo].[MST_Room].[RoomTypeID] = [dbo].[MST_RoomType].[RoomTypeID]

	INNER JOIN [dbo].[MST_RoomStatus]
	on [dbo].[MST_Room].[StatusID] = [dbo].[MST_RoomStatus].[StatusID]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_Room].[UserID] = [dbo].[MST_User].[UserID]

	INNER JOIN [dbo].[MST_Hotel]
	on [dbo].[MST_Room].[HotelID] = [dbo].[MST_Hotel].[HotelID]

WHERE (@TypeName is null OR [dbo].[MST_RoomType].[TypeName] like '%'+@TypeName+'%')
AND   (@Status is null OR [dbo].[MST_RoomStatus].[Status] like '%'+@Status+'%')
AND	  (@child is null OR [dbo].[MST_Room].[ChildCapacity] like '%'+@child+'%')
AND	  (@Adult is null OR [dbo].[MST_Room].[AdultCapacity] like '%'+@Adult+'%')

ORDER BY [dbo].[MST_Room].[RoomID]
END