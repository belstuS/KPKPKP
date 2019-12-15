use KP_2019;


--  DealState  --
go
create procedure GetDealStates
as
begin
	select * from DealState;
end;


go 
create procedure GetDealStateById(
	@Id int
)
as
begin
	select * from DealState where Id = @Id;
end;


go
create procedure AddDealState(
	@State nvarchar(20)
)
as
begin
	insert into DealState(State)
	values(@State);
end;


go
create procedure UpdateDealState(
	@Id int,
	@State nvarchar(20)
)
as
begin
	update DealState set
		State = @State
	where Id = @Id;
end;


go
create procedure DeleteDealState(
	@Id int
)
as
begin
	delete from DealState where Id = @Id;
end;


drop procedure  GetDealStates,
				GetDealStateById,
				AddDealState,
				UpdateDealState,
				DeleteDealState;