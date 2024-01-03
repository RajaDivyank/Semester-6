CREATE PROCEDURE [dbo].[PR_User_SelectAll]
AS
BEGIN
SELECT [dbo].[Use_Registration].[UserID],
	   [dbo].[Use_Registration].[UserName],
	   [dbo].[Use_Registration].[Email],
	   [dbo].[Use_Registration].[Password],
	   [dbo].[Use_Registration].[UserNumber],
	   [dbo].[Use_Registration].[IsActive],
	   [dbo].[Use_Registration].[IsAdmin],
	   [dbo].[Use_Registration].[Created],
	   [dbo].[Use_Registration].[Modified]

FROM [dbo].[Use_Registration]
ORDER BY [dbo].[Use_Registration].[UserName],
		 [dbo].[Use_Registration].[Email]
END

--============================================================

CREATE PROCEDURE [dbo].[PR_User_SelectByUserID]
	@UserID int
AS
BEGIN
		SELECT	[dbo].[Use_Registration].[UserName],
				[dbo].[Use_Registration].[Email],
				[dbo].[Use_Registration].[Password],
				[dbo].[Use_Registration].[UserNumber],
				[dbo].[Use_Registration].[IsActive],
				[dbo].[Use_Registration].[IsAdmin],
				[dbo].[Use_Registration].[Modified],
				[dbo].[Use_Registration].[Created]
FROM [dbo].[Use_Registration]
WHERE [dbo].[Use_Registration].[UserID] = @UserID
ORDER BY [dbo].[Use_Registration].[UserName],
		 [dbo].[Use_Registration].[Email]
END

--============================================================

CREATE PROCEDURE [dbo].[PR_User_DeleteByUserID]
	@UserID int
AS
BEGIN	
	DELETE FROM [dbo].[Use_Registration]
	WHERE [dbo].[Use_Registration].[UserID] = @UserID
END

--============================================================

CREATE PROCEDURE [dbo].[PR_User_Insert_Record]
	@UserName			varchar(100),
	@Email				varchar(100),
	@Password			varchar(50),
	@UserNumber			varchar(50)
AS
INSERT INTO [dbo].[Use_Registration]
(
	[dbo].[Use_Registration].[UserName],
	[dbo].[Use_Registration].[Email],
	[dbo].[Use_Registration].[Password],
	[dbo].[Use_Registration].[UserNumber]
)
VALUES
(
	@UserName,
	@Email,
	@Password,
	@UserNumber
)

--============================================================

CREATE PROCEDURE [dbo].[PR_User_UpdateByUserID]
	@UserID				int,
	@UserName			varchar(100),
	@Email				varchar(100),
	@Password			varchar(50),
	@UserNumber			varchar(50)
AS
BEGIN
UPDATE [dbo].[Use_Registration]
	SET [dbo].[Use_Registration].[UserName] = @UserName,
		[dbo].[Use_Registration].[Email] = @Email,
		[dbo].[Use_Registration].[Password] = @Password,
		[dbo].[Use_Registration].[UserNumber] = @UserNumber
	WHERE [dbo].[Use_Registration].[UserID] = @UserID
END