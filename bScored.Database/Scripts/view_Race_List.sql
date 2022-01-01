
/****** Object:  View [dbo].[Race_Draw]    Script Date: 15/02/2021 10:08:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Race_Draw]
AS
SELECT        dbo.Results.ResultId, dbo.Results.EventId, dbo.Results.Race_No, dbo.Results.Membership_No, dbo.OSM_Membership.First_Name, dbo.OSM_Membership.Last_Name, dbo.Results.Lane_No, dbo.Races.Class_No, 
                         dbo.BMX_Classes.Name AS Class_Name, dbo.Phases.Phase_Name, dbo.Races.Moto_No, dbo.OSM_Clubs.[Group], dbo.Riders.Plate
FROM            dbo.Results INNER JOIN
                         dbo.OSM_Membership ON dbo.Results.Membership_No = dbo.OSM_Membership.Membership_No INNER JOIN
                         dbo.Races ON dbo.Results.EventId = dbo.Races.EventId AND dbo.Results.Race_No = dbo.Races.Race_No INNER JOIN
                         dbo.BMX_Classes ON dbo.Races.Class_No = dbo.BMX_Classes.Class_No AND dbo.Races.EventId = dbo.BMX_Classes.EventID INNER JOIN
                         dbo.Phases ON dbo.Races.Moto_No = dbo.Phases.Phase_No INNER JOIN
                         dbo.Riders ON dbo.Results.RiderID = dbo.Riders.RiderID LEFT OUTER JOIN
                         dbo.OSM_Clubs ON dbo.OSM_Membership.Club_Code = dbo.OSM_Clubs.Club_Code
GO
