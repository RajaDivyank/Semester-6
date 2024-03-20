CREATE OR ALTER PROCEDURE [dbo].[PR_Payment_SelectAll]
AS
BEGIN
	SELECT 
		[dbo].[MST_Payment].[PaymentID],
		[dbo].[MST_Payment].[BookingID],
		[dbo].[MST_Payment].[UserID],
		[dbo].[MST_Payment].[PaymentMethodID],
		[dbo].[MST_Payment].[PaymentDate],
		[dbo].[MST_Payment].[Amount],
		[dbo].[MST_Payment].[Created],
		[dbo].[MST_Payment].[Modified],
		[dbo].[MST_PaymentMethod].[Method],
		[dbo].[MST_Booking].[RegistrationName],
		[dbo].[MST_Booking].[TotalDays],
		[dbo].[MST_User].[UserName]
	FROM [dbo].[MST_Payment]

	INNER JOIN [dbo].[MST_Booking]
	on [dbo].[MST_Payment].[BookingID] = [dbo].[MST_Booking].[BookingID]


	INNER JOIN [dbo].[MST_PaymentMethod]
	on [dbo].[MST_Payment].[PaymentMethodID] = [dbo].[MST_PaymentMethod].[PaymentMethodID]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_Payment].[UserID] = [dbo].[MST_User].[UserID]

	ORDER BY [dbo].[MST_Payment].[PaymentID]
END

--============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Payment_DeleteByPaymentID]
@paymentID int
AS
BEGIN
	Delete from [dbo].[MST_Payment]
	where [dbo].[MST_Payment].[PaymentID] = @paymentID
END

--============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Payment_SelectByPaymentID]
@PaymentID int
AS
BEGIN
	SELECT 
		[dbo].[MST_Payment].[PaymentID],
		[dbo].[MST_Payment].[BookingID],
		[dbo].[MST_Payment].[UserID],
		[dbo].[MST_Payment].[PaymentMethodID],
		[dbo].[MST_Payment].[PaymentDate],
		[dbo].[MST_Payment].[Amount],
		[dbo].[MST_Payment].[Created],
		[dbo].[MST_Payment].[Modified],
		[dbo].[MST_PaymentMethod].[Method],
		[dbo].[MST_Booking].[RegistrationName],
		[dbo].[MST_Booking].[TotalDays],
		[dbo].[MST_User].[UserName]
	FROM [dbo].[MST_Payment]

	INNER JOIN [dbo].[MST_Booking]
	on [dbo].[MST_Payment].[BookingID] = [dbo].[MST_Booking].[BookingID]

	INNER JOIN [dbo].[MST_PaymentMethod]
	on [dbo].[MST_Payment].[PaymentMethodID] = [dbo].[MST_PaymentMethod].[PaymentMethodID]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_Payment].[UserID] = [dbo].[MST_User].[UserID]

	WHERE [dbo].[MST_Payment].[PaymentID] = @PaymentID
END

--=======================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Payment_InsertRecord] 
	@PaymentMethodID	int,
	@UserID				int
AS
BEGIN
INSERT INTO [dbo].[MST_Payment]
(
   [dbo].[MST_Payment].[PaymentMethodID]
   ,[dbo].[MST_Payment].[UserID]
   ,[dbo].[MST_Payment].[PaymentDate]
   ,[dbo].[MST_Payment].[Created]
   ,[dbo].[MST_Payment].[Modified]
)
VALUES
(
	@PaymentMethodID,
	@UserID,
	GETDATE(),
	GETDATE(),
	GETDATE()
)
END

--======================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Payment_UpdateRecord]
	@PaymentID			int,
	@PaymentMethodID	int,
	@UserID				int,
	@BookingID			int
AS
BEGIN
	UPDATE [dbo].[MST_Payment]
	SET
		[dbo].[MST_Payment].[PaymentMethodID] = @PaymentMethodID,
		[dbo].[MST_Payment].[UserID] = @UserID,
		[dbo].[MST_Payment].[BookingID] = @BookingID,
		[dbo].[MST_Payment].[PaymentDate] = (Select [dbo].[MST_Payment].[PaymentDate] from [dbo].[MST_Payment] where [dbo].[MST_Payment].[PaymentID] = @PaymentID),
		[dbo].[MST_Payment].[Created] = (Select [dbo].[MST_Payment].[Created] from [dbo].[MST_Payment] where [dbo].[MST_Payment].[PaymentID] = @PaymentID),
		[dbo].[MST_Payment].[Modified] = GETDATE()
	WHERE [dbo].[MST_Payment].[PaymentID] = @PaymentID
END
