use master
go

if(DB_ID('WeiBo') is not null) drop database WeiBo
go

create database WeiBo
go

use WeiBo
go

--用户表
create table TblUser
(
	uid int identity primary key not null,
	username nvarchar(20) unique not null,
	password nvarchar(20) not null,
	nickname nvarchar(200) not null,
	regDate datetime default getdate() not null
)
go

insert into TblUser(username,password,nickname) values('admin','123456','内置管理员')
go

select * from TblUser
go

--微博信息表
create table TblMessage
(
	mid int identity primary key not null,
	uid int foreign key references TblUser(uid) not null,
	title nvarchar(50) not null,
	content nvarchar(2000) not null,
	created datetime default getdate() not null,
	deleted char(1) default 'n' not null
)
go

select * from TblMessage
go

--回帖表
create table TblReturn
(
	rid int identity primary key not null,
	mid int foreign key references TblMessage(mid) not null,
	uid int foreign key references TblUser(uid) not null,
	content nvarchar(500) not null,
	created datetime default getdate() not null
)
go

select * from TblReturn
go

select * from TblUser
go

insert into TblMessage(uid,title,content) values(1,'欢迎','欢迎使用微博')
insert into TblMessage(uid,title,content) values(2,'哈哈哈','啊速度啊是')
insert into TblMessage(uid,title,content) values(3,'驾驶技','速度发货四度')
insert into TblMessage(uid,title,content) values(5,'参加啊','啊地啊安师大')
insert into TblMessage(uid,title,content) values(3,'啊说啊','打不嗲声光电')
insert into TblMessage(uid,title,content) values(1,'说反话都可','啊手打算')
go

select * from TblMessage
go

select COUNT(*) from TblMessage where deleted='n'
go

select top 5 m.mid,m.title,m.created,u.nickname
from TblMessage m 
inner join TblUser u on m.uid=u.uid
where m.deleted='n' and m.mid not in
(
	select top 5 mid from TblMessage
	where deleted='n'
	order by mid desc
)
order by m.mid desc
go