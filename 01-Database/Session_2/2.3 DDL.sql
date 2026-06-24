-- self study : 
--   delete vs truncate in Logging ldf file

---------------------------------------
------------ DDL ---------------------- 
---------------------------------------

--====================================================
-- Create [Structure (Database or Database Object)] --
--====================================================

-- Note : The database consists of one or more than one Schema, the schema contains database Objects such 
--        as (Tables , views , ...) 

create database ITIDB_Test   -- Created with the default Configurations (mdf and lfd files sizes , ..)
use ITIDB_Test               


--==============================================
--========== Example 1 =========================
--==============================================


create table Students(
	id int primary key identity (1,1) ,
	FName varchar(15) ,
	Age int ,
	Address varchar(50) ,
	Dep_id int            -- Don't miss altering the table for this FK after creating depertments table
)

create table Departments(
	id int primary key identity(10,10) ,
	Name varchar(15) ,
	Hiring_Date date ,
)

alter table Students 
add foreign key (Dep_id) references Departments(id)

create table Instructors(
	id int primary key , 
	Name varchar(15) ,
	Address varchar(50) , 
	Bonus int , 
	Salary int ,
	Hour_Rate int ,
	Dep_Id int references Departments(id)
)


--==============================================
--========== Example 2 =========================
--==============================================


Create table Employees
(
	Id int primary key identity(1,1),         -- identity (sead , increament) [discussed next]
	FName varchar(40) not null ,              -- Required
	LName varchar(40) null ,                  -- Optional (Or without writing null it's by default allows null)
	[Address] varchar(40) default 'Cairo' ,   -- Square brackets if it's a reserved word or multi-word name
	Gender char(1) ,
	Salary decimal(8,2) ,
	BirthDate date ,
	[Hiring Date] date default getdate()
	SupervisorId int references Employees(Id) ,
	DepartmentNo int ,
)


create table Departments
(
	DNumber int Identity(10,10) ,
	Primary Key(DNumber) ,            -- another way for making the PK
	DName varchar(50) not null ,
	ManagerId int ,
	Foreign Key (ManagerId) references Employees (Id) ,  -- on delete cascade on update set null [discussed session 6 , Relationship Roles]
)


create table [Department Locations]
(
	DNumber int references Departments(DNumber) , 
	[Location] varchar(100) ,
	Primary Key(DNumber,[Location])   -- Composite PK 
)


--===============
-- Identity ----- 
--===============


create table test 
(
	empId int primary key, 
	empName varchar(20)
)

insert into test 
values (1,'mahmoud'),
       (2,'ahmed'),
	   (3,'shoura')

-- so we must write a unique empId every time !! why don't we use the Identity (auto increment) ???

-- Note : the table can contain only one identity , AND also the table can contain only one PK (It's not a must to have 
--        PK , PK can be specified at any time), It's NOT A MUST to use the identity with PK , we can use the identity 
--        with any int datatype column because identity value can only be INTEGER.

-- Note : the identity can be used only with one column , so when having composite PK , the identity can
--        be used for ONLY ONE column of the composite PK

-- With Identity we will not provide the PK , it will be automatically provided when inserting
-- identity (seed, increment) , ex: (10,10) => 10,20,30,40, ...  , ex: (1,1) => 1,2,3,4,5, ...

create table test 
(
	empId int primary key identity(1,1), 
	empName varchar(20)
)

insert into test 
values ('mahmoud'),      -- automatically takes empId = 1
       ('ahmed'),        -- automatically takes empId = 2
	   ('shoura')        -- automatically takes empId = 3

delete from test         -- deleting all rows

insert into test 
values ('Ali')           -- automatically takes id = 4 (the last id was 3)

select SCOPE_IDENTITY()  -- => 4 
-- returns the last identity value that was inserted in a table that uses Identity 
-- Note : Must run the query with the insert

select IDENT_CURRENT('test')    -- => 4
-- returns the last identity value that was inserted in the given table name 
-- Note : can run without insert before it. 

dbcc checkident('test',reseed,0)          -- dbcc => Database Consistency Check
-- After delete from test , we notice that when inserting the identity still uses the last value before 
-- deleting ... so to reseed the identity value and start from a given number use this query



--==========================================================
-- Alter [Update Structure (Database or Database Object)] --
--==========================================================

-- Alter Database itself : 
Alter database 
Modify name = XYZ
-- Note : We must be using another database , not using the database we want to change it's name
 

-- Alter Database object , ex: Table
--   1. Alter Add
--   2. Alter Alter
--   3. Alter Drop 
--   4. Alter Disable / Enable (With triggers, discussed later)

--===============
---1. Alter Add : 
--===============

Alter Table Employees 
Add NetSalary int                                -- Add Column 

 
Alter Table Departments 
Add Constraint UQ_ManagerId unique(ManagerId)    -- Add Constraint
-- OR
Alter Table Departments 
Add unique(ManagerId)                            -- Add Constraint (without 'Constraint' keyword)


Alter Table Departments 
Add Constraint FK_Dep_Manager Foreign Key (ManagerId) references Employee(Id) -- Add FK
 -- OR
Alter Table Departments 
Add Foreign Key (ManagerId) references Employee(Id)           -- Add FK (without 'Constraint' keyword)

-- Note : previous => on delete cascade on update set null [discussed later]


--=================
---2. Alter Alter : 
--=================

-- Note : Take care when changing the type of a column, as the data that are currently in the table in 
--        that column must fit in the new column type.

Alter table Employees 
Alter column NetSalary bigint not null    -- Edit column 

-- wrong : unique is a constraint !!!! 
Alter Table Employees  
Alter Column ManagerId Unique     -- Wrong , alter is used for data type or nullability
 

--================
---3. Alter Drop : 
--================

Alter table Employees 
Drop column NetSalary    -- Drop column

Alter table Departmnets 
drop Constraint [FK_department_manage_2860EC]  -- Drop FK (Drop Relationship)
-- OR
Alter table Departmnets 
drop [FK_department_manage_2860EC]     -- Drop FK (Drop Relationship) (without 'Constraint' keyword)

-- Note : to get the name of the FK => using wizard => right click on the table => Keys 


--=========================================================
-- Drop [Delete Structure (Database or Database Object)] --
--=========================================================

-- Drop => deletes the data and the metadate  

Drop database XYZ        -- We must be using another database , not using the database we want to delete
Drop Table XYZ           -- will not drop if this is referenced by a foreign key 
Drop Function XYZ        -- discussed later ...
Drop View XYZ			 -- discussed later ...


--=========================================================
-- Truncate [Advanced , Discussed again later ...] --------
--=========================================================

-- Truncate : 
-- it Drops and then recreates the table , may be used to delete all data in the table
-- Truncate is considered as DDL , because it drops and re-created (modifies database structure)
--   1. Removes all rows from the table.
--   2. Resets identity columns
--   3. Faster than DELETE because it doesn’t log each row deletion individually 

-- Notes : 
--   - Requires explicit permission (ALTER permission) 
--   - Can be rolled back but (inside a transaction)

truncate table Employees

-- When TRUNCATE CANNOT Be Used ?
-- 1 - When the table has a foreign key constraint (unless you first remove or disable the constraint).
-- 2 - If the table is referenced in an indexed view


--=========================================================
-- Truncate VS Delete VS Drop -----------------------------
--=========================================================


-- drop table student : 
--    - DDL 
--    - drop data and metadata (if we want the table again we must recreate it !) 
--    - works only when the table is child (it's PK is not in another table as FK) (table not referenced)
--    - if it's a parent table then we must delete the relationship (FK) and then drop the table
-- truncate table student :
--    - DDL (deletes the table and re-create it again)
--    - deletes ALL data 
--    - reset identity to the seed (which we configured when creating the table in the first time)
--    - CANNOT SPECIFY SOME RECORDS TO BE DELETED .. IT DELETES ALL.
--    - Requires explicit permission (ALTER permission) 
--    - logging ldf file is a bit different than the of delete statement, so it's a bit faster than delete. 
--    - CAN BE ROLLDER BACK BUT IT MUST BE INSIDE A TRANSACTION.
--    - works with child tables only , if the table is a parent table then the FK must be dropped first.
--    - Truncate doesn't change the table structure or constraints , only the identity column changes.
-- delete from student : 
--    - DML
--    - delete data only, the metadata is not deleted or dropped. 
--    - we can use 'where' here , to delete some rows that follow a condition.
--    - changes ALWAYS stored in ldf file (slower)
--    - can be rolled back
--    - can work with parent tables or child tables 
--    - Requires explicit permission (DELETE permission)



--============================================================================================
--============================================================================================

-- SSMS UI/GUI Notes : 
-- Create New Database : Right Click on Databases => New Database => specify database name =>
--                       specify mdf and ldf file sizes => locate the DB on our device => 
--                       General Note: Don't put the backup on the C drive (some windows security reasons)
-- 
-- Create New Table : Select database => Right Click on Tables => New => Table => add the wanted columns
--                    with their datatypes and specify Nullability (use "Tab" for NEXT  and "Shift Tab" for 
--                    BACK) => right click on the column for setting it as a PK => for composite PK select 
--                    the PKs with Ctrl => right click set as PK => click on the column and down you 
--                    will find the column properties (Identity, default value, ..) => Ctrl+s saving 
--
-- Edit Design of Table : right click on the table => Design => if you cannot edit the metadata => 
--                        we must first go to => Tools => Options => Designers => Table and database 
--                        designer => UnCheck "Prevent saving changes that require table re-creation"
--
-- Create a Database Diagram : Right Click on the Database Diagram => New Database Diagram => 
--                             select wanted tables that will be shown , this will show the relationships
--                             between tables also.
--
-- Create New Relationship : Make a database diagram => try to connect the two columns with each other
--                           by draging the PK to the FK => choose the PK and FK => Ctrl+s for saving 
--                           Note : The type of the FK must be the same type as the PK
--
-- Edit current Relationship : DB diagram => right click on the relationship line in DB diagram => 
--                             properties => tables and columns specifications. see PK and FK
--
-- Create a unique Constraint : right click on the table => Design => right click => Indexes/Keys => 
--                              add a new Key for the table => select column => Unique = yes
--                              
--
-- See/Edit data in tables : Right Click on the table => Edit Top 200 Rows => can use "Tab" for NEXT field 
--                           and "Shift Tab" for BACK => right click => Execute SQL (for Refreshing)
-- 
-- Only See data : Right Click on the table => Select Top 1000 Rows
--
-- Know executed code when using wizard : ex: when creating table => right click on the table => 
--                                        script table as => Create To => New Query editor window 


-- Note : When restoring a database backup , some times the diagrams don't open when clicking on them , 
--        to solve this problem => right click on the database => properties => files => owner = sa
--        (sa => SQL Admin) ... now we can view the diagram and create relationships if we want 


-- Important Notes : 
--    1. In 1-1 relationships, the Foreign Key must be Unique.
--    2. In any Total Participation, the Foreign Key must be NOT NULL.
--    3. Relationships cannot be edited, they must be deleted (drop FK) then added in the right way.
--    4. The Primary Key column is always (Unique and Not Null)
--    5. The Unique Key column is always Unique But allowes Null
--    6. The type of the FK must be the same type as the PK
--    7. By default all columns allow null, unless we use "not null" constraint (OR make the column PK)
--    8. we put Date and Characters/strings between single quotation. ex: '1/1/2025' OR 'XYZ'
--    9. If the name don't fit in the target type (ex: varchar(10)) then it will take first 10 characters
--       only. This doesn't happen with seeding data inside columns by wizard, as if we entered a value that 
--       will not fit in the column , we will have an error.
