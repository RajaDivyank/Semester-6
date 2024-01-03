CREATE PROCEDURE [dbo].[PR_RoomType_SelectAll]
AS
BEGIN
SELECT [dbo].[MST_RoomType].[RoomTypeID],
	   [dbo].[MST_RoomType].[TypeName],
	   [dbo].[MST_RoomType].[Description],
	   [dbo].[MST_RoomType].[PricePerDay],
	   [dbo].[MST_RoomType].[Created],
	   [dbo].[MST_RoomType].[Modified]
FROM [dbo].[MST_RoomType]
ORDER BY [dbo].[MST_RoomType].[RoomTypeID]
END

--====================================================

CREATE PROCEDURE [dbo].[PR_RoomType_SelectByRoomTypeID]
@RoomTypeID int
AS
BEGIN
	SELECT	[dbo].[MST_RoomType].[RoomTypeID],
			[dbo].[MST_RoomType].[TypeName],
			[dbo].[MST_RoomType].[Description],
			[dbo].[MST_RoomType].[PricePerDay],
			[dbo].[MST_RoomType].[Created],
			[dbo].[MST_RoomType].[Modified]
	from [dbo].[MST_RoomType]
	where [dbo].[MST_RoomType].[RoomTypeID] = @RoomTypeID 
End

--==========================================================

CREATE PROCEDURE [dbo].[PR_RoomType_DeleteByRoomTypeID]
@RoomTypeID  int
AS
BEGIN
	Delete from [dbo].[MST_RoomType]
	where [dbo].[MST_RoomType].[RoomTypeID] = @RoomTypeID
END

--==========================================================

CREATE PROCEDURE [dbo].[PR_RoomType_InsertRecord]
	@TypeName	varchar(100),
	@Description varchar(500),
	@PricePerDay decimal(10,2)
AS
BEGIN
INSERT INTO [dbo].[MST_RoomType]
(
	[dbo].[MST_RoomType].[TypeName]
   ,[dbo].[MST_RoomType].[Description]
   ,[dbo].[MST_RoomType].[PricePerDay]
   ,[dbo].[MST_RoomType].[Created]
   ,[dbo].[MST_RoomType].[Modified]
)
VALUES
(
	@TypeName,
	@Description,
	@PricePerDay,
	GETDATE(),
	GETDATE()
)
END

--=======================================================

CREATE PROCEDURE [dbo].[PR_RoomType_UpdateRecord]
	@RoomTypeID 	int,
	@TypeName		varchar(100),
	@Description	varchar(500),
	@PricePerDay	decimal(10,2)
AS
BEGIN
	UPDATE [dbo].[MST_RoomType]
	SET
		[dbo].[MST_RoomType].[TypeName] = @TypeName,
		[dbo].[MST_RoomType].[Description] = @Description,
		[dbo].[MST_RoomType].[PricePerDay] = @PricePerDay,
		[dbo].[MST_RoomType].[Created] = (Select [dbo].[MST_RoomType].[Created] from [dbo].[MST_RoomType] where [dbo].[MST_RoomType].[RoomTypeID] = @RoomTypeID),
		[dbo].[MST_RoomType].[Modified] = GETDATE()
	WHERE [dbo].[MST_RoomType].[RoomTypeID] = @RoomTypeID
END

--=======================================================

CREATE PROCEDURE [dbo].[PR_RoomType_Filter]
	@TypeName		varchar(100) = null,
	@PricePerDay	decimal(10,2) = null
AS
BEGIN
SELECT [dbo].[MST_RoomType].[RoomTypeID],
	   [dbo].[MST_RoomType].[TypeName],
	   [dbo].[MST_RoomType].[Description],
	   [dbo].[MST_RoomType].[PricePerDay],
	   [dbo].[MST_RoomType].[Created],
	   [dbo].[MST_RoomType].[Modified]
		FROM [dbo].[MST_RoomType]
		WHERE (@TypeName is null OR [dbo].[MST_RoomType].[TypeName] like '%'+@TypeName+'%')
		AND (PricePerDay is null OR [dbo].[MST_RoomType].[PricePerDay] like '%'+@PricePerDay+'%')
ORDER BY [dbo].[MST_RoomType].[RoomTypeID]
END