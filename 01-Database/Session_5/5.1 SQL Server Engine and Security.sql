-------------------------------------------------
-------------------------------------------------
------------ SQL Server Engine ------------------
-------------------------------------------------


-- SQL Server is a tool , specified in many areas , areas such as : Data Analysis , Adminstration , Development 
-- Courses and Certificates : 
--   1. Writing Queries using T-SQL (this course .. )
--   2. Implementing SQL Server DB  (second course : ADV SQL [views , stored procedures , triggers , .. ])
--   3. Maintain SQL Server DB and Adminstration (Recovery , Mirroring , Replication , .. )
--   4. SQL Server Business Intelligence 

-- SQL Server and Oracle => Fully Relational Database Management Systems (Fully RDBMS) , while 'Access' is RDBMS (not fully)


-- In the ERD , we have cardinality (1-1) , (1-M) and (M-M) , but physically inside the database we have only (1-M) , so 
-- we have a table that has the PK and other table that has FK (Parent and Child) ... A (M-M) relationship is actually 
-- double (1-M) relationships.


----------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------


-- SQL Server Version and SQL Server Edition 

-- 1. SQL Server Version : every couple of years we have a new version. Now we have many versions , partitioned into 
--    some generations =>
--      1.1 - 1st Generation : till 1998 , SQL server was compatable with Windows OS version (new version for new Windows)
--      1.2 - 2nd Generation : starting from 1999 , now we can have different SQL versions on different Windows versions 
--      1.3 - 3rd Generation : starting from 2005 , The major development done here in the tool , interface , security , .. 
--                             latest versions now improves the non-functional requiremnet more than the functional req
--                             ex: improves recovery , security ... But development wise we have minimal improvements
--
-- 2.SQL Server Editions : different features with different prices !
--      2.1 - Enterprise : large scale , business critical applications. 
--      2.2 - Standard Developer : small - medium , departmental applications
--      2.3 - BI Edition : BI services 
--      2.4 - Express : Entry level , learning edition 
--      2.5 - Azure : Cloud (No setup , no hardware , pay as you go) , requires fast internet connection , no data privacy 


-- When installing a setup , we install an "instance" , it contains : 
--   - Services that run in the background =>
--        - most known service : DB engine (SQL Server [MSSQLSERVER]) for developer editions ----- or SQL Server [SQLEXPRESS]
--        - other service : SSIS (SQL Server Integration Services) , SSAS (SQL Server Analysis Service) , SSRS (Reporting)
--        - other service : Data Quality Service 
--
--   - Application used by the developers =>
--        - most known application : SSMS (SQL Server Management Studio) for DB engine services
--        - other application : SQL Server Data Tools (For BI)
--        - other application : Data Quality Client (For Data Quality Services)


-- Types of instances : 
-- Note : 
--    - Each instance has it's databases , users , database objects , .... 
--    - knowing the instance is important , used to configure the connection string in our application (known later)
-- 
-- 1. Default instance : usually the first instance when we install the SQL Server
--                       [DB Engine SQL Server (MSSQLSERVER)]
--                       By default gets the name and IP of the device 
--                       connect on this service using (.) or (local) or (IP) or (PC-Name)
--						 CAN HAVE ONLY ONE DEFAULT INSTANCE
--
-- 2. Named instance   : usually when installing SQL Server for the second time (
--                       ex: [DB Engine (Cairo)]
--                       connect on this service using (.\Cairo) or (local\Cairo) or (IP\Cairo) or (PC-Name\Cairo)
--                       Special Case : SQL Server Express Edition is a named instance , by defualt it's name is SQLexpress
--                       CAN HAVE MULTIPLE NAMED INSTANCES, GIVEN A UNIQUE NAME FOR EACH INSTANCE (USED TO CONNECT)
--                       maybe we need another instance for security reasons or replication of data or educational purpose
--                       ex: having three SQL services on the same device simulates having 3 devices each with a 
--                           service , so we could experiment DB replication. 



-- How servers can talk to each other (on the same device or on other devices) ?
--  - For a database object (table , function , view , ...) we have a 'Full Path'
--    Full Path => ServerName.DatabaseName.SchemaName.ObjectName
--
--    ex: if I'm currently using the ITI Database , then i can write query like this : 
--        select * from Student
--        But the most appropriate way to write this query is : (we provided this info before in the login and using DB)
--        select * from [MyLaptopName].ITI.dbo.Student
--        Notes : 
--           1. dbo is the default schema (discussed later)
--           2. It's not a must to give the 3 parts , we can give only DBName.Schema.ObjName if we are using same server
--
--  - This means that while I'm using a server , I can query another server (YES) but if i have permissions ....


----------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------

-- Security : 

-- Authentication : 
--     - Login (Name and Password) 
--     - 1. Windows Authentication : usually windows users are SQL server admins
--          So the admin doesn't give the access of his windows user for other DB users (developers)
--          if they logged in to the service using admin username and password they can do things not authorized to them
--          on the databases or on the Windows OS itself !
--
--     - 2. SQL Server Authentication : 
--          Admin now creates usernames (logins) and passwords for DB users (developers) to start using databases

-- Authorization : 
--       Permissions that the user have (after login successfully)
--       ex: insert only , read only , read insert update delete , .... 



-- Authentication : 
--   - Notice when opening SSMS , when connecting we have "Authentication" => Windows Authentication + username + password
--   - That's when we setup the SQL Server , it by default takes the username and password for the current windows user , 
--     and because we currently are logged in with that user so we can connect to DB service using windows authentication
--     without entering username or password (we are already logged in !!)



-- How to create Login usernames and Passwords for DB ueres or developers ? 4 steps =>
-- 1 - Change Authentication Mode of the Server : 
--      - connect with windows auth => Right click on the Server => properties => Security Tab =>  
--        Server Authentication => check (SQL Server and Windows Authentication Mode)
--
-- 2 - Restart Service : 
--      - Right click on the Server => Restart  ... OR Restart the services in the background
--
-- 3 - Create New Login :
--      - Server => Security => Right Click on Logins => Give login username => SQL Server Authentication =>  
--        Password and Confirm Password => (better to uncheck " Enforce password policy ")
--      
-- 4 - Make the login as a Database User : 
--      - Inside wanted Database => Security => Right click on Users => New User => User Name = Login Name => OK 
--        ( Schema will be discussed later )

-- Now when we disconnect and try to connect , we can choose Authentication => "SQL Server Authentication" , then 
-- provide the Login name and Password , I will be connected to the server but when trying to use a database that I'm
-- not a user to it then I will have an error "The database 'Database Name' is not accessible" , the only database i can
-- use is the database I'm a user on. BUT there is still a problem , what can i do on the database and tables , that I'm
-- authorized for ? Till now we didn't add the authorization , it's only authentication to be a user for the server for a 
-- specific database , NEXT WILL BE AUTHORIZATION.



-- Authorization : After being a database user , to make the permissions :
-- Note : this will be discussed further more but later .. 
-- 1 - Login as an Admin with Windows Authentication 
-- 2 - Right Click on the table or any database object that we want to add a permission for a user on it.
--     Note : User must be a user for the database (previous 4 steps)
-- 3 - Properties 
-- 4 - Permissions 
-- 5 - If the user is not added , Add the user first
-- 6 - select a user , grant permission , deny permission , what about options not checked as deny or grant ??
--     Here is an importnant thing : if we go to => Server => Security => Logins => double click on the login we created
--                                   => Server Roles => (it's by default 'Public' server role) .. so the default is
--                                   that this user doesn't have any permissions (only one permission => connect to server)
--                                   that means that if the role of the user is 'public' then it's not important to 
--                                   speficy that a permission is Denied (because it's by default denied ! ) ... But if the 
--                                   role was other thing (ex: dbcreator , sysadmin) , then here we must specify what is
--                                   granted and what is denied .


-- Note : if we tried to do an action that is not authorized for us , we will have error (the permission is denied ... )

-- Very Important Note : Take care about the User of the New Query file , if we made a new query file with a user , and 
--                       then logged on another user , the first file is still logged on the first user. Make sure we
--                       are working with the right user and writing queries in the file that are authorized for that user



-- How many admins do we have in the Server ? 
-- 1 - The Windows user  : used by the admin when he is using the database on-site. 
-- 2 - sa (system admin) : it's here by default , used by the admin when connecting remotly. Cannot change it's name 
--                         but can change it's password. We can use this sa admin to login to the server , when connecting
--                         specify the login username = sa , and the password for the sa to login as you are now admin but
--                         remotly using the server.