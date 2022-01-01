
/****** Object:  View [dbo].[Riders_List]    Script Date: 16/01/2021 4:10:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Riders_List]
AS
SELECT        TOP (100) PERCENT dbo.Riders.RiderID, dbo.Riders.Membership_No, dbo.OSM_Membership.First_Name, dbo.OSM_Membership.Last_Name, dbo.OSM_Clubs.[Group] AS Club, dbo.Riders.Plate, dbo.Riders.Transponder, 
                         BMX_Classes_1.Name AS Class_Name, dbo.OSM_Membership.BirthDate, YEAR(dbo.Events.Date) - YEAR(dbo.OSM_Membership.BirthDate) AS Age, dbo.Riders.Class_No, 
                         (CASE WHEN BMX_Classes.Name = BMX_Classes_1.Name THEN '' ELSE BMX_Classes.Name END) AS Merged_To, BMX_Classes_1.Race_Class, dbo.Riders.EventId, BMX_Classes_1.Type, dbo.Riders.Chip_Status, 
                         dbo.OSM_Membership.Status AS Membership_Status, dbo.Riders.FinishTime, BMX_Classes_1.RaceOrder
FROM            dbo.Events RIGHT OUTER JOIN
                         dbo.Riders ON dbo.Events.EventID = dbo.Riders.EventId LEFT OUTER JOIN
                         dbo.OSM_Membership LEFT OUTER JOIN
                         dbo.OSM_Clubs ON dbo.OSM_Membership.Club_Code = dbo.OSM_Clubs.Club_Code ON dbo.Riders.Membership_No = dbo.OSM_Membership.Membership_No LEFT OUTER JOIN
                         dbo.BMX_Classes INNER JOIN
                         dbo.BMX_Classes AS BMX_Classes_1 ON dbo.BMX_Classes.EventID = BMX_Classes_1.EventID AND dbo.BMX_Classes.Class_No = BMX_Classes_1.Race_Class ON dbo.Riders.EventId = BMX_Classes_1.EventID AND 
                         dbo.Riders.Class_No = BMX_Classes_1.Class_No
GO
