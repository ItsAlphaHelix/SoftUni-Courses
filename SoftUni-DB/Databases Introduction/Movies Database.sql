CREATE DATABASE MOVIES

CREATE TABLE Directors (
    Id INT PRIMARY KEY,
    DirectorName NVARCHAR(MAX) NOT NULL,
    Notes NVARCHAR(MAX)

)
CREATE TABLE Genres (
    Id INT PRIMARY KEY,
    GenreName NVARCHAR(MAX) NOT NULL,
    Notes NVARCHAR(MAX)
)
CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    CategoryName NVARCHAR(MAX) NOT NULL,
    Notes NVARCHAR(MAX)
)
CREATE TABLE Movies
(
	Id INT PRIMARY KEY,
	Title NVARCHAR(MAX) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT NOT NULL,
	Length TIME,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL(5,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors VALUES
(1, 'Stoyan', NULL),
(2, 'Dimityr', NULL),
(3, 'Pesho', NULL),
(4, 'Angel', NULL),
(5, 'Georgi', NULL)


INSERT INTO Genres VALUES
(1, 'Drama', NULL),
(2, 'Comedy', NULL),
(3, 'Action', NULL),
(4, 'Fantastic', NULL),
(5, 'Horror', NULL)

INSERT INTO Categories VALUES
(1, 'Films', NULL),
(2, 'TV-Series', NULL),
(3, 'Animation', NULL),
(4, 'Biography', NULL),
(5, 'Documentary', NULL)

INSERT INTO Movies VALUES
(1, 'IT', 1, 2019, NULL, 4, 2, NULL, NULL),
(2, 'After', 2, 2019, NULL, 1, 2, 10, 'Best movie all times'),
(3, 'After 2', 3, 2020, NULL, 1, 2, 10, 'Another good SQL :D'),
(4, 'After 3', 4, 2021, NULL, 1, 2, 10, 'Keeping up the good work'),
(5, 'A star is born', 5, 2018, NULL, 1, 2, 10, 'One of the best dramas out there')

SELECT * FROM Movies