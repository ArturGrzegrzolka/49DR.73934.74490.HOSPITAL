using FixItYourselfHospital.Data;
using FixItYourselfHospital.Models;
using System.Windows.Controls;
using System.Linq;
using System.Windows;

namespace FixItYourselfHospital.Forms
{
    /// <summary>
    /// Interaction logic for EmployeesListPage.xaml
    /// </summary>
    public partial class EmployeesRoleListPage : Page
    {
        private RoleModel _selectedRole { get; set; }
        public EmployeesRoleListPage(RoleModel selectedRole)
        {
            _selectedRole = selectedRole;

            this.Title = $"Employees list ({selectedRole.RoleDescription})";

            InitializeComponent();
            FillInEmployeesList();
        }

        #region Events

        private void button_Details_Click(object sender, RoutedEventArgs e)
        {
            // getting index value from button's tag is the only solution in here because you can click it even without making a selection
            // and without making a selection we couldn't get index to connect row with personnel model
            var buttonOfInterest = sender as Button;
            var indexOfInterest = (int)buttonOfInterest.Tag;
            var personnelModelOfInterest = listView_Employees.Items[indexOfInterest];

            var details = new PersonnelDetails((PersonnelModel)personnelModelOfInterest);
            details.ShowDialog();
        }

        #endregion

        // fill in employees list according to selected role in MainHub
        private void FillInEmployeesList()
        {
            foreach (var employee in StaticData.personnelModelList.Where(employee => employee.UserRole == _selectedRole.RoleId))
            {
                listView_Employees.Items.Add(employee);
            }
        }
    }
}
