using BusinessObject.Models;
using System.Windows;

namespace HShopAPP.View;

public partial class Home : Window
{
    public Home( )
    {
        InitializeComponent();
    }
    private void ViewButton_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new ViewProductPage());
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        DangNhap dangNhap = new DangNhap();
        dangNhap.Show();
        this.Close();
    }

    private void ProfileButton_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new ProfilePage());
    }
    private void OrderButton_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new OrderPage());
    }
}
