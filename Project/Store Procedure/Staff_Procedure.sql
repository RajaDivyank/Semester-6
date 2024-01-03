CREATE PROCEDURE [dbo].[PR_Staff_SelectAll]
AS
BEGIN
SELECT [dbo].[MST_Staff].[StaffID],
	   [dbo].[MST_Staff].[HotelID],
	   [dbo].[MST_Staff].[RoleID],
	   [dbo].[MST_Staff].[UserID],
	   [dbo].[MST_Staff].[FirstName],
	   [dbo].[MST_Staff].[LastName],
	   [dbo].[MST_Role].[Role],
	   [dbo].[MST_Staff].[Salary],
	   [dbo].[MST_Staff].[DateOfBirth],
	   [dbo].[MST_Staff].[StaffNumber],
	   [dbo].[MST_Staff].[StaffEmail],
	   [dbo].[MST_Staff].[DateOfJoining],
	   [dbo].[MST_Staff].[IDProofPhotoPath],
	   [dbo].[MST_Staff].[IDProof],
	   [dbo].[MST_Staff].[StaffImage],
	   [dbo].[MST_Staff].[Created],
	   [dbo].[MST_Staff].[Modified]
FROM [dbo].[MST_Staff]

	INNER JOIN [dbo].[MST_Role]
	ON [dbo].[MST_Staff].[RoleID] = [dbo].[MST_Role].[RoleID]

ORDER BY [dbo].[MST_Staff].[FirstName],
		 [dbo].[MST_Staff].[LastName]
END

--========================================================

CREATE PROCEDURE [dbo].[PR_Staff_SelectByStaffID]
@StaffID int
AS
BEGIN
	Select 
		[dbo].[MST_Staff].[StaffID],
		[dbo].[MST_Staff].[FirstName],
		[dbo].[MST_Staff].[LastName],
		[dbo].[MST_Staff].[Salary],
		[dbo].[MST_Staff].[StaffImage],
		[dbo].[MST_Staff].[DateOfBirth],
		[dbo].[MST_Staff].[StaffNumber],
		[dbo].[MST_Staff].[StaffEmail],
		[dbo].[MST_Staff].[DateOfJoining],
		[dbo].[MST_Staff].[IDProof],
		[dbo].[MST_Staff].[Created],
		[dbo].[MST_Staff].[Modified]
	from [dbo].[MST_Staff]

	where [dbo].[MST_Staff].[StaffID] = @StaffID 
End

--=========================================================

CREATE PROCEDURE [dbo].[PR_Staff_DeleteByStaffID]
@StaffID int
AS
BEGIN
	Delete from [dbo].[MST_Staff]
	where [dbo].[MST_Staff].[StaffID] = @StaffID
END

--==========================================================

CREATE PROCEDURE [dbo].[PR_Staff_InsertRecord]
	@RoleID 			int,
	@FirstName			varchar(100),
	@LastName			varchar(100),
	@Salary				decimal(10,2),
	@DateOfBirth		Date,
	@StaffNumber		varchar(50),
	@StaffEmail			varchar(100),
	@DateOfJoining		date,
	@IDProofPhotoPath	varchar(200),
	@IDProof			varchar(100),
	@StaffImage			varchar(200)
AS
BEGIN
INSERT INTO [dbo].[MST_Staff]
(
	[dbo].[MST_Staff].[RoleID]
   ,[dbo].[MST_Staff].[FirstName]
   ,[dbo].[MST_Staff].[LastName]
   ,[dbo].[MST_Staff].[Salary]
   ,[dbo].[MST_Staff].[DateOfBirth]
   ,[dbo].[MST_Staff].[StaffNumber]
   ,[dbo].[MST_Staff].[StaffEmail]
   ,[dbo].[MST_Staff].[DateOfJoining]
   ,[dbo].[MST_Staff].[IDProofPhotoPath]
   ,[dbo].[MST_Staff].[IDProof]
   ,[dbo].[MST_Staff].[StaffImage]
)
VALUES
(
	@RoleID,
	@FirstName,
	@LastName,
	@Salary,
	@DateOfBirth,
	@StaffNumber,
	@StaffEmail,
	@DateOfJoining,
	@IDProofPhotoPath,
	@IDProof,
	@StaffImage
)
END

--======================================================

CREATE  PROCEDURE [dbo].[PR_Staff_UpdateRecord]
	@StaffID			int,
	@RoleID 			int,
	@FirstName			varchar(100),
	@LastName			varchar(100),
	@Salary				decimal(10,2),
	@DateOfBirth		Date,
	@StaffNumber		varchar(50),
	@StaffEmail			varchar(100),
	@DateOfJoining		date,
	@IDProofPhotoPath	varchar(200),
	@IDProof			varchar(100),
	@StaffImage			varchar(200)
AS
BEGIN
	UPDATE [dbo].[MST_Staff]
	SET
		[dbo].[MST_Staff].[RoleID] = @RoleID,
		[dbo].[MST_Staff].[FirstName] = @FirstName,
		[dbo].[MST_Staff].[LastName] = @LastName,
		[dbo].[MST_Staff].[Salary] = @Salary,
		[dbo].[MST_Staff].[DateOfBirth] = @DateOfBirth,
		[dbo].[MST_Staff].[StaffNumber] = @StaffNumber,
		[dbo].[MST_Staff].[StaffEmail] = @StaffEmail,
		[dbo].[MST_Staff].[DateOfJoining] = @DateOfJoining,
		[dbo].[MST_Staff].[IDProofPhotoPath] = @IDProofPhotoPath,
		[dbo].[MST_Staff].[IDProof] = @IDProof,
		[dbo].[MST_Staff].[StaffImage] = @StaffImage,
		[dbo].[MST_Staff].[Created] = (Select [dbo].[MST_Staff].[Created] from [dbo].[MST_Staff] where [dbo].[MST_Staff].[StaffID] = @StaffID),
		[dbo].[MST_Staff].[Modified] = GETDATE()
	WHERE [dbo].[MST_Staff].[StaffID] = @StaffID
END

--=========================================================

CREATE PROCEDURE [dbo].[PR_Staff_Filter]
@FirstName varchar(100) = null,
@StaffEmail varchar(100) = null,
@Role varchar(100) = null
as
BEGIN
	Select 
		[dbo].[MST_Staff].[StaffID]
		,[dbo].[MST_Staff].[RoleID]
		,[dbo].[MST_Staff].[FirstName]
		,[dbo].[MST_Staff].[LastName]
		,[dbo].[MST_Staff].[Salary]
		,[dbo].[MST_Staff].[DateOfBirth]
		,[dbo].[MST_Staff].[StaffNumber]
		,[dbo].[MST_Staff].[StaffEmail]
		,[dbo].[MST_Staff].[DateOfJoining]
		,[dbo].[MST_Staff].[IDProofPhotoPath]
		,[dbo].[MST_Staff].[IDProof]
		,[dbo].[MST_Staff].[StaffImage]

		FROM [dbo].[MST_Staff]
		INNER JOIN [dbo].[MST_Role]
		ON [dbo].[MST_Staff].[RoleID] = [dbo].[MST_Role].[RoleID]

WHERE (@FirstName is null OR [dbo].[MST_Staff].[FirstName] like '%'+@FirstName+'%')
AND   (@StaffEmail is null OR [dbo].[MST_Staff].[StaffEmail] like '%'+@StaffEmail+'%')
AND	  (@Role is null OR [dbo].[MST_Role].[Role] like '%'+@Role+'%')

ORDER BY [dbo].[MST_Staff].[StaffID]
END