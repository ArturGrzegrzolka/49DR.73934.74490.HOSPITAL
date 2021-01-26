using FixItYourselfHospital.Data;
using FixItYourselfHospital.Forms;
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
        private DataContext dataContext;

        public LoginWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();

            dataContext = new DataContext();
            StaticData.dataContext = dataContext;
            textBox_Login.Focus();
        }

        #region Events

        private void label_ForgotPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            textBlock_Label_ForgotPassword.TextDecorations = TextDecorations.Underline;
        }

        private void label_ForgotPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            textBlock_Label_ForgotPassword.TextDecorations = null;
        }

        private void button_Login_Click(object sender, RoutedEventArgs e)
        {


            if(dataContext.CheckInternetConnection())
            {
                try
                {
                    var login = textBox_Login.Text;
                    var password = textBox_Password.Password;

                    if (string.IsNullOrEmpty(login.Trim()))
                        throw new ArgumentNullException();

                    if (string.IsNullOrEmpty(password.Trim()))
                        throw new ArgumentNullException();

                    // check if user's credentials are in the database
                    if (!StaticData.dataContext.CheckLoginCredentials(login, password))
                        throw new MissingMemberException();
                    else
                    {
                        // set currently logged user info for further actions
                        StaticData.currentlyLoggedIn = dataContext.CurrentlyLoggedInUserInfo(login, password);
                        var mainHub = new MainHub();
                        mainHub.Show();
                        this.Close();
                    }
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
            else
            {
                MessageBox.Show("Cannot connect to the database. Check your internet connection.", "No connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void textBlock_Label_ForgotPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Well.. too bad. This feature is still work in progress.", "What a pity", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        #endregion
    }
}
