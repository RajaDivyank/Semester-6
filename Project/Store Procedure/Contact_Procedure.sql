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