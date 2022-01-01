CREATE OR ALTER PROCEDURE [sp_Series_Insert] 
	-- Add the parameters for the stored procedure here
	@SeriesID int output,
	@Name nvarchar(50),
	@Sponser nvarchar(50),
	@Administrator nvarchar(10),
	@Numer_of_Rounds int,
	@Min_Non_Mandatory int,
	@Date Date,
	@Result_File nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Series(Name, Sponser, Administrator, Numer_of_Rounds, Min_Non_Mandatory, Date, Result_File) VALUES (@Name, @Sponser, @Administrator, @Numer_of_Rounds, @Min_Non_Mandatory, @Date, @Result_File)

	SET @SeriesID = SCOPE_IDENTITY()
END