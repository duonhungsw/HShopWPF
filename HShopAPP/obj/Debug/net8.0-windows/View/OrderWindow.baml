   M S B A M L   `   `   `  ����C  ?HShopAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HShopAPP.ViewHShopAPP.View  5   	       HShopAPP.View.OrderWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HShopAPP.View     5   	     � Title$  Đặt hàng��5   	   $	��300��6   $	��400��6'    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$0 *E:\\.Net\\HShop\\HShopAPP\\Image\\logo.png��5
   	    � ShowInTaskbar$ False��5   	    � WindowStyle$
 None=�5   	    � 	Resources 5         BorderedButtonStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� Triggers P� Property P� Value��%;  &	        �� 5   
   " ��6,   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � �� �#20bf6b6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 Left=�64   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $
 10��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5!       5"      P� 5#       �@J�IsMouseOver$
 True��61   . �5$      ��  � ��
 �����63   5%      5'      5(      .��5)      � $��6,10,2,0q�6    � ColumnDefinitions 5*   
   �� 5+      �� 5,      $	��55* �6   .+�5/   
   �� $8��2E:\.Net\HShop\HShopAPP\Image\backgoundwindown.jpeg��6   $
��Fill=�6N    J� Opacity$	 0.7Q�6]   $��-6,-12,-3,-2q�6k   $��2��6�   �� 50   
   $��2��6   .+�51      �� $��50��61   $��50��6=   $
��Left=�52      $��5q�6(   ��51      �� *	ImagePath+52   (   �� 53      $
��Bold"�65   $��16(�6G   $��5q�6U   $��23��6`   ��6   �� *ProductName+6`   �� 54      $��5q�6I   ��6   �� *Price+ �� StringFormat$ Price: ₫{0}��6I   �� 55      $��Nhập số lượng��6   $
��Bold"�6-   $��5q�6?   �� 56       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��5q�6O   .+�57      �� -   5        $��-��57      $��30��6%   60   �� 58      -   5        $��QuantityTextBox��58      $��50��61   $��1��6<    �� TextAlignment$ Center=�6E    �� 
IsReadOnly$
 True��6\   �� 59      -   5        $��+��59      $��30��6%   60   5:      �� 5;      $ 
Horizontal=�6   $��Center=�62   $	��0,5q�6M   .+�5<      �� $
��Bold"�6   $��5q�6*   .��65   Địa chỉ6?   �� 5=      .+�5>      �� -   5         ��Name$ 
txtAddress��5>      $	��250��63   $��25��6?   $��5q�6l   $��0q�6x   
������ ��6K   �� *AccountAddress+6�   �� 5?      $��1��6    
�������6+   5@      5A      �� 5B      -   5         ��Name$ 	BuyButton��5B      $��	Mua Hàng��6(   #��[  6S   $	��104��6�   $��35��6�   $
��Bold"�5C      $
��Left=�6'   $��50,0,0,0q�6B   �� 5D      -   5        $ RemoveButton��5D      $��Huỷ��6+   $	��104��6S   $��35��6_   ���#a5b1c2#��[  6�   $��0,-35,-200,0q�6�   $��Center=�6�   5E      5F      5G      