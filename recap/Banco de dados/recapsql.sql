create database M_QuironRecap
use M_QuironRecap

create table Medicos(
	idMedico int primary key identity,
	nome varchar (255) not null,
	crm varchar (255) not null unique,
	crmuf varchar (255) not null
)

create table Pacientes(
	idPaciente int primary key identity,
	nome varchar (255) not null,
	dataNascimento date not null,
	cpf varchar (255) not null unique,
	idMedico int foreign key references Medicos (idMedico)
)

insert into Medicos
values ('Thiago Silva Mello','123','SP'),
	   ('Tatiana Mello de Camargo', '456', 'Rj'),
	   ('Fabiana Mello Antoniate', '789', 'RS');

insert into Pacientes
values ('Giovanna Camargo','2003/12/03','51729160832', 2),
	   ('Monique Cristina', '1999/04/25', '29158475698', 3),
	   ('Maria Eduarda Lorena', '2004/01/14', '62830271943',1),
	   ('Anna Beatriz Silva', '2005/10/04', '25489752148',1);	


select * from Medicos
select * from Pacientes