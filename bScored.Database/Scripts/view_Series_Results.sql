/****** Object:  View [dbo].[Series_Results]    Script Date: 3/01/2022 10:08:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Series_Results]
AS
SELECT        dbo.Series_Riders.SeriesID, dbo.Series_Riders.Membership_No, UPPER(LEFT(dbo.OSM_Membership.First_Name, 1)) + LOWER(RIGHT(dbo.OSM_Membership.First_Name, LEN(dbo.OSM_Membership.First_Name) - 1)) 
                         AS First_Name, dbo.OSM_Membership.Last_Name, dbo.OSM_Membership.BirthDate, YEAR(dbo.Series.Date) - YEAR(dbo.OSM_Membership.BirthDate) AS Age, dbo.OSM_Clubs.[Group] AS Club, dbo.Series_Riders.Class_No, 
                         dbo.Series_Riders.Class_Name, dbo.Series_Riders.Hilltime, dbo.Series_Riders.Finishtime, dbo.Series_Riders.Entered, dbo.Series_Riders.Series_Total, dbo.Series_Riders.R1_Total, dbo.Series_Riders.R2_Total, 
                         dbo.Series_Riders.R3_Total, dbo.Series_Riders.R4_Total, dbo.Series_Riders.R5_Total, dbo.Series_Riders.R6_Total, dbo.Series_Riders.R7_Total, dbo.Series_Riders.R8_Total, dbo.Series_Riders.R9_Total, 
                         dbo.Series_Riders.R10_Total, dbo.Series_Riders.R11_Total, dbo.Series_Riders.R12_Total, dbo.Series.Min_Non_Mandatory, 
                         CASE WHEN dbo.Series_Riders.Entered >= dbo.Series.Min_Non_Mandatory THEN 1 ELSE 0 END AS Qualified
FROM            dbo.Series RIGHT OUTER JOIN
                         dbo.Series_Riders ON dbo.Series.SeriesID = dbo.Series_Riders.SeriesID LEFT OUTER JOIN
                         dbo.OSM_Clubs RIGHT OUTER JOIN
                         dbo.OSM_Membership ON dbo.OSM_Clubs.Club_Code = dbo.OSM_Membership.Club_Code ON dbo.Series_Riders.Membership_No = dbo.OSM_Membership.Membership_No
GO