using BusinessObject.Models;
using BusinessObject.ViewModel;
using DataAccess.Repository.HAccountRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;
using System.Windows.Controls;

namespace HShopAPP;

public partial class ProfilePage : Page
{
    private Account loggedInCustomer;
    private readonly IAccountRepositories _accountRepositories;
    public ProfilePage()
    {
        InitializeComponent();
         loggedInCustomer = AccountManager.LoggedInAccount;
        _accountRepositories = new HAccountRepositories();
        InitializeCustomerData();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var Account = new Account();
            Account.AccountId = loggedInCustomer.AccountId;
            Account.AccountAddress = txtLocation.Text;
            Account.AccountPhone = txtPhone.Text;
            Account.AccountName = txtName.Text;
            if (GenderComboBox.SelectedItem is ComboBoxItem selected)
            {
                Account.Gender = selected.Content.ToString();
            }
            Account.AccountPassword = txtpassword.Text;
            Account.AccountEmail = txtEmail.Text;
            Account.RoleID = loggedInCustomer.RoleID;
            _accountRepositories.UpdateAsync(Account);
            MessageBox.Show("Update successfully");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
    }

    private async void InitializeCustomerData()
    {
        var account = await _accountRepositories.GetByIdAsync(loggedInCustomer.AccountId);
        txtName.Text = account.AccountName;
        txtEmail.Text = account.AccountEmail;
        txtPhone.Text = account.AccountPhone;
        txtLocation.Text = account.AccountAddress;
        txtpassword.Text = account.AccountPassword;

        if (account.Gender == "Nam")
            GenderComboBox.SelectedItem = GenderComboBox.Items[0];
        else if (account.Gender == "Nữ")
            GenderComboBox.SelectedItem = GenderComboBox.Items[1];
        else
            GenderComboBox.SelectedItem = GenderComboBox.Items[2];
    }


    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        // Implement cancel logic here
        MessageBox.Show("Profile update canceled.");
    }
}
