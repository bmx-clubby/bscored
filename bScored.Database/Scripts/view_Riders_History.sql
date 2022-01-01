/****** Object:  View [dbo].[Riders_History]    Script Date: 29/12/2021 3:21:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Riders_History]
AS
SELECT        dbo.Riders.EventId, dbo.Events.Name, dbo.Events.Date, dbo.Riders.Membership_No, UPPER(LEFT(dbo.OSM_Membership.First_Name, 1)) + LOWER(RIGHT(dbo.OSM_Membership.First_Name, 
                         LEN(dbo.OSM_Membership.First_Name) - 1)) AS First_Name, dbo.OSM_Membership.Last_Name, dbo.Riders.Plate, dbo.Riders.Transponder, dbo.BMX_Classes.Name AS Class_Name
FROM            dbo.Events INNER JOIN
                         dbo.Riders ON dbo.Events.EventID = dbo.Riders.EventId INNER JOIN
                         dbo.BMX_Classes ON dbo.Riders.EventId = dbo.BMX_Classes.EventID AND dbo.Riders.Class_No = dbo.BMX_Classes.Class_No LEFT OUTER JOIN
                         dbo.OSM_Membership ON dbo.Riders.Membership_No = dbo.OSM_Membership.Membership_No LEFT OUTER JOIN
                         dbo.OSM_Clubs ON dbo.OSM_Membership.Club_Code = dbo.OSM_Clubs.Club_Code
GO