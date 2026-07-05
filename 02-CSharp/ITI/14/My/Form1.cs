using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace My
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter sqlDataAdapter;
        DataTable dt = new();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["pubs"].ConnectionString);

            // Main adapter
            sqlDataAdapter = new SqlDataAdapter("SELECT * FROM titles", sqlConnection);

            SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);

            sqlDataAdapter.UpdateCommand = builder.GetUpdateCommand();
            sqlDataAdapter.InsertCommand = builder.GetInsertCommand();
            sqlDataAdapter.DeleteCommand = builder.GetDeleteCommand();
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Clear();

            // Load titles
            sqlDataAdapter.Fill(dt);
            gridView.DataSource = dt;

            // Load publishers for dropdown
            SqlDataAdapter pubAdapter =
                new SqlDataAdapter("SELECT pub_id, pub_name FROM publishers", sqlConnection);

            DataTable pubTable = new DataTable();
            pubAdapter.Fill(pubTable);

            // Create ComboBox column
            DataGridViewComboBoxColumn pubColumn = new DataGridViewComboBoxColumn();

            pubColumn.DataSource = pubTable;
            pubColumn.DisplayMember = "pub_name";
            pubColumn.DataPropertyName = "pub_id";     // column in titles table , bind to this
            pubColumn.ValueMember = "pub_id";
            pubColumn.HeaderText = "Publisher";


            // add the column as the last column in the list
            // gridView.Columns.Add(pubColumn);

            // OR Replace the original pub_id column
            int colIndex = gridView.Columns["pub_id"].Index;
            gridView.Columns.Remove("pub_id");
            gridView.Columns.Insert(colIndex, pubColumn);

            gridView.Columns["title_id"].ReadOnly = true;

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dt.Rows)
            {
                Trace.WriteLine(row.RowState);
            }

            sqlDataAdapter.Update(dt);

            MessageBox.Show("Changes saved successfully.");
        }

    }
}
