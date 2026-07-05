using BLL.Entities;
using BLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL.EntityManager
{
    public static class EmployeeManager
    {
        static DatabaseManager databaseManager = new();
        public static EmployeeList spGetEmps()
        {
            try
            {
                return DataTableToList(databaseManager.ExecuteDataTable("spGetEmps"));
            }
            catch
            {

            }
            return new();
        }

        // Two functions for mapping : 
        public static EmployeeList DataTableToList(DataTable dt)
        {
            EmployeeList emps = new();
            try
            {
                foreach (DataRow item in dt.Rows)
                {
                    emps.Add(DataRowToEmployee(item));
                }
            }
            catch
            {

            }
            return emps;
        }
        public static Employee DataRowToEmployee(DataRow dr)
        {
            // mapping : 
            return new Employee
            {
                emp_id = dr.Field<string>("emp_id")!,
                fname = dr.Field<string>("fname")!,
                lname = dr.Field<string>("lname")!,
                job_id = dr.Field<short>("job_id"),
                pub_id = dr.Field<string>("pub_id")!,
                hire_date = dr.Field<DateTime>("hire_date"),
                minit = dr.Field<string>("minit"),
                job_lvl = dr.Field<byte?>("job_lvl"),
                entityState = EntityState.Unchanged
            };
        }

        public static bool spUpdateJobLvl(string empid, int lvl)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>() { ["@empid"] = empid, ["@lvl"] = lvl };
                return databaseManager.ExecuteNonQuery("spUpdateJobLvl", parameters) > 0;
            }
            catch
            {
                
            }
            return false;
        }
    }
}
