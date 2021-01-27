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
    public partial class EmployeeAddPage : Page
    {
        private string Admin { get { return "Administrator"; } }
        private string Nurse { get { return "Nurse"; } }
        private string SelectedRole { get; set; }
        private SpecializationModel SelectedSpec { get; set; }

        public EmployeeAddPage()
        {
            InitializeComponent();
            FillInRoleComboBox();
            FillInSpecComboBox();
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

                StaticData.dataContext.CreateNewEmployee(GeneratePersonnelModel());

                MessageBox.Show($"User {StaticData.NewEmployeeUsername} succesfully added.", "Success");

                ClearData();
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

        private PersonnelModel GeneratePersonnelModel()
        {
            if (SelectedSpec == null)
                SelectedSpec = StaticData.specializationModelList.First(s => s.SpecializationDescription.Equals((string)comboBox_Specialization.SelectedItem));

            var userIds = new List<int>();

            var selectedRole = StaticData.roleModelList.First(r => r.RoleDescription.Equals((string)comboBox_Role.Text));
            StaticData.personnelModelList.ForEach(p => userIds.Add(p.UserId));
            userIds.Sort();
            var lastUserId = userIds.Last();

            var newEmployee = new PersonnelModel()
            {
                UserId = lastUserId + 1,
                UserName = textBox_Name.Text,
                UserSecondName = textBox_SecondName.Text,
                UserEmail = textBox_Email.Text,
                UserRole = selectedRole.RoleId,
                UserSpecialization = SelectedSpec.SpecializationId,
                UserPwz = textBox_Pwz.Text,
                UserPesel = textBox_Pesel.Text,
                UserLogin = StaticData.NewEmployeeUsername,
                UserPassword = StaticData.NewEmployeePassword,
                UserRoleModel = selectedRole,
                UserSpecializationModel = SelectedSpec
            };

            StaticData.personnelModelList.Add(newEmployee);

            return newEmployee;
        }

        private void ClearData()
        {
            textBox_Name.Text = string.Empty;
            textBox_SecondName.Text = string.Empty;
            textBox_Email.Text = string.Empty;
            comboBox_Role.SelectedIndex = -1;
            comboBox_Specialization.SelectedIndex = -1;
            textBox_Pwz.Text = string.Empty;
            textBox_Pesel.Text = string.Empty;
            textBox_Username.Text = string.Empty;
            textBox_Password.Text = string.Empty;

            button_Add.IsEnabled = false;

            StaticData.NewEmployeePassword = string.Empty;
            StaticData.NewEmployeeUsername = string.Empty;
        }
    }
}
