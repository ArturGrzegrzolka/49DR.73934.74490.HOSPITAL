using FixItYourselfHospital.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;

namespace FixItYourselfHospital.Data
{
    // Literally bag for data with static access to everything from every corner of application
    public static class StaticData
    {
        public static string connectionString { get; set; }
        public static DataContext dataContext { get; set; }
        public static List<PersonnelModel> personnelModelList { get; set; }
        public static List<RoleModel> roleModelList { get; set; }
        public static List<SpecializationModel> specializationModelList { get; set; }
        public static PersonnelModel currentlyLoggedIn { get; set; }
        public static string NewEmployeeUsername { get; set; }
        public static string NewEmployeePassword { get; set; }

        public static void LoadStaticData()
        {
            connectionString = dataContext.connectionString;

            personnelModelList = dataContext.GetPersonnelList();
            roleModelList = dataContext.GetRoleList();
            specializationModelList = dataContext.GetSpecializationList();

            FillInPersonnelModel();
        }

        private static void FillInPersonnelModel()
        {
            if(personnelModelList != null)
            {
                foreach (var personnelModel in personnelModelList)
                {
                    personnelModel.UserRoleModel = roleModelList
                        .First(rm => rm.RoleId
                        .Equals(personnelModel.UserRole));

                    personnelModel.UserSpecializationModel = specializationModelList
                        .First(sm => sm.SpecializationId
                        .Equals(personnelModel.UserSpecialization));
                }
            }

            currentlyLoggedIn = personnelModelList.First(pm => pm.UserId.Equals(currentlyLoggedIn.UserId));
        }

        #region Utilities

        public static string ReadSetting(string key) //get any config value by key
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings[key] ??
                    throw new ArgumentNullException(nameof(key));
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Error reading app settings", "Error");
            }

            return value;
        }

        #endregion
    }
}
