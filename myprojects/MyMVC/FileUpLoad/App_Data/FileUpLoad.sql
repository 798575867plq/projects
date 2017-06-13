use master
go

if(DB_ID('FileUpLoad') is not null) drop database FileUpLoad
go

create database FileUpLoad
go

use FileUpLoad
go

create table TblFiles
(
	fid int identity primary key not null,
	--上传文件的原始文件名称
	filename nvarchar(255) not null,
	--上传文件在服务器中保存的名称
	filepath varchar(50) unique not null,
	--上传文件的mime类型
	contentType varchar(100) not null,
	--上传的文件描述信息
	description nvarchar(500) not null,
	--上传文件的大小
	size int not null,
	uploadDate datetime default getdate() not null
)
go

select * from TblFiles
go
