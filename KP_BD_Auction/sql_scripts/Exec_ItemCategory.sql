use KP_2019;


--  ItemCategory  --
go
create procedure GetItemCategories
as
begin
	select * from ItemCategory;
end;


go
create procedure GetItemCategoryById(
	@Id int
)
as
begin
	select * from ItemCategory where Id = @Id;
end;


go
create procedure AddItemCategory(
	@Category nvarchar(50)
)
as
begin
	insert into ItemCategory(Category)
	values (@Category);
end;


go
create procedure UpdateItemCategory(
	@Id int,
	@Category nvarchar(50)
)
as
begin
	update ItemCategory set
		Category = @Category
	where Id = @Id;
end;


go
create procedure DeleteItemCategory(
	@Id int
)
as
begin
	delete from ItemCategory where Id = @Id;
end;


drop procedure  GetItemCategories,
				GetItemCategoryById,
				AddItemCategory,
				UpdateItemCategory,
				DeleteItemCategory;