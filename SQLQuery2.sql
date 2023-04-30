USE Dating
CREATE PROCEDURE usp_InsertUser
@UserName nvarchar(255),
@Password nvarchar(255),
@Salt nvarchar(255),
@Email nvarchar(255),
@CreatedDate DateTime
AS
BEGIN
INSERT INTO [User](Username, psw, salt, email, CreateDate)
Values(@UserName, @Password, @Salt, @Email, @CreatedDate)
END


GO
CREATE PROCEDURE usp_UserExist
@username nvarchar(255)
AS
SELECT COUNT(username) FROM [User] WHERE [user].Username = @username;

GO





GO 
CREATE PROCEDURE usp_GetPassword
@id int
AS
SELECT Psw FROM [User] Where [User].id = @id;
END

GO 
CREATE PROCEDURE usp_GetSalt
@id int
AS
SELECT salt FROM [User] Where [User].id = @id;

GO
CREATE PROCEDURE usp_GetId
@username nvarchar(255)
AS
SELECT Id FROM [User] Where [User].Username = @username;

GO
CREATE PROCEDURE usp_UpdateProfile
@id int,
@Firstname nvarchar(255),
@Lastname nvarchar(255),
@Birthdate DateTime,
@Height decimal,
@About nvarchar(255),
@CityId int,
@GenderId int
AS
BEGIN
  UPDATE userProfile
  SET FirstName = @Firstname,
      LastName = @Lastname,
      Birthdate = @Birthdate,
      Heigth = @Height,
      About = @About,
      CityID = @CityId,
      GenderID = @GenderId
  WHERE Id = @Id
END



GO
CREATE PROCEDURE usp_GetUserProfile
@id int
AS
SELECT * FROM UserProfile where UserID = @id

GO
CREATE PROCEDURE usp_GetCity
@zip int
AS
SELECT CityName FROM City where City.zip = @zip

GO
CREATE PROCEDURE usp_GetGender
@id int
AS
SELECT GenderName FROM Gender where gender.Id = @id

