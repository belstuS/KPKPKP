use KP_2019

--  Item  --
go
create procedure GetItems
as
begin
	select * from Item;
end;


go
create procedure GetItemById(
	@Id int
)
as
begin
	select * from Item where Id = @Id;
end;


go
create procedure AddItem(
	@Name nvarchar(50),
	@Description nvarchar(256),
	@Category_Id int,
	@StartedPrice money,
	@PriceGrowth money
)
as
begin
	insert into Item(Name, Description, Category_Id, StartedPrice, PriceGrowth)
	values(@Name, @Description, @Category_Id, @StartedPrice, @PriceGrowth);
end;


go
create procedure UpdateItem(
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(256),
	@Category_Id int,
	@StartedPrice money,
	@PriceGrowth money
)
as
begin
	update Item set
		Name = @Name,
		Description = @Description,
		Category_Id = @Category_Id,
		StartedPrice = @StartedPrice,
		PriceGrowth = @PriceGrowth
	where Id = @Id;
end;


go
create procedure DeleteItem(
	@Id int
)
as
begin
	delete from Item where Id = @Id;
end;



INSERT INTO [dbo].[Item]
           ([Name]
           ,[Description]
           ,[Category_Id]
           ,[StartedPrice]
           ,[PriceGrowth])
     VALUES
		   ('IPhone', 'Phone', 1, 2000, 50),
           ('BMW', '', 1, 40000, 500),
           ('Baack', '', 1, 200, 10),
           ('Gold pen', '', 1, 5000, 200),
           ('Flwoers', '', 1, 5, 1),
           ('Tony Stark toy', '', 1, 100000, 100000),
           ('Clock', '', 1, 250, 5),
           ('Sandwich', '', 1, 1, 1),
           ('Gitara', '', 1, 150, 15),
           ('Virginity', '', 1, 1000000, 100000),
           ('Elephant', '', 1, 700000, 7000)


--drop procedure  GetItems,
--				GetItemById,
--				AddItem,
--				UpdateItem,
--				DeleteItem;