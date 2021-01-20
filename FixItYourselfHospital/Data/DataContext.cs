using Dapper;
using FixItYourselfHospital.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FixItYourselfHospital.Data
{
    // main class responsible for actions connected with database
    public class DataContext
    {
        public string connectionString { get; set; }
        private IDbConnection Connection { get; set; }

        public DataContext()
        {
            connectionString = StaticData.ReadSetting("connectionString");
            Connection = new SqlConnection(connectionString);
        }

        #region Stored Procedures

        public List<PersonnelModel> GetPersonnel()
        {
            Connection.Open();
            var result = Connection.Query<PersonnelModel>("fiy_get_staff_information", commandType: CommandType.StoredProcedure).ToList();
            Connection.Close();

            return result;
        }

        public bool CheckLoginCredentials(string login, string password)
        {
            var param = new DynamicParameters();
            param.Add("@p_UserLogin", login);
            param.Add("@p_UserPassword", password);

            Connection.Open();
            var result = Connection.QueryFirstOrDefault<bool>("fiy_check_credentials", param, commandType: CommandType.StoredProcedure);
            Connection.Close();

            return result;
        }

        #endregion
    }
}
