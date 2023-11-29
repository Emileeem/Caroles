use master
go

if exists(select * from sys.databases where name = 'Caroles')
	drop database Caroles

create database Caroles
go

use Caroles
go

create table Cliente(
	ID int identity primary key, 
	Nome varchar(20) not null,
	Sobrenome varchar(50) not null,
	Senha varchar(90) not null, 
	DataNasc date not null,
	Email varchar (50) not null,
	Salt varchar (200) not null,
);
go

create table Funcionario(
	ID int identity primary key,
	Senha varchar(90) not null,
	Email varchar (50) not null,
	Salt varchar (200) not null,
);
go
create table Codigos(
	ID int identity primary key,
	CodigoAleat varchar(9) not null
); 
go
create table Produtos(
	ID int identity primary key,
	Nome varchar(20) not null,
	Preco decimal (5, 2) not null,
	Foto varbinary(MAX) null,
	Descricao varchar(500) not null,
	CodigosId int references Codigos(ID) not null
);
go

create table PedidoCliente(
	ID int identity primary key,
	ProdutosId int references Produtos(ID) not null,
	HoraPedido datetime null,
	HoraPronto datetime null
); 
go

