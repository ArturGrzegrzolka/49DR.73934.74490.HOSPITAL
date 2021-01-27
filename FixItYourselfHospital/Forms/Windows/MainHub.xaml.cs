using FixItYourselfHospital.Data;
using FixItYourselfHospital.Extensions;
using FixItYourselfHospital.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FixItYourselfHospital.Forms
{
    /// <summary>
    /// Interaction logic for MainHub.xaml
    /// </summary>
    public partial class MainHub : Window
    {
        private PersonnelModel loggedIn { get; set; }

        public MainHub()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            StaticData.LoadStaticData();
            loggedIn = StaticData.currentlyLoggedIn;

            InitializeComponent();
        }

        #region Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var adminRoleModel = StaticData.roleModelList.First(rm => rm.RoleId == 0);

            if (loggedIn.UserRole == adminRoleModel.RoleId)
            {
                menu_AdminPanel.Visibility = Visibility.Visible;
            }

            textBlock_LoggedAs.Text += $"{loggedIn.UserName} {loggedIn.UserSecondName} ({loggedIn.UserRoleModel.RoleDescription})";
        }

        private void OpenEmployeesList(object sender, RoutedEventArgs e)
        {
            var selection = sender as MenuItem;
            
            //get type of role/specialization to define type of displayed data on employeesListPage
            var selectedRole = StaticData.roleModelList.FirstOrDefault(rm => rm.RoleDescription == (string)selection.Tag);
            var selectedSpecialization = StaticData.specializationModelList.FirstOrDefault(rm => rm.SpecializationDescription == (string)selection.Tag);

            App.MainHubRef = this;

            if(selectedRole != null)
                this.frame_Parent.Navigate(new EmployeesRoleListPage(selectedRole));
            else
                this.frame_Parent.Navigate(new EmployeesSpecListPage(selectedSpecialization));
        }

        private void menu_AdminPanel_AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.frame_Parent.Navigate(new EmployeeAddPage());
        }

        private void menu_AdminPanel_DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.frame_Parent.Navigate(new EmployeesDeleteListPage());
        }

        private void menu_AdminPanel_EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.frame_Parent.Navigate(new EmployeesRoleListPage());
        }

        private void menu_Shifts_Click(object sender, RoutedEventArgs e)
        {
            this.frame_Parent.Navigate(new EmployeeShiftsPage());
        }

        #endregion
    }
}
