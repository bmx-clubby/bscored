/****** Object:  View [dbo].[Series_Names]    Script Date: 3/01/2022 10:07:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Series_Names]
AS
SELECT        dbo.Series_Events.ID, dbo.Series_Events.SeriesID, dbo.Events.EventID, dbo.Events.Name, dbo.Events.Date, dbo.Events.Entry_No
FROM            dbo.Series_Events INNER JOIN
                         dbo.Events ON dbo.Series_Events.EventID = dbo.Events.EventID
GO
