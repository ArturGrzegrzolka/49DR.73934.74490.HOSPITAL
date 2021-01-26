using Dapper;
using FixItYourselfHospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

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

        #region Utilities

        public bool CheckInternetConnection()
        {
            try
            {
                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        #endregion

        #region Stored Procedures

        public List<PersonnelModel> GetPersonnelList()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.Query<PersonnelModel>("fiy_get_staff_information", commandType: CommandType.StoredProcedure).ToList();
            Connection.Close();

            return result;
        }

        public List<RoleModel> GetRoleList()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.Query<RoleModel>("fiy_get_roles", commandType: CommandType.StoredProcedure).ToList();
            Connection.Close();

            return result;
        }

        public List<SpecializationModel> GetSpecializationList()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.Query<SpecializationModel>("fiy_get_specialization", commandType: CommandType.StoredProcedure).ToList();
            Connection.Close();

            return result;
        }

        public bool CheckLoginCredentials(string login, string password)
        {
            var param = new DynamicParameters();
            param.Add("@p_UserLogin", login);
            param.Add("@p_UserPassword", password);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.QueryFirstOrDefault<bool>("fiy_check_credentials", param, commandType: CommandType.StoredProcedure);
            Connection.Close();

            return result;
        }

        public bool CheckIfShiftExists(int month)
        {
            var param = new DynamicParameters();
            param.Add("@p_Month", month);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.QueryFirstOrDefault<bool>("fiy_check_month", param, commandType: CommandType.StoredProcedure);
            Connection.Close();

            return result;
        }

        public ShiftModel GetShiftsWithDate(DateTime date)
        {
            var param = new DynamicParameters();
            param.Add("@p_Date", date);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.QueryFirstOrDefault<ShiftModel>("fiy_get_shifts_for_date", param, commandType: CommandType.StoredProcedure);
            Connection.Close();

            return result;
        }

        public string GetRoleDescription(int roleId)
        {
            var param = new DynamicParameters();
            param.Add("@p_UserRoleId", roleId);


            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.QueryFirstOrDefault<string>("fiy_get_role_description", param, commandType: CommandType.StoredProcedure);
            Connection.Close();

            return result;
        }

        public string GetSpecializationDescription(int specId)
        {
            var param = new DynamicParameters();
            param.Add("@p_UserSpecializationId", specId);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.QueryFirstOrDefault<string>("fiy_get_specialization_description", param, commandType: CommandType.StoredProcedure);
            Connection.Close();

            return result;
        }

        public PersonnelModel CurrentlyLoggedInUserInfo(string login, string password)
        {
            var param = new DynamicParameters();
            param.Add("@p_UserLogin", login);
            param.Add("@p_UserPassword", password);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.Query<PersonnelModel>("fiy_get_logged_person_info", param, commandType: CommandType.StoredProcedure).First();
            Connection.Close();

            return result;
        }

        public void GenerateShifts(DataTable shifts)
        {
            var param = new DynamicParameters();
            var dp = new DynamicParameters(new { p_DataTable = shifts });
            param.AddDynamicParams(dp);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var result = Connection.Execute("fiy_insert_shift_for_month", param, commandType: CommandType.StoredProcedure);
            Connection.Close();
        }

        #endregion
    }
}
