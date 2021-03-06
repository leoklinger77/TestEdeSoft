Create Database test;

USE Test

CREATE TABLE  Caes(
	Id					int IDENTITY(1,1) NOT NULL,
	Nome				varchar(255) NULL,
	Raca				varchar(255) NULL,
 CONSTRAINT PK_Caes PRIMARY KEY CLUSTERED 
(
	Id ASC
))

CREATE TABLE  CaesDono(
	CaesId				int NOT NULL,
	DonosId				int NOT NULL,
 CONSTRAINT PK_CaesDono PRIMARY KEY CLUSTERED 
(
	DonosId ASC,
	CaesId ASC
))

CREATE TABLE  Donos(
	Id					int IDENTITY(1,1) NOT NULL,
	Nome				varchar(255) NULL,
 CONSTRAINT PK_Donos PRIMARY KEY CLUSTERED 
(
	Id ASC
))

ALTER TABLE  CaesDono  WITH CHECK ADD  CONSTRAINT FK_CaesDono_Caes_CaesId FOREIGN KEY(CaesId)
REFERENCES  Caes (Id)
GO
ALTER TABLE  CaesDono CHECK CONSTRAINT FK_CaesDono_Caes_CaesId
GO
ALTER TABLE  CaesDono  WITH CHECK ADD  CONSTRAINT FK_CaesDono_Donos_DonosId FOREIGN KEY(DonosId)
REFERENCES  Donos (Id)
GO
ALTER TABLE  CaesDono CHECK CONSTRAINT FK_CaesDono_Donos_DonosId
GO
