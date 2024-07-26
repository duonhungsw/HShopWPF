using BusinessObject.Models;
using DataAccess.Repository.HAccountRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;

namespace HShopAPP.View;


public partial class RegisterWindow : Window
{
    private readonly IAccountRepositories _accountRepositories;
    public RegisterWindow()
    {
        InitializeComponent();
        _accountRepositories = new HAccountRepositories();
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtpassword.Text))
        {
            MessageBox.Show("Vui lòng nhập đầy đủ tên, email và mật khẩu.");
            return;
        }
        var email = await _accountRepositories.ValidEmailAsync(txtEmail.Text);
        if (email == null)
        {
            Account account = new Account
            {
                AccountName = txtName.Text,
                AccountEmail = txtEmail.Text,
                AccountPhone = txtPhone.Text,
                AccountAddress = txtLocation.Text,
                AccountPassword = txtpassword.Text,
                RoleID = 1,
                Gender = GenderComboBox.SelectedValue.ToString()
            };

            await _accountRepositories.CreateAsync(account);
            MessageBox.Show("Tạo tài khoản thành công :3");
        }
        else
        {
            MessageBox.Show("Email đã được sử dụng!");
        }

        
    }


    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Bạn muốn dừng đăng ký tài khoản?",
                                                     "Xác nhận",
                                                     MessageBoxButton.YesNo,
                                                     MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            this.Close();
        }
        
    }
}
