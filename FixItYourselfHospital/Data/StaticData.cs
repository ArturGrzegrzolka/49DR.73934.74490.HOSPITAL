using FixItYourselfHospital.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;

namespace FixItYourselfHospital.Data
{
    // Literally bag for data with static access to everything from every corner of application
    public static class StaticData
    {
        public static string connectionString { get; set; }
        public static List<PersonnelModel> personnelModelList { get; set; }

        public static void LoadStaticData()
        {
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
