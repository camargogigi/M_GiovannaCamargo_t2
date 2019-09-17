CREATE DATABASE M_OpFlix
USE M_OpFlix

--M_01_GiovannaCamargo_DDL;

CREATE TABLE TiposUsuarios(
	IdTipoUser INT PRIMARY KEY IDENTITY
	,Tipo VARCHAR (200) UNIQUE NOT NULL
);
CREATE TABLE Tipos(
	IdTipo INT PRIMARY KEY IDENTITY
	,Nome VARCHAR (200) UNIQUE NOT NULL
);
CREATE TABLE Plataformas(
	IdPlataforma INT PRIMARY KEY IDENTITY
	,Nome VARCHAR (200) UNIQUE NOT NULL
);
CREATE TABLE Categorias(
	IdCategoria INT PRIMARY KEY IDENTITY
	,Nome VARCHAR (200) UNIQUE NOT NULL
);
CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY
	,Nome VARCHAR (200) UNIQUE NOT NULL
	,IdTipoUser INT FOREIGN KEY REFERENCES TiposUsuarios (IdTipoUser)
	,Telefone VARCHAR (20) UNIQUE NOT NULL
	,CPF VARCHAR (15) UNIQUE NOT NULL
	,Senha VARCHAR (200) NOT NULL
	,Email VARCHAR (200) UNIQUE NOT NULL
);
CREATE TABLE Lancamentos(
	IdLancamento INT PRIMARY KEY IDENTITY
	,Nome VARCHAR (200) UNIQUE NOT NULL
	,DataEstreia DATETIME NOT NULL
	,IdTipo INT FOREIGN KEY REFERENCES Tipos (IdTipo)
	,Descricao VARCHAR (500) NOT NULL
	,Sinopse VARCHAR (500) NOT NULL
	,IdCategoria INT FOREIGN KEY REFERENCES Categorias (IdCategoria)
	,IdPlataforma INT FOREIGN KEY REFERENCES Plataformas (IdPlataforma)
	,TempoDuracao VARCHAR (200) NOT NULL
);
CREATE TABLE Favoritos (
	IdLancamento INT FOREIGN KEY REFERENCES Lancamentos (IdLancamento)
	,IdUsuario INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
);



--M_02_GiovannaCamargo_DML;

INSERT INTO TiposUsuarios (Tipo)
VALUES ('Administrador')
	   ,('Cliente');

INSERT INTO Tipos (Nome)
VALUES ('Filme')
	   ,('Série');


INSERT INTO Plataformas(Nome)
VALUES ('Netflix')
	   ,('Amazon')
	   ,('Cinema');

INSERT INTO Usuarios (Nome, IdTipoUser, Telefone, CPF, Senha, Email)
VALUES ('Helena', 1, 99999, 2854211, '123659g8', 'h@.com')
	   ,('Erik', 2, 55555, 2854212, '123659g8', 'e@.com')
	   ,('Giovanna', 2, 99599, 285213, '123659g8', 'g@.com');

INSERT INTO Categorias(Nome)
VALUES ('Ação')
	   ,('Anime')
	   ,('Clássico')
	   ,('Comédia')
	   ,('Stand-up')
	   ,('Documentário')
	   ,('Drama')
	   ,('HollyWood')
	   ,('Musicais')
	   ,('Suspenses')
	   ,('Terror')
	   ,('Teen')
	   ,('Infantil');

INSERT INTO Lancamentos(Nome, DataEstreia ,IdTipo ,Descricao ,Sinopse ,IdCategoria ,IdPlataforma ,TempoDuracao)
VALUES ('Alice através do espelho', '2019-08-04T00:00:00', 1, 'Estrelado por estrelas como Mia Wasikowska e JOHNNY DEPP', 'Depois de passar anos no mar, Alice retorna. Mas ela precisa atravessar o espelho e voltar no tempo para salvar o chapeleiro antes que seja tarde
', 1, 2, '1h54min'),
	   ('Sintonia', '2019-07-05T00:00:00', 2, '1 Temporada', 'Criados juntos na quebrada de SP, três jovens amigos correm atrás de  seus sonhos rodeados por música, droga e religião
', 12, 1, '43min/ep'),
	   ('Cinderella', '2018-12-12T00:00:00', 1, 'Lily James é Ella neste Live Action de Cinderella', 'A órfã Ella precisa lidar com o péssimo tratamento que recebe da madrasta e das meia-irmãs, até que um encontro inesperado faz tudo mudar
', 12, 2, '1h47min'),
	   ('Sing', '2019-03-26T00:00:00', 1, 'Dublado por  Matthew McConaughey, Reese Witherspoon, Seth MacFarlane', 'Um coala otimista tenta salvar seu teatro com um concurso de canto com uma elefanta tímida, uma gorila adolescente e muitos outros participantes
', 9, 3, '1h54min');

INSERT INTO Favoritos(IdLancamento, IdUsuario)
VALUES (3,2)
	   ,(1,3)
	   ,(2,2)
	   ,(4,3)
	   ,(4,1);


--M_03_GiovannaCamargo_DQL;

SELECT * FROM TiposUsuarios;
SELECT * FROM Tipos;
SELECT * FROM Favoritos ORDER BY IdLancamento ASC;
SELECT * FROM Plataformas ORDER BY IdPlataforma asc;
SELECT * FROM Usuarios ORDER BY IdUsuario asc;
SELECT * FROM Categorias ORDER BY IdCategoria asc;
SELECT * FROM Lancamentos ORDER BY IdLancamento asc;


select Usuarios.*, TiposUsuarios.* 
from Usuarios
inner join TiposUsuarios
on Usuarios.IdTipoUser = TiposUsuarios.IdTipoUser;

select Lancamentos.*, Plataformas.*, Tipos.*, Categorias.*
from Lancamentos
join Plataformas
on Lancamentos.IdPlataforma = Plataformas.IdPlataforma
join Tipos
on Lancamentos.IdTipo = Tipos.IdTipo
join Categorias
on Lancamentos.IdCategoria = Categorias.IdCategoria;

select Favoritos.*, Lancamentos.*, Usuarios.*
from Favoritos
join Lancamentos
on Favoritos.IdLancamento = Lancamentos.IdLancamento
join Usuarios
on Favoritos.IdUsuario = Usuarios.IdUsuario

delete from Favoritos