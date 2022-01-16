
/****** Object:  View [dbo].[Race_Draw]    Script Date: 15/02/2021 10:08:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Race_List]
AS
SELECT        dbo.Races.RaceId, dbo.Races.EventId, dbo.Races.Race_No, dbo.Races.Moto_No, dbo.Phases.Phase_Name AS Moto_Name, dbo.Races.Class_No, dbo.BMX_Classes.Name AS Class_Name, dbo.Races.Gate_No, 
                         dbo.Races.Starttime, dbo.BMX_Classes.Type AS Class_Type, dbo.Races.Race_Status
FROM            dbo.Races INNER JOIN
                         dbo.BMX_Classes ON dbo.Races.Class_No = dbo.BMX_Classes.Class_No AND dbo.Races.EventId = dbo.BMX_Classes.EventID INNER JOIN
                         dbo.Phases ON dbo.Races.Moto_No = dbo.Phases.Phase_No
GO