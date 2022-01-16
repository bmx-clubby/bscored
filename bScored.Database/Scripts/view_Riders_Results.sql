
/****** Object:  View [dbo].[Riders_Results]    Script Date: 3/01/2022 10:05:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Riders_Results]
AS
SELECT        TOP (100) PERCENT RiderID, EventId, Membership_No, First_Name, Last_Name, Plate, Transponder, Class_Name, Club, BirthDate, Age, Class_No, Merged_To, Race_Class,
                             (SELECT        SUM(Points) AS Expr1
                               FROM            dbo.Results
                               WHERE        (EventId = r.EventId) AND (Membership_No = r.Membership_No)) AS Points, Type, FinishTime, RaceOrder
FROM            dbo.Riders_List AS r
GO