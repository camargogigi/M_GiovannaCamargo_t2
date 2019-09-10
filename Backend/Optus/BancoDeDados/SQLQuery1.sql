CREATE DATABASE M_Optus;
USE M_Optus;

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

SELECT * FROM Estilos;

INSERT INTO Estilos 
	VALUES ('Funk'),
		   ('Pagode'),
		   ('Pop'),
		   ('R&B'),
		   ('MPB');

INSERT INTO Artistas 
	VALUES ('Mc Livinho', 1),
		   ('Exaltassamba', 2),
		   ('Justin Bieber', 3),
		   ('Beyoncé', 4),
		   ('Silva', 5);

SELECT * FROM ARTISTAS;

SELECT A.IdArtista, A.Nome, A.IdEstilo, E.Nome AS NomeEstilo FROM Artistas A INNER JOIN Estilos E ON A.IdEstilo = E.IdEstilo;

CREATE TABLE Usuarios 
(
	IdUsuario 	INT PRIMARY KEY IDENTITY
	,Email		VARCHAR(255) NOT NULL UNIQUE
	,Senha		VARCHAR(255) NOT NULL
	,Permissao	VARCHAR(255) NOT NULL
);

INSERT INTO Usuarios (Email, Senha, Permissao) 
	VALUES ('admin@email.com', '123456', 'ADMINISTRADOR');
INSERT INTO Usuarios (Email, Senha, Permissao) 
	VALUES ('comum@email.com', '123456', 'COMUM');

SELECT * FROM Usuarios;