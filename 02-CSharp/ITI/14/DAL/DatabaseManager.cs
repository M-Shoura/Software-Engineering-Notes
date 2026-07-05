using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class DatabaseManager
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public DatabaseManager()
        {
            try
            {
                sqlConnection = new();
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pubs"].ConnectionString;
                sqlCommand = new();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter = new(sqlCommand) ;
                dataTable = new();
            }
            catch
            {

            }
        }
        public int ExecuteNonQuery(string SPName , Dictionary<string , object> parameters)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = SPName;
                if(parameters!=null)
                {
                    foreach(var param in parameters)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter(param.Key, param.Value));
                    }
                }
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                return sqlCommand.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return -1;
        }
        public object ExecuteScalar(string SPName, Dictionary<string, object> parameters)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = SPName;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter(param.Key, param.Value));
                    }
                }
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                return sqlCommand.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return new();
        }
        public DataTable ExecuteDataTable(string SPName, Dictionary<string, object> parameters)
        {
            try
            {
                dataTable.Clear();
                sqlCommand.Parameters.Clear();
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter(param.Key, param.Value));
                    }
                }
                sqlCommand.CommandText = SPName;
                sqlDataAdapter.Fill(dataTable);
            }
            catch
            {

            }
            return dataTable;
        }
        public object ExecuteScalar(string SPName)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = SPName;
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                return sqlCommand.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return new();
        }
        public DataTable ExecuteDataTable(string SPName)
        {
            try
            {
                dataTable.Clear();
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = SPName;
                sqlDataAdapter.Fill(dataTable);
            }
            catch
            {

            }
            return dataTable;
        }
        public int ExecuteNonQuery(string SPName)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = SPName;
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                return sqlCommand.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return -1;
        }
    }
}
