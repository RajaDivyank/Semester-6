CREATE OR ALTER PROCEDURE [dbo].[PR_RoomStatus_SelectAll]
AS
BEGIN
SELECT [dbo].[MST_RoomStatus].[StatusID],
	   [dbo].[MST_RoomStatus].[Status],
	   [dbo].[MST_RoomStatus].[Created],
	   [dbo].[MST_RoomStatus].[Modified]
FROM [dbo].[MST_RoomStatus]
ORDER BY [dbo].[MST_RoomStatus].[StatusID]
END

--=============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_RoomStatus_SelectByStatusID]
@StatusID int
AS
BEGIN
SELECT [dbo].[MST_RoomStatus].[StatusID],
	   [dbo].[MST_RoomStatus].[Status],
	   [dbo].[MST_RoomStatus].[Created],
	   [dbo].[MST_RoomStatus].[Modified]
	from [dbo].[MST_RoomStatus]
	where [dbo].[MST_RoomStatus].[StatusID] = @StatusID 
End

--==================================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_RoomStatus_DeleteByStatusID]
@StatusID  int
AS
BEGIN
	Delete from [dbo].[MST_RoomStatus]
	where [dbo].[MST_RoomStatus].[StatusID] = @StatusID
END

--==================================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_RoomStatus_InsertRecord]
	@Status 	varchar(100)
AS
BEGIN
INSERT INTO [dbo].[MST_RoomStatus]
(
	[dbo].[MST_RoomStatus].[Status]
   ,[dbo].[MST_RoomStatus].[Created]
   ,[dbo].[MST_RoomStatus].[Modified]
)
VALUES
(
	@Status,
	GETDATE(),
	GETDATE()
)
END

--============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_RoomStatus_UpdateRecord]
	@StatusID  	int,
	@Status		varchar(100)
AS
BEGIN
	UPDATE [dbo].[MST_RoomStatus]
	SET
		[dbo].[MST_RoomStatus].[Status] = @Status,
		[dbo].[MST_RoomStatus].[Created] = (Select [dbo].[MST_RoomStatus].[Created] from [dbo].[MST_RoomStatus] where [dbo].[MST_RoomStatus].[StatusID] = @StatusID),
		[dbo].[MST_RoomStatus].[Modified] = GETDATE()
	WHERE [dbo].[MST_RoomStatus].[StatusID] = @StatusID
END

--=======================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_RoomStatus_Filter]
@Status   varchar(100) = null
AS
BEGIN
	Select 
		 [dbo].[MST_RoomStatus].[StatusID]
		,[dbo].[MST_RoomStatus].[Status]
		,[dbo].[MST_RoomStatus].[Created]
		,[dbo].[MST_RoomStatus].[Modified]
		FROM [dbo].[MST_RoomStatus]
		WHERE (@Status is null OR [dbo].[MST_RoomStatus].[Status] like '%'+@Status+'%')
ORDER BY [dbo].[MST_RoomStatus].[StatusID]
END