   M S B A M L   `   `   `  ����P  LFixItYourselfHospital, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FixItYourselfHospital.FormsFixItYourselfHospital.Forms  5      2    ,FixItYourselfHospital.Forms.EmployeeEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:FixItYourselfHospital.Forms     5        N� Title$  EmployeeAddPage��5	      .��5      � .+�5   
   �� $
��Name��6   $
��Left=�6   $��185,131,0,0q�6:   $	��Top=�6O   �� 5   
   -   5         ��Name$ textBox_Name��5      $
��Left=�6(   $��23��6C   $��242,133,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��228��6�   �� 5   
   $��Second Name��6   $
��Left=�6&   $��145,162,0,0q�6A   $	��Top=�6V   �� 5   
   -   5        $ textBox_SecondName��5      $
��Left=�6.   $��23��6I   $��242,166,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��228��6�   �� 5   
   $��Email��6   $
��Left=�6    $��189,193,0,0q�6;   $	��Top=�6P   �� 5   
   -   5        $ textBox_Email��5      $
��Left=�6)   $��23��6D   $��242,197,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��228��6�   �� 5   
   $
��Role��6   $
��Left=�6   $��194,224,0,0q�6:   $	��Top=�6O   �� 5   
   -   5         ��Name$ comboBox_Role��5      $
��Left=�6*   $��242,228,0,0q�6E   $	��Top=�6Z   $	��228��6r   6~   �� 5   
   $��Specialization��6   $
��Left=�6)   $��147,255,0,0q�6D   $	��Top=�6Y   �� 5   
   -   5        $ comboBox_Specialization��5      $
��Left=�64   $��242,259,0,0q�6O   $	��Top=�6d   $	��228��6|   �� 5   
   $��
PWZ Number��6   $
��Left=�6%   $��147,286,0,0q�6@   $	��Top=�6U   �� 5   
   -   5        $ textBox_Pwz��5      $
��Left=�6'   $��23��6B   $��242,290,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��228��6�   �� 5   
   $��Pesel��6   $
��Left=�6    $��190,317,0,0q�6;   $	��Top=�6P   �� 5   
   -   5        $ textBox_Pesel��5      $
��Left=�6)   $��23��6D   $��242,320,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��228��6�   �� 5!   
   $��Username��6   $
��Left=�6#   $��166,348,0,0q�6>   $	��Top=�6S   �� 5"   
   -   5        $ textBox_Username��5"      $
��Left=�6,   $��23��6G   $��242,352,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��228��6�    �� 
IsReadOnly . 6�   �� 5$   
   $��Password��6   $
��Left=�6#   $��167,379,0,0q�6>   $	��Top=�6S   �� 5%   
   -	   5        $ textBox_Password��5%      $
��Left=�6,   $��23��6G   $��242,383,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��228��6�   �� 5'   
   -
   5         ��Name$ 
button_Add��5'      $��Update��6%   $
��Left=�66   $��286,432,0,0q�6Q   $	��Top=�6f   $��75��6~    �� 	IsDefault . {�.  6�   �� 5(   
   -   5        $ button_GenerateUsername��5(      $��Generate��62   $
��Left=�6E   $��477,353,0,0q�6`   $	��Top=�6u   $��60��6�   $��22��6�   6�   �� 5*   
   ���	#FFCDCDCD$
��Left=�6%   $	��564��6@   $	��Top=�6M   $	��648��6e    K� ZIndex$ -1��6q   �� 5+   
   -   5         ��Name$ 
image_Logo��5+      $-��'/Resources/Images/FYI_Hospital_Logo.png��6$   $��101,436,93,-11q�6U   $ -1��6m   6�   �� 5,   
   -   5        $ image_AddEmployee��5,      $5��//Resources/Images/FIY_Hospital_EditEmployee.png��6+   $��138,13,114,427q�6d   $ -1��6|   6�   5-      5.      