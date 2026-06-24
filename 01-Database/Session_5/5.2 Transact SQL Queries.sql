-------------------------------------------------
-------------------------------------------------
------------ Transact-SQL Queries ---------------
-------------------------------------------------


-- Transact-SQL Queries : Microsoft added some functions and new queries for the ANSI-SQL to inhance T-SQL =>
-- Top     Newid     Selectinto     Bulkinsert     insert based on select    ranking functions     merge statements


----------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------

-- Top and Top with Ties : 


-- Top : It's a keyword , Not a function (written as top(2) or top 2 without brackets). used when we want to get the 
--       top X number of rows from a query result. it's like 'limit' in MySQL 

-- Remember => Query execution : from => select => orderby => top 


select * from Student
-- Data is sorted by the PK , and clustered on the hard disk by the PK also.

-- To specify some rows to be returned , we can use 'where' , or also 'top' ...
-- works on the result of the query , so if we used 'where' then we will get the result first then take top X rows 


select top 5 *
from Student

select top 5 St_Fname , St_Address
from Student

-- Will make the filteration of 'where' first , then take top 5 rows
select top 5 St_Fname , St_Address
from Student
where St_Lname like 'a%'


-- Note : using Aggregate functions with top is useless , as the aggregate functions return only one row !!
-- Next Ex: returns only one row , as it's the return from the aggregate function !
select top(2) max(st_age)
from Student


select top(2) St_Age
from Student
order by St_Age desc


select top(1) Ins_Id , Ins_Name , Salary
from Instructor
order by Salary        -- smallest salary , or NULL if there is null ...


-- instructor having MAX Salary
select top(1) Ins_Id , Ins_Name , Salary
from Instructor
order by Salary desc  
  

-- instructor having Second Max Salary
select top(1) Ins_Id , Ins_Name , Salary
from Instructor
where Salary < (select top(1) salary from Instructor order by Salary desc)
order by Salary desc    

-- or another way :

select top(1) Ins_Id , Ins_Name , Salary
from Instructor
where Salary < (select max(salary) from Instructor)
order by Salary desc    

-- or another way :

select top(1) *
from (select top(2) * from Instructor order by Salary desc) as NEW     -- must give an alias name 
order by salary asc


----------------------------------------------------------------------------------------------------------

-- Top with Ties : 

-- same as top : ex: top(4) order by age desc , gets the first four large ages of students  + if the fifth age is same 
--               as the fourth age then it will be included in the result .. means that result count may be more than 4 

select top 2 with ties St_Id , St_Age
from Student
order by St_Age

-- ex:  id    column Ages sorted asc
--      1        15
--      2        16
--      3        16
--      4        16
--      5        20

-- Top(2)           ==> ids ==== 1,2
-- Top(2) with ties ==> ids ==== 1,2,3,4


--========================================================================================================================
--========================================================================================================================

-- NewId() : 

-- Newid : built-in function in SQL Server , creates a "Global Unique Id" (GUID) or "Universally Unique Identifier" (UUID)
-- GUID : Unique Id on the server level 
-- GUID vs Identity on tables : identity column values can be the same in tables , but GUID cannot be the same for one
--                              server ! It's unique for the whole server. 
--
-- The GUID is randomized , so it can be used for two reasons : 
--   1 - making it as a virtual column with randomly generated value every time we run the query , so we can use it with
--       order by and top() to get random rows from the table for each query run.
--   2 - making the PK column as a newid , (Default Value SQL [NOT DEFAULT VALUE]) automatically the PK column gets a 
--       new GUID and it's valid because this ensures uniqueness because of how it is generated. The algorithm used to
--       create GUIDs incorporates multiple unique factors, making it nearly impossible to generate the same GUID 
--       twice—even across different servers.

-- Note : 
--   Default value VS Default Value SQL : 
--       - Default value : We give a defualt value for the column , ex: default value for address is 'Cairo'
--       - Default value SQL : Every time we add a row we will call the function of generating a newid for example 


select * , newid() as GUID
from Student
order by GUID

-- Each time we will have a different student, because table is sorted based on a randomly generated values in runtime
select top 1 *
from Student
order by newid() 


--========================================================================================================================
--========================================================================================================================

-- Select into : 


-- Select into : [ it's DDL ]  Creates table from existing table. Takes a Copy from the table 
-- Copy from : Columns [structure and data types], Data (All rows from the source table that follow the 'where' condition))
-- Select into doesn't Copy : 
--      1 - Indexes (Primary, Unique, Non-clustered, ... )
--      2 - Constraints (Primary Key, Foreign Key, Default, Check, ... )
--      3 - Triggers
--      4 - Computed Columns
--      5 - Table Properties (Compression settings, FileGroups, ... )


-- How to Copy Table Structure + Indexes/Constraints?
-- 1 - Create the Table Manually => create table Employees_Copy (...)
-- 2 - Copy Data using INSERT INTO => (INSERT INTO SELECT * FROM Employees)  -> Insert based on Select (Discussed next)

-- Note : No problem in having a table without PK , we can add the PK at any time after creating the table.

-- Note : When using SELECT INTO, Identity columns are copied but lose their Identity property , must Re-add Identity 
--        Property to the column (data is copied but we must re-add the identity property)

-- Does SELECT INTO copy NOT NULL?
-- NO, except in one special case.
--    The rule: By default, columns become NULLABLE in the new table
--    EXCEPTION: If the column is:
--       - A PRIMARY KEY   Or   defined as IDENTITY
--    Then it will remain NOT NULL !



-- Doesn't affect the DB
select * 
from Student 


-- Made a new table called 'newTable' , which is a copy from student table (structure and data) 
select * into newTable
from Student
-- note : if we tried to execute the same query again : error => already having object with the same name in DB


-- it's not a must to take the whole data from the table , we can specify what rows to be copies based on a 
-- 'where' condition , and also select wanted columns !
-- Note : the newly created table will have the structure of the columns in the select into 
select St_Fname , St_Lname into newTable2
from Student
where St_Address = 'Alex'


-- Copy data to a new created table in other database ! 
select * into [CompanySD].dbo.Student
from Student


-- Copy the structure of the table only without any data (put a false condition) !
select * into newTable3
from Student
where 1 = 2                     -- False condition 


--========================================================================================================================
--========================================================================================================================

-- Insert Based on Select (insert into) : 

-- Insert Types (DML) : 
--  1. Simple Insert                            -- discussed before
--  2. Constructor Insert (Row Constructor)     -- discussed before
--  3. Insert Based on Select (insert into)
--  4. Bulk Insert


-- 1. Simple Insert 
insert into Student (st_id , st_Fname, st_age)
values (150,'Ali',22)


-- 2. Constructor Insert [Row Constructor] (for inserting more than one record)
insert into Student (st_id , st_Fname, st_age)
values (151,'Ali',22), (152,'Ahmed',23) , (153,'Mahmoud',24)


-- 3. insert based on select

select * from Instructor
where Salary>5000

-- What if i want to take this data (copy it) , and insert it in an EXISTING table (we will NOT	create the table)
-- it appends data to an existing table
-- Note : the existing table must have the same columns of the select

insert into ExistingTable   -- if destination table don't have same column datatype order, we can specify them (next query)
select * from Instructor
where Salary>5000

insert into ExistingTable            
select Ins_Id, Ins_Name from Instructor
where Salary>5000

-- Note : we now can have insert + DML and joins ? 
-- ex : the existing table must have 3 columns (int , varchar(x) , int) OR Specify the columns as we do with normal inserts
--      and we will put the data returned from the query and join inside it (Take care of the PKs in the destination table)

insert into ExistingTable            -- can be ExistingTable (id, name, grades) [specify the columns as normal inserts]
select C.Crs_Id , C.Crs_Name , Sc.Grade
from Course C inner join Stud_Course SC 
on C.Crs_Id = Sc.Crs_Id
where Sc.Grade is not null


-- insert into select VS select into : 
--
-- insert into select : insert data in a table that is already there (Existing Table)
-- select into        : Create and insert data in the newly created table



-- 4. Bulk insert : insert data from file, appends data to an existing table
-- if we have a .txt file having this data and we want to insert the data in our table : 
--
-- 10,Ahmed 
-- 20,Mahmoud
-- 30,Shoura

bulk insert ExistingTable
from 'C:\Data.txt'                -- give the actual file path
with(fieldterminator=',')


-- More Advanced : to insert data from files that are not .txt (excel , xml , oracle file , ... )
--                 This is called Data Integration , we will not go through this topic in our course but we can 
--                 use Microsoft's wizard to make this format changing : 
--                 Wizard : Right click on a database => Tasks => Import Data OR Export Data => in our example Export =>
--                          select the source (SQL Server) => Server name and Authentication (as when we connect) => 
--                          Database Name => Specify Destination (in our example excel file) => specify excel file path =>
--                          now specify if we want to write a query , or select copying data from tables directly => 
--                          Note : datatypes are converted implicitly => finish 
--
--                          Now we have added data in the selected tables (or written query) to the excel file that is 
--                          in the given path. 
--
--
--                 Excel's Wizard : This also can be done from excel => Data => Get Data from Database => 
--                                  From SQL Server Database => Now excel interacts with the Background SQL Service => 
--                                  Give the server name and database name => select wanted tables => Load ! 

-- As we discussed before (session 2) , we can use the SQL service from application other than SSMS to connect to the 
-- DB , we used Excel in the previous step , we can also use CMD  : 

--		sqlcmd -S "."  ('S' -> Server, '.' -> my server or computer)
--	    use MyCompany
--	    GO
--	    select * from Employees
--	    GO
--      sqlcmd -S "." -d "ITI" -q "select * from Student" ('d' => database name , 'q' => query)
--	    GO
--      sqlcmd -S "." -d "ITI" -q "select * from Student" -o "D:\testResult.txt" ('o' => output file path)
--	    GO


-- How to Copy Table Structure + Indexes/Constraints (select into will not work in this case) ?
-- 1 - Create the Table Manually => create table Employees_Copy (...)
-- 2 - Copy Data using INSERT INTO => (INSERT INTO SELECT * FROM Employees) -> Insert based on Select