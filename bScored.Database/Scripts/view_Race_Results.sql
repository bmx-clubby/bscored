GO

/****** Object:  View [dbo].[Race_Results]    Script Date: 29/12/2021 3:19:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Race_Results]
AS
SELECT        dbo.Races.EventId, dbo.Races.Race_No, dbo.Results.Membership_No, dbo.OSM_Membership.First_Name, dbo.OSM_Membership.Last_Name, dbo.Results.Hilltime, dbo.Results.Finishtime, dbo.Results.Place, 
                         dbo.Results.Points, dbo.Results.ResultId, dbo.Races.Moto_No, dbo.Races.Class_No, dbo.Riders.Plate, dbo.Riders.Transponder
FROM            dbo.Races INNER JOIN
                         dbo.Results ON dbo.Races.EventId = dbo.Results.EventId AND dbo.Races.Race_No = dbo.Results.Race_No INNER JOIN
                         dbo.OSM_Membership ON dbo.Results.Membership_No = dbo.OSM_Membership.Membership_No INNER JOIN
                         dbo.Riders ON dbo.Results.RiderID = dbo.Riders.RiderID
GO


