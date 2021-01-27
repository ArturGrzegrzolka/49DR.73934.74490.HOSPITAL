using FixItYourselfHospital.Data;
using FixItYourselfHospital.Models;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
using System;
using System.Windows.Data;

namespace FixItYourselfHospital.Forms
{
    /// <summary>
    /// Interaction logic for EmployeesDeleteListPage.xaml
    /// </summary>
    public partial class EmployeesDeleteListPage : Page
    {
        public EmployeesDeleteListPage()
        {
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
            var personnelModelOfInterest = (PersonnelModel)listView_Employees.Items[indexOfInterest];

            // I know that I didn't even add currently logged in person to list of employees, but users manage to achieve every bug, soooo...
            if(personnelModelOfInterest != StaticData.currentlyLoggedIn)
            {
                if (MessageBox.Show($"Do you really want to delete {personnelModelOfInterest.UserName} {personnelModelOfInterest.UserSecondName}?",
                    "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    StaticData.dataContext.DeleteEmployee(personnelModelOfInterest.UserId);

                    // refresh the list after deletion
                    StaticData.personnelModelList.Remove(personnelModelOfInterest);
                    FillInEmployeesList();
                }
            }
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView_Employees.ItemsSource).Refresh();
        }

        #endregion

        // fill in employees list according to selected role in MainHub
        private void FillInEmployeesList()
        {
            listView_Employees.ItemsSource = StaticData.personnelModelList.Where(p => p != StaticData.currentlyLoggedIn);
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
