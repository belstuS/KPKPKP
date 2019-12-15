use KP_2019;


--  Participant  --
go
create procedure GetParticipants
as
begin
	select * from Participant;
end;


go
create procedure GetParticipantById(
	@Id int
)
as
begin
	select * from Participant where Id = @Id;
end;


go
create procedure AddParticipant(
	@FirstName nvarchar(50),
	@MiddleName nvarchar(50),
	@LastName nvarchar(50),
	@Age int,
	@EMail nvarchar(50),
	@PhoneNumber nvarchar(20)
)
as
begin
	insert into Participant(FirstName, MiddleName, LastName, Age, EMail, PhoneNumber)
	values(@FirstName, @MiddleName, @LastName, @Age, @EMail, @PhoneNumber);
end;


go
create procedure UpdateParticipant(
	@Id int,
	@FirstName nvarchar(50),
	@MiddleName nvarchar(50),
	@LastName nvarchar(50),
	@Age int,
	@EMail nvarchar(50),
	@PhoneNumber nvarchar(20)
)
as
begin
	update Participant set
		FirstName = @FirstName,
		MiddleName = @MiddleName,
		LastName = @LastName,
		Age = @Age,
		EMail = @EMail,
		PhoneNumber = @PhoneNumber
	where Id = @Id;
end;


go
create procedure DeleteParticipant(
	@Id int
)
as
begin
	delete from Participant where Id = @Id;
end;


