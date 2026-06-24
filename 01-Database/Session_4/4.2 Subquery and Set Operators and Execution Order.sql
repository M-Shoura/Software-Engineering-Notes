--==========================================================================================
--========= Subquery =======================================================================
--==========================================================================================


-- it's using the output of the inner query as an input for outer query
-- subqueries can be written in any place , select , where , from , having
-- It's not a must to use aggregate functions with subqueries
-- It's not a must to use the same table for the inner query and the outer query


-- Note : 
--   In most cases, Joins are faster than Subqueres, so it's better to use joins if we can. 
--   In some cases it's a must to use subquery.
--
--   Best Performance -> ... -> Worst Performance
--   Querying one table -> Querying multiple tables with joins -> Sub querying (they are two queries)


-- Ex1 : select students data that have age < avg age
select * 
from student
where St_Age<avg(st_age)           -- WRONG , we cannot use an aggregate function in the 'where'

-- To solve this: 
--   1. get the avg age using a subquery (inner query).
--   2. then use it as the where condition (outer query). 

select * 
from student
where St_Age < (select avg(st_age) from Student) 


-- Ex2: select question and the total number of questions (ex: 1 out of 15 , 2 out of 15 , ... )
select Id, (select count(Id) from Questions)
from Questions 


-- Ex3: select department names that contain students 
--      inner query => Gets the dept ids that are in student table (depts having students)
--      outer query => gets dept names that have ids in the returned list (so we used 'in' not '=' )

-- Note : if the return from the inner query is more than one value , then we CANNOT use (= > < >= <= !=)
--        we can use (in , not in)
select dept_name
from Department 
where Dept_Id in (select distinct Dept_Id 
                  from Student
				  where Dept_Id is not null)

-- The same query using join : 
select distinct D.Dept_Name
from Department D inner join Student S
on D.Dept_Id = S.Dept_Id


-- Ex4: We can use Subqueries + DML (but it's better if we can achieve the same result with joins)

-- Subquery : 
delete from Stud_Course
where crs_id in (select Crs_Id from Course where Crs_Name in ('OOP','SWE'))

-- Join : 
delete SC
from Stud_Course SC inner join Course C
on Sc.CID_Id = C.Crs_ID
where C.Crs_Name in ('OOP','SWE')


--==========================================================================================
--========= Set Operators ==================================================================
--==========================================================================================

-- Set Operators / Union Family Operators : (union , union all , intersect , except)

-- if we run the following two queries , then they are called 'Batch' (set of independant queries)
-- each query has it's execution plan , result set and memory.
select St_Fname from student
select Ins_Name from Instructor

-- what about if we want them in a one query result ?  ===> Use Set operators
-- Notes : 
--   1. The resulting result set columns have the name of the first select statement columns 
--   2. the number of selected columns in the two queries MUST BE EQUAL.
--   3. the datatypes of selected columns must be the same in the two queries ( + same order of selection). 
--   4. The result may contain NULL , so this must be handeled if we want using 'where __ is not null'
--   5. operators can be used with tables with no relationships , maybe in different databases
--   6. Set Operators VS Join : 
--        Set Operators : (Combine Columns from Both Queries in the Same Column , column under a column)
--        Join : (Combine Columns Side by Side)

select St_Fname from student                        -- same number of selected columns
union                                     
select Ins_Name from Instructor

select cast(St_Age as varchar(3)) from student      -- same datatypes 
union                                        
select Ins_Name from Instructor

-- union all => result of the first query + result of the second query
-- union     => 'Distinct' result + 'Sorted' Result 
--              result of the first query + result of the second query - intersection of the two queries
-- intersect => only shared data between the two selects (based on the selected columns)
--              Note : 'Distinct' result
--              ex: 
--              select name, id from student 
--              intersect 
--              select name, id from instructor
--              -- result => students and instructors having the SAME NAME AND ID
-- Except    => Data in the first select BUT NOT FOUND in the second select 
--              Note : 'Distinct' result

-- Important : in union and intersect and except => 
-- for example , Union => 
-- What if we select the Id and the name ???? 
-- to tell that the two rows are the same so we will remove one of them (due to getting distinct)
-- In this case, we check if the entire row is repeated or not, means that the two rows must have the same 
-- id and name , if id or name are different then they are not same. 



--==========================================================================================
--========= Execution Order and Subquery New Table =========================================
--==========================================================================================


-- The right execution order of a query : 
-- 1.  from 
-- 2.  join
-- 3.  on 
-- 4.  where 
-- 5.  group by
-- 6.  having
-- 7.  select 
-- 8.  order by 
-- 9.  top       -- discussed later
-- 10. into      -- discussed later

-- Note : In interviews , we should read the query in the same execution order.
--        ex: from .. where .. select .. order by ...



-- order by is executed after the select , so we can use the alias name (used in the select) in order by.
select st_fname +' '+ st_lname as FullName
from Student
order by FullName                  -- no problem , we can use the alias name here 

-- where is executed before the select , so we CANNOT use the alias name (used in the select) in the where.
select st_fname +' '+ st_lname as FullName
from Student
where FullName like 'a%'   

-- this problem can be solved using Subqueries :
select * 
from (
	select st_fname +' '+ st_lname as FullName
	from Student
	) as newTable      
where FullName like 'a%' 

-- when subquery is here in the 'from' , we must give an alias name for the resulting table , because this
-- table is created in the run time. Now the condition will be in the new table that has column FullName.


--============================================================================================


-- Exists in SQL : 
-- Exists : A logical operator used in a WHERE clause to check whether a subquery returns AT LEAST ONE ROW. 
--          It does not return data, it returns TRUE or FALSE.

-- Ex: 
-- SELECT * FROM table1
-- WHERE EXISTS (
--     SELECT 1
--     FROM table2
--     WHERE condition
-- );

-- If the subquery returns at least one row => EXISTS = TRUE
-- If it returns no rows                    => EXISTS = FALSE

-- Notes : 
--   - Exists stops searching as soon as it finds one row (very efficient)
--   - The columns inside the subquery don’t matter
--   - Opposite operator: NOT EXISTS

-- Ex: Returns customers who have at least one order
SELECT *
FROM Customers c
WHERE EXISTS (
    SELECT 1
    FROM Orders o
    WHERE o.CustomerID = c.CustomerID
);


-- Not Exists : 
-- Ex: Returns customers with NO orders
SELECT *
FROM Customers c
WHERE NOT EXISTS (
    SELECT 1
    FROM Orders o
    WHERE o.CustomerID = c.CustomerID
);
