
DROP PROCEDURE  IF EXISTS sp_series_totals

GO

CREATE PROCEDURE sp_series_totals
	-- Add the parameters for the stored procedure here
	@SeriesID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Calculate Series Total
    UPDATE Series_Riders SET Series_Total = IsNull(R1_Total, 0) +
         IsNull(R2_Total, 0) + IsNull(R3_Total, 0) + IsNull(R4_Total, 0) + 
		 IsNull(R5_Total, 0) + IsNull(R6_Total, 0) + IsNull(R7_Total, 0) + 
		 IsNull(R8_Total, 0) + IsNull(R9_Total, 0) + IsNull(R10_Total, 0) + 
		 IsNull(R11_Total, 0) + IsNull(R12_Total, 0)  
         WHERE SeriesID = @SeriesID

    -- Calculate Events Entered
	UPDATE Series_Riders SET Entered = CASE WHEN R1_Total IS NOT NULL THEN 1 ELSE 0 END + 
         CASE WHEN R2_Total IS NOT NULL THEN 1 ELSE 0 END + 
         CASE WHEN R3_Total IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN R4_Total IS NOT NULL THEN 1 ELSE 0 END +
		 CASE WHEN R5_Total IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN R6_Total IS NOT NULL THEN 1 ELSE 0 END +
         CASE WHEN R7_Total IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN R8_Total IS NOT NULL THEN 1 ELSE 0 END +
         CASE WHEN R9_Total IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN R10_Total IS NOT NULL THEN 1 ELSE 0 END +
         CASE WHEN R11_Total IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN R12_Total IS NOT NULL THEN 1 ELSE 0 END
		 WHERE SeriesID = @SeriesID

END
GO


