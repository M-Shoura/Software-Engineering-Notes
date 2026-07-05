using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MyAndAssignment
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // sqlConnection = new("Data source=.;Initial Catalog=pubs;Integrated Security=true;Encrypt=false;");
            sqlConnection = new();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pubs"].ConnectionString;
            this.Text = ConfigurationManager.AppSettings["BranchId"];
            
            sqlConnection.StateChange += (sender, e) => this.Text = $"State was {e.OriginalState} and now {e.CurrentState}";
            this.FormClosed += (sender, e) => sqlConnection?.Dispose();     // dispose unmanaged resources
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // to avoid exceptions of opening the connection multiple times (clicking the button more than one time)
            if(sqlConnection.State == ConnectionState.Closed)               // see this enum called "ConnectionState"
                sqlConnection?.Open();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            sqlConnection?.Close();
        }
    }
}
