using DataAccess.Repository.HAccountRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;

namespace HShopAPP.View;


public partial class ForgotPass : Window
{
    private readonly IAccountRepositories _accountRepositories;
    public ForgotPass()
    {
        InitializeComponent();
        _accountRepositories = new HAccountRepositories();
    }

    private async void SendButton_Click(object sender, RoutedEventArgs e)
    {
        var email = txtForgotEmail.Text;
        if (email != null)
        {
            var acc = await _accountRepositories.ValidEmailAsync(email);
            if (acc != null)
            {
                ResetPassWindown reset = new ResetPassWindown(acc);
                reset.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email không tồn tại!");
            }
        }
    }

    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
