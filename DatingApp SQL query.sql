CREATE DATABASE Dating
GO
USE Dating
GO

Create table [User](
Id int IDENTITY(1,1) PRIMARY KEY,
Username nvarchar(255) UNIQUE NOT NULL,
Psw nvarchar(255) NOT NULL,
salt nvarchar(255) NOT NULL,
Email nvarchar(255) NOT NULL,
CreateDate DateTime NOT NULL,
DeleteDate DateTime
);

Create table City(
zip int PRIMARY KEY,
CityName NVARCHAR(255)
);

CREATE TABLE Gender(
Id int IDENTITY(1,1) PRIMARY KEY,
GenderName NVARCHAR(255) NOT NULL
);

CREATE TABLE UserProfile(
Id int IDENTITY(1,1) PRIMARY KEY,
FirstName nvarchar(255),
LastName NVARCHAR(255),
Birthdate DateTime,
Heigth decimal,
About nvarchar(255),
UserID int FOREIGN KEY REFERENCES [user](Id),
CityID int FOREIGN KEY REFERENCES City(zip),
GenderID int FOREIGN KEY REFERENCES Gender(Id)
);

CREATE TABLE Likes(
ID int IDENTITY(1,1),
Liker int FOREIGN KEY REFERENCES UserProfile(id),
Liked int FOREIGN KEY REFERENCES UserProfile(id),
LikedBack bit,
);

CREATE TABLE ProfilePicture(
Id int IDENTITY(1,1) PRIMARY KEY,
[url] varchar(512),
ProfileID int FOREIGN KEY REFERENCES UserProfile(id)
);

CREATE TABLE msg(
id int identity(1,1) PRIMARY KEY,
Sender int FOREIGN KEY REFERENCES UserProfile(Id),
Reciever int FOREIGN KEY REFERENCES UserProfile(id),
[Message] NVARCHAR(255)
);

CREATE TABLE OldMSG(
id int PRIMARY KEY,
Sender int FOREIGN KEY REFERENCES UserProfile(Id),
Reciever int FOREIGN KEY REFERENCES UserProfile(id),
[Message] NVARCHAR(255)
);

GO
CREATE TRIGGER trg_Msg_Insert ON msg
AFTER INSERT
AS
BEGIN
INSERT INTO OldMSG
SELECT * FROM inserted;
END;


GO
CREATE Trigger trg_Userprofile_Insert on [User]
after insert
as
begin
INSERT INTO UserProfile(UserID)
SELECT ID FROM inserted;
END;

