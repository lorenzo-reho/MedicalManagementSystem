using System;
using System.Data.SqlClient;

namespace MedicalManagementSystem.Repository
{
    internal class DBRepository
    {

        private String connectionString;

        public DBRepository()
        {
            connectionString = "Data source=HOST-MACHINE;Initial Catalog=MedicalMS;User ID=lorenzo;Password=password";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
