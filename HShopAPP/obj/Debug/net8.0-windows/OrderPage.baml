   M S B A M L   `   `   `  ����C  ?HShopAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:HShopAPPHShopAPP  5          HShopAPP.OrderPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:HShopAPP     5        N� Title$  	OrderPage��5	      .��5      � 
�������.+�5   
   �� $
��Auto=�6   .��5   
   �� -   5         ��Name$ RoomsInfoContent��5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10q�62   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��61   $��0,0,10,0q�6=   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ RoomDataGrid��5         AutoGenerateColumns$ False��6-   $��10,50,10,10q�6I      
IsReadOnly$
 True��6^      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6Q   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *	OrderId+6Q     5      $ Tên sản phẩm��6-   $	 * 6k   
 6C   �� *Product.ProductName+6k     5      $ Địa chỉ��6)   $	 * 6[   
 6:   �� *OrderAddress+6[     5      $ Tổng tiền ��6)   $	 * 6\   
 6=   �� *
OrderTotal+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Trạng thái��61   $	 * 6E      CellTemplate 5      �� 5   "   .R�5   &   �� ��5   *   �� 5   .    �� 
TargetType" ��64   .�5   2   ��  �� Property � �� �� Value$ Chưa xác nhận��6I    �� Triggers 5   2   �� 5   6    �� Binding 6B   �� *Status+ �� Value True6]   .a�5    :   ��  � ��$ Đã xác nhận��6Q   5!   7   5#   /   5%   '   5&   #   5(        5)      $
 Edit��61    5*      �� 5+      .R�5,   "   �� -   5        $
��🖉��5,   *   67   5-      5/      52      53      54      55      56      