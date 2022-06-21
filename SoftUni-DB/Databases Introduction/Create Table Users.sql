CREATE TABLE [Users] (
    [Id] BIGINT PRIMARY KEY IDENTITY,
    [Username] VARCHAR(30),
    [Password] VARCHAR(26),
    [ProfilePicture] VARBINARY(MAX),
    CHECK (DATALENGTH([ProfilePicture]) <= 900000),
    [LastLoginTime] DECIMAL(5, 2),
    [IsDeleted] CHAR(3) 
)

INSERT INTO [Users]([Username], [Password], [LastLoginTime], [IsDeleted])
    VALUES
('Ivan', '123Ivan255', 13.55, 'No'),
('Mitko', '33Ivan255', 15.55, 'Yes'),
('Kolio', '5520K', 11.35, 'No'),
('Georgi', 'g20G', 9.45, 'Yes'),
('Hektor', '133HektorR', 20.30, 'Yes')



SELECT * FROM [Users]