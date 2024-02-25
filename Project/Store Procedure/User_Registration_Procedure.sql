CREATE OR ALTER  PROCEDURE [dbo].[PR_SEC_User_SelectAll]
AS
BEGIN
SELECT [dbo].[MST_User].[UserID],
	   [dbo].[MST_User].[UserName],
	   [dbo].[MST_User].[Email],
	   [dbo].[MST_User].[Password],
	   [dbo].[MST_User].[UserNumber],
	   [dbo].[MST_User].[IsActive],
	   [dbo].[MST_User].[IsAdmin],
	   [dbo].[MST_User].[IsManager],
	   [dbo].[MST_User].[Created],
	   [dbo].[MST_User].[Modified]

FROM [dbo].[MST_User]
ORDER BY [dbo].[MST_User].[UserID],
		 [dbo].[MST_User].[UserName],
		 [dbo].[MST_User].[Email]
END

--============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_SEC_User_SelectByUserID] 
@UserID int
AS
BEGIN
		SELECT	[dbo].[MST_User].[UserID],
				[dbo].[MST_User].[UserName],
				[dbo].[MST_User].[Email],
				[dbo].[MST_User].[Password],
				[dbo].[MST_User].[UserNumber],
				[dbo].[MST_User].[IsActive],
				[dbo].[MST_User].[IsAdmin],
				[dbo].[MST_User].[IsManager],
				[dbo].[MST_User].[Modified],
				[dbo].[MST_User].[Created]
FROM [dbo].[MST_User]
WHERE [dbo].[MST_User].[UserID] = @UserID
ORDER BY [dbo].[MST_User].[UserID]
END

--============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_SEC_User_DeleteByUserID]
	@UserID int
AS
BEGIN	
	DELETE FROM [dbo].[MST_User]
	WHERE [dbo].[MST_User].[UserID] = @UserID
END

--============================================================

ALTER   PROCEDURE [dbo].[PR_SEC_User_SignUp]
	@UserName			varchar(100),
	@Email				varchar(100),
	@Password			varchar(50),
	@UserNumber			varchar(50),
	@IsAdmin			bit = false,
	@IsActive			bit = false,
	@IsManager			bit = false
AS
BEGIN
INSERT INTO [dbo].[MST_User]
(
	[dbo].[MST_User].[UserName],
	[dbo].[MST_User].[Email],
	[dbo].[MST_User].[Password],
	[dbo].[MST_User].[UserNumber],
	[dbo].[MST_User].[IsActive],
	[dbo].[MST_User].[IsAdmin],
	[dbo].[MST_User].[IsManager],
	[dbo].[MST_User].[Created],
	[dbo].[MST_User].[Modified]
)
VALUES
(
	@UserName,
	@Email,
	@Password,
	@UserNumber,
	@IsActive,
	@IsAdmin,
	@IsManager,
	GETDATE(),
	GETDATE()
)
END
--===========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_SEC_User_SignIn]
    @EmailOrUserName	VARCHAR(100),
    @Password			VARCHAR(50)
AS
BEGIN
    SELECT 
		[dbo].[MST_User].[UserID]
		,[dbo].[MST_User].[UserName]
		,[dbo].[MST_User].[Email]
		,[dbo].[MST_User].[Password]
		,[dbo].[MST_User].[UserNumber]
		,[dbo].[MST_User].[IsAdmin]
		,[dbo].[MST_User].[IsActive]
		,[dbo].[MST_User].[IsManager]
    FROM [dbo].[MST_User]
    WHERE (Email = @EmailOrUserName OR UserName = @EmailOrUserName OR UserNumber = @EmailOrUserName)
	 AND [dbo].[MST_User].[Password] = @Password
END

--============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_SEC_User_UpdateByUserID]
	@UserID				int,
	@IsAdmin			bit,
	@IsManager			bit
AS
BEGIN
UPDATE [dbo].[MST_User]
	SET 
		[dbo].[MST_User].[IsAdmin] = @IsAdmin,
		[dbo].[MST_User].[IsManager] = @IsManager
	WHERE [dbo].[MST_User].[UserID] = @UserID
END

--========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_User_UpdateByUserID]
	@UserID				int,
	@UserName			varchar(100),
	@Email				varchar(100),
	@Password			varchar(50),
	@UserNumber			varchar(50)
AS
BEGIN
UPDATE [dbo].[MST_User]
	SET 
		[dbo].[MST_User].[UserName] = @UserName,
		[dbo].[MST_User].[Email] = @Email,
		[dbo].[MST_User].[Password] = @Password,
		[dbo].[MST_User].[UserNumber] = @UserNumber
	WHERE [dbo].[MST_User].[UserID] = @UserID
END