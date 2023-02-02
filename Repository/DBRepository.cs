using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementSystem.Repository
{
    internal class DBRepository
    {

        private String connectionString;

        public DBRepository() {
            connectionString = "Data source=HOST-MACHINE;Initial Catalog=MedicalMS;User ID=lorenzo;Password=password";
        }

        protected SqlConnection GetConnection() {
            return new SqlConnection(connectionString);
        }

    }
}
