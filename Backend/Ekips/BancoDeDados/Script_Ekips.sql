CREATE DATABASE M_Ekips;
USE M_Ekips; 

CREATE TABLE Departamentos (
	IdDepartamento INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (100) NOT NULL UNIQUE
);

CREATE TABLE StatusCargo(
	IdStatus INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (20) NOT NULL
);

CREATE TABLE Cargos (
	IdCargo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (100) NOT NULL UNIQUE,
	IdStatus INT FOREIGN KEY REFERENCES StatusCargo(IdStatus),

);

CREATE TABLE Usuarios (
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (100) NOT NULL UNIQUE,
	Senha VARCHAR (100) NOT NULL,
	Permissão VARCHAR (100) NOT NULL 
);

CREATE TABLE Funcionarios (
	IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (100) NOT NULL UNIQUE,
	Cpf VARCHAR(11) NOT NULL UNIQUE,
	DataNascimento DATETIME NOT NULL,
	Salario VARCHAR (100) NOT NULL,
	IdDepartamento INT FOREIGN KEY REFERENCES Departamentos(IdDepartamento),
	IdCargo INT FOREIGN KEY REFERENCES Cargos(IdCargo),
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
);




INSERT INTO Departamentos 
VALUES ('administrativo'),
	   ('financeiro'),
	   ('recursos humanos'),
	   ('operacional'),
	   ('jurídico'),
	   ('tecnologia '),
	   ('comercial');
SELECT * FROM Departamentos ORDER BY IdDepartamento ASC;

INSERT INTO StatusCargo 
VALUES ('Ativo'),
	   ('Não Ativo');
SELECT * FROM StatusCargo ORDER BY IdStatus ASC;

INSERT INTO Cargos (Nome, IdStatus) 
VALUES ('Analista', 1),
	   ('Contador',1),
	   ('Diretor RH',2),
	   ('Gerente Assistente',2),
	   ('Advogado Trabalhista',1),
	   ('Product Owner',1),
	   ('Vendedor',1);
SELECT * FROM Cargos ORDER BY IdCargo ASC;

INSERT INTO Usuarios (Email, Senha, Permissão)
VALUES ('administrativo@email.com', '12581', 'ADMINISTRADOR'),
	   ('financeiro@email.com', '485545', 'COMUM'),
	   ('RH@email.com', '544321', 'ADMINISTRADOR'),
	   ('operacional@email.com', '5541616', 'COMUM'),
	   ('jurídico@email.com', '565656','COMUM'),
	   ('tecnologia@email.com', '165416', 'ADMINISTRADOR'),
	   ('comercial@email.com', '2525', 'COMUM');
SELECT * FROM Usuarios ORDER BY IdUsuario ASC;

INSERT INTO Funcionarios(Nome, Cpf, DataNascimento, Salario, IdDepartamento, IdCargo, IdUsuario)
VALUES ('Stefany De Oliveira', '12581452852', '1978-02-09T09:10:00', 'R$1.298,00', 1,1, 1),
	   ('Edson Lopes', '12581452853', '1979-10-29T09:10:00', 'R$2.898,00',2,2,2),
	   ('Lula Ladrão Roubou Meu Coração', '12581452854', '1989-04-12T09:10:00', 'R$1.500,00',3,3,3),
	   ('Tatiana Camargo', '12581452855', '1979-07-07T09:10:00', 'R$8.958,00',4,4,4),
	   ('Carolina Silva', '12581452856', '1984-11-03T09:10:00', 'R$14.508,00',5,5,5),
	   ('Teodorico', '12581452857', '2000-09-22T09:10:00', 'R$2.898,00',6,6,6),
	   ('Onório', '12581452858', '1969-05-11T09:10:00', 'R$5.898,00',7,7,7);
SELECT * FROM Funcionarios ORDER BY IdFuncionario ASC;



