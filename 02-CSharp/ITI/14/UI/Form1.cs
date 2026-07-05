using BLL.EntityLists;
using BLL.EntityManager;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EmployeeList employees;
        BindingSource bindingSource;
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employees = EmployeeManager.spGetEmps();
            bindingSource = new(employees, "");
            gridView.DataSource = bindingSource;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
