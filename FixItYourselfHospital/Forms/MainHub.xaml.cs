using FixItYourselfHospital.Data;
using FixItYourselfHospital.Extensions;
using FixItYourselfHospital.Models;
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

        #endregion
    }
}
