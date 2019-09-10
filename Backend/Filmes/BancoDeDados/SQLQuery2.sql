USE M_Filmes;

INSERT INTO Generos
VALUES ('Ficção'),
	   ('Ação'),
	   ('Nacional'),
	   ('Teen'),
	   ('Infantil');
SELECT * FROM Generos

INSERT INTO Filmes (Titulo, IdGenero)
VALUES ('Alice no país das maravilhas',1),
	   ('Vingadores',2),
	   ('De pernas pro ar',3),
	   ('Barraca do Beijo', 4),
	   ('Barbie no castelo de diamantes',5);
SELECT * FROM Filmes

Delete from Filmes

INSERT INTO Filmes (Titulo, IdGenero)
VALUES ('Alice no país das maravilhas',1),
	   ('Vingadores',2),
	   ('De pernas pro ar',3),
	   ('Barbie no castelo de diamantes',5);

	   
	   select * from filmes