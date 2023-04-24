----
-- BEFORE Creating or Dropping a database make sure to have Master database selected (Top Left of this screen).
---- 
--drop database Dating;
--go

--create database Dating;
--go

use Dating;
go

create table [Users]
(
	Id int primary key identity(1,1),
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(50) not null,
	[Login] nvarchar(50) not null,
	[Password] nvarchar(50) not null,
	[Password2] nvarchar(50) not null, 
	CreateDate datetime not null default getdate(),
	DeleteDate datetime null
)
-- We need to create so many genders, that chosing one says it all...
create table Gender
(
	Id int primary key identity(1,1),
	GenderName nvarchar(50) not null unique,
	Elaborate nvarchar(100) null
)

create table City
(
	Id int primary key not null,
	CityName nvarchar(50) not null unique
)

create table UserProfile
(
	Id int primary key identity(1,1),
	UserName nvarchar(50) unique not null,
	BirthDate datetime not null,
	Height int not null default 0,
	AboutMe nvarchar(255), 
	CityId int foreign key references City(Id),
	GenderId int foreign key references Gender(Id),
	UsersId int foreign key references Users(Id),
	check (BirthDate <= dateadd(year, -18, getdate()))
)

go
create table ProfilePictures
(
	Id int primary key identity(1,1),
	Title nvarchar(50) not null,
	PicURL nvarchar(100) not null,
	UserProfileId int foreign key references UserProfile(Id)
)
go

create table Likes
(
	Id int primary key identity(1,1),
	Liker int foreign key references UserProfile(Id) not null,
	Likee int foreign key references UserProfile(Id) not null,
	[Status] int not null default 0,
)
go

create table [Messages]
(
	Id int primary key identity(1,1),
	Sender int foreign key references UserProfile(Id) not null,
	Receiver int foreign key references UserProfile(Id) not null,
	[Status] int not null default 0,
	Msg nvarchar(255) null
)
go
create table [OldMessages]
(
	Id int primary key not null,
	Sender int not null,
	Receiver int not null,
	[Status] int not null,
	Msg nvarchar(255) null
)
go

-- create non-clustered index on column GenderId of table UserProfile
CREATE INDEX Idx_GenderId
ON UserProfile (GenderId);

-- Create trigger on table Message for After Delete. Will insert the deleted row in OldMessages table.
/* After DELETE trigger on [Messages] table */

IF OBJECT_ID('TRG_DeleteSyncMessages') IS NOT NULL
DROP TRIGGER TRG_DeleteSyncMessages
GO

CREATE TRIGGER TRG_DeleteSyncMessages 
ON dbo.[Messages]
AFTER DELETE
AS
BEGIN
INSERT INTO dbo.[OldMessages]
SELECT * FROM DELETED
END
GO

-- Create data for the tables

-- CITY TABLE
insert into City values (3000, 'Helsingør')
insert into City values (3200, 'Helsinge')
insert into City values (3300, 'Frederiksværk')
insert into City values (3400, 'Hillerød')
insert into City values (3450, 'Allerød')
insert into City values (3460, 'Birkerød')

-- GENDER TABLE
insert into Gender (GenderName, Elaborate) values ('Male', 'I think of myself as 100% man')
insert into Gender (GenderName, Elaborate) values ('Female', 'I think of myself as 100% woman')
insert into Gender (GenderName, Elaborate) values ('Gay', 'Man - I like men')
insert into Gender (GenderName, Elaborate) values ('Lesbian', 'Woman - (man) I like women')
insert into Gender (GenderName, Elaborate) values ('Asexual', 'I think of myself as having no sex ')
insert into Gender (GenderName, Elaborate) values ('TransSexual', 'modified body to transition from one gender or sex to another')
insert into Gender (GenderName, Elaborate) values ('hermaphrodite ', 'having both male and female sex organs or other sexual characteristics')
	
-- USERS TABLE
insert into [Users] (FirstName, LastName, Email, [Login], [Password],[Password2],CreateDate)
values
('Palle', 'Westermann', 'pwe@tec.dk', 'prut', 'prut123.', 'prut123.', getdate())

insert into [Users] (FirstName, LastName, Email, [Login], [Password],[Password2],CreateDate)
values
('Hansi', 'Hinterseer', 'hansi@lousymusic.com', 'hansi', 'hansi123.', 'hansi123.', getdate())

insert into [Users] (FirstName, LastName, Email, [Login], [Password],[Password2],CreateDate)
values
('Ulla', 'Drac', 'drac@lousymusic.com', 'drac', 'drac123.', 'drac123.', getdate())

insert into [Users] (FirstName, LastName, Email, [Login], [Password],[Password2],CreateDate)
values
('Benny', 'Hill', 'Hill@humour.com', 'Hill', 'Hill123.', 'Hill123.', getdate())

insert into [Users] (FirstName, LastName, Email, [Login], [Password],[Password2],CreateDate)
values
('Delilah', 'Mums', 'lilah@bt.dk', 'Laila', 'Laila123.', 'Laila123.', getdate())

insert into [Users] (FirstName, LastName, Email, [Login], [Password],[Password2],CreateDate)
values
('Karla', 'Kumme', 'karla@tec.dk', 'karla', 'karla123.', 'karla123.', getdate())

--USERPROFILE TABLE
insert into UserProfile (UserName, BirthDate, Height, AboutMe, CityId, GenderId, UsersId)
values
('KrudtUglen', '1967-07-26', 180, 'Just tooooo nice', 3400, 1, 1)

insert into UserProfile (UserName, BirthDate, Height, AboutMe, CityId, GenderId, UsersId)
values
('BigTrouble', '1977-10-26', 190, 'Tallish girlie', 3450, 4, 2)

insert into UserProfile (UserName, BirthDate, Height, AboutMe, CityId, GenderId, UsersId)
values
('Singasongman', '1897-11-07', 193, 'Musika para me', 3000, 3, 3)

insert into UserProfile (UserName, BirthDate, Height, AboutMe, CityId, GenderId, UsersId)
values
('UllaBulla', '2001-11-07', 173, 'Bloody me', 3200, 4, 4)

insert into UserProfile (UserName, BirthDate, Height, AboutMe, CityId, GenderId, UsersId)
values
('Bennyman', '2003-10-17', 93, 'Up HIll', 3460, 3, 5)

insert into UserProfile (UserName, BirthDate, Height, AboutMe, CityId, GenderId, UsersId)
values
('Delilah', '1923-11-11', 93, 'Oldie', 3460, 2, 6)






--select * from [Users]
--select * from Gender