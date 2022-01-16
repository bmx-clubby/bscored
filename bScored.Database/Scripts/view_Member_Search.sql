
/****** Object:  View [dbo].[Member_Search]    Script Date: 1/02/2021 9:50:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Member_Search]
AS
SELECT        dbo.OSM_Membership.Membership_No, dbo.OSM_Membership.First_Name, dbo.OSM_Membership.Last_Name, dbo.OSM_Membership.Member_Type, YEAR(GETDATE()) - YEAR(dbo.OSM_Membership.BirthDate) AS Age, 
                         dbo.OSM_Membership.First_Name + N' ' + UPPER(dbo.OSM_Membership.Last_Name) AS Name, dbo.OSM_Clubs.[Group] AS Club, dbo.OSM_Membership.Club_Code, dbo.OSM_Membership.Transponder, 
                         dbo.OSM_Membership.Transponder_ID1, dbo.OSM_Membership.Transponder_ID2, dbo.OSM_Membership.Transponder_ID3
FROM            dbo.OSM_Membership LEFT OUTER JOIN
                         dbo.OSM_Clubs ON dbo.OSM_Membership.Club_Code = dbo.OSM_Clubs.Club_Code
GO
