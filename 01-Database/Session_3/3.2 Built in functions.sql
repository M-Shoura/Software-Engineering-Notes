--===================
-- Functions in SQL
--===================

-- A Function is a Database Object (Like table) , We use Functions to stop repeating the same code. 
-- Functions can be =>
--       1. built-in 
--       2. user-defined (discussed in Advanced SQL)

-- Functions are : 
-- 1 - User Defined (Discussed in Advanced SQL) 
--       1.1 - Scalar Valued
--       1.2 - Table Valued

-- 2 - Built-in : (See Microsoft documentation for more functions ...)
--     In this session 
--          2.1 - NULL
--          2.2 - Casting (Conversion)
--          2.3 - DateTime
--          2.4 - String
--          2.5 - Math
--     Next Sessions : 
--          2.6 - Aggregate
--          2.7 - Logical
--          2.8 - Ranking
--          2.9 - System and Security 

-- Microsoft Docs : https://learn.microsoft.com/en-us/sql/t-sql/functions/functions?view=sql-server-ver16
-- or we can see the functions using the SSMS => click on any database => Programmability => Functions =>
--                                            => System Functions 


-- First Of All : If we faced the following problem : 
--      'TRY_CONVERT' or any other function is not a recognized built-in function name.
--  then the database might be set to an older compatibility level, how to know ?

SELECT name, compatibility_level  
FROM sys.databases  
WHERE name = DB_NAME();  -- Checks the current database
-- if it's less than 110 , then we must change it by .. 
ALTER DATABASE YourDatabaseName  
SET COMPATIBILITY_LEVEL = 160;

--=========================================================================================================================

-- If we want to print a string , then write it in the select as : 
-- The following way may cause problems (with nulls and casting)
select 'My name is ' + st_fname
from student


--=========================================================================================================================
--=========================================================================================================================


-- 1 - Null Functions : No category for Null functions in SQL Docs, but they are from System Functions
--     [[[ IsNull , Coalesce ]]]

--=========================================================================================================================


-- Isnull : If a value is null, then replace it with another value of the same datatype 

select Isnull(st_Fname,'NO NAME')
from student

select Isnull(st_Fname,st_Lname)             -- if Fname and Lname are null , then it returns null 
from student

select Isnull(salary,1000)
from employee

select Isnull(st_Fname, isnull(st_Lname, 'NO NAME'))     -- or use Coalesce
from student               

-- Note : if we concate a string with null then the all string will be null (can be solved with 
--        Casting functions , discussed next )

select Isnull(st_Fname,'') + ' ' + Isnull(st_lname,'')
from student


--=========================================================================================================================

-- Coalesce : same as isnull but with a better way
-- shows the first not null value, Not important to have same datatypes, ex: coalesce(Salary,Address,SSN)
-- if no one has value and all are Nulls , it returns Null !

select Coalesce(st_Fname,st_lname,'NO NAME')
from student

--=========================================================================================================================
--=========================================================================================================================

-- 2 - Casting Functions (Conversion) : 
--     [[[ Convert , Try_Convert , Cast , Try_Cast , Parse , Try_Parse ]]]
--     Note : 'Try' Versions are used to avoid errors and exceptions, if we cannot convert or cast 
--             or parse then will select 'NULL' 
--     Convert and Cast are both the same, used to convert from any datatype to any another datatype 
--     (small difference when using convert when converting from 'date' to 'string')


-- WRONG , we cannot concat two values of different types (int must be converted first)
select st_fname + ' ' + st_age         -- ERROR
from student

--=========================================================================================================================


-- Convert and Try_convert : [Cast from any datatype to any datatype], takes the target datatype we 
--                           want to convert to , and the value we want to convert. Also Can be used 
--                           to trim . Also we use varchar(max) if we don't know the size after convertion 
--                           to avoid loosing data.

select isnull(st_fname,'no name') + ' ' + convert(varchar(max), isnull(st_age,0))     
from student


select try_convert(int,'100')       -- 100
select try_convert(int,'ABC')       -- NULL
select convert(int,'ABC')           -- Error and Exception

--=========================================================================================================================

-- Cast and Try_Cast [Cast from any datatype to any datatype] : 

select isnull(st_fname,'no name') + ' ' + cast(isnull(st_age,0) as varchar(max))     
from student


select try_cast('100' as int)        -- 100 as an int
select try_cast('100/3' as int)      -- Null 
select try_cast('ABC' as int)        -- Null
select cast('ABC' as int)            -- Error and Exception



-- Convert and Cast are the same in all situations but differes only in one case (converting from 
-- 'date' to 'string') : Convert can take a third parameter for specifying the format of showing the date  
-- But this feature isn't commonly used with Convert, in string functions we will discuss the 'Format' 
-- function that is better in this case


declare @Today Date = '12/31/2024'
select Cast(@Today as varchar(100))              -- 2024-12-31
select Convert(varchar(100) , @Today , 101)      -- 12/31/2024
select Convert(varchar(100) , @Today , 102)      -- 2024.12.31
select Convert(varchar(100) , @Today , 103)      -- 31/12/2024
select Convert(varchar(100) , @Today , 104)      -- 31.12.2024
-- WE HAVE MORE FORMATS , check them in microsoft documents 


--=========================================================================================================================


-- Parse and Try_parse : Used to convert from 'string' to 'datetime and numeric types' ... 
-- Note : it's Slower (uses CLR functions)

select parse('12/31/2024' as datetime)     -- string to datetime
select parse('2024' as int)                -- string to int

select try_parse('100' as int)       -- 100
select try_parse('ABC' as int)       -- NULL


--=========================================================================================================================
--=========================================================================================================================

-- Some string functions , discussed here and in string functions also : 
-- [[[Concat , Concat_ws]]]

-- Concat : it's a string function but we discussed it here because it => 
--            1. converts any type to string
--            2. takes any number of parameters
--            3. Casts all parameters to strings
--            4. if null , will be mapped to empty string '' 
--            5. Concat all given parameters

select Concat('Student name : ' , st_fname , ' student age : ', st_age)
from student

-- Concat with seperator : Takes the seperator first and concates the parameters with it 
select Concat_WS(' // ','Student name: ' , st_fname , 'student age: ', st_age) 
from student
-- result => Student name: Mahmoud // student age: 23



-- So, next is Bad , must convert age to varchar(5) , and use IsNull with both 
select Fname + ' ' + age from Student         

-- Next is the best way : 
select concat(Fname,' ',age) from Student


--=========================================================================================================================
--=========================================================================================================================


-- 3 - DateTime Functions : 
--     Getdate , GetUTCdate , Day , Month , Year , DatePart , Datename , isdate , EOMonth , DateDiff... 

select getdate()          -- current system date (now cairo +2:00)
select getutcdate()       -- current date UTC


select day(getdate())                  -- gets the day number only
select DatePart(day,getdate())

select month(getdate())                -- gets the month number only
select DatePart(month,getdate())

select year(getdate())                 -- gets the year number only
select DatePart(year,getdate())

select DatePart(quarter,getdate())     -- 4 quarters in the year

select DatePart(week,getdate())        -- number of the week we are currently in in this year

select DatePart(hour,getdate())        -- current hour

select Datename(month,getdate())       -- month name in English 


if isdate('2009-05-12') = 1
	select 'Valid'
else 
	select 'Invalid !!!'


select EOMonth(getdate())        -- 31-01-2024  ,  selects the last day in this month (end of month) 
select day(EOMonth(getdate()))   -- 31   ,   selects the last day in this month (end of month)  


select datediff(day , '12-1-2024' , '12-31-2024' )
select datediff(month , '12-1-2024' , '12-31-2024' )
select datediff(year , '12-1-2024' , '12-31-2024' )
-- datediff() => Takes interval (ex: day, month, year, week) , start date , end date , and returns int
-- ex1: datediff(day , yesterday , today) = 1 
-- ex2: datediff(day , today , yesterday) = -1


--=========================================================================================================================
--=========================================================================================================================


-- 4 - String Functions : 
-- [[[ Format , len , Upper , Lower , String_Agg , Substring , ASCII , Left , Right , LTrim , RTrim , 
--     Trim , Replace , Reverse , concat , concat_ws ]]]


-- Format : takes the value , format , culture (can be null and not given) ... 
--          Value must be Numeric or DateTime

select format(cast('11/28/2023'  as date) , 'dd-MM-yy')
select format(Getdate(),'ddd MM yyyy')
select format(Getdate(),'dd / MM / yy')
select format(Getdate(),'dd')
select format(Getdate(),'d')
select format(Getdate(),'dddd','ar')     -- Culture Provided as 'ar' (arabic)
select format(Getdate(),'MMM','ar')      -- Culture Provided as 'ar' (arabic)
select format(Getdate(),'HH')     
select format(Getdate(),'mm')     
select format(Getdate(),'hh:mm tt')
select format(GETDATE() , 'dddd-MM-yyyy :HH:mm:ss tt')

select format(123456789,'###-###-###')


--=========================================================================================================================

-- len : selects the length of a string (actual length, not the column length specified in table metadata)
select len(St_fname) from student  

select * from Employee where len(Fname)>3

--=========================================================================================================================

-- Upper and Lower : selects the string as all characters uppercase or lowercase

select Upper(St_FName) , Lower(St_fname)
from Student

--=========================================================================================================================

-- Substring : selects a substring of a given string 
--             Takes the string , the start index , and the count next wanted
--             Note : SQL is NOT zero index and starts from index 1 

select Substring('Shoura', 2,3)     -- hou

select Substring(st_Fname, 1 , len(st_Fname)-1) from Student      -- All First names without the last character

select * from Students where Substring(st_Fname,1,1) = 'A'

--=========================================================================================================================

-- ASCII : selects the ascii code for the first char of the string 
select Ascii('abc')     -- 97

--=========================================================================================================================

-- String_Agg : Returns the Concatination of values of a COLUMN (numeric or string)

select string_agg(St_FName, ', ')    -- concat all student first name seperated with ','
from Student

select string_agg(St_age, ', ')
from Student

--=========================================================================================================================

-- Left and right : selects a substring from left or right with a given number of characters

select right(st_FName,2)     -- Ahmed will be 'ed'
from Student

select left(st_FName,2)      -- Ahmed will be 'Ah'
from Student

--=========================================================================================================================

-- LTrim and RTrim and Trim : Trim all the spaces before and after the string, or the spaces before the 
--                            string only, or the after the string only
--                            Note : spaces inside the string are NOT Trimmed 

select Trim ('   Mahmoud    Shoura     ')       -- 'Mahmoud    Shoura'
select LTrim ('   Mahmoud    Shoura     ')      -- 'Mahmoud    Shoura     '
select RTrim ('   Mahmoud    Shoura     ')      -- '   Mahmoud    Shoura'

--=========================================================================================================================

-- Replace : replaces characters with another characters
select replace('zzzAAAzzz' , 'A' , '0')       -- zzz000zzz

--=========================================================================================================================

-- Reverse : reverses the string 
select reverse('shoura')                 -- aruohs

--=========================================================================================================================

-- Again : 
-- Concat : it's a string function but we discussed it here because it => 
--            1. converts any type to string
--            2. takes any number of parameters
--            3. Casts all parameters to strings
--            4. if null , will be mapped to empty string '' 
--            5. Concat all given parameters

select Concat('Student name : ' , st_fname , ' student age : ', st_age)
from student

-- Concat with seperator : Takes the seperator first and concates the parameters with it 
select Concat_WS(' // ','Student name: ' , st_fname , 'student age: ', st_age) 
from student
-- result => Student name: Mahmoud // student age: 23


-- So, next is Bad , must convert age to varchar(5) , and use IsNull with both 
select Fname + ' ' + age from Student         

-- Next is the best way : 
select concat(Fname,' ',age) from Student


--=========================================================================================================================
--=========================================================================================================================

-- 5 - Math Functions : 
--     [[[Abs, Power, Sqrt, Ceiling, Floor, Round]]]

select abs(-100)         -- 100

select Power(5,2)        -- 25

select sqrt(16)          -- 4

select Ceiling(5.1)      -- 6
select Ceiling(5.9)      -- 6

select floor(5.1)        -- 5
select floor(5.9)        -- 5

select round((5/3.0),1)  -- 1.700
select round((5/3.0),2)  -- 1.670
select round((5/3.0),3)  -- 1.667


--=========================================================================================================================
--=========================================================================================================================

-- Other functions : 

select db_name()         -- Know what is the currently used Database 

select suser_name()      -- Know the current user that is logged in 


--=========================================================================================================================
--=========================================================================================================================


-- Like statement : used when we know a pattern that is followed by date 

select * 
from Employee
where Fname = 'Ahmed'
-- IS THE SAME AS
select * 
from Employee
where Fname like 'Ahmed'


-- Using "like" keyword for regular expressions (regex) and patterns
-- The two reserved Characters (_ and %)
-- _  ==> One character 
-- %  ==> Zero or More Characters

-- Examples : 
like '%a%'              -- Contain the char 'a'
like '%backend%'        -- any string contains "backend" word 
like '_a'               -- two char name and the second char is 'a'
like 'a%'               -- First char is 'a'
like '%a'               -- Last char is 'a'
like '_a%'              -- second char a followed by zero or more chars 
like '%a_'              -- any string that 'a' is the character before last
like 'a%d'              -- any string starts with 'a' and ends with 'd' , ex : ad , aXXXd , .... 
like '___'              -- any string has length = 3
like '___%'             -- any string has length = 3 or more
like '_m__'             -- any string has length = 4 and second character is m
like 'ahm%'             -- any string starts with 'ahm' followed by zero or more chars
like '[ahm]%'           -- [OR] starts with any char of them (a,h,m) followed by any number of chars (zero or more)
like '[^ahm]%'          -- [NOT OR] starts with any char except  (a,h,m) followed by any number of chars (zero or more)
like '[a-h]%'           -- [RANGE] starts with any char from 'a' -> 'h' followed by any number of chars (zero or more)
like '[^a-h]%'          -- [NOT IN RANGE] starts with chars rather than chars from 'a' to 'h' , ex: john , mahmoud , zyad 
like '[(am)(gh)]%'      -- [group of elements] starts with 'am' or 'gh' followed by any number of chars (ex: amir, ghada)
like '[345]_'           -- starts with any digit of them (3,4,5) followed by ONLY one char (3m, 4d, 5X)
like '%[%]'             -- any string that has the last character as '%' , ex: ahmed% , mahmoud% , % , ...
like '%[%]%'            -- any string that contains the character '%' , ex: ahmed%yousef , %ali , % , ...
like '%[_]%'            -- any string that contains the character '_' , ex: ahmed_yousef , _ali , _ , ...
like '[_]%[_]'          -- any string that starts and ends with character '_' , ex: _ahmed_ , _mahmoud ahmed_ , __ , ...
like '[_]%'             -- any string that has the first character as '_' , ex: _ahmed , _mahmoud , _ , ...

-- self study in regular expressions (in like '') : * ? \ 