use KP_2019

--  Auction  --
go
create procedure GetAuctions
as
begin
	select * from Auction;
end;


go
create procedure GetAuctionById(
	@Id int
)
as
begin
	select * from Auction where Auction.Id = @Id;
end;


go
create procedure AddAuction(
	@Date date,
	@StartTime time,
	@EndTime time,
	@Income money
)
as
begin
	insert into Auction(Date, StartTime, EndTime, Income)
	values(@Date, @StartTime, @EndTime, @Income);
end;


go
create procedure UpdateAuction(
	@Id int,
	@Date date,
	@StartTime time,
	@EndTime time,
	@Income money
)
as
begin
	update Auction set
		Date = @Date,
		StartTime = @StartTime,
		EndTime = @EndTime,
		Income = @Income
	where Id = @Id;
end;


go
create procedure DeleteAuction(
	@Id int
)
as
begin
	delete from Auction where Id = @Id;
end;

drop procedure	GetAuctions,
				GetAuctionById,
				AddAuction,
				UpdateAuction,
				DeleteAuction;