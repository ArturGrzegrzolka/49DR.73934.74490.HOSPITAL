   M S B A M L   `   `   `  ���� P  LFixItYourselfHospital, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FixItYourselfHospital.FormsFixItYourselfHospital.Forms  4    .FixItYourselfHospital.Forms.EmployeeShiftsPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:FixItYourselfHospital.Forms       N� Title$  EmployeeShiftsPage��.��� .+��� $��20,35,434,0q�$	��267��$	��Top=�.+�&   System.Windows.Controls.Calendar  -     Name$ calendar_Shifts��   DisplayDateStart$  X��� $��33��$	��Top=�$��
10,0,-10,0q�.��Selected date:�� -    ��Name$ textBox_selectedData�� �� 
IsReadOnly . $	��170��$��26��$	��Top=����� *SelectedDate+ �� ElementName$ calendar_Shifts�� �� StringFormat$ d�� �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ button_Find��$
��Find��$��20��$��60��$��10q�$	��Top=��� ���	#FFCDCDCD$
��Left=�$	��564��$	��Top=�$	��648��	 K� ZIndex$	 -1���� -   
 ��Name$
 listView_Employees�� �� AlternationCount$
 1000��$��219,10,10,22q� �� View �� .P��� $
��Name�� �� Width$ 70�� �� DisplayMemberBinding �� *
UserName+�� $��Second Name��$ 80�� �� *UserSecondName+�� $
��Role��$ 80�� �� *UserRoleModel.RoleDescription+�� $��Specialization��$	 120�� �� *31UserSpecializationModel.SpecializationDescription+�� $��Details��$ 48�� �� CellTemplate �� .R��� $ button_Details��-   $��30��$��30��$��?��
 � Tag �� *!(ItemsControl.AlternationIndex)+ �� RelativeSource ��  �� AncestorType$ ListViewItemL�����  �� 
TargetType" ��.R�� .+�A� ��
� .���  � Offset$ 0Q� � Color$ 	#FFC0C000�� �� 	Transform V� .~���  �� ScaleY$
 0.65Q��� $��Center=�$��Center=��� -    ��Name$ 
image_Logo��$-��'/Resources/Images/FYI_Hospital_Logo.png��$��-145,383,278,0q�$	 -1��$	��181��$	��Top=�