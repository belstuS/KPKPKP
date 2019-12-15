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


drop procedure  GetItems,
				GetItemById,
				AddItem,
				UpdateItem,
				DeleteItem;