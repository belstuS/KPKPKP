use KP_2019

--  Helpers

go
create procedure GetItemsJoin
as
begin
	select  Item.Id, 
			Item.Name,
			Item.Description,
			Item.Category_Id,
			ItemCategory.Category,
			Item.StartedPrice,
			Item.PriceGrowth
	from Item
	inner join ItemCategory on Item.Category_Id = ItemCategory.Id;
end;

go
create procedure GetDealsJoin
as
begin
	select  Deal.Id,
			Deal.Buyer_Id,
			Deal.Seller_Id,
			Deal.Item_Id,
			Deal.Auction_Id,
			Deal.DealState_Id,
			Deal.Time,
			Deal.Price,
			P1.LastName as BuyerName,
			P2.LastName as SellerName,
			Item.Name as ItemName,
			Auction.Date,
			DealState.State
	from Deal
	inner join Participant as P1 on Deal.Buyer_Id = P1.Id
	inner join Participant as P2 on Deal.Seller_Id = P2.Id
	inner join Item on Deal.Item_Id = Item.Id
	inner join Auction on Deal.Auction_Id = Auction.Id
	inner join DealState on Deal.DealState_Id = DealState.Id
end;


go
create procedure GetTradingProgressJoin
as
begin
	select  TradingProgress.Id,
			TradingProgress.Deal_Id,
			TradingProgress.Byer_Id,
			TradingProgress.StepTime,
			TradingProgress.StepRate,
			Deal.Time,
			Participant.LastName as BuyerName
	from TradingProgress
	inner join Deal on TradingProgress.Deal_Id = Deal.Id
	inner join Participant on TradingProgress.Byer_Id = Participant.Id;
end;


select DATEPART(YEAR, GETDATE())


go
create procedure GetFutureAuctions
as
begin
	select * from Auction
	where   DATEPART(YEAR, Auction.Date) >= DATEPART(YEAR, GETDATE()) and
			DATEPART(MONTH, Auction.Date) >= DATEPART(MONTH, GETDATE()) and
			DATEPART(DAY, Auction.Date) >= DATEPART(DAY, GETDATE());
end;

go
create procedure GetDealsByAuctionId(
	@Id int
)
as
begin
	select  Deal.Id,
			Deal.Buyer_Id,
			Deal.Seller_Id,
			Deal.Item_Id,
			Deal.Auction_Id,
			Deal.DealState_Id,
			Deal.Time,
			Deal.Price,
			P1.LastName as BuyerName,
			P2.LastName as SellerName,
			Item.Name as ItemName,
			Auction.Date,
			DealState.State
	from Deal
	inner join Participant as P1 on Deal.Buyer_Id = P1.Id
	inner join Participant as P2 on Deal.Seller_Id = P2.Id
	inner join Item on Deal.Item_Id = Item.Id
	inner join Auction on Deal.Auction_Id = Auction.Id
	inner join DealState on Deal.DealState_Id = DealState.Id
	where Deal.Auction_Id = @Id and
		  Deal.DealState_Id = (
								select DealState.Id from DealState
								where DealState.State = 'Run')
end;


go
create procedure GetAvailableItems
as
begin
	select * from Item
	inner join ItemCategory on Item.Category_Id = ItemCategory.Id
	where ItemCategory.Category = 'Available'
end;


go
create procedure SetSold(
	@Id int
)
as
begin
	update Item set
		Category_Id = (
						select ItemCategory.Id from ItemCategory
						where ItemCategory.Category = 'Sold')
	where Id = @Id;
end;


go
create procedure GetUsers
as
begin
	select * from Users;
end;


go
create procedure GetUserByLogin(
	@Login nvarchar(50)
)
as
begin
	select top(1) * from Users
	where Users.Login = @Login;
end;


go
create procedure EndAuction(
	@Id int
)
as
begin
	update Auction set
		Income =   (select sum(Deal.Price) from Deal
					where Deal.Auction_Id = @Id)
	where Id = @Id;
end;


go
create procedure MakeDealNoActive(
	@Id int
)
as
begin
	update Deal set
		DealState_Id = (select DealState.Id from DealState
						where DealState.State = 'Is over')
	where Id = @Id;
end;

/*
drop procedure  GetItemsJoin,
				GetDealsJoin,
				GetTradingProgressJoin,
				GetFutureAuctions,
				GetDealsByAuctionId,
				GetAvailableItems,
				GetUsers;
				*/

