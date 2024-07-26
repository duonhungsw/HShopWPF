using BusinessObject.Models;
using DataAccess.Repository.HAccountRepositories;
using DataAccess.Repository.HRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;
using System.Windows.Controls;

namespace HShopAPP;


public partial class AccountManagementPage : Page
{
    private readonly IAccountRepositories _accountRepositories;
    private readonly IRoleRepositories _roleRepositories;
    public AccountManagementPage()
    {
        InitializeComponent();
        _accountRepositories = new HAccountRepositories();
        _roleRepositories = new RoleRepositories();
        LoadRoleList();
        LoadData();
    }
    private async void LoadData()
    {
        var list = await _accountRepositories.GetAllAsync();
        UsersDataGrid.ItemsSource= list;
    }
    public async void LoadRoleList()
    {
        try
        {
            var roleList = await _roleRepositories.GetAllAsync();
            RoleComboBox.ItemsSource = roleList;
            RoleComboBox.DisplayMemberPath = "RoleName";
            RoleComboBox.SelectedValuePath = "RoleId";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error on load list of roles");
        }
    }
    private async void EditUserButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (UsersDataGrid.SelectedItem is Account selectedUser)
        {
            var account = await _accountRepositories.GetByIdAsync(selectedUser.AccountId);
            txtName.Text = account.AccountName;
            txtEmail.Text = account.AccountEmail;
            txtPhone.Text = account.AccountPhone;
            txtLocation.Text = account.AccountAddress;
            txtpassword.Text = account.AccountPassword;
            RoleComboBox.SelectedValue = account.Role.RoleId;
            if (account.Gender == "Nam")
                GenderComboBox.SelectedItem = GenderComboBox.Items[0];
            else if (account.Gender == "Nữ")
                GenderComboBox.SelectedItem = GenderComboBox.Items[1];
            else
                GenderComboBox.SelectedItem = GenderComboBox.Items[2];

            // Populate other fields similarly
            UsersContent.Visibility = System.Windows.Visibility.Collapsed;
            EditUserForm.Visibility = System.Windows.Visibility.Visible;
        }
        else
        {
            MessageBox.Show("Error load data");
        }
    }

    private async void DeleteUserButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (UsersDataGrid.SelectedItem is Account selectedUser)
        {
            if (selectedUser.AccountId != 0)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this customer?",
                                                     "Confirm Deletion",
                                                     MessageBoxButton.YesNo,
                                                     MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    await _accountRepositories.DeleteAsync(selectedUser.AccountId);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Error to delete");
            }
        }
    }

    private async void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        try
        {
            if (UsersDataGrid.SelectedItem is Account selectedUser)
            {
                int.TryParse(RoleComboBox.SelectedValue?.ToString(), out int roleId);
                var selectedRole = GenderComboBox.SelectedItem as Role;
                var Account = new Account();
                Account.AccountId = selectedUser.AccountId;
                Account.AccountAddress = txtLocation.Text;
                Account.AccountPhone = txtPhone.Text;
                Account.AccountName = txtName.Text;
                if (GenderComboBox.SelectedItem is ComboBoxItem selectedItem)
                {
                    Account.Gender = selectedItem.Content.ToString();
                }

                Account.AccountPassword = txtpassword.Text;
                Account.AccountEmail = txtEmail.Text;
                Account.RoleID = roleId;
                await _accountRepositories.UpdateAsync(Account);
                MessageBox.Show("Update successfully");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        EditUserForm.Visibility = System.Windows.Visibility.Collapsed;
        UsersContent.Visibility = System.Windows.Visibility.Visible;
    }

    private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        // Handle Cancel button click in Edit User Form
        EditUserForm.Visibility = System.Windows.Visibility.Collapsed;
        UsersContent.Visibility = System.Windows.Visibility.Visible;
    }
}
