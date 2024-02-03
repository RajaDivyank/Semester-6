CREATE OR ALTER PROCEDURE [dbo].[PR_PaymentMethod_SelectAll]
AS
BEGIN
	SELECT 
		[dbo].[MST_PaymentMethod].[PaymentMethodID],
		[dbo].[MST_PaymentMethod].[UserID],
		[dbo].[MST_PaymentMethod].[Method],
		[dbo].[MST_PaymentMethod].[Created],
		[dbo].[MST_PaymentMethod].[Modified],
		[dbo].[MST_User].[UserName]
	FROM [dbo].[MST_PaymentMethod]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_PaymentMethod].[UserID] = [dbo].[MST_User].[UserID]

	ORDER BY [dbo].[MST_PaymentMethod].[PaymentMethodID]
END

--=============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_PaymentMethod_DeleteByPaymentMethodID]
@PaymentMethodID  int
AS
BEGIN
	Delete from [dbo].[MST_PaymentMethod]
	where [dbo].[MST_PaymentMethod].[PaymentMethodID] = @PaymentMethodID
END

--=================================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_PaymentMethod_SelectByPaymentMethodID]
@PaymentMethodID int
AS
BEGIN
	Select 
		[dbo].[MST_PaymentMethod].[PaymentMethodID],
		[dbo].[MST_PaymentMethod].[UserID],
		[dbo].[MST_PaymentMethod].[Method],
		[dbo].[MST_PaymentMethod].[Created],
		[dbo].[MST_PaymentMethod].[Modified]
	from [dbo].[MST_PaymentMethod]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_PaymentMethod].[UserID] = [dbo].[MST_User].[UserID]

	where [dbo].[MST_PaymentMethod].[PaymentMethodID] = @PaymentMethodID
End

--===============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_PaymentMethod_InsertRecord]
	@UserID		int,
	@Method 	varchar(100)
AS
BEGIN
INSERT INTO [dbo].[MST_PaymentMethod]
(
	[dbo].[MST_PaymentMethod].[UserID]
   ,[dbo].[MST_PaymentMethod].[Method]
   ,[dbo].[MST_PaymentMethod].[Created]
   ,[dbo].[MST_PaymentMethod].[Modified]
)
VALUES
(
	@UserID,
	@Method,
	GETDATE(),
	GETDATE()
)
END

--=======================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_PaymentMethod_UpdateRecord]
	@PaymentMethodID 	int,
	@UserID				int,
	@Method 			varchar(100)
AS
BEGIN
	UPDATE [dbo].[MST_PaymentMethod]
	SET
		[dbo].[MST_PaymentMethod].[UserID] = @UserID,
		[dbo].[MST_PaymentMethod].[Method] = @Method,
		[dbo].[MST_PaymentMethod].[Created] = (Select [dbo].[MST_PaymentMethod].[Created] from [dbo].[MST_PaymentMethod] where [dbo].[MST_PaymentMethod].[PaymentMethodID] = @PaymentMethodID),
		[dbo].[MST_PaymentMethod].[Modified] = GETDATE()
	WHERE [dbo].[MST_PaymentMethod].[PaymentMethodID] = @PaymentMethodID
END

--=========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_PaymentMethod_Filter]
	@Method		varchar(100) = null
AS
BEGIN
	Select 
		[dbo].[MST_PaymentMethod].[PaymentMethodID],
		[dbo].[MST_PaymentMethod].[UserID],
		[dbo].[MST_PaymentMethod].[Method],
		[dbo].[MST_PaymentMethod].[Created],
		[dbo].[MST_PaymentMethod].[Modified]
	FROM [dbo].[MST_PaymentMethod]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_PaymentMethod].[UserID] = [dbo].[MST_User].[UserID]

	WHERE (@Method is null OR [dbo].[MST_PaymentMethod].[Method] like '%'+@Method+'%')
	ORDER BY [dbo].[MST_PaymentMethod].[PaymentMethodID]
END