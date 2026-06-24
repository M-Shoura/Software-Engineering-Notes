-------------------------------------------------
-------------------------------------------------
------------ Ranking Functions ------------------
-------------------------------------------------


-- Ranking Functions : 4 types of ranking functions 
-- 1. Row_Number()
-- 2. Dense_Rank()
-- 3. Rank()
-- 4. NTile()

-- - Ranking functions solves business questions in an efficient way (avoiding many subqueries to achieve a query result)
-- - Each ranking function puts numbering in a certain sequence, choose the sequencing we want ! 
-- - They assign a rank or number to each row in a result set ( based on a specific column’s values ). They are commonly 
--   used for ranking, pagination, and analytics. All ranking functions require the OVER() , which can include: 
--      1 - order by (Mandatory) => Defines the order by criteria in which ranking values are assigned. 
--      2 - partition by (Optional) => Groups rows before ranking (for grouping) 

--  1 - Row_Number() => ex: 1,2,3,4,5,6,7,8,9,10, .... Every Row Gets a Unique Number , No Gaps , Useful for Pagination
--  2 - Dense_Rank() => ex: 1,2,2,2,3,4,5,6,6,6, ..... Ties (Duplicates) Get Same Rank , No Gaps in Ranking
--  3 - Rank()       => ex: 1,2,2,4,4,4,4,4,9,10,..... Ties (Duplicates) Get Same Rank , Gaps Exist After Duplicate Ranks
--  4 - NTile(n)     => Divides Rows into n Groups, Useful for Quartiles, Deciles, Percentiles (examples discussed next)


-- Note : 
-- To use the ranking function values , we must use subqueries (we cannot use 'where' of the same query , it is executed 
-- before the select that has the ranking functions)

----------------------------------------------------------------------------------------------------------------------------

select Ins_Id , Ins_Name , Salary 
          , ROW_NUMBER() over (order by Salary desc) as RN
          , Dense_Rank() over (order by Salary desc) as DR
          , Rank()       over (order by Salary desc) as [Rank]
from Instructor


-- The previous Query can be a subQuery , and filter with the condition we want : 

select * from (
        select Ins_Id , Ins_Name , Salary 
                    , ROW_NUMBER() over (order by Salary desc) as RN
                    , Dense_Rank() over (order by Salary desc) as DR
                    , Rank()       over (order by Salary desc) as [Rank]
        from Instructor 
) as newTable
where RN <= 10     --- or DR or Rank (which one of them is wanted)


----------------------------------------------------------------------------------------------------------------------------

-- Ex : get the two elder students in Student table

-- using top keyword : 
select top 2 St_Id , St_Fname , St_Age
from Student
order by St_Age desc


-- using Ranking : 
select St_Id , St_Fname , St_Age
from (
	select * , Row_number() over (order by st_age desc) as RN
	from Student
) as new
where RN <= 2


----------------------------------------------------------------------------------------------------------------------------

-- Ex : get the 5th Younger Student

-- using top keyword : 
select top 1 *
from (
	select top 5 * from Student
	order by st_age 
) as new
order by st_age desc


-- using Ranking : 
select *
from (
	select *, ROW_NUMBER() over (order by St_age) as RN
	from Student
) as new 
where RN = 5


----------------------------------------------------------------------------------------------------------------------------


--  4 - NTile(n) => Takes one parameter (int) , Divides Rows into n Groups, Useful for Quartiles, Deciles, Percentiles 
--                  First group takes rank 1 , second group takes rank 2 , and so on ... 
--                  ex: if we have 9 rows in the result , and we want to make them 3 groups , then : 
--                      ordering : 1,1,1, 2,2,2, 3,3,3
--                      tries to make groups count equal as possable , last groups can have at maximum count_diff = 1
--                  ex: if we have 8 rows in the result , we want to make them 3 groups , then : 
--                      ordering : 1,1,1, 2,2,2, 3,3
--                  ex: if we have 10 rows in the result , we want to make them 3 groups , then : 
--                      ordering : 1,1,1,1, 2,2,2, 3,3,3

-- Note : NTile can be used in Pagination , Top also can be used in Pagination , but 'Offset' and 'Fetch' are better.

select Ins_Id , Ins_Name , Salary , NTILE(4) over(order by Salary desc) as levels
from Instructor

-- if we have 14 rows , and we want them to be 4 groups => then the first group count = (4) , second group count = (4), 
-- third group count = (3) , fourth group count = (3) .. means that the last groups one may have a smaller number count.


----------------------------------------------------------------------------------------------------------------------------


-- Partition by :
--   - over ( write 'partition by' before 'order by' )
--   - Group by VS Partition By : To use group by we must use an aggregate function, so the group by can hide rows, 
--                                but here with 'partition by' we don't hide rows , the table is partitioned to groups 
--                                using a certain column but without hiding rows. Then when using ranking functions, 
--                                the ranking works per each group, ex: we order by salary in each group and ranking
--                                function values are given for each group independently. 
--   - Note : if we have a group that has value 'Null' in the partition by column , they are grouped into one group.
--   - Ex1 : 

use Company_SD
select Fname , Dno , Salary , Row_Number() over (partition by Dno order by Salary desc) as RN
from Employee

-- FName      Dno      Salary     RN
--
-- Mahmoud    10       10,000      1
-- Ahmed      10       10,000      2
-- Shoura     10       9,000       3
--
-- Amr        20       7,500       1
-- 
-- Ali        30       18,000      1
-- Mostafa    30       8,000       2
-- Mohamed    30       4,000       3

-- So we start counting from 1 in each group (partition) ... each group has it's independent counter 


-- Ex2 : get the eldest student at each department : 

select *
from (
	select St_Id , St_Fname , St_Age , Dept_Id , ROW_NUMBER() over (partition by Dept_id order by st_age desc) as RN
	                                           , Dense_Rank() over (partition by Dept_id order by st_age desc) as DR
	from Student
	where st_age is not null and dept_id is not null
) as new
where RN = 1         -- eldest student in each department
-- where RN = 3      -- THIRD eldest student (having third max age) in each department 
-- where DR = 1      -- eldest student(s) in each department (if top(2) max(age) in the deparment has the same age then 
--                                                            the two students will be shown)


----------------------------------------------------------------------------------------------------------------------------


-- Using Aggregation Function with Partition By : can be done without 'group by' or 'having' [ No hiding columns ]

use ITI

select Ins_id , Ins_Name , dept_id , max(Salary) over (Partition by dept_id)
from Instructor

-- see different results :
select dept_id , max(Salary)
from Instructor
group by dept_id 

-- see different results : 
select Ins_id , Ins_Name , dept_id , (select max(Salary) from instructor )
from Instructor


----------------------------------------------------------------------------------------------------------------------------


-- Ntile(n) vs Partition By : 
--   - NTile(n) : partiton the table according to the number of groups WE WANT (n => given in the query)
--     ex: first group can have count = 100 , all other group MUST have count = 100 or 99 only (difference >= 0 && <= 1)
--   - Partiton By : partitions the table according to the actual groups that are in the table for the choosen column 
--     ex: one group can have count = 100 , and other group can have count = 5 (difference >= 0)


-- Using Ntile() with Partition By : 
-- ntile + partition by : Part Inside Part , Group Inside Group , partition the whole table to a number of groups 
--                        (based on number of groups for a choosen column in Partition by) and then these groups and 
--                        partitioned again into given number of groups choosen in Ntile() 
-- Ex: 
use ITI
select * 
from ( select * , Ntile(2) over (partition by dept_id order by st_id desc) as NewCol
       from Student ) as newTable


-- Id  FName      Dept_id    NewCol
--
-- 4   Mahmoud    10          1
-- 3   Ahmed      10          1
-- 2   Shoura     10          2
-- 1   Magdy      10          2
--    
-- 10  Amr        20          1
--    
-- 6   Ali        30          1
-- 5   Mostafa    30          1
-- 4   Mohamed    30          2

-- so first we will partition using the Dept_id [same dept_id will be in one group] , then order them by their id , 
-- then use Ntile to partition then into groups (in our example 2 groups) => so this results in :

-- count(id=10) => 4 , then they are (2 groups)  
-- (group 1 (id=10)) 
-- (group 2 (id=10))

-- count(id=20) => 1 , then they are (1 group)
-- (group 3 (id=20)) 

-- count(id=30) => 3 , then they are (2 groups)
-- (group 4 (id=30))
-- (group 5 (id=30)) 


-- Ex: Get the first group in each department => Add ' where NewCol = 1 ' (Group 1,3,4)
-- Ex: Get the first group in a specific department => Add ' where NewCol = 1 and dept_id = 10 ' (Group 1)


----------------------------------------------------------------------------------------------------------------------------


-- Note : Order by after using any ranking function : after using ranking functions and assigning values for the rows ..
--        ex: order by names ! the result will be ordered by names , but maybe with shuffled ranking function values 
--        ex: we ordered by salaries descending with ranking functions , after having the result now order by name : 
  
select Ins_Id , Ins_Name , Salary 
          , ROW_NUMBER() over (order by Salary desc) as RN
          , Dense_Rank() over (order by Salary desc) as DR
          , Rank()       over (order by Salary desc) as [Rank]
from Instructor
order by Instructor.Ins_Name