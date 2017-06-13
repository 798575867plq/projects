use master
go
if(DB_ID('EmployeeManager') is not null) drop database EmployeeManager
go
create database EmployeeManager
go
use EmployeeManager
go

--���ű�
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

insert into TblDept(deptName,deptInfo) values('���²�','������Ա�Ĳ���')
insert into TblDept(deptName,deptInfo) values('������','���ǳ���Գ')
insert into TblDept(deptName,deptInfo) values('Ӫ����','���԰���������ͺ�ӵ���')
go

select * from TblDept
go
select * from TblEmployee
go

select e.eid,e.ename,e.salary,e.deptId,e.indate 
,case e.sex when 'm' then '����' else 'Ů��' end 'sex'
,d.deptName,d.deptInfo
from TblEmployee e 
inner join TblDept d on e.deptId=d.deptId
go

--��ҳ��ѯ����
select top 5 * from TblEmployee
go

--��ҳԭ��
--ÿҳ��ʾ5�ʣ���һҳ��1-5���ڶ�ҳ6-10������

--topû�а취�����ʾ����ļ�¼
--����������ȥ��ǰ��ļ�¼��ʽ�����
--ʣ�µļ�¼ҲֻҪ5��
select top 5 * from TblEmployee
where eid not in 
(select top 5 eid from TblEmployee)
go

select top 5 * from TblEmployee
where eid not in
(select top 10 eid from TblEmployee)
go

--���˵�һҳ������������¼����ʽ
--2,5==> 5*(2-1)
--3,10==> 5*(3-1)
--ȥ����¼=��ҳ��С*����ҳҳ��-1��
select top 7 * from TblEmployee
go

select top 7 * from TblEmployee
where eid not in
(select top 7 eid from TblEmployee)
go
 