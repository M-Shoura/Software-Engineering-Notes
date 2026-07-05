using BLL.Entities;
using BLL.EntityLists;
using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class frmDetaiedView : Form
    {
        public frmDetaiedView()
        {
            InitializeComponent();
        }
        BindingNavigator bindingNavigator;
        BindingSource bindingSource;
        private void frmDetaiedView_Load(object sender, EventArgs e)
        {
            EmployeeList employees = EmployeeManager.spGetEmps();
            bindingSource = new(employees, "");
            bindingNavigator = new(bindingSource);

            bindingSource.AddingNew += (sender, e) => e.NewObject = new Employee()
            {
                emp_id = Guid.NewGuid().ToString().Substring(0, 9),
                fname = "",
                lname = "",
                hire_date = DateTime.Today,
                job_id = 10,
                pub_id = "abc",
                entityState = EntityState.Added
            };

            bindingNavigator.Dock = DockStyle.Top;
            this.Controls.Add(bindingNavigator);

            lblEmpId.DataBindings.Add("Text", bindingSource, "emp_id");
            txtEmpName.DataBindings.Add("Text", bindingSource, "fname");
            lblStatus.DataBindings.Add("Text", bindingSource, "entityState");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
