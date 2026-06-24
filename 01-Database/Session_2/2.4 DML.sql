--==========================================
-- DML : insert , Update , Delete ----------
--==========================================


---------------------------------------------
------- Insert ------------------------------
---------------------------------------------

-- Insert : Simple insert [Add ONLY ONE Record] & Row Constructor [Add More Than one Record]

-- NOTE : Data in the table is by default sorted by the pk

--=================================================================================

-- 1 - Simple insert [Add ONLY ONE Record] : 

-- To insert ALL the data with their exact order in the table design :
insert into employee 
values(1,'shoura','1/1/2025','cairo',5000,23,Null)


-- To insert SOME data with any order we specify :
insert into employee (ename,eid,eage)
values('shoura',1,23)

--=================================================================================

-- 2 - Row Constructor [Add More Than one Record] : 

-- to insert more than one row with the previous two ways : 
insert into employee 
values(1,'shoura','1/1/2025','cairo',5000,23,Null),
values(2,'Mahmoud','2/2/2022','alex',4000,20,Null)

insert into employee (ename,eid,eage)
values('shoura',1,25),
values('Mahmoud',2,20),
values('Ali',3,22)


-- Notes
-- 1. when inserting , don't miss providing a unique PK , to avoid violating the PK rules.
-- 2. Date : single cauts +  MM/DD/YYYY
-- 3. If there is an identity , we don't put it in the values
-- 4. when inserting some data in columns , the other not choosed columns must be one of the following : 
--    Nullable     OR     Having Identity      OR     Having Default Value


--------------------------------------------------------------------
-------------------------------Update-------------------------------
--------------------------------------------------------------------


-- Update all rows
update employee
set esalary += 100

update employee
set eaddress=Null


-- Update some rows 
update employee
set eaddress = 'mansoura'
where eid = 1


-- update rows in MORE THAN ONE column 
update employee
set eaddress = 'mansoura', esalary = 8000
where eaddress = 'cairo' and eage > 35




--------------------------------------------------------------------
-------------------------------Delete-------------------------------
--------------------------------------------------------------------


-- delete all rows
delete from employee


-- delete some rows
delete from employee
where eid=1

-- Notes : 
-- 1. delete -> DML Query , deletes the data only , doesn't affect the structure