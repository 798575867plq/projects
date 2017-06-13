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
	--�ϴ��ļ���ԭʼ�ļ�����
	filename nvarchar(255) not null,
	--�ϴ��ļ��ڷ������б��������
	filepath varchar(50) unique not null,
	--�ϴ��ļ���mime����
	contentType varchar(100) not null,
	--�ϴ����ļ�������Ϣ
	description nvarchar(500) not null,
	--�ϴ��ļ��Ĵ�С
	size int not null,
	uploadDate datetime default getdate() not null
)
go

select * from TblFiles
go
