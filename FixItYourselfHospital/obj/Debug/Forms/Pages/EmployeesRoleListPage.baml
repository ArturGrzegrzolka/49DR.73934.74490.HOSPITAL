   M S B A M L   `   `   `  ����P  LFixItYourselfHospital, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FixItYourselfHospital.FormsFixItYourselfHospital.Forms  5      7    1FixItYourselfHospital.Forms.EmployeesRoleListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:FixItYourselfHospital.Forms     5        N� Title$  Employees List��5	      .��5      � .+�5   
   �� -   5        $��	txtFilter��5   =   $	��Top=�6   $��127,10,378,0q�6'   $��23��6r   $	��Top=�6~   �� 5   
   $��Second Name filter��6   $
��Left=�6-   $��10,7,0,0q�6H   $	��Top=�6Z   �� 5   
   -   5         ��Name$ listView_Employees��5       �� AlternationCount$
 1000��6/   $��0,43,0,0q�6G    �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$	 130��63    �� DisplayMemberBinding 6?   �� *
UserName+�� 5      $��Second Name��6%   $	 150��6:    6F   �� *UserSecondName+�� 5      $
��Role��6%   $	 150��63    6?   �� *UserRoleModel.RoleDescription+�� 5      $��Specialization��6%   $	 130��6=    6I   �� *31UserSpecializationModel.SpecializationDescription+�� 5      $��Details��6%   $ 48��66    �� CellTemplate 5      �� 5      .R�5   "   ��  ��Name$ button_Details��6)   -   5        $��30��5   A   $��30��6L   $��?��6X   
 � Tag 6�   �� *!(ItemsControl.AlternationIndex)+	 �� RelativeSource	 �� 
 �� AncestorType$
 ListViewItemL���5   &   �� 5   *    �� 
TargetType" ��6:   .R�5   .   � .+�5   2   A� ��5   6   
� 5   :   .��5    >   �  � Offset$ 0Q�6K    � Color$ 	#FFC0C000��6V    �� 	Transform 5!   >   V� 5"   B   .~�5#   F   ��  �� ScaleY$
 0.65Q�6U   5$   C   5&   ;   5(   3   �� 5)   2   $��Center=�6C   $��Center=�5*   5   5+   /   5,   +   5.   #   5/      51      52      54      55      56      