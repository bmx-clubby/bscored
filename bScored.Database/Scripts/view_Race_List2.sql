

/****** Object:  View [dbo].[Race_Draw]    Script Date: 15/02/2021 10:08:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER VIEW [Race_List2]
AS
SELECT        RaceId, EventId, Race_No, Moto_No, Moto_Name, Class_No, Class_Name, Gate_No, Starttime, Class_Type, Race_Status,
                             (SELECT        COUNT(Lane_No) AS Expr1
                               FROM            dbo.Results
                               WHERE        (EventId = r.EventId) AND (Race_No = r.Race_No)) AS Entry_No,
                             (SELECT        COUNT(Lane_No) AS Expr1
                               FROM            dbo.Results AS Results_1
                               WHERE        (EventId = r.EventId) AND (Race_No = r.Race_No) AND (Lane_No > 0)) AS Draw_No
FROM            dbo.Race_List AS r
GO
