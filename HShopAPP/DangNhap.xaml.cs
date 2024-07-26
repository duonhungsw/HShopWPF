using BusinessObject.ViewModel;
using DataAccess.Repository.HAccountRepositories;
using DataAccess.Repository.IRepositories;
using HShopAPP.View;
using Microsoft.Win32;
using System.Windows;

namespace HShopAPP;

public partial class DangNhap : Window
{
    private readonly IAccountRepositories _accountRepositories;
    public DangNhap()
    {
        InitializeComponent();
        _accountRepositories = new HAccountRepositories();
    }
    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPass.Password))
        {
            MessageBox.Show("Phải nhập email và password");
            return;
        }

        var account = await _accountRepositories.Login(txtName.Text, txtPass.Password);

        if (account != null)
        {
            AccountManager.LoggedInAccount = account;
            switch (account.Role.RoleId)
            {
                case 1:
                    Home home = new Home();
                    home.Show();
                    break;
                case 2:
                    AdminManagement admin = new AdminManagement();
                    admin.Show();
                    break;
                default:
                    MainWindow main = new MainWindow();
                    main.Show();
                    break;
            }
            this.Close();
        }
        else
        {
            MessageBox.Show("Tài khoảng không tồn tại!");
        }
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void ForgotPassword_click(object sender, RoutedEventArgs e)
    {
        ForgotPass forgot = new ForgotPass();
        forgot.Show();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        RegisterWindow register = new RegisterWindow();
        register.Show();

    }
}
