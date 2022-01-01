
/****** Object:  View [dbo].[Rider_Classes]    Script Date: 29/12/2021 3:20:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [Rider_Classes]
AS
SELECT        dbo.BMX_Classes.EventID, dbo.BMX_Classes.Class_No, dbo.BMX_Classes.Name, dbo.BMX_Classes.Entry_No, dbo.BMX_Classes.Race_Class, 
                         (CASE WHEN BMX_Classes.Name = BMX_Classes_1.Name THEN BMX_Classes.Race_No ELSE 0 END) AS Race_No, (CASE WHEN BMX_Classes.Name = BMX_Classes_1.Name THEN '' ELSE BMX_Classes_1.Name END) 
                         AS Merged_To, dbo.BMX_Classes.MinEntry, dbo.BMX_Classes.Type, dbo.BMX_Classes.RaceOrder, dbo.BMX_Classes.FinalOrder, dbo.BMX_Classes.ClassID
FROM            dbo.BMX_Classes INNER JOIN
                         dbo.BMX_Classes AS BMX_Classes_1 ON dbo.BMX_Classes.Race_Class = BMX_Classes_1.Class_No AND dbo.BMX_Classes.EventID = BMX_Classes_1.EventID
GO