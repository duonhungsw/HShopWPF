using System.Windows;

namespace HShopAPP.View;


public partial class AdminManagement : Window
{
    public AdminManagement()
    {
        InitializeComponent();
    }

    private void AccountButton_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new AccountManagementPage());
    }

    private void CategoryButton_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new CategoryManagementPage());
    }

    private void ProductButton_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new ProductManagementPage());
    }

    private void OrderButton_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new OrderManagementPage());
    }

    private void RoleButton_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new RoleManagementPage());
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        DangNhap dangNhap = new DangNhap();
        dangNhap.Show();
        this.Close();
    }
}
