CREATE OR ALTER PROCEDURE [dbo].[PR_Room_SelectAll]
AS
BEGIN
	SELECT 
		[dbo].[MST_Room].[RoomID],
		[dbo].[MST_Room].[UserID],
		[dbo].[MST_Room].[RoomTypeID],
		[dbo].[MST_Room].[StatusID],
		[dbo].[MST_Room].[RoomImage],
		[dbo].[MST_Room].[ChildCapacity],
		[dbo].[MST_Room].[AdultCapacity],
		[dbo].[MST_Room].[Created],
		[dbo].[MST_Room].[Modified],
		[dbo].[MST_RoomType].[TypeName],
		[dbo].[MST_RoomType].[Description],
		[dbo].[MST_RoomType].[PricePerDay],
		[dbo].[MST_RoomStatus].[Status],
		[dbo].[MST_User].[UserName]
	FROM [dbo].[MST_Room]

	Left outer JOIN [dbo].[MST_RoomType]
	on [dbo].[MST_Room].[RoomTypeID] = [dbo].[MST_RoomType].[RoomTypeID]

	Left outer JOIN [dbo].[MST_RoomStatus]
	on [dbo].[MST_Room].[StatusID] = [dbo].[MST_RoomStatus].[StatusID]

	Left Outer JOIN [dbo].[MST_User]
	on [dbo].[MST_Room].[UserID] = [dbo].[MST_User].[UserID]

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

CREATE OR ALTER PROCEDURE [dbo].[PR_Room_SelectByRoomID]
@RoomID int
AS
BEGIN
	SELECT 
		[dbo].[MST_Room].[RoomID],
		[dbo].[MST_Room].[UserID],
		[dbo].[MST_Room].[RoomTypeID],
		[dbo].[MST_Room].[StatusID],
		[dbo].[MST_Room].[RoomImage],
		[dbo].[MST_Room].[ChildCapacity],
		[dbo].[MST_Room].[AdultCapacity],
		[dbo].[MST_Room].[Created],
		[dbo].[MST_Room].[Modified],
		[dbo].[MST_RoomType].[Description],
		[dbo].[MST_RoomType].[PricePerDay],
		[dbo].[MST_RoomType].[TypeName],
		[dbo].[MST_RoomStatus].[Status],
		[dbo].[MST_User].[UserName]
	FROM [dbo].[MST_Room]
	INNER JOIN [dbo].[MST_RoomType]
	on [dbo].[MST_Room].[RoomTypeID] = [dbo].[MST_RoomType].[RoomTypeID]

	INNER JOIN [dbo].[MST_RoomStatus]
	on [dbo].[MST_Room].[StatusID] = [dbo].[MST_RoomStatus].[StatusID]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_Room].[UserID] = [dbo].[MST_User].[UserID]

	WHERE [dbo].[MST_Room].[RoomID] = @RoomID
	
End

--==============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Room_InsertRecord] 
	@RoomTypeID		int,
	@StatusID		int,
	@UserID			int,
	@RoomImage		varchar(500),
	@AdultCapacity	int,
	@ChildCapacity	int
AS
BEGIN
INSERT INTO [dbo].[MST_Room]
(
	[dbo].[MST_Room].[RoomTypeID]
   ,[dbo].[MST_Room].[StatusID]
   ,[dbo].[MST_Room].[UserID]
   ,[dbo].[MST_Room].[RoomImage]
   ,[dbo].[MST_Room].[AdultCapacity]
   ,[dbo].[MST_Room].[ChildCapacity]
   ,[dbo].[MST_Room].[Created]
   ,[dbo].[MST_Room].[Modified]
)
VALUES
(
	@RoomTypeID,
	@StatusID,
	@UserID,
	@RoomImage,
	@AdultCapacity,
	@ChildCapacity,
	GETDATE(),
	GETDATE()
)
END

Exec PR_Room_InsertRecord 2,2,2,'edsfnkskx',1,2

--==========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Room_UpdateRecord]
	@RoomID			int,
	@UserID			int,
	@RoomTypeID		int,
	@StatusID		int,
	@RoomImage		varchar(500),
	@AdultCapacity	int,
	@ChildCapacity	int
AS
BEGIN
	UPDATE [dbo].[MST_Room]
	SET
		[dbo].[MST_Room].[RoomTypeID] = @RoomTypeID,
		[dbo].[MST_Room].[StatusID] = @StatusID,
		[dbo].[MST_Room].[UserID] = @UserID,
		[dbo].[MST_Room].[RoomImage] = @RoomImage,
		[dbo].[MST_Room].[AdultCapacity] = @AdultCapacity,
		[dbo].[MST_Room].[ChildCapacity] = @ChildCapacity,
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
		[dbo].[MST_Room].[UserID],
		[dbo].[MST_Room].[RoomTypeID],
		[dbo].[MST_Room].[StatusID],
		[dbo].[MST_Room].[RoomImage],
		[dbo].[MST_Room].[ChildCapacity],
		[dbo].[MST_Room].[AdultCapacity],
		[dbo].[MST_Room].[Created],
		[dbo].[MST_Room].[Modified],
		[dbo].[MST_RoomType].[TypeName],
		[dbo].[MST_RoomStatus].[Status],
		[dbo].[MST_User].[UserName]
	FROM [dbo].[MST_Room]

	INNER JOIN [dbo].[MST_RoomType]
	on [dbo].[MST_Room].[RoomTypeID] = [dbo].[MST_RoomType].[RoomTypeID]

	INNER JOIN [dbo].[MST_RoomStatus]
	on [dbo].[MST_Room].[StatusID] = [dbo].[MST_RoomStatus].[StatusID]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_Room].[UserID] = [dbo].[MST_User].[UserID]

WHERE (@TypeName is null OR [dbo].[MST_RoomType].[TypeName] like '%'+@TypeName+'%')
AND   (@Status is null OR [dbo].[MST_RoomStatus].[Status] like '%'+@Status+'%')
AND	  (@child is null OR [dbo].[MST_Room].[ChildCapacity] like '%'+@child+'%')
AND	  (@Adult is null OR [dbo].[MST_Room].[AdultCapacity] like '%'+@Adult+'%')

ORDER BY [dbo].[MST_Room].[RoomID]
END