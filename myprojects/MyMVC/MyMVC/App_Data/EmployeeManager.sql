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

select e.eid,e.ename,e.salary,e.deptId,e.indate 
,case e.sex when 'm' then '男性' else '女性' end 'sex'
,d.deptName,d.deptInfo
from TblEmployee e 
inner join TblDept d on e.deptId=d.deptId
go

--分页查询基础
select top 5 * from TblEmployee
go

--分页原理
--每页显示5笔，第一页是1-5，第二页6-10。。。

--top没有办法完成显示后面的记录
--所以我们用去掉前面的记录方式来完成
--剩下的记录也只要5笔
select top 5 * from TblEmployee
where eid not in 
(select top 5 eid from TblEmployee)
go

select top 5 * from TblEmployee
where eid not in
(select top 10 eid from TblEmployee)
go

--除了第一页，后面跳过记录数公式
--2,5==> 5*(2-1)
--3,10==> 5*(3-1)
--去掉记录=分页大小*（分页页码-1）
select top 7 * from TblEmployee
go

select top 7 * from TblEmployee
where eid not in
(select top 7 eid from TblEmployee)
go
 