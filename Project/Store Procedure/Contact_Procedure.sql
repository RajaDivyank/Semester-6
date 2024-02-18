CREATE OR ALTER PROCEDURE [dbo].[PR_Contact_SelectAll]
AS
BEGIN
SELECT [dbo].[MST_Contact].[ContactID],
	   [dbo].[MST_Contact].[UserID],
	   [dbo].[MST_Contact].[Name],
	   [dbo].[MST_Contact].[Email],
	   [dbo].[MST_Contact].[Subject],
	   [dbo].[MST_Contact].[Message],
	   [dbo].[MST_Contact].[Created],
	   [dbo].[MST_Contact].[Modified]
FROM [dbo].[MST_Contact]
ORDER BY [dbo].[MST_Contact].[ContactID]
END

--=============================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Contact_SelectByContactID]
@ContactID int
AS
BEGIN
	SELECT [dbo].[MST_Contact].[ContactID],
	   [dbo].[MST_Contact].[UserID],
	   [dbo].[MST_Contact].[Name],
	   [dbo].[MST_Contact].[Email],
	   [dbo].[MST_Contact].[Subject],
	   [dbo].[MST_Contact].[Message],
	   [dbo].[MST_Contact].[Created],
	   [dbo].[MST_Contact].[Modified]
	FROM [dbo].[MST_Contact]
	WHERE [dbo].[MST_Contact].[ContactID] = @ContactID 
End

--=========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Contact_DeleteByContactID]
@ContactID  int
AS
BEGIN
	Delete from [dbo].[MST_Contact]
	where [dbo].[MST_Contact].[ContactID] = @ContactID
END

--===========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Contact_InsertRecord]
	@UserID		int,
	@Name		varchar(100),
	@Email		varchar(100),
	@Subject	varchar(100),
	@Message	varchar(300)
AS
BEGIN
INSERT INTO [dbo].[MST_Contact]
(
	   [dbo].[MST_Contact].[UserID],
	   [dbo].[MST_Contact].[Name],
	   [dbo].[MST_Contact].[Email],
	   [dbo].[MST_Contact].[Subject],
	   [dbo].[MST_Contact].[Message],
	   [dbo].[MST_Contact].[Created],
	   [dbo].[MST_Contact].[Modified]
)
VALUES
(
	@UserID,
	@Name,
	@Email,
	@Subject,
	@Message,
	GETDATE(),
	GETDATE()
)
END

--==============================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Contact_UpdateRecord]
	@ContactID	int,
	@UserID		int,
	@Name		varchar(100),
	@Email		varchar(100),
	@Subject	varchar(100),
	@Message	varchar(300)
AS
BEGIN
	UPDATE [dbo].[MST_Contact]
	SET
		[dbo].[MST_Contact].[UserID] = @UserID,
		[dbo].[MST_Contact].[Name] = @Name,
		[dbo].[MST_Contact].[Email] = @Email,
		[dbo].[MST_Contact].[Subject] = @Subject,
		[dbo].[MST_Contact].[Message] = @Message,
		[dbo].[MST_Contact].[Created] = (Select [dbo].[MST_Contact].[Created] from [dbo].[MST_Contact] where [dbo].[MST_Contact].[ContactID] = @ContactID),
		[dbo].[MST_Contact].[Modified] = GETDATE()
	WHERE [dbo].[MST_Contact].[ContactID] = @ContactID
END

--================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Contact_Filter] 
	@Name		varchar(100) = null,
	@Email		varchar(100) = null
AS
BEGIN
SELECT [dbo].[MST_Contact].[ContactID],
	   [dbo].[MST_Contact].[UserID],
	   [dbo].[MST_Contact].[Name],
	   [dbo].[MST_Contact].[Email],
	   [dbo].[MST_Contact].[Subject],
	   [dbo].[MST_Contact].[Message],
	   [dbo].[MST_Contact].[Created],
	   [dbo].[MST_Contact].[Modified]
		FROM [dbo].[MST_Contact]
		WHERE (@Name is null OR [dbo].[MST_Contact].[Name] like '%'+@Name+'%')
		AND (@Email is null OR [dbo].[MST_Contact].[Email] like '%'+@Email+'%')
ORDER BY [dbo].[MST_Contact].[ContactID]
END