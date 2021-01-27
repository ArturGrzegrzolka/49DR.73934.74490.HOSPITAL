using FixItYourselfHospital.Data;
using FixItYourselfHospital.Extensions;
using FixItYourselfHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FixItYourselfHospital.Forms
{
    /// <summary>
    /// Interaction logic for EmployeeAddPage.xaml
    /// </summary>
    public partial class EmployeeEditPage : Page
    {
        private string Admin { get { return "Administrator"; } }
        private string Nurse { get { return "Nurse"; } }
        private string SelectedRole { get; set; }
        private SpecializationModel SelectedSpec { get; set; }
        public PersonnelModel _employee { get; set; }

        public EmployeeEditPage(PersonnelModel employee)
        {
            _employee = employee;

            InitializeComponent();
            FillInRoleComboBox();
            FillInSpecComboBox();
            FillInData();
        }

        #region Events

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            var errorList = InputCheck();
            var errorStringBuilder = new StringBuilder();

            try
            {
                if (errorList != null && errorList.Count > 0)
                {
                    foreach (var error in errorList)
                    {
                        errorStringBuilder.AppendLine(error);
                    }

                    throw new Exception();
                }

                StaticData.NewEmployeePassword = textBox_Password.Text;
                StaticData.NewEmployeeUsername = textBox_Username.Text;

                StaticData.dataContext.UpdateEmployee(UpdatePersonnelModel());

                MessageBox.Show($"User {StaticData.NewEmployeeUsername} succesfully edited.", "Success");

                ClearData();

                this.NavigationService.Navigate(new EmployeesRoleListPage());
            }
            catch (Exception)
            {
                MessageBox.Show(errorStringBuilder.ToString(), "Validation error");
            }
        }

        private void button_GenerateUsername_Click(object sender, RoutedEventArgs e)
        {
            var name = textBox_Name.Text;
            var secondName = textBox_SecondName.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(secondName))
            {
                textBox_Username.Text = $"{char.ToUpper(name[0])}{secondName.Substring(0, 3).ToUpper()}";
                button_Add.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("To generate username you need to properly fill Name and Second Name fields.", "Input error");
            }
        }

        private void comboBox_Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRole = (string)comboBox_Role.SelectedItem;

            if (SelectedRole != null)
            {
                if (SelectedRole.Equals(Admin) || SelectedRole.Equals(Nurse))
                {
                    // temp add new role into spec combobox for auto-selecting purposes
                    comboBox_Specialization.Items.Add(SelectedRole);
                    comboBox_Specialization.SelectedItem = SelectedRole;
                    comboBox_Specialization.IsEnabled = false;

                    SelectedSpec = StaticData.specializationModelList.First(s => s.SpecializationDescription.Equals(SelectedRole));
                }
                else
                {
                    // delete previously added temp new role in spec combobox if there's any
                    if (comboBox_Specialization.Items.Contains(Admin))
                        comboBox_Specialization.Items.Remove(Admin);

                    if (comboBox_Specialization.Items.Contains(Nurse))
                        comboBox_Specialization.Items.Remove(Nurse);

                    comboBox_Specialization.SelectedIndex = 0;
                    comboBox_Specialization.IsEnabled = true;
                }
            }
        }

        #endregion

        private void FillInRoleComboBox()
        {
            foreach (var role in StaticData.roleModelList)
            {
                comboBox_Role.Items.Add(role.RoleDescription);
            }
        }

        private void FillInSpecComboBox()
        {
            foreach (var spec in StaticData.specializationModelList
                .Where(spec => !spec.SpecializationDescription.Equals(Admin) && !spec.SpecializationDescription.Equals(Nurse)))
            {
                comboBox_Specialization.Items.Add(spec.SpecializationDescription);
            }
        }

        private List<string> InputCheck()
        {
            var errorList = new List<string>();

            if (!textBox_Name.Text.IsValidName())
                errorList.Add("- Invalid name format.");

            if (!textBox_SecondName.Text.IsValidName())
                errorList.Add("- Invalid second name format.");

            if (!textBox_Email.Text.IsValidEmail())
                errorList.Add("- Invalid email format.");

            if (!textBox_Pwz.Text.IsValidPwzNumber())
                errorList.Add("- Invalid PWZ number format.");

            if (!textBox_Pesel.Text.IsValidPesel())
                errorList.Add("- Invalid pesel format.");

            if (!textBox_Password.Text.IsValidPassword())
                errorList.Add("- Invalid password format.");

            if (string.IsNullOrEmpty(textBox_Username.Text))
                errorList.Add("- Invalid username format. User GENERATE button!");

            return errorList;
        }

        private PersonnelModel UpdatePersonnelModel()
        {
            //to-do update personnelModelList with edited employee

            var selectedSpec = StaticData.specializationModelList
                .First(s => s.SpecializationDescription.Equals((string)comboBox_Specialization.SelectedItem));

            var selectedRole = StaticData.roleModelList
                .First(r => r.RoleDescription.Equals((string)comboBox_Role.Text));

            var editedEmployee = new PersonnelModel()
            {
                UserId = _employee.UserId,
                UserName = textBox_Name.Text,
                UserSecondName = textBox_SecondName.Text,
                UserRole = selectedRole.RoleId,
                UserSpecialization = selectedSpec.SpecializationId,
                UserEmail = textBox_Email.Text,
                UserPwz = textBox_Pwz.Text,
                UserPesel = textBox_Pesel.Text,
                UserLogin = StaticData.NewEmployeeUsername,
                UserPassword = StaticData.NewEmployeePassword,
                UserRoleModel = selectedRole,
                UserSpecializationModel = selectedSpec
            };

            var employeeToReplace = StaticData.personnelModelList.First(p => p.UserId == _employee.UserId);

            StaticData.personnelModelList.Remove(employeeToReplace);
            StaticData.personnelModelList.Add(editedEmployee);

            return editedEmployee;
        }

        private void ClearData()
        {
            StaticData.NewEmployeePassword = string.Empty;
            StaticData.NewEmployeeUsername = string.Empty;
        }

        private void FillInData()
        {
            textBox_Name.Text = _employee.UserName;
            textBox_SecondName.Text = _employee.UserSecondName;
            textBox_Email.Text = _employee.UserEmail;

            var role = _employee.UserRoleModel.RoleDescription;

            if (role.Equals(Admin) || role.Equals(Nurse))
                comboBox_Specialization.Items.Add(role);

            comboBox_Role.SelectedItem = role;
            comboBox_Specialization.SelectedItem = role;
            textBox_Pwz.Text = _employee.UserPwz;
            textBox_Pesel.Text = _employee.UserPesel;

            button_Add.IsEnabled = false;
        }
    }
}
