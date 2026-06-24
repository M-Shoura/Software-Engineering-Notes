---------------------------------------------------------------------------------------------------
----------------------Database Life cycle Revision-------------------------------------------------
---------------------------------------------------------------------------------------------------
/*
	The Business consultant ask the customer some questions, and then make the RSD or SRS Document,
	then the developers use this doc to visualize it to the ERD (Entity Relationship diagram) that
	contains the Entities, attributes of these entities and relationships between these entities. 
	
	Note : One Document can have more than one ERD (mis understanding or ambiguous words , so ask the
	       business consultant / system analyst in any ambiguous case)
	
	Then we take the ERD and make the physical design of the database (Relations or Tables) that will 
	be used in implementing the database in the server, we here have some rules that must be followed 
	to make the best design ... (meet business requirements (done in ERD), No Repeated data, No 
	unnecessary Nulls)

*/

-- ===================================================================================================
-- ===================================================================================================
-- ===================================================================================================


-- What is SQL and it's categories ? 
--
--
-- 			ANSI SQL (American National Standart Institute)
--  ____________________________|________________________________
-- 	|                          |                |                |
-- 	|					       |				|				 |
--   Microsoft               Oracle           IBM           Open Source
-- Transact-SQL (T-SQL)      PL-SQL        IBM-PL-SQL          MySQL
-- 
-- 
-- => Minimal differneces between them in writing queries (DQL), and in Microsoft SQL Server we can 
--    use both 2 syntaxes , ANSI and T-SQL.
-- 
-- Query Categories :  
--    1 - DDL => Data Definition Language
--    2 - DML => Data Manipulation Language
--    3 - DCL => Data Control Language
--    4 - DQL => Data Query Language
--    5 - TCL => Transactional Control Language
-- 
-- 
-- 1 - 
-- DDL : Data Definition Language , For Meta Data and Structure (define or modify database structures)
-- 	   - Meta data : column names, column types, ... 
--     - Create ( Table , Schema , View , Function , .. )
-- 	   - Alter
-- 	   - Drop 
-- 	   - Select into        
-- 	   - Trancate (drop the table and then recreates it ... better than delete in case of deleting all data)
-- 
-- 
-- 2 - 
-- DML : Data Manipulation Language, For Data only 
--     - Insert
-- 	   - Update
-- 	   - Delete
-- 	   - Merge
-- 
-- 
-- 3 - 
-- DCL : Data Control Language, For Controlling Access Security and Permissions
--     - Grant
-- 	   - Deny
-- 	   - Revoke
-- 
-- 
-- 4 - 
-- DQL : Data Query Language, For Displaying data from Database (no change in data , only displaying)
--     - Select + (Aggregate Function , Grouping , Union , Joins , Subqueries)
-- 
-- 
-- 
-- 5 - 
-- TCL : Transaction Control Language , For Managing Transaction Execution 
--     - Begin Transaction 
-- 	   - Commit
-- 	   - Rollback

-- ===================================================================================================
-- ===================================================================================================
-- ===================================================================================================


-- Notes : 
--   1. Now we will start implementing the Design that we designed in tha last step (Mapping schema), we 
--      will use SQL Server.
--
--   2. First we need to install the SQL Server Services (It's a Windows Service that runs in the background
--      and will be found in the services of Windows, and can only be installed on Windows OS), we will 
--      install the Developer Free Edition of SQL Server Services ... starting from this step we can use the 
--      Service using the CMD, and writing queries and running it through the CMD like this : 
	    
--		sqlcmd -S "."  ('S' -> Server, '.' -> my server or computer)
--	    use MyCompany
--	    GO
--	    select * from Employees
--	    GO
--      sqlcmd -S "." -d "ITI" -q "select * from Student" ('d' => database name , 'q' => query)
--	    GO
--      sqlcmd -S "." -d "ITI" -q "select * from Student" -o "D:\testResult.txt" ('o' => output file path)
--	    GO
--	    
--      Note : we use "go" to use the Transactions.  


-- if we installed the Express Edition , then we will find the service named as 'SQL Server (SQLEXPRESS)'
-- if we installed the Developer Edition , then we will find the service named as 'SQL Server (MSSQLSERVER)'


--	3. But there is a better way using the SQL Server Management Studio (SSMS) -> UI , it's a Tool used to  
--	   connect to the SQL Server Service that we installed. Now we can make many configurations using the 
--	   Wizard instead of writing code 
--	   Note : We can use another tools to connect to the service => Visual Studio, VS Code
--
--	4. When opening the SSMS, we choose the Server Type (Database Engine), Server Name (.) or (server name) 
--	   that we will be connected on , or the (IP of the server), and Authentication Type.
--	   
--     Server Name =>
--     Developer Edition =>    . OR IP Address of the Server OR Device Name
--     Express Edition   =>    .\SQLexpress

--	5. We have 2 types of Authentication : 
--      1 - Windows Authentication (With username and password of Windows. Uses the credentials of Windows 
--	        account that we are logged in now. No need to store or enter a separate username/password for 
--			SQL Server.)
--	    2 - SQL Server Authentication (With username and password for the SQL Server instance. Requires a 
--	        separate username and password created in SQL Server. Independent of Windows credentials.)
--
--  6. Basically, Any database consists of two files : 
--         1. MDF : Meta Data File (contains Meta Data of the database , Data of Database), can be more than
--                  one file 
--         2. LDF : LOG Data File (contains the Transactions performed on the database, insert, update, 
--                  delete , .. ), LDF is ONLY ONE FILE


----------------------------------------------------------------------------------------------------------
--------------------Starting SQL Code---------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------

-- Notes : 
--    1. SQL => Structured Query Language
--
--    2. Make a New Query File using the (new query button) , this file is only for writing queries and 
--       notes , it's not saved in the database (don't miss saving the file on the device and continious
--       saving for the queries written after any change !! 
--    
--    3. Make sure that you are working with the right Connection String (right database, right User, 
--       right Server and Service).
-- 
-- 	  4. SQL is not case sensitive (in code or Data)
-- 
--    5. When writing the query then executing it : the query is sent to the service and then the service 
--       executes this query on the database. We must first use the database that we want to query by : 
--          - selecting the database from the drop down list 
--            OR
--          - command : use DATABASE_NAME , ex: use ITI



------------------------------------------------------------------------------------------------------------
----------------------- Comments ---------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------

-- Single Line Comment 
/*

Multiple 
Line 
Comment

*/

-- Keyboard Shortcuts for comments   -> ctrl+k , ctrl+c    
-- Keyboard Shortcuts for Un comment -> ctrl+k , ctrl+u  



-- ===========================================================================================================
-- ===========================================================================================================
-- ===========================================================================================================

-- 'Go' Keyword :

-- 1. The GO keyword is a batch separator in SQL Server (T-SQL). It’s not an SQL command (cannot be used  
--    inside stored procedures, triggers, or functions), but an instruction for SQL Server Management Studio 
--    (SSMS) or SQLCMD to execute batches separately.
-- 2. We can define that this is the last line of the batch by 'Go' , to avoid showing errors in the code 
--    we are writing


-- ===========================================================================================================
-- ===========================================================================================================
-- ===========================================================================================================


-- Backup and Restore Database : 


-- Backup : backup the database and can be shared between the team ..
-- Right click on the database -> Tasks -> Backup -> Full backup -> Choose destination 
--                                                   Note: don't miss adding the file extension .bak

-- Restore : Take the shared backup and restore it on the device 
-- Right click on Databases -> Restore Database -> Device -> choose backup file location


backup database ITIDB_Test
to disk='d:\itiDb.bak'

restore database ITIDB_Test
from disk='d:\itiDb.bak'

-- To take a copy of the database and restore it : 
--   Option 1 : Stop the Service of SQL Server from windows services, then copy mdf and ldf files and paste 
--	            them in the other device, then start the service again. 
--   Option 2 : Backup the database , then restore it on the other computer.
-- 	            Backup  : right click on the database => Tasks => Back up
-- 			    Restore : right click on the database => Tasks => Restore (Or Databases => Restore Database)




---------------------------------------------------------------------------------------------------------
-----------------------Variables-------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------

-- Note : Print gets it as a value , select gets it as a Table (row & col)


-------------Local Variables (user-defined)----------------
-----------------------------------------------------------

declare @name varchar(10) = 'Mahmoud'
select @name         -- or print @name

declare @name varchar(10) = 'Mahmoud'
set @name = 'Shoura'
print @name          -- or select @name

declare @name varchar(10) = 'Mahmoud'
set @name = 'Mahmoud Shoura'    -- More than 10 characters!
print @name     --> Mahmoud Sh

declare @name varchar(10) = 'Mahmoud'
set @name = 10
print @name     --> 10

declare @name varchar(10) = 'Mahmoud'
set @name = 10
print @name+1     --> 11

---------------Global Variables (built-in)------------------
------------------------------------------------------------

print or select @@VERSION , @@LANGUAGE , @@SERVERNAME , ........
-- Note : We cannot make global variables , we have many of them 
-- @@ is used when using Global variables in SQL 

select @@VERSION
-- displays the current version of microsoft sql server that is installed 
select @@SERVERNAME
-- displays the name of the computer that I'm using 


-----------------------------------------------------------
---------------------- Data types -------------------------
-----------------------------------------------------------

-- Note : 1 Byte = 8 Bits

--------------------Numeric Datatypes----------------------

bit              -- size = 1 bit , boolean Value 0 --> False , 1--> True
tinyint          -- size = 1 byte  -> -128   -> 127   or 0 -> 255 (if unsigned)
smallint         -- size = 2 bytes -> -32768 -> 32767 or 0 -> 65555 (if unsigned)
int				 -- size = 4 bytes 
bigint			 -- size = 8 bytes


---------------- Fractions/Floating Datatypes ----------------

smallmoney       -- 4 bytes & 4 numbers after point 
money            -- 8 bytes & 4 numbers after point 
real             -- 4 bytes & 8 digit only and round up
float            -- 8 bytes & up to 32 digit 
decimal(p,s)     -- 5 to 17 bytes , Datatype and also makes validation at the same time (Recommended)
-- p -> precision , The maximum total number of digits to be stored on both the left and the right sides
--      of the decimal point. The precision must be a value from 1 through the maximum precision of 38. 
--      The default precision is 18

-- s -> scale , The number of decimal digits that are stored to the right of the decimal point. This number 
--      is subtracted from p to determine the maximum number of digits to the left of the decimal point. Scale 
--      must be a value from 0 through p, and can only be specified if precision is specified. The default 
--      scale is 0 and can be omitted and not written, and so 0 <= s <= p

-- decimal(5,4)    => Valid , p=5, s=4
-- decimal(4,5)    => NOT VALID , s must be <=p
-- decimal(4)      => Valid , p=4 , s=0
-- decimal         => Valid , p=18 , s=0

decimal(5,2)     -- All digits are 5 , and 2 of them are after the point 
				 -- ex: 123.45   --> Valid
				 -- ex: 181.125  --> Valid (will be 181.13) 
				 -- ex: 2345.43  --> Not Valid ! 

-- Notes : 
--   1. decimal is Prefered over FLOAT when you need correct decimal values (no rounding errors).
--   2. Numeric(7,4) is the same as decimal(7,4)


-- The storage of the DECIMAL (and NUMERIC) datatype in SQL Server depends only on the precision (p)
--    if p is from 1 - 9	then storage bytes = 5
--    if p is from 10-19	then storage bytes = 9
--    if p is from 20-28	then storage bytes = 13
--    if p is from 29-38	then storage bytes = 17


declare @n decimal(5,2) = 192.1
print @n --> 192.10

declare @m decimal(5,5) = 0.2
print @m --> 0.20000

declare @m decimal(5,2) = 12.345
print @m --> 12.35  -- Note : rounded 

declare @m decimal(5,2) = 1992.1
print @m --> error Arithmetic overflow error converting numeric to data type numeric.


--------------------String Datatypes-------------------------

char             -- By default the size is 1 only for one character
char(10)         -- Fixed length , Ahmed --> 5 , but will 10 will be occupied from memory
varchar(10)      -- variable lengh , Ahmed --> 5 so 5 ONLY will be occupied from memory (not 10)
nchar(10)        -- Fixed length like char() but with unicode to use symbols other than English
nvarchar(10)     -- variable lengh like varchar() but with unicode to use symbols other than English
varchar(max)     -- up to 2GB
nvarchar(max)    -- up to 2GB

-- Note : Old and not used now and will be removed in a future version of SQL Server
text()
ntext()


--------------------Date Time Datatypes-----------------------

date             -- MM/DD/YYYY or DD/MM/YYYY  (the operating system , and can be printed as we want later)
time             -- hh:mm:ss.123 --> default is 3 ( time(3) )
time(5)          -- hh:mm:ss.12345
smalldatetime    -- MM/DD/YYYY hh:mm:00     -> No seconds stored
datetime         -- MM/DD/YYYY hh:mm:ss.123 -> Default is 3
datetime2(5)     -- MM/DD/YYYY hh:mm:ss.12345
datetimeoffset   -- ex: 05/23/2023 10:30 +2:00 Timezone


--------------------Binary Datatypes--------------------------

-- Note : Used when storing the date is bits 

binary(2)           -- Fixed length binary string (2 bytes) 
varbinary(2)        -- variable length binary string
varbinary(max)      -- variable length binary string up to 2 GB
image               -- the image is converted to binary and stored in the database (Bad and not recomended)


---------------------Other Datatypes---------------------------

XML              
sql_variant      -- like var in Javascript ( store any datatype )
