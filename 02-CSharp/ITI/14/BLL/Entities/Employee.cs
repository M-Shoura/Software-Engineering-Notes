using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Employee : EntityBase
    {
        // Properties == table attribiutes
        /*
         * [emp_id] [dbo].[empid] NOT NULL,
	     * [fname] [varchar](20) NOT NULL,
	     * [minit] [char](1) NULL,
	     * [lname] [varchar](30) NOT NULL,
	     * [job_id] [smallint] NOT NULL,
	     * [job_lvl] [tinyint] NULL,
	     * [pub_id] [char](4) NOT NULL,
	     * [hire_date] [datetime] NOT NULL,
         */
        public Employee()
        {
            entityState = EntityState.Added;
        }
        public required string emp_id { get; set; }
        public required string fname 
        { 
            get; 
            set
            {
                if(field != value)
                {
                    field = value;
                    if(entityState != EntityState.Added)
                        this.entityState = EntityState.Modified;
                }
            }
        }
        public string? minit { get; set; }
        public required string lname { get; set; }
        public required short job_id { get; set; }
        public short? job_lvl { get; set; }
        public required string pub_id { get; set; }
        public required DateTime hire_date { get; set; }
    }
}
