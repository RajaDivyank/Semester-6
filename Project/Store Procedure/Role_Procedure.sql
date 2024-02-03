CREATE OR ALTER PROCEDURE [dbo].[PR_Role_SelectAll]
AS
BEGIN
SELECT [dbo].[MST_Role].[RoleID],
	   [dbo].[MST_Role].[Role],
	   [dbo].[MST_Role].[Created],
	   [dbo].[MST_Role].[Modified]
FROM [dbo].[MST_Role]
ORDER BY [dbo].[MST_Role].[RoleID]
END

--===============================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Role_DeleteByRoleID]
@RoleID  int
AS
BEGIN
	Delete from [dbo].[MST_Role]
	where [dbo].[MST_Role].[RoleID] = @RoleID
END

--===============================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Role_SelectByRoleID]
@RoleID int
AS
BEGIN
	Select 
		[dbo].[MST_Role].[RoleID],
		[dbo].[MST_Role].[Role],
		[dbo].[MST_Role].[Created],
		[dbo].[MST_Role].[Modified]
	from [dbo].[MST_Role]
	where [dbo].[MST_Role].[RoleID] = @RoleID 
End

--================================================

CREATE PROCEDURE [dbo].[PR_Role_InsertRecord]
	@Role	varchar(100)
AS
BEGIN
INSERT INTO [dbo].[MST_Role]
(
	[dbo].[MST_Role].[Role]
   ,[dbo].[MST_Role].[Created]
   ,[dbo].[MST_Role].[Modified]
)
VALUES
(
	@Role,
	GETDATE(),
	GETDATE()
)
END

--============================================

CREATE PROCEDURE [dbo].[PR_Role_UpdateRecord]
	@RoleID 	int,
	@Role		varchar(100)
AS
BEGIN
	UPDATE [dbo].[MST_Role]
	SET
		[dbo].[MST_Role].[Role] = @Role,
		[dbo].[MST_Role].[Created] = (Select [dbo].[MST_Role].[Created] from [dbo].[MST_Role] where [dbo].[MST_Role].[RoleID] = @RoleID),
		[dbo].[MST_Role].[Modified] = GETDATE()
	WHERE [dbo].[MST_Role].[RoleID] = @RoleID
END

--==========================================

CREATE PROCEDURE [dbo].[PR_Role_Filter]
@Role varchar(100) = null
AS
BEGIN
	Select 
		 [dbo].[MST_Role].[RoleID]
		,[dbo].[MST_Role].[Role]
		,[dbo].[MST_Role].[Created]
		,[dbo].[MST_Role].[Modified]
		FROM [dbo].[MST_Role]
		WHERE (@Role is null OR [dbo].[MST_Role].[Role] like '%'+@Role+'%')
ORDER BY [dbo].[MST_Role].[RoleID]
END