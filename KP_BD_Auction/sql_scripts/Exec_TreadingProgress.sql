use KP_2019;


--  TradingProgress  --
go
create procedure GetTradingProgresses
as
begin
	select * from TradingProgress;
end;


go
create procedure GetTradingProgressById(
	@Id int
)
as
begin
	select * from TradingProgress;
end;


go
create procedure AddTradingProgress(
	@Deal_Id int,
	@Byer_Id int,
	@StepTime time,
	@StepRate money
)
as
begin
	insert into TradingProgress(Deal_Id, Byer_Id, StepTime, StepRate)
	values(@Deal_Id, @Byer_Id, @StepTime, @StepRate);
end;


go
create procedure UpdateTradingProgress(
	@Id int,
	@Deal_Id int,
	@Byer_Id int,
	@StepTime time,
	@StepRate money
)
as
begin
	update TradingProgress set
		Deal_Id = @Deal_Id,
		Byer_Id = @Byer_Id,
		StepTime = @StepTime,
		StepRate = @StepRate
	where Id = @Id;
end;


go
create procedure DeleteTradingProgress(
	@Id int
)
as
begin
	delete from TradingProgress where Id = @Id;
end;


drop procedure  GetTradingProgresses,
				GetTradingProgressById,
				AddTradingProgress,
				UpdateTradingProgress,
				DeleteTradingProgress;