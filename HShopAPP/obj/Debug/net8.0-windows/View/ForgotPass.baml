   M S B A M L   `   `   `  ����C  ?HShopAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HShopAPP.ViewHShopAPP.View  5   	       HShopAPP.View.ForgotPass   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HShopAPP.View     5   	     � Title$  Quên mật khẩu��5   	   $	��150��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�6;    � Icon$0 *E:\\.Net\\HShop\\HShopAPP\\Image\\logo.png��5	       � 	Resources 5         BorderedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value��%;  &	        �� 5   
   " ��6,   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � �� �#20bf6b6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 Left=�64   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       	 5!      P� 5"      
 �@J�IsMouseOver$
 True��61   . �5#      ��  � ��
 �����63   5$      5&      5'      .��5(      � $��6,10,2,0q�6    � ColumnDefinitions 5)   
   �� 5*      �� 5+      $	��55* �6   .+�5.   
   �� $8��2E:\.Net\HShop\HShopAPP\Image\backgoundwindown.jpeg��6   $
��Fill=�6N    J� Opacity$	 0.7Q�6]   $��-6,-24,-3,-2q�6k   $��2��6�   �� 5/   
   $��2��6   .+�50      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $	��0,5q�6M   .+�51      �� $
��Bold"�6   $��Center=�6*   $��0,0,10,0q�6E   .��6W   Nhập email6c   �� 52      .+�53      �� -   5         ��Name$ txtForgotEmail��53      $	��268��66   $��22��6B   $��5q�6N   $��0q�6Z   
������ 6n   �� 54      $��1��6    
�������6+   55      56      �� 57      -   5         ��Name$ 	BuyButton��57      $��Gửi��6(   #��[  6O   $	��104��6|   $��35��6�   $
��Bold"�58      $
��Left=�6#   $��	50,25,0,0q�6>   �� 59      -   5        $ RemoveButton��59      $��Huỷ��6+   $	��104��6N   $��35��6Z   ���#a5b1c2#��[  6{   $��0,-35,-200,0q�6�   $��Center=�6�   5:      5;      5<      