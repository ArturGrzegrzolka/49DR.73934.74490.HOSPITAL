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
using System.Windows.Shapes;

namespace FixItYourselfHospital.Forms
{
    /// <summary>
    /// Interaction logic for PersonnelDetails.xaml
    /// </summary>
    public partial class PersonnelDetails : Window
    {
        private PersonnelModel _personnel { get; set; }
        public PersonnelDetails(PersonnelModel personnel)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _personnel = personnel;

            InitializeComponent();
            FillInEmployeeData();
        }

        private void FillInEmployeeData()
        {
            label_Id.Content = _personnel.UserId;
            label_Name.Content = _personnel.UserName;
            label_SecondName.Content = _personnel.UserSecondName;
            label_Role.Content = _personnel.UserRoleModel.RoleDescription;
            label_Spec.Content = _personnel.UserSpecializationModel.SpecializationDescription;
            label_Pwz.Content = _personnel.UserPwz;
            label_Email.Content = _personnel.UserEmail;
        }
    }
}
