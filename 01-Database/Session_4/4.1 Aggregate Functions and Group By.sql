-- Self Study (NOT a must) : 
--  - How to measure the performance of the query ? 
--  - Execution Plan 
--  - Common Table Expression (CTE)


--==========================================================================================
--========= Aggregate Functions ============================================================
--==========================================================================================

-- Aggregate functions : max , min , count , avg , sum 
-- they do mathematical operations on the data in the tables 
-- They are Scalar Functions , so they return just only one value
-- Note : Aggregate functions doesn't take care of Nulls , they are not considered 

--===========================================================================================================

-- Count : Returns the number of rows, (NULLS are not counted) .. Takes * or a specified column
select count(*)     -- The count of all rows 
from Student

select count(Id)    -- The count of Id , same as count(*)
from Student

select count(age)   -- if we have 20 students and 5 of them have NULL age value then the count = 15 only
from Student

--===========================================================================================================

-- Sum : Returns the summation of values of a Column, Works ONLY with Numeric Values and if we tried to 
--       use a non-numeric values 
--       ex: Sum(nvarchar_column) => then we will have an Error => Operand data type nvarchar is invalid for 
--           sum operator. 
--       Note : Use String_Agg function for aggregating and concatination of strings in one value , we 
--              discussed it before in string functions


select Sum(St_age)            -- Sum of all ages (nulls are not counted of course)
from Student

select Sum(St_Fname)          -- Error 
from Student

--===========================================================================================================

-- Max : Returns the max value of a column, if numeric column then return the largest number , if string 
--       type column then return the largest lexicographical sorting ('Z' then 'Y' then 'X' ... then 'A')
--       Note : If the all column is null then will return null

select Max(st_age)
from Student

select Max(St_Fname)
from Student

--===========================================================================================================

-- Min : Returns the min value of a column, if numeric column then return the smallest number , if string 
--       type column then return the smallest lexicographical sorting ('A' then 'B' then 'C' ... then 'Z')
--       Note : If the all column is null then will return null


select Min(st_age)
from Student

select Min(St_Fname)
from Student

--===========================================================================================================

-- Avg : Returns the average of values of a column (same as 'sum(X)/count(X)' where X is the same column)

select avg(salary)
from Employee
-- Same as 
select sum(salary)/count(salary) 
from Employee

-- This will divide on the total count (maybe the result we want), as there may be NULL Values ...
select sum(salary)/count(*)        
from Employee
-- Same as 
select avg(isnull(salary,0))
from employee

--===========================================================================================================

-- Ex: Student table having 15 rows , 14 of them have name , the last student doesn't have a name 

-- count(*)                  -- counts all (result => 15)
-- count(Id)                 -- counts PK (result => 15) .. same as count(*)
-- count(name)               -- counts rows that have name (not null names) (result => 14) (result <= count(*))
-- count(isnull(name,' '))   -- counts rows that have name, if null => replace null with ' ' (result => 15)



--==========================================================================================
--========= Group by =======================================================================
--==========================================================================================

-- Used when we want to group some column having the same value in a specific column, along side with 
-- aggregate functions to perform calculations on each group.
-- Ex:
--    having same DeptId => group rows of employees in the same department 
--    having same Age    => group rows of employees having the same age
-- 
-- Notes: 
--   1. Any column is selected with the aggregate function (and this column is not an aggregate function) 
--      must be with the Group by, because aggregate function returns one value (scalar) , but the column 
--      that was selected has many rows so this can be solved using group by.
--   2. it means : for every group having the same value in this 'column', get the aggregate function 
--      value of each group. 
--   3. we can group by a column that is not selected.
--   4. Aggregate Functions' , 'group by' and 'having' .. all of them hide rows.



-- Ex: WRONG !!!
select min(salary), DeptId
from employee
-- SQL ERROR : column DeptId is invalid in the select list because it's not contained in either 
--             aggregate function or group by clause.


-- Ex: Get the minimum salary for each department id
select min(salary) as MinSalary, DeptId
from employee
group by DeptId

-- In this example, we group all employees that are in the same department in one group , and then 
-- get the min salary from these groups ... results in => 
-- DeptId    MinSalary
-- 10          1000
-- 20          2500
-- 30          1250


-- Note : if the min salary is Null then there is no salary for employees in this department , but if 
--        there is at least one employee having salary in the department then this salary will be the 
--        minimum and null will not be shown. 


-- Here the Aggregate function works on the table (as a one group)
select count(*) as 'Count of Students' 
from Student

-- Here the Aggregate function works on the groups of the table (groups having the same dept_Id)
select dept_id, count(*) as 'Count of Students per department' 
from Student
where dept_id is not null
group by Dept_Id



-- Ex: Use group by to group some rows with a repeating value column , NO logic in grouping by the PK !!
--     But it's a valid syntax ... group by * is not a valid syntax 

select count(*), Id
from Employee
group by Id

-- results in => 
--    count    Id
--     1       1
--     1       2
--     1       3


-- Ex: Group by * is INVALID syntax, we must specify the columns (it's useless also ..)
select count(*), *
from Employee
group by id, name, ................


-- Note : when using where in the query that uses group by, the where is executed before the group by , 
--        and the where usually doesn't change the number of groups (can change the number of groups in  
--        one case => all rows in that group doesn't satisfy the condition in the where) , but it may  
--        change the value that is returned with each group (the aggregate function value) 


-- Ex: any address that starts with letter other than 'a' is execluded and not counted 
--      for each department id , count the employees having address that starts with character 'a'
select count(id), Dept_Id
from Employee
where address like 'a%'
group by Dept_Id


-- Ex: if dept_id = 10 group doesn't have any employee that has salary > 6000 , then this group
--      will not appear in the result ! 
select sum(salary), Dept_Id
from Employee
where salary > 6000
group by Dept_Id


--============================================================================================

-- Having : 
 
-- To make filters on the resulting groups , use 'having' (condition on the aggregate function)
-- 'Where'  => Filters Rows (where is executed for each row , not group !!!)
-- 'Having' => Filters Groups
-- 'Where' and 'Having' can be both in the same query without any problems !
-- Note : Where is executed before the group by , so the rows are filtered first and then they are 
--        grouped be the column/columns. After that the having is executed so it filters the resulting
--        groups.


--Ex1: get all the groups having sum(salary)>25000  (only groups that satisfy the having condition)
select sum(salary), Dept_Id
from Employee
group by Dept_Id
having sum(salary)>25000


-- Ex2: get the cities having more than 4 employees , so if we have a city that has 3 employees then this
--      city will not be shown in the result of the next query : 
select count(id), address
from Employee
group by address
having count(id)>4


-- Ex3: 
select dept_id, count(*) as 'Count of Students per department (count must be 3 or more to be considered)' 
from Student
where dept_id is not null
group by Dept_Id
having count(*) >= 3


-- Ex4 : we can select aggregate function , and then use a different aggregate function in the 'having'
select sum(salary), Dept_Id
from Employee
group by Dept_Id
having count(Id)>5
-- here we will first get the groups that satisfy the condition , groups having more than 5 employees , 
-- and then sum the salaries of employees in these groups 


-- Ex5 : 'having' can come without 'group by' (special case => selecting only an aggregate function)
select max(salary), min(salary)
from Employee
having count(id)>100
-- so here if the count of all employees is > 100 , then we will have result , otherwise no result 


-- Ex6 : 
select sum(salary)
from Instructor
having count(*) > 10
-- Here we work as the table is a one group 
-- If the count of instructors is more than 10 it will select the sum , otherwise it will not select 
-- any thing , and in the last example we cannot select any other column with the aggregate function 


-- Important : Some Where conditions Can be written in Having. If the condition is NOT aggregated ...
-- Ex: 
select Dno, Count(*)
from Employee
group by Dno
having Dno = 10

-- Same as : 
select Dno, Count(*)
from Employee
where Dno = 10
group by Dno

-- This works logically , but it’s bad practice


-- To sum up , we use 'having' in two cases : 
-- 1 - making a aggregation condition on the groups that are produced from 'group by'    (most used)
-- 2 - when we use 'having' without 'group by' in the only one case (selecting only an aggregate function), 
--     ex: sum of salaries of all instructors incase number of instructors is more than 10 

--============================================================================================

-- Using more than one column with group by :

-- Ex1: this example doesn't make sense [as each deptId has only one deptName]
--      Note : All selected columns must be in the group by
select sum(salary), DeptId , DeptName
from Employee E inner join Department D 
on E.DeptId = D.Id
group by DeptId , DeptName                       -- All columns in the select


--Ex2: 

-- Gets the count of students in each department 
select count(id),DeptId
from Employee
group by DeptId


-- Gets the count of students in each address (city) 
select count(id),address
from Employee
group by address


-- Gets the count for students in each address in each department (group by the combination)
select count(id),DeptId, address
from Employee
group by DeptId, address       -- group by the address first then group by dept_id 


-- result could be for example :
-- countNum    DeptId     Address
--   2           10        alex
--   1           20        alex
--   2           30        alex
--   3           10        cairo
--   1           20       mansoura
--   1           30       mansoura


select dept_id, Address ,count(*) as 'Count of employees per department' 
from Employee
where dept_id is not null and Address is not null
group by Address , Dept_Id         -- group by the dept_id first then group by the address 

-- result be like: 
-- dept_id     address
-- 10            Cairo
-- 10            Tanta
-- 20            Cairo
-- 20            Tanta


-- we can change the ordering of group by columns: 
select dept_id, Address , count(*) as 'Count of employees per department' 
from Employee
where dept_id is not null and Address is not null
group by Dept_Id , Address          -- group by the address first then group by dept_id 


-- result be like: 
-- dept_id     address
-- 10            Cairo
-- 20            Cairo
-- 30            Tanta
-- 40            Tanta



-- Ex: select the supervisor name and the count of students the supervisor supervise on 

select super.St_Fname 'supervisor name' , count(*) 'supervise on'
from Student Std inner join Student super
on std.St_super = super.St_Id
group by super.St_Fname
-- this may produce wrong results, because we can have more than one supervisor named with X and they 
-- will be merged in one row !

-- This is the right way, When self-joining we must group by the PK also: 
select super.St_Id , super.St_Fname 'supervisor name' , count(*) 'supervise on'
from Student Std inner join Student super
on std.St_super = super.St_Id
group by super.St_Fname , super.St_Id



-- Interview Question : 
-- when selecting an aggregate function, then we work with the table as a ONE GROUP or MANY GROUPS =>
--   1 - ONE GROUP   : when NOT USING 'group by' 
--   2 - MANY GROUPS : when USING 'group by' 