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
	isAdmin bit not null
);
go

create table Codigos(
	ID int identity primary key,
	CodigoAleat varchar(9) not null
); 
go
create table Imagem(
	ID int identity primary key,
	Foto varbinary(MAX) not null
);
go
create table Produtos(
	ID int identity primary key,
	Nome varchar(20) not null,
	Preco decimal (5, 2) not null,
	Descricao varchar(500) not null,
	Categoria varchar(15) not null,
	Promocao bit not null,
	ImagemId int references Imagem(ID) null,
	CodigosId int references Codigos(ID) null
);
go

create table PedidoCliente(
	ID int identity primary key,
	Apelido varchar(20),
	ProdutosId int references Produtos(ID) not null,
	HoraPedido datetime null,
	HoraPronto datetime null
); 
go

select * from Imagem
select * from Produtos

update Cliente 
	set isAdmin = 1
	where Nome = 'Admin'