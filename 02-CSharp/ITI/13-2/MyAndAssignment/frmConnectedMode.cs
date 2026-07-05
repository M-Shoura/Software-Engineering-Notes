using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MyAndAssignment
{
    public partial class frmConnectedMode : Form
    {
        public frmConnectedMode()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection;      // for the connection string 
        SqlCommand sqlCommand;            // for the command , for wraping the query in it.
        // Note : usually we use only one SqlCommand , NOT one for each query !!! 
        private void frmConnectedMode_Load(object sender, EventArgs e)
        {
            sqlConnection = new();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pubs"].ConnectionString;

            sqlCommand = new();
            // sqlCommand.CommandType = CommandType.Text;      // by default it's text , can be StoredProcedure if we want
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select * from employee";

            // how to execute the command ? based on the type of the command => 
            // - execute nonQuery  (insert , update , delete) , return int (num of rows affected)
            // - execute reader    (select) , returns a SqlDataReader (rows,cols) locks the data in the database and retrieve row by row
            // - execute Xmlreader (select) , returns the data as XML based , not rows and cols , (also readonly)
            // - execute scalar    (aggregate function , one value) , ex: sum , ...  returns a "System.Object" of first col and first row
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (sqlConnection?.State != ConnectionState.Open)
                sqlConnection.Open();                           // open the connection 

            var sqlDataReader = sqlCommand.ExecuteReader();

            lstEmpsNames.Items.Clear();

            // lstPrdNames.DataSource = sqlDataReader;           
            // - last line will build , but when clicking the button we will have an exception because this is the reader and it doesn't
            //   implement the IList (as we discussed) , so we are not able to "Bind"

            // so we must get the data row by row 
            while (sqlDataReader.Read())
            {
                // if here the connection closed , then the data will not be available , because the connection must be opened to get data
                lstEmpsNames.Items.Add(sqlDataReader["fname"]);
                // this is not binding , as we cannot see the changes in the data source and the UI will not capture this changes , and if 
                // we changed the data in the UI , will these changes be reflected to the data source ? NO
            }

            sqlConnection.Close();         // close the opened connection 
        }

        private void btnExecSP_Click(object sender, EventArgs e)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "spGetEmps";

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            var sqlDataReader = sqlCommand.ExecuteReader();

            lstEmpsNames.Items.Clear();
            while (sqlDataReader.Read())
            {
                lstEmpsNames.Items.Add(sqlDataReader["lname"]);
            }

            sqlConnection.Close();
        }

        private void btnScalar_Click(object sender, EventArgs e)
        {
            sqlCommand.CommandText = "select count(*) as cnt from employee";
            sqlCommand.CommandType = CommandType.Text;

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            var sqlDataReader = sqlCommand.ExecuteReader();

            lstEmpsNames.Items.Clear();
            while (sqlDataReader.Read())
            {
                lstEmpsNames.Items.Add(sqlDataReader["cnt"]);
            }

            // or directly : 
            // lstEmpsNames.Items.Add(sqlCommand.ExecuteScalar().ToString());

            sqlConnection.Close();
        }

        private void btnUpdateEmpLvl_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            sqlCommand.CommandText = """
                update employee set job_lvl = @jobLvl where emp_id = @EmpId
                """;
            sqlCommand.Parameters.Add("@jobLvl", SqlDbType.Int);          // between 25 and 100 
            sqlCommand.Parameters.Add("@EmpId", SqlDbType.Variant);       // ex: first emp id : PMA42628M

            sqlCommand.Parameters["@EmpId"].Value = txtEmpId.Text;
            sqlCommand.Parameters["@jobLvl"].Value = numericUpDownEmpLvl.Value;

            var numOfRows = sqlCommand.ExecuteNonQuery();
            this.Text = $"{numOfRows} rows affected";

            sqlConnection.Close();
        }
    }
}
