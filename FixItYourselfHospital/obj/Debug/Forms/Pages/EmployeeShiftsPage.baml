   M S B A M L   `   `   `  ����P  LFixItYourselfHospital, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FixItYourselfHospital.FormsFixItYourselfHospital.Forms  5      4    .FixItYourselfHospital.Forms.EmployeeShiftsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:FixItYourselfHospital.Forms     5        N� Title$  EmployeeShiftsPage��5	      .��5      � .+�5   
   �� $��20,35,434,0q�6   $	��267��6*   $	��Top=�67   .+�5      &   System.Windows.Controls.Calendar  -   5          Name$ calendar_Shifts��5         DisplayDateStart$  X�60   �� 5      $��33��6   $	��Top=�6    $��
10,0,-10,0q�68   .��6L   Selected date:6\   �� 5      -   5         ��Name$ textBox_selectedData��5       �� 
IsReadOnly . $	��170��6F   $��26��6R   $	��Top=�6�   ��6^   �� *SelectedDate+ �� ElementName$ calendar_Shifts�� �� StringFormat$ d�� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5         ��Name$ button_Find��5      $
��Find��6*   $��20��69   $��60��6E   $��10q�6P   $	��Top=�6\   6t   5      �� 5   
   ���	#FFCDCDCD$
��Left=�6%   $	��564��6@   $	��Top=�6M   $	��648��6e   	 K� ZIndex$	 -1��6q   �� 5   
   -   5        
 ��Name$
 listView_Employees��5       �� AlternationCount$
 1000��6/   $��219,10,10,22q�6G    �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$ 70��63    �� DisplayMemberBinding 6>   �� *
UserName+�� 5      $��Second Name��6%   $ 80��6:    6E   �� *UserSecondName+�� 5      $
��Role��6%   $ 80��63    6>   �� *UserRoleModel.RoleDescription+�� 5      $��Specialization��6%   $	 120��6=    6I   �� *31UserSpecializationModel.SpecializationDescription+�� 5      $��Details��6%   $ 48��66    �� CellTemplate 5      �� 5      .R�5   "   �� $ button_Details��6)   -   5        $��30��5   A   $��30��6L   $��?��6X   
 � Tag 6�   �� *!(ItemsControl.AlternationIndex)+ �� RelativeSource ��  �� AncestorType$ ListViewItemL���5   &   �� 5    *    �� 
TargetType" ��6:   .R�5!   .   � .+�5"   2   A� ��5#   6   
� 5$   :   .��5%   >   �  � Offset$ 0Q�6K    � Color$ 	#FFC0C000��6V    �� 	Transform 5&   >   V� 5'   B   .~�5(   F   ��  �� ScaleY$
 0.65Q�6U   5)   C   5+   ;   5-   3   �� 5.   2   $��Center=�6C   $��Center=�5/   5   50   /   51   +   53   #   54      56      57      59      �� 5;   
   -   5         ��Name$ 
image_Logo��5;      $-��'/Resources/Images/FYI_Hospital_Logo.png��6$   $��-145,383,278,0q�6U   $	 -1��6m   $	��181��6   $	��Top=�6�   5<      5=      