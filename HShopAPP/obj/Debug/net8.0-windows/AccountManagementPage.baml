   M S B A M L   `   `   `  ����C  ?HShopAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:HShopAPPHShopAPP  5      $    HShopAPP.AccountManagementPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:HShopAPP     5        N� Title$  AccountManagementPage��5	      .��5      � .+�5   
   �� -   5         ��Name$ UsersContent��5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10q�62   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��61   $��0,0,10,0q�6=   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ UsersDataGrid��5      ���#81ecec   AutoGenerateColumns$ False��6C   $��10,50,10,10q�6_      
IsReadOnly$
 True��6t      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *AccountName+6W     5      $ Email��6)   $	 * 6Y   
 68   �� *AccountEmail+6Y     5      $ Phone��6)   $	 * 6Y   
 68   �� *AccountPhone+6Y     5      $ Address��6)   $	 * 6]   
 6:   �� *AccountAddress+6]     5      $
 Role��6)   $	 * 6Y   
 67   �� *Role.RoleName+6Y   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Edit��6-      CellTemplate 5      �� 5      .R�5   "   �� -   5        $
��🖉��5   )   ���#55efc46K   5      5        5      $ Delete��6-    5      �� 5       .R�5!   "   �� -   5        $��🗑️��5!   )   
���  ��6H   5"      5$      5&      5'      � 5*   
   -   5         �Name$ EditUserForm��5*      $y�	Collapsed=�6%   
�������.+�5+      �� $
��Auto=�6   .��5,      �� $��Center=�6   $��Center=�6:   $	��300��6U   .+�5-      �� $��Thông tin khách hàng��6    $��24(�6<   $
��Bold"�6J   ���#2f3640$��0,0,0,20q�6q   $��Center=�6�   �� 5/      $ 
Horizontal=�6!   $��Center=�6:   $	��0,5q�6U   .+�50      �� $+��%E:\.Net\HShop\HShopAPP/Image/name.png��6    $��20��6O   $��20��6Z   $��0,0,10,0q�6f   �� 51      .+�52      �� -   5        $ txtName��52   &    �� 
IsReadOnly$
 True��67   $	��250��6I   $��25��6U   $��5q�6b   $��0q�6n   
������ 6�   �� 53      $��1��6(   
�������63   54      55      �� 57      $ 
Horizontal=�6!   $��Center=�6:   $	��0,5q�6U   .+�58      �� $,��&E:\.Net\HShop\HShopAPP/Image/email.png��6    $��20��6P   $��20��6[   $��0,0,10,0q�6g   �� 59      .+�5:      �� -   5        $ txtEmail��5:   &   $
 True��68   $	��250��6K   $��25��6W   $��5q�6d   $��0q�6p   
������ 6�   �� 5;      $��1��6(   
�������63   5<      5=      �� 5?      $ 
Horizontal=�6!   $��Center=�6:   $	��0,5q�6U   .+�5@      �� $,��&E:\.Net\HShop\HShopAPP/Image/phone.png��6    $��20��6P   $��20��6[   $��0,0,10,0q�6g   �� 5A      .+�5B      �� -	   5        $ txtPhone��5B   &   $	��250��68   $��25��6D   $��5q�6Q   $��0q�6]   
������ 6q   �� 5C      $��1��6(   
�������63   5D      5E      �� 5G      $ 
Horizontal=�6!   $��Center=�6:   $	��0,5q�6U   .+�5H      �� $.��(E:\.Net\HShop\HShopAPP/Image/address.png��6    $��20��6R   $��20��6]   $��0,0,10,0q�6i   �� 5I      .+�5J      �� -
   5        $ txtLocation��5J   &   $	��250��6;   $��25��6G   $��5q�6T   $��0q�6`   
������ 6t   �� 5K      $��1��6(   
�������63   5L      5M      �� 5O      $ 
Horizontal=�6!   $��Center=�6:   $	��0,5q�6U   .+�5P      �� $4��.E:\.Net\HShop\HShopAPP/Image/password-icon.png��6    $��20��6X   $��20��6c   $��0,0,10,0q�6o   �� 5Q      .+�5R      �� -   5        $ txtpassword��5R   &   $	��250��6;   $��25��6G   $��5q�6T   $��0q�6`   
������ 6t   �� 5S      $��1��6(   
�������63   5T      5U      �� 5W      $ 
Horizontal=�6!   $��Center=�6:   $	��0,5q�6U   .+�5X      �� $-��'E:\.Net\HShop\HShopAPP/Image/gender.png��6    $��20��6Q   $��20��6\   $��0,0,10,0q�6h   �� 5Y      .+�5Z      �� -   5        $��GenderComboBox��5Z   '   $	��250��6=   $��25��6I   $��5q�6U   .@�5[   "   �� $	��Nam��6/   �� 5\   "   $
��Nữ��6/   �� 5]   "   $��Khác��6/   5^      5_      5`      �� 5a      $ 
Horizontal=�6!   $��Center=�6:   $	��0,5q�6U   .+�5b      �� $+��%E:\.Net\HShop\HShopAPP/Image/role.png��6    $��20��6O   $��20��6Z   $��0,0,10,0q�6f   �� 5c      .+�5d      �� -   5        $��RoleComboBox��5d   (   $	��250��6<   $��25��6H   $��5q�6T   5f      5g      5h      �� 5k      $ 
Horizontal=�6!   $��Center=�6:   $��20q�6W   .+�5l      �� -   5        $
��Lưu��5l   !   $	��100��6/   $��30��6;   $��10q�6G   ���#4cd137
����������#44bd32$��2q�6�   �� 5m      -   5        $��Huỷ��5m   !   $	��100��6/   $��30��6;   $��10q�6G   ���#e84118
����������#c23616$��2q�6�   5n      5o      5p      5q      5t      5u      