   M S B A M L   `   `   `  ���� P  LFixItYourselfHospital, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FixItYourselfHospital.FormsFixItYourselfHospital.Forms  7    1FixItYourselfHospital.Forms.EmployeesRoleListPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:FixItYourselfHospital.Forms       N� Title$  Employees List��.��� .+��� -   $��	txtFilter��$	��Top=�$��127,10,378,0q�$��23��$	��Top=��� $��Second Name filter��$
��Left=�$��10,7,0,0q�$	��Top=��� -    ��Name$ listView_Employees�� �� AlternationCount$
 1000��$��0,43,0,0q� �� View �� .P��� $
��Name�� �� Width$	 130�� �� DisplayMemberBinding �� *
UserName+�� $��Second Name��$	 150�� �� *UserSecondName+�� $
��Role��$	 150�� �� *UserRoleModel.RoleDescription+�� $��Specialization��$	 130�� �� *31UserSpecializationModel.SpecializationDescription+�� $��Details��$ 48�� �� CellTemplate �� .R���  ��Name$ button_Details��-   $��30��$��30��$��?��
 � Tag �� *!(ItemsControl.AlternationIndex)+	 �� RelativeSource	 �� 
 �� AncestorType$
 ListViewItemL�����  �� 
TargetType" ��.R�� .+�A� ��
� .���  � Offset$ 0Q� � Color$ 	#FFC0C000�� �� 	Transform V� .~���  �� ScaleY$
 0.65Q��� $��Center=�$��Center=�