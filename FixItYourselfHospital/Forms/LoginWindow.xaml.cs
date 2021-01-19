using FixItYourselfHospital.Data;
using System;
using System.Windows;
using System.Windows.Input;

namespace FixItYourselfHospital
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        #region Events

        private void button_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var login = textBox_Login.Text;
                var password = textBox_Password.Password;

                if (string.IsNullOrEmpty(login.Trim()))
                    throw new ArgumentNullException();

                if (string.IsNullOrEmpty(password.Trim()))
                    throw new ArgumentNullException();

                //to do - open main hub
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Credential fields cannot be empty", "Error");
            }
            catch (MissingMemberException)
            {
                MessageBox.Show("User does not exist", "Error");
            }
        }

        #endregion
    }
}
