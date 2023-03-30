create table Compradores(
	id int identity primary key,
	email varchar(100) not null unique check (email like '%@%.%'),
	nome varchar(100) not null,
	morada varchar(100) not null,
	nif varchar(9) not null,
	password varchar(64) not null,
	estado int not null,
	perfil int not null check (perfil in ('0','1')),
	lnkRecuperar varchar(36),
	data_lnk date,
)

CREATE TABLE Produtos
(
	[nproduto] INT NOT NULL PRIMARY KEY identity,
	nome varchar(100) not null,
	preco decimal(8,2) not null check (preco > 0),
	tipo varchar(50) not null,
	stock int not null check (stock >= 0)
)
create table Compras(
	ncompras int identity primary key,
	nproduto int references Produtos(nproduto),
	idcompradores int references Compradores(id),
	data_compra date default check (data_compra < getdate())
)


