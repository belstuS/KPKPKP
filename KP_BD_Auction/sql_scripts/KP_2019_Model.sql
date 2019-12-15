go

use KP_2019;

create table Participant
(
	Id				int identity(1, 1)	not null,
	FirstName		nvarchar(50)		not null,
	MiddleName		nvarchar(50)		not null,
	LastName		nvarchar(50)		not null,
	Age				int					not null,
	EMail			nvarchar(50)					unique,
	PhoneNumber		nvarchar(20)		not null	unique,

	primary key(Id)
);

create table Auction
(
	Id				int identity(1, 1)	not null,
	Date			date				not null,
	StartTime		time				not null,
	EndTime			time				not null,
	Income			money							default(0),

	primary key(Id)
);

create table ItemCategory
(
	Id				int identity(1, 1)	not null,
	Category		nvarchar(50)		not null	unique,

	primary key(Id)
);

create table DealState
(
	Id				int identity(1, 1)	not null,
	State			nvarchar(20)		not null	unique,

	primary key(Id)
);

create table Item
(
	Id				int identity(1, 1)	not null,
	Name			nvarchar(50)		not null,
	Description		nvarchar(256),
	Category_Id		int,
	StartedPrice	money				not null,
	PriceGrowth		money				not null,

	primary key(Id),
	foreign key(Category_Id) references ItemCategory(Id),
);


select * from Item

create table Deal
(
	Id				int identity(1, 1)	not null,
	Buyer_Id		int					not null,
	Seller_Id		int					not null,
	Item_Id			int					not null,
	Auction_Id		int					not null,
	DealState_Id	int					not null,
	Time			time				not null,
	Price			money				not null,

	primary key(Id),
	foreign key(Buyer_Id) references Participant(Id),
	foreign key(Seller_Id) references Participant(Id),
	foreign key(Item_Id) references Item(Id),
	foreign key(Auction_Id) references Auction(Id),
	foreign key(DealState_Id) references DealState(Id),
);


create table TradingProgress
(
	Id				int identity(1, 1)	not null,
	Deal_Id			int					not null,
	Byer_Id			int					not null,
	StepTime		time				not null,
	StepRate		money				not null,

	primary key(Id),
	foreign key(Deal_Id) references Deal(Id),
	foreign key(Byer_Id) references Participant(Id)
);


create table Users
(
	Id				int identity(1, 1)	not null,
	Login			nvarchar(50)		not null,
	Password		nvarchar(50)		not null,
	Role			nvarchar(50)		not null

	primary key(Id)

);

create table Register
(
	Id				int identity(1,1)	not null,
	Login			nvarchar(50)		not null,
	Password		nvarchar(50)		not null,
	Role			nvarchar(50)		not null

	primary key(Id),
);


drop table  TradingProgress,
			Deal, 
			Item, 
			DealState, 
			ItemCategory, 
			Auction, 
			Participant;


