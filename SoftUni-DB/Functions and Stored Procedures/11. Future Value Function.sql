CREATE FUNCTION ufn_CalculateFutureValue
        (@Sum DECIMAL(18, 4), @yir FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
    DECLARE @Result DECIMAL(18, 4)
    SET @Result = @Sum * Power((1 + @yir), @NumberOfYears)
    RETURN @Result
END

GO

CREATE TABLE Formula(
    InitialSum DECIMAL(18, 9),
    YearlyInterestRate FLOAT(24),
    Years INT
)

INSERT INTO Formula VALUES
(1000, 0.1, 5)

SELECT 
dbo.ufn_CalculateFutureValue(InitialSum, YearlyInterestRate, Years) AS [Output]
FROM Formula