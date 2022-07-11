create database Avicom;
go

use Avicom;
go

create table [dbo].[Manager]
(
	[ID_Manager] [int] not null identity(1,1), 
	[Name] [varchar] (40) not null,
	constraint [PK_Manager] primary key clustered 
	([ID_Manager] ASC) on [PRIMARY]
)
go

create table [dbo].[ClientStatus]
(
	[Status] [varchar] (15) not null, 
	constraint [PK_Status] primary key clustered 
	([Status] ASC) on [PRIMARY],
	constraint [UQ_Status] unique ([Status])
)
go

create table [dbo].[Product]
(
	[ID_Product] [int] not null identity(1,1), 
	[Name] [varchar] (40) not null,
	[Price] [decimal] (38,2) null default (0.00),
	[Type] [varchar] (40) not null,
	[SubPeriod] [varchar] (8)  null,
	constraint [PK_Product] primary key clustered 
	([ID_Product] ASC) on [PRIMARY],
	constraint [CH_Price] check ([Price]>=0)
)
go

create table [dbo].[Client]
(
	[ID_Client] [int] not null identity(1,1), 
	[Status] [varchar] (15) not null,
	[Manager_ID] [int] not null,
	[Name] [varchar] (40) not null,
	constraint [PK_Client] primary key clustered 
	([ID_Client] ASC) on [PRIMARY],
	constraint [FK_ClientStatus_Client] foreign key ([Status]) -- ограничение по типу внешнего ключа,
	-- с указанием названия ограничения "откуда-куда" с указанием поля из данной таблицы, которое является внешним ключом
	references [dbo].[ClientStatus] ([Status]),-- ссылка на значение первичного ключа родительской таблицы
	constraint [FK_Manager_Client] foreign key ([Manager_ID])
	references [dbo].[Manager] ([ID_Manager])
)
go

create table [dbo].[BuyedProducts](

	[Client_ID] [int] not null,
	[Product_ID] [int] not null,
	PRIMARY KEY([Client_ID], [Product_ID]),

	constraint [FK_Client_BuyedProducts] foreign key ([Client_ID])
	references [dbo].[Client] ([ID_Client]),

	constraint [FK_Product_BuyedProducts] foreign key ([Product_ID])
	references [dbo].[Product] ([ID_Product])
)
go

