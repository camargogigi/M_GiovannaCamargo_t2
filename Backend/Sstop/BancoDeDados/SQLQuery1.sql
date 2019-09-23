CREATE DATABASE M_Sstop;

USE M_Sstop;

CREATE TABLE Estilos
(
    IdEstilo    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Artistas
(
    IdArtista     INT PRIMARY KEY IDENTITY
    ,Nome		  VARCHAR(200) UNIQUE
    ,IdEstilo     INT FOREIGN KEY REFERENCES Estilos (IdEstilo)
);


INSERT INTO Estilos VALUES ('R&B');
INSERT INTO Artistas VALUES ('Jeremih', 1);

SELECT * FROM Estilos;
SELECT * FROM ARTISTAS;

SELECT A.IdArtista, A.Nome, A.IdEstilo, E.Nome AS NomeEstilo FROM Artistas A INNER JOIN Estilos E ON A.IdEstilo = E.IdEstilo;

SELECT IdEstilo, Nome FROM Estilos

