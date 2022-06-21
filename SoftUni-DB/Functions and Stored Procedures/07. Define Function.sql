CREATE DATABASE Words

CREATE TABLE Words(
    SetOfLetters NVARCHAR(50),
    Word NVARCHAR(50) 
)

INSERT INTO Words VALUES
('oistmiahf', 'Sofia'),
('oistmiahf', 'halves'),
('bobr', 'Rob'),
('pppp', 'Guy')

GO

CREATE OR ALTER FUNCTION ufn_isWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @currentIndex INT = 1
		WHILE(@currentIndex <= LEN(@word))
		BEGIN
			IF(CHARINDEX(SUBSTRING(@word, @currentIndex, 1), @setOfLetters) = 0)
				RETURN 0
			ELSE 
				SET @currentIndex += 1
		END
	RETURN 1
END

GO

SELECT
SetOfLetters
,Word
,dbo.ufn_IsWordComprised(SetOfLetters, Word) AS Result
FROM Words 