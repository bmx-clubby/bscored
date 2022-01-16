/****** Object:  View [dbo].[Race_Timing]    Script Date: 29/12/2021 3:20:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Race_Timing]
AS
SELECT        dbo.Mylaps_Pasing.ID, dbo.Mylaps_Pasing.EventId, dbo.Mylaps_Pasing.Timestamp, dbo.Mylaps_Pasing.Transponder, dbo.Mylaps_Pasing.Membership_No, dbo.OSM_Membership.First_Name, 
                         dbo.OSM_Membership.Last_Name, dbo.Mylaps_Pasing.GateTime, dbo.Passing_Type.Name AS Type_Name, 'Race ' + LTRIM(STR(dbo.Races.Race_No)) + ' Moto ' + LTRIM(STR(dbo.Races.Moto_No)) 
                         + ' ' + dbo.BMX_Classes.Name AS Race_Name, dbo.Mylaps_Pasing.RaceId, dbo.Mylaps_Pasing.Type, dbo.Mylaps_Pasing.Ignore
FROM            dbo.BMX_Classes INNER JOIN
                         dbo.Races ON dbo.BMX_Classes.EventID = dbo.Races.EventId AND dbo.BMX_Classes.Class_No = dbo.Races.Class_No RIGHT OUTER JOIN
                         dbo.Mylaps_Pasing LEFT OUTER JOIN
                         dbo.Passing_Type ON dbo.Mylaps_Pasing.Type = dbo.Passing_Type.Type ON dbo.Races.RaceId = dbo.Mylaps_Pasing.RaceId LEFT OUTER JOIN
                         dbo.OSM_Membership ON dbo.Mylaps_Pasing.Membership_No = dbo.OSM_Membership.Membership_No
GO
