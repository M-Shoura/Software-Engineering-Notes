--=========
-- Joins : 
--=========

--  Used when selecting data from more than one table in the same query. Actually used when we need data 
--  from more than one table (this data can be selected and shown , used in a conditon , ....)


-- Mainly we have 3 types of joins : 
-- 1. Cross Join (Cartesian Product)
-- 2. Inner Join (Equi Join)
-- 3. Outer Join (left outer join , right outer join , full outer join)
-- Note : Self Join (unary relationship) is a special type of joins

--============================================================================================

-- 1. Cross Join (Cartesian Product) : 
--      - used when wanting to generate large number of FAKE data to work with and test the database with it.
--      - used when wanting to get all the combinations of data in different tables.
--      - Ex: table Jeans Pants (5 rows) and table Polo Shirts (3 rows) 
--      - result => each jeans pant with each polo shirt , result count = 5*3=15 result and combination

-- ANSI old syntax (Cartesian Product) : 
select S.St_FName , D.Dept_name
from Student S , Department D

-- Microsoft new syntax (Cross Join) : replace (,) with (cross join)
select S.St_FName , D.Dept_name
from Student S Cross Join Department D


--============================================================================================

-- 2. Inner Join (Equi Join) :
--    - Return only matching records from both tables based on a specified condition.
--    - If a row from either tables does not have a match, it is excluded from the result.
--    - condition is written as  =>    Pk = Fk


-- ANSI old syntax (Equi Join) : 
select S.St_FName , D.Dept_name 
from Student S , Department D
where S.Dept_Id = D.Dept_Id



-- Microsoft new syntax (Inner Join) : 
-- replace (,) and condition which is in (where) with (inner join OR join) and put condition in (on)
select S.St_FName as [Student First Name] , D.Dept_name as [Department Name]
from Student S inner join Department D
on S.Dept_Id = D.Dept_Id 



-- Note : if the name of the PK equals the name of the FK , or some selected columns have the same name  
--        between tables , then we must use table names (Student.DeptId and Department.DeptId) or give 
--        alias names for tables and use them to avoid ambiguity.

-- Ex: After using alias names : 
select S_name , D_name 
from Student S inner join Department D
on S.DeptId = D.DeptId



-- Condition with 'On' vs Condition with 'Where' : 

-- Note : With large number of tables, inner join (condition with 'on') is faster than Equi
--        join (condition with 'where')

-- Condition With 'On' : 
select S.St_FName , D.Dept_name 
from Student S inner join Department D
on S.Dept_Id = D.Dept_Id and D.Dept_name = 'SD'

-- The condition (Department Name = 'SD') is applied before joining the tables.
-- This can improve performance in some cases.
-- The Department table is filtered first, and only matching 'SD' department Students are joined.


-- Condition With 'Where' :
select S.St_FName , D.Dept_name 
from Student S inner join Department D
on S.Dept_Id = D.Dept_Id 
where D.Dept_name = 'SD'

-- The join happens first (all matching rows are combined).
-- Then, the result is filtered to include only 'SD' department Students.


-- Note : sometimes the join condition is not Pk = Fk 
-- Ex: select instructor name and student name, that are in the same city ... condition (ins.City = st.City)
--     it's a useless example :)

--============================================================================================

-- 3. Outer Join : 
--      - Means that unmatched rows from one or both tables will be included in the result.
--      - It's an inner join + part of a table (left table OR right Table OR Both of them)
--      - Shows the part of a table that didn't participate in the relationship (NULL)
--          3.1 - Left Outer Join 
--          3.2 - right Outer Join  
--          3.3 - Full Outer Join  



-- 3.1 - Left Outer Join : can be written as (Left Join) OR (Left Outer Join)
--           - Includes all rows from the left table and only matching rows from the right table.
--           - If no match is found in the right table, NULL values are used for right-side columns.

select S.St_FName , D.Dept_name 
from Student S left outer join Department D
on S.Dept_Id = D.Dept_Id 

-- result => Shows all students and their departments, even if students are not assigned to a department 
--           and don't participate in the relationship.



-- 3.2 - Right Outer Join : can be written as (Right Join) OR (Right Outer Join)
--          - Includes all rows from the right table and only matching rows from the left table.
--          - If no match is found in the left table, NULL values are used for left-side columns.

select S.St_FName , D.Dept_name 
from Student S right outer join Department D
on S.Dept_Id = D.Dept_Id

-- result => Shows students and all departments, even if no students work in a department and this department
--           don't participate in the relationship , it will be still shown.


-- 3.3 - Full Outer Join : can be written as (Full Join) OR (Full Outer Join)
--          - Combines both LEFT and RIGHT JOIN.
--          - Includes all rows from both tables, with NULLs where no match exists.
--          - result = result of inner join + additional rows from left outer + additional rows from 
--                     right outer

select S.St_FName , D.Dept_name 
from Student S full outer join Department D
on S.Dept_Id = D.Dept_Id

-- result => Shows all students and all departments, all students even if some students don't work in
--           departments , they are still in the result , and all departments even if no students work in 
--           them , they are still in the result.


-- Note : Full Outer Join is Not supported in MySQL, but can be simulated using UNION


--============================================================================================

-- 4. Self Join (unary relationship) : 
--      - special type of joins , can be of any join type (cross or inner or outer)
--      - relationship between rows in the same entity type , FK and PK are in the same table 
--      - we use two instances from the same table.

-- ex1: Select the employee name and his supervisor name : Inner join
select emp.Ename , super.Ename
from Employee emp inner join  Employee super
on emp.superId = super.Id


-- ex2: Select the employee name and his supervisor name , even it the employee doesn't have a 
--     supervisor : left outer join OR Right outer join based on the place of Table Employee Emp
select emp.Ename , super.Ename
from Employee emp left outer join  Employee super
on emp.superId = super.Id


-- ex3: Select the employee name and his supervisor name , even it the supervisor doesn't have any 
--     employees to supervise on : left outer join OR Right outer join based on the place of Table SuperEmp 
select emp.Ename , super.Ename
from Employee emp right outer join  Employee super
on emp.superId = super.Id


--============================================================================================

-- joining multiple tables (more than 2 tables) : 

-- ANSI old syntax (Equi Join) :   
select S.St_id , S.St_fname , C.Crs_name , SC.Grade	
from Student S , Stud_Course SC , Course C
where S.St_id = SC.St_id and C.Crs_id = SC.Crs_id

-- Microsoft new syntax (Inner Join) :  the 'on' condition must follow the 'join' type 
select S.St_id , S.St_fname , C.Crs_name , SC.Grade	
from Student S inner join Stud_Course SC on S.St_id = SC.St_id 
inner join Course C on C.Crs_id = SC.Crs_id


-- Note : 
--  - Can be used with any type of joins.
--  - Number of joins = (number of tables - 1)
--  - Writing a condition in first on (ex: S.Age>30), maybe better performance due two decreasing 
--    the number of rows that are matched with the second join


--============================================================================================

-- Join with DML (update , delete) : insert will be discussed later [insert based on select (insert into)]
-- Why we need it ? update or delete from one table based on data from other tables ..  

-- Ex: Update : update the grade (+1) to all students live in 'Cairo' in all courses

update Student_Course
	set grade += 1
where StudentAddress = 'cairo'     -- Error , address is not in Student_Course table

 
update Student_Course
	set grade += 1
from Student S inner join Student_Course SC on S.Id = SC.StdId 
where S.StudentAddress = 'cairo'


-- OR use the alias name : 
update SC
	set grade += 1
from Student S inner join Student_Course SC on S.Id = SC.StdId 
where S.StudentAddress = 'cairo'


-- Ex: update and join and select in the same time !
update Stud_Course 
	set Grade +=2 
select S.St_Fname , D.Dept_Name ,Sc.Grade 
from Student S , Stud_Course sc , Department D
where S.St_Id = Sc.St_Id and D.Dept_Id = S.Dept_Id and D.Dept_Name = 'SD'


-- Ex: Delete : delete student grades in all courses, but to students live in 'Cairo' only

delete Stud_Course
from Student S inner join Stud_Course SC 
on S.St_id = SC.St_id 
where S.St_Address = 'Cairo'

-- OR use the alias name : 
delete SC
from Student S inner join Stud_Course SC 
on S.St_id = SC.St_id 
where S.St_Address = 'Cairo'
