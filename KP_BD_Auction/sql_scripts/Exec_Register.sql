use KP_2019;

-- Register --

go
create procedure GetRegister
as
begin
	select * from Register;
end;

go
create procedure GetRegisterById(
	@Id int
)
as
begin
	select * from Register where Id = @Id;
end;

