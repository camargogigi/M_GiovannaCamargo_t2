--ddl

CREATE DATABASE M_Gufos

USE M_Gufos;

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL 
	,Nome VARCHAR(255) NOT NULL
	,Email VARCHAR(255) NOT NULL UNIQUE
	,Senha VARCHAR(255) NOT NULL
	,Permissao VARCHAR(255) NOT NULL
);

CREATE TABLE Categorias(
	IdCategoria INT PRIMARY KEY IDENTITY NOT NULL 
	,Nome VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE Eventos(
	IdEvento INT PRIMARY KEY IDENTITY NOT NULL 
	,Titulo VARCHAR(255) NOT NULL
	,Descricao TEXT
	,DataEvento DATETIME NOT NULL
	,Localizacao VARCHAR(255) NULL
	,Ativo BIT NOT NULL DEFAULT(1)
	,IdCategoria INT FOREIGN KEY REFERENCES Categorias (IdCategoria)
);

CREATE TABLE Presencas(
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
	,IdEvento INT FOREIGN KEY REFERENCES Eventos (IdEvento)
);

--dml

INSERT INTO Usuarios(Nome, Email, Senha, Permissao)
	VALUES ('Administrador', 'admin@admin.com', '123456', 'Administrador');


INSERT INTO Usuarios(Nome, Email, Senha, Permissao)
	VALUES ('Josias Cabele', 'jc@senai.com', '123456', 'Aluno');

INSERT INTO Categorias(Nome)
	VALUES ('Jogos'),('Meetup'),('Futebol');

SELECT * FROM Categorias ORDER BY IdCategoria ASC;

INSERT INTO Eventos(Titulo, Descricao, DataEvento, Ativo, Localizacao, IdCategoria)
	VALUES ('Ping Pong', 'Campeonato redes contra dev', '2019-06-03T19:00:00', 1, 'Alameda Barão de Limeira, 539', 1);

SELECT * FROM Eventos ORDER BY IdEvento ASC;
SELECT * FROM Presencas;
SELECT * FROM Usuarios;

INSERT INTO Presencas(IdEvento, IdUsuario)
	VALUES (1,2)


