use KP_2019

go

CREATE FUNCTION GetPasswordHash(@password nvarchar(50))
RETURNS nvarchar(50)
BEGIN
    declare @hashedPassword varbinary(500) = HASHBYTES('SHA2_512', @password);
	declare @hashToReturn nvarchar(50) = convert(nvarchar(50), @hashedPassword, 2);

	return @hashToReturn;
END;

go
--drop function GetPasswordHash
CREATE procedure HashUserPasswords
as
begin
	DECLARE @userId int
	Declare @password nvarchar(50)

   DECLARE my_cur CURSOR FOR 
     SELECT id
     FROM Users
   
   OPEN my_cur

   FETCH NEXT FROM my_cur INTO @userId

   WHILE @@FETCH_STATUS = 0
   BEGIN
        select top(1) 
			@password = [password]
		from Users
		where Users.Id = @userId;

		set @password = dbo.GetPasswordHash(@password);

        update Users
		set Password = @password
		where Users.Id = @userId;

        FETCH NEXT FROM my_cur INTO @userId
   END
   
   CLOSE my_cur
   DEALLOCATE my_cur
end;

exec HashUserPasswords;
go



create procedure IsPasswordValid(
	@Password nvarchar(50),
	@UserName nvarchar(50) 
)
as
begin
  declare @hashedPassword nvarchar(50);

  select 
    @hashedPassword = Users.Password
  from Users
  where Users.Login = @UserName;

  set @Password = dbo.GetPasswordHash(@Password);

  if(@hashedPassword = @Password)
  select 1;
  else
  select 0;
end;

--drop procedure IsPasswordValid
go
