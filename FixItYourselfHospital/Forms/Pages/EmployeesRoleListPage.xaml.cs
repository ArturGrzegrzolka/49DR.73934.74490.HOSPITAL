using FixItYourselfHospital.Data;
using FixItYourselfHospital.Models;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System;

namespace FixItYourselfHospital.Forms
{
    /// <summary>
    /// Interaction logic for EmployeesListPage.xaml
    /// </summary>
    public partial class EmployeesRoleListPage : Page
    {
        private RoleModel _selectedRole { get; set; }
        public EmployeesRoleListPage(RoleModel selectedRole = null)
        {
            _selectedRole = selectedRole;

            InitializeComponent();
            FillInEmployeesList();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView_Employees.ItemsSource);
            view.Filter = UserFilter;
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

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView_Employees.ItemsSource).Refresh();
        }

        #endregion

        // fill in employees list according to selected role in MainHub
        private void FillInEmployeesList()
        {
            // by input role define if we need to display lit of specific roles or full list of employees
            if(_selectedRole != null)
            {
                listView_Employees.ItemsSource = StaticData.personnelModelList
                    .Where(p => p.UserRole == _selectedRole.RoleId);
            }
            else
            {
                listView_Employees.ItemsSource = StaticData.personnelModelList;
            }
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as PersonnelModel).UserSecondName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
