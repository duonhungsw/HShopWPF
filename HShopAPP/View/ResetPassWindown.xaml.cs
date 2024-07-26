using BusinessObject.Models;
using DataAccess.Repository.HAccountRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;

namespace HShopAPP.View;


public partial class ResetPassWindown : Window
{
    private Account resetAccount;
    private readonly IAccountRepositories _accountRepositories;

    public ResetPassWindown(Account account)
    {
        InitializeComponent();
        resetAccount = account;
        _accountRepositories = new HAccountRepositories();
    }

    private async void SendButton_Click(object sender, RoutedEventArgs e)
    {
        var newPass = txtnewpass.Text;
        var confirmPass = txtconfirmpass.Text;
        if (newPass == null || confirmPass == null)
        {
            MessageBox.Show("Chưa nhập đủ thông tin!");
        }
        if (newPass.Equals(confirmPass))
        {
            var accReset = new Account 
            { 
                AccountId = resetAccount.AccountId,
                AccountName = resetAccount.AccountName,
                AccountEmail = resetAccount.AccountEmail,
                AccountPassword = newPass,
                AccountPhone = resetAccount.AccountPhone,
                Gender = resetAccount.Gender,
                AccountAddress = resetAccount.AccountAddress,
                RoleID = resetAccount.RoleID,
            };
            await _accountRepositories.UpdateAsync(accReset);
            MessageBox.Show("Cập nhật mật khẩu thành công");
            this.Close();
        }
        else
        {
            MessageBox.Show("Mật khẩu không trùng nhau");
        }
    }

    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
