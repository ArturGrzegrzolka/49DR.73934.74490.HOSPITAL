using FixItYourselfHospital.Data;
using FixItYourselfHospital.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FixItYourselfHospital.Forms
{
    /// <summary>
    /// Interaction logic for EmployeesSpecListPage.xaml
    /// </summary>
    public partial class EmployeesSpecListPage : Page
    {
        private SpecializationModel _selectedSpec { get; set; }
        public EmployeesSpecListPage(SpecializationModel selectedSpec)
        {
            _selectedSpec = selectedSpec;

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
            listView_Employees.ItemsSource = StaticData.personnelModelList.Where(p => p.UserSpecialization == _selectedSpec.SpecializationId);
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
