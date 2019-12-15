use KP_2019;


--  Deal  --
go
create procedure GetDeals
as
begin
	select * from Deal;
end;


go
create procedure GetDealById(
	@Id int
)
as
begin
	select * from Deal where Id = @Id;
end;


go
create procedure AddDeal(
	@Buyer_Id int,
	@Seller_Id int,
	@Item_Id int,
	@Auction_Id int,
	@DealState_Id int,
	@Time time,
	@Price money
)
as
begin
	insert into Deal(Buyer_Id, Seller_Id, Item_Id, Auction_Id, DealState_Id, Time, Price)
	values(@Buyer_Id, @Seller_Id, @Item_Id, @Auction_Id, @DealState_Id, @Time, @Price);
end;


go
create procedure UpdateDeal(
	@Id int,
	@Buyer_Id int,
	@Seller_Id int,
	@Item_Id int,
	@Auction_Id int,
	@DealState_Id int,
	@Time time,
	@Price money
)
as
begin
	update Deal set
		Buyer_Id = @Buyer_Id, 
		Seller_Id = @Seller_Id, 
		Item_Id = @Item_Id, 
		Auction_Id = @Auction_Id, 
		DealState_Id = @DealState_Id, 
		Time = @Time, 
		Price = @Price
	where Id = @Id;
end;


go
create procedure DeleteDeal(
	@Id int
)
as
begin
	delete from Deal where Id = @Id;
end;


drop procedure  GetDeals,
				GetDealById,
				AddDeal,
				UpdateDeal,
				DeleteDeal;