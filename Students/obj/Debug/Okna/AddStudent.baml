   M S B A M L   `   `   `  ����  Students    Students.Okna.AddStudent   5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � WindowStartupLocation$  CenterScreen=�5       � 
ResizeMode$ CanMinimize=�5	       � Title$ 
AddStudent��5      $	��180��6   $	��240��6(   $	��180��67   $	��240��6G   .��5      � $��4,4,4,4q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Nr. Indeksu:��6-   �� 5   
   $��1��6   $��0��6   $��Imię:��6-   �� 5   
   $��2��6   $��0��6   $��	Nazwisko:��6-   �� 5   
   $��3��6   $��0��6   $��Data Urodzenia:��6-   �� 5   
   -   5         ��Name$ IndeksTb��5      $��0��6$   $��1��61    � ToolTip$, &Numer indeksu musi posiadać 6 znaków��6A    �� 	MaxLength$ 6��6p   6�   �� 5   
   -   5        $ ImieTb��5      $��1��6"   $��1��6/   $ 30��6?   $ Minimum 3 znaki��6N   6|   �� 5   
   -   5        $ 
NazwiskoTb��5      $��2��6&   $��1��63   $ 30��6C   $ Minimum 3 znaki��6R   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DataDp��5      $��3��6%   $��1��62   	 � 	Resources	 5       :  4System.Windows.Controls.Primitives.DatePickerTextBox
 �� 
TargetType �� Property �� Value��%[   '        �� 5!      "
  6   .�5"      ��  �@��
IsReadOnly . 63   5#      5$      5%      � 5&   
   $��4��6   $��0��6   ��5'      �� 5(      "
 �6    �� Triggers 5)      P� 5*       P� Property �@J�IsMouseOver P� Value . . �5+      ��  �@�Cursor$
 Hand��67   5,      5.      .+�50      �� -   5         ��Name$ DodajStudentaBtn��50      
�������
����� �$��Dodaj studenta��6   {�.  6�   51      �� 52   
   -   5        $ WalidacjaOpen��52   .   $��1��6   $��4��6!      MetroCircleButtonStyle#���   6E   
��� � �$
��Left=�6�   $��30��6�   $��30��6�   {�.  $��Center=�6�   $y�Hidden=�6�   .��53      �� $��10��6   $��10��6#   
��� � � J� OpacityMask 54      !� 55       j� Stretch$
 Fill=�6"     appbar_door_enter !� Visual# [ 61   57      58      �� 59   
   -   5        $ WalidacjaLock��59   .   $��1��6   $��4��6!   #���   6E   
���  ��$
��Left=�6�   $��30��6�   $��30��6�   {�.  $��Center=�6�   .��5:      �� $��10��6   $��10��6#   
���  �� 5;      !� 5<      $
 Fill=�6"     appbar_lock# [ 61   5>      5?      5@      5A      