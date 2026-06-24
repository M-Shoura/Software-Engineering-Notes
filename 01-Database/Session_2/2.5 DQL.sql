-- DQL : select =>
--          - all data
--          - specific data
--          - order by asc desc
--          - select + (between , not between , in , not in , is null , is not null ) 


-- Note : using DQL (select) doesn't change the actual data in the tables and databases.

--============================================================================================

select * from Student                     -- selecting ALL columns with *
select Fname,Lname from Student           -- selecting SOME specific columns 
-- Note : * => For COLUMNS, specifying that ALL columns will be returned in the result
--        OR specify the coolumns we want only  ... for filtering ROWS use 'where' with a condition

--============================================================================================

-- Notes : 
--   1. we can filter (using 'where') based on a column that is not in the 'select'
--   2. we can order by a column that is not in the 'select'
--   3. not equal ======>   !=   or   <>

select * from student
order by age  /* asc */     -- by default it's ascending (asc)

select * from student
order by age  desc

select St_Id , St_Fname , St_Lname 
from Student
order by St_FName desc , St_LName  -- order by first name descending, if some rows has the same first 
--                                 -- name then order by last name ascending 

select St_Id , St_Fname , St_Lname 
from Student
order by 2 , 3 desc    -- order by first name (number 2 in selection) ascending , then by 
--                     -- last name (number 3 in selection) descending

select St_Id , St_Fname , St_Lname 
from Student
order by 5             -- Error : no column number 5 in the select 
                 

select *
from Student
order by 5        -- order by age (number 5 in table columns) ascending 


-- Notes 
--      1. The data is by default soreted ascending by the PK on the hard disk.
--      2. When ordering , the null value is sorted as the smallest value.

--============================================================================================

select distinct FName          -- Distinct => ORDER THE DATA + REMOVE REPEATED VALUES (only unique)
from student

select distinct Dept_id , St_Fname    -- Distinct ROW of data 
from Student
where dept_id is not null

--============================================================================================

select * from student
where name is not null and age is null

-- With NULLS we use (is , is not) , using (= , != , > , < , >= , <=) is WRONG !! Nulls are not values

--============================================================================================

select * from student
where address='alex' and age > 30


select * from student
where address='alex' or address='cairo'
-- SAME AS : 
select * from student
where address in ('alex','cairo')


select * from student
where age in (20,30)         -- only age = 20 and age = 30

select * from student
where age not in (25,27)         -- all ages without age=25 and age = 27 (ex: ..., 24, 26, 28, ...)


select * from student
where age between (20,30)    -- all ages between 20 and 30 (ex: 20, 21 , ... 30) (20 and 30 included)
-- SAME AS : 
select * from student
where age >=20 and age<=30   -- all ages between 20 and 30 (ex: 20, 21 , ... 30) (20 and 30 included)


select * from student
where age not between (20,30)    -- (ex: ..., 19, 31, ...)

--============================================================================================

-- Using Alias naming (new name) : a temporary name for a table or column, used to improve readability

select Fname +' '+ Lname as 'Full Name'
from Student

-- alias name can be written in more than one way : 
--    Fname +' '+ LName as 'Full Name'      -- more than one word
--    Fname +' '+ LName as "Full Name"      -- more than one word
--    Fname +' '+ LName as [Full Name]      -- more than one word
--    Fname +' '+ LName as FullName         -- one word
--    Fname +' '+ LName FullName            -- one word
--    FullName = Fname +' '+ LName

-- Note : We can also give an alias name for Table Names


-- Note : the Alias name must be used after the execution of 'select' , ex: cannot use alias name with 
--        where as the select is not executed yet !

-- EX: WRONG !!	(where) is executed before select , so where don't know what is [Full Name] yet
select S.St_Id as Id , S.St_Fname as 'First Name' , S.St_Lname [Last Name] 
from Student S
where [Last Name] = 'Shoura'          -- WRONG !!!!!!!