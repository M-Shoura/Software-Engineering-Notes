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
    public partial class frmUpdateJobLvl : Form
    {
        public frmUpdateJobLvl()
        {
            InitializeComponent();
        }
        BindingSource bindingSource;
        EmployeeList employees;
        private void frmUpdateJobLvl_Load(object sender, EventArgs e)
        {
            employees = EmployeeManager.spGetEmps();
            bindingSource = new(employees, "");
            lstEmps.DataSource = bindingSource;
            lstEmps.DisplayMember = "fname";
            lstEmps.ValueMember = "emp_id";

            // numericUpDownJobLvl.DataBindings.Add("Value", bindingSource, "job_lvl");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bindingSource.EndEdit();
            this.Text = EmployeeManager.spUpdateJobLvl(lstEmps.SelectedValue.ToString(), (int)numericUpDownJobLvl.Value).ToString();
        }

        private void lstEmps_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownJobLvl.Value = (lstEmps.SelectedItem as Employee).job_lvl.Value;
        }
    }
}
