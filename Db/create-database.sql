CREATE DATABASE [Interview]
GO

USE [Interview];
GO
create table dbo.records(
[Id] int identity primary key, 
[name] nvarchar(255) not null
)
GO

insert into dbo.records([name]) values('test1');
insert into dbo.records([name]) values('test2');
insert into dbo.records([name]) values('test3');
GO