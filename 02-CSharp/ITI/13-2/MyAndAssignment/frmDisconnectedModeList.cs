using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyAndAssignment
{
    public partial class frmDisconnectedModeList : Form
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        DataTable dt = new();
        SqlDataAdapter sqlDataAdapter;
        BindingSource bindingSource;
        BindingNavigator bindingNavigator;
        public frmDisconnectedModeList()
        {
            InitializeComponent();
        }

        private void frmDisconnectedModeList_Load(object sender, EventArgs e)
        {
            sqlConnection = new();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pubs"].ConnectionString;
            sqlCommand = new("select * from employee", sqlConnection);

            sqlDataAdapter = new(sqlCommand);

            SqlCommandBuilder sqlCommandBuilder = new(sqlDataAdapter);
            sqlDataAdapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
            sqlDataAdapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
            sqlDataAdapter.DeleteCommand = sqlCommandBuilder.GetDeleteCommand();

            sqlDataAdapter.Fill(dt);

            lstEmpNames.DataSource = dt;      // will not work as we expect , will show the tostring of the object employee , because
                                              //                                // it took the whole row of data not specific info

            // so we must specify what will be shown in the list 
            lstEmpNames.DisplayMember = "fname";
            lstEmpNames.ValueMember = "emp_id";


            // improved down using the binding source instead of the datatable directly : 
            // lblEmpId.DataBindings.Add("Text", dt, "emp_id");                // the label supports "Complex Data Binding" 
            // // Text : property of the "lblEmpId" label 
            // // dt   : data source 
            // // emp_id : the specific value we will take
            // // same with others ..... 
            // 
            // txtEmpName.DataBindings.Add("Text", dt, "lname");
            // numericUpDownJobId.DataBindings.Add("value", dt, "job_id");

            bindingSource = new(dt, "");  // incase we don't have a list on the side , so how to change the employees shown ? 
            // we bind directly to the binding source so we can make buttons for next and previous and this is available with binding source


            // improved version : 
            lblEmpId.DataBindings.Add("Text", bindingSource, "emp_id");                // the label supports "Complex Data Binding" 
            txtEmpName.DataBindings.Add("Text", bindingSource, "lname");
            numericUpDownJobId.DataBindings.Add("value", bindingSource, "job_id");


            // instead of making the next and prev buttons , we have a control called "Binding Navigator" , which cannot be found in the 
            // controls in the UI so we must make it manually as here : 

            bindingNavigator = new BindingNavigator(bindingSource);
            this.Controls.Add(bindingNavigator);
            bindingNavigator.Dock = DockStyle.Top;
        }

        private void lstEmpNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            // when changing the selected name : 
            this.Text = lstEmpNames.SelectedValue.ToString();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bindingSource.MoveNext();
        }
    }
}
