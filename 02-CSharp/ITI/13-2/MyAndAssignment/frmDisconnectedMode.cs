using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyAndAssignment
{
    public partial class frmDisconnectedMode : Form
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        DataTable dt = new();
        SqlDataAdapter sqlDataAdapter;
        public frmDisconnectedMode()
        {
            InitializeComponent();
        }

        private void frmDisconnectedMode_Load(object sender, EventArgs e)
        {
            sqlConnection = new();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pubs"].ConnectionString;
            sqlCommand = new("select * from employee", sqlConnection);
            // sqlCommand.Connection = sqlConnection;              // written in the ctor of the object above .. 
            // sqlCommand.CommandText = "select * from employee"   // written in the ctor of the object above .. 
            
            // to put the data comming from the SQL Command in the data table , we must wrape the command in a "SqlDataAdaptor" first
            sqlDataAdapter = new(sqlCommand);

            // now to be able to insert , update , delete .. this is generation of commands instead of making them manually
            SqlCommandBuilder sqlCommandBuilder = new(sqlDataAdapter);
            sqlDataAdapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
            sqlDataAdapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
            sqlDataAdapter.DeleteCommand = sqlCommandBuilder.GetDeleteCommand();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlDataAdapter.Fill(dt);   // open SQL connection , execute select command , fill data table with data , close connection
            gridViewEmps.DataSource = dt;       // simple data binding

            // now it's not important to open and close the connection , and the data is binded automatically 
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // to debug in the output window : (next session discuss how ADO knows that this row is changed and this is deleted and .... )
            foreach(DataRow row in dt.Rows)
            {
                Trace.WriteLine(row.RowState);  // modified , unchanged , added , ... to keep track what changed in the data 
            }

            // any changes in the data is done in the data table , how to update the data that is in the database it self now ? 
            sqlDataAdapter.Update(dt);  // update for =>  insert , update , delete .. for commiting changes to the database from data table

        }
    }
}
