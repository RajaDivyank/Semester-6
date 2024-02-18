CREATE OR ALTER PROCEDURE [dbo].[PR_Booking_SelectAll]
AS
BEGIN
	SELECT 
		[dbo].[MST_Booking].[RoomID],
		[dbo].[MST_Booking].[UserID],
		[dbo].[MST_Booking].[BookingID],
		[dbo].[MST_Booking].[CheckIn],
		[dbo].[MST_Booking].[CheckOut],
		[dbo].[MST_Booking].[TotalDays],
		[dbo].[MST_Booking].[RegistrationName],
		[dbo].[MST_Booking].[MobileNumber],
		[dbo].[MST_Booking].[IdProofName],
		[dbo].[MST_Booking].[IdProofPhoto],
		[dbo].[MST_Booking].[BookingStatus],
		[dbo].[MST_Booking].[SpecialRequest],
		[dbo].[MST_Booking].[Created],
		[dbo].[MST_Booking].[Modified],
		[dbo].[MST_User].[UserName],
		[dbo].[MST_RoomType].[PricePerDay],
		[dbo].[MST_RoomType].[RoomTypeID],
		[dbo].[MST_RoomType].[TypeName],
		[dbo].[MST_Room].[AdultCapacity],
		[dbo].[MST_Room].[ChildCapacity],
		[dbo].[MST_Room].[RoomImage],
		[dbo].[MST_RoomType].[Description]
	FROM [dbo].[MST_Booking]

	INNER JOIN [dbo].[MST_Room]
	on [dbo].[MST_Booking].[RoomID] = [dbo].[MST_Room].[RoomID]

	INNER JOIN [dbo].[MST_RoomType]
	on [dbo].[MST_RoomType].[RoomTypeID] = [dbo].[MST_Room].[RoomTypeID]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_Booking].[UserID] = [dbo].[MST_User].[UserID]

	ORDER BY [dbo].[MST_Booking].[BookingID]
END

--==========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Booking_DeleteByBookingID]
@BookingID int
AS
BEGIN
	Delete from [dbo].[MST_Booking]
	where [dbo].[MST_Booking].[BookingID] = @BookingID
END

--============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Booking_SelectByBookingID]
@BookingID int
AS
BEGIN
SELECT 
		[dbo].[MST_Booking].[RoomID],
		[dbo].[MST_Booking].[UserID],
		[dbo].[MST_Booking].[BookingID],
		[dbo].[MST_Booking].[CheckIn],
		[dbo].[MST_Booking].[CheckOut],
		[dbo].[MST_Booking].[TotalDays],
		[dbo].[MST_Booking].[RegistrationName],
		[dbo].[MST_Booking].[MobileNumber],
		[dbo].[MST_Booking].[IdProofName],
		[dbo].[MST_Booking].[IdProofPhoto],
		[dbo].[MST_Booking].[BookingStatus],
		[dbo].[MST_Booking].[SpecialRequest],
		[dbo].[MST_Booking].[Created],
		[dbo].[MST_Booking].[Modified],
		[dbo].[MST_User].[UserName],
		[dbo].[MST_RoomType].[RoomTypeID],
		[dbo].[MST_RoomType].[TypeName],
		[dbo].[MST_Room].[AdultCapacity],
		[dbo].[MST_Room].[ChildCapacity],
		[dbo].[MST_Room].[RoomImage],
		[dbo].[MST_RoomType].[Description],
		[dbo].[MST_RoomType].[PricePerDay]
	FROM [dbo].[MST_Booking]

	INNER JOIN [dbo].[MST_Room]
	on [dbo].[MST_Booking].[RoomID] = [dbo].[MST_Room].[RoomID]

	INNER JOIN [dbo].[MST_RoomType]
	on [dbo].[MST_RoomType].[RoomTypeID] = [dbo].[MST_Room].[RoomTypeID]

	INNER JOIN [dbo].[MST_User]
	on [dbo].[MST_Booking].[UserID] = [dbo].[MST_User].[UserID]

	WHERE [dbo].[MST_Booking].[BookingID] = @BookingID
END

--===============================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Booking_InsertRecord] 
	@RoomID			int,
	@UserID			int,
	@CheckIn		datetime,
	@CheckOut		datetime,
	@RegistrationName	varchar(100),
	@BookingStatus  varchar(100) = "Pending",
	@SpecialRequest  varchar(500),
	@MobileNumber	varchar(100),
	@IdProofName    varchar(100),
	@IdProofPhoto	varchar(500)
AS
BEGIN
INSERT INTO [dbo].[MST_Booking]
(
	[dbo].[MST_Booking].[RoomID]
   ,[dbo].[MST_Booking].[UserID]
   ,[dbo].[MST_Booking].[CheckIn]
   ,[dbo].[MST_Booking].[CheckOut]
   ,[dbo].[MST_Booking].[TotalDays]
   ,[dbo].[MST_Booking].[RegistrationName]
   ,[dbo].[MST_Booking].[MobileNumber]
   ,[dbo].[MST_Booking].[IdProofName]
   ,[dbo].[MST_Booking].[IdProofPhoto]
   ,[dbo].[MST_Booking].[BookingStatus]
   ,[dbo].[MST_Booking].[SpecialRequest]
   ,[dbo].[MST_Booking].[Created]
   ,[dbo].[MST_Booking].[Modified]
)
VALUES
(
	@RoomID,
	@UserID,
	@CheckIn,
	@CheckOut,
	DATEDIFF(day, @CheckIn, @CheckOut),
	@RegistrationName,
	@MobileNumber,
	@IdProofName,
	@IdProofPhoto,
	@BookingStatus,
	@SpecialRequest,
	GETDATE(),
	GETDATE()
)
END

--========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Booking_UpdateRecord]
	@BookingID			int,
	@RoomID				int,
	@UserID				int,
	@CheckIn			datetime,
	@CheckOut			datetime,
	@RegistrationName	varchar(100),
	@MobileNumber		varchar(100),
	@IdProofName		varchar(100),
	@IdProofPhoto		varchar(500),
	@SpecialRequest		varchar(500)
AS
BEGIN
	UPDATE [dbo].[MST_Booking]
	SET
		[dbo].[MST_Booking].[RoomID] = @RoomID,
		[dbo].[MST_Booking].[UserID] = @UserID,
		[dbo].[MST_Booking].[CheckIn] = @CheckIn,
		[dbo].[MST_Booking].[CheckOut] = @CheckOut,
		[dbo].[MST_Booking].[TotalDays] = DATEDIFF(day, @CheckIn, @CheckOut),
		[dbo].[MST_Booking].[RegistrationName] = @RegistrationName,
		[dbo].[MST_Booking].[MobileNumber] = @MobileNumber,
		[dbo].[MST_Booking].[IdProofName] = @IdProofName,
		[dbo].[MST_Booking].[IdProofPhoto] = @IdProofPhoto,
		[dbo].[MST_Booking].[SpecialRequest] = @SpecialRequest,
		[dbo].[MST_Booking].[Created] = (Select [dbo].[MST_Booking].[Created] from [dbo].[MST_Booking] where [dbo].[MST_Booking].[BookingID] = @BookingID),
		[dbo].[MST_Booking].[Modified] = GETDATE()
	WHERE [dbo].[MST_Booking].[BookingID] = @BookingID
END

---===========================================================

CREATE OR ALTER PROCEDURE [dbo].[PR_Update_BookingStatus_Booked] 
@BookingID		int,
@BookingStatus	varchar(100) = Booked
AS
BEGIN
	UPDATE [dbo].[MST_Booking]
	SET
	[dbo].[MST_Booking].[BookingStatus] = @BookingStatus
	WHERE [dbo].[MST_Booking].[BookingID] = @BookingID
END

CREATE OR ALTER PROCEDURE [dbo].[PR_Update_BookingStatus_Cancel]
@BookingID		int,
@BookingStatus	varchar(100) = Cancel
AS
BEGIN
	UPDATE [dbo].[MST_Booking]
	SET
	[dbo].[MST_Booking].[BookingStatus] = @BookingStatus
	WHERE [dbo].[MST_Booking].[BookingID] = @BookingID
END