using FixItYourselfHospital.Data;
using FixItYourselfHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FixItYourselfHospital.Forms
{
    /// <summary>
    /// Interaction logic for EmployeeShiftsPage.xaml
    /// </summary>
    public partial class EmployeeShiftsPage : Page
    {
        public DataContext _dataContext { get; set; }

        public EmployeeShiftsPage()
        {
            _dataContext = StaticData.dataContext;

            InitializeComponent();
            calendar_Shifts.SelectedDate = DateTime.Now;

            // available days from the first day of the current month
            calendar_Shifts.DisplayDateStart = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
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

        private void button_Find_Click(object sender, RoutedEventArgs e)
        {
            var selectedDateTime = DateTime.Parse(textBox_selectedData.Text, System.Globalization.CultureInfo.InvariantCulture);
            var personnelShift = _dataContext.GetShiftsWithDate(selectedDateTime);

            if (personnelShift == null)
            {
                if (!_dataContext.CheckIfShiftExists(selectedDateTime.Month))
                {
                    if (MessageBox.Show($"No shifts scheduled for current month. Do you want to generate schedule?",
                        "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // to do - recalculate shifts
                    }
                }
                else
                {
                    MessageBox.Show("According to the system nobody works today! Contact support to schedule this day and update database.", "Warning");
                }
            }
            else
            {
                    // list is going to be relatively short, so let's use LINQ instead of AddRange to merge two lists
                    listView_Employees.ItemsSource = (personnelShift.DoctorIdsList
                    .Concat(personnelShift.NurseIdsList)
                    .ToList()
                    .Select(personnel => StaticData.personnelModelList
                    .First(p => p.UserId
                    .Equals(personnel))))
                    .ToList();
            }
        }
        #endregion
    }
}
