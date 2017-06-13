use master
go
if(DB_ID('EmployeeManager') is not null) drop database EmployeeManager
go
create database EmployeeManager
go
use EmployeeManager
go

--部门表
create table TblDept
(
	deptId int identity(100,1) primary key,
	deptName nvarchar(50) unique not null,
	deptInfo nvarchar(200) not null
)
go

create table TblEmployee
(
	eid int identity(100000,1) primary key,
	deptId int foreign key references TblDept(deptId) not null,
	ename nvarchar(20) not null,
	sex char(1) check(sex in ('m','f')) not null,
	salary decimal(10,2) check (salary>0) not null,
	indate datetime default getdate() not null
)
go

insert into TblDept(deptName,deptInfo) values('人事部','管理人员的部门')
insert into TblDept(deptName,deptInfo) values('开发部','都是程序猿')
insert into TblDept(deptName,deptInfo) values('营销部','可以把梳子卖给秃子的人')
go

select * from TblDept
go
select * from TblEmployee
go