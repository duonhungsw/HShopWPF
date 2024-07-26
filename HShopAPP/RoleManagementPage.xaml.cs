using BusinessObject.Models;
using DataAccess.Repository.HRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;
using System.Windows.Controls;

namespace HShopAPP;

public partial class RoleManagementPage : Page
{
    private readonly IRoleRepositories _roleRepositories;
    public RoleManagementPage()
    {
        InitializeComponent();
        _roleRepositories = new RoleRepositories();
        LoadData();
    }

    private async void LoadData()
    {
        var list = await _roleRepositories.GetAllAsync();
        DataGrid.ItemsSource = list;
    }
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {

        HContent.Visibility = Visibility.Collapsed;
        AddForm.Visibility = Visibility.Visible;
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (txtAddName is not null)
            {
                var Role = new Role
                {
                    RoleName = txtAddName.Text,
                    Accounts = new List<Account>() 
                };
                await _roleRepositories.CreateAsync(Role);
                MessageBox.Show("Thêm thành công!");
                LoadData();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        AddForm.Visibility = Visibility.Collapsed;
        HContent.Visibility = Visibility.Visible;
    }


    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        AddForm.Visibility = System.Windows.Visibility.Collapsed;
        HContent.Visibility = System.Windows.Visibility.Visible;
    }

    private void EditButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataGrid.SelectedItem is Role entity)
        {
            txtID.Text = entity.RoleId.ToString();
            txtName.Text = entity.RoleName;

            HContent.Visibility = System.Windows.Visibility.Collapsed;
            EditForm.Visibility = System.Windows.Visibility.Visible;
        }
        // Populate other fields similarly
    }

    private async void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataGrid.SelectedItem is Role entity)
        {
            if (entity.RoleId is not 0)
            {
                MessageBoxResult result = MessageBox.Show("Bạn thực sự muốn xoá không?",
                                             "Xác nhận xoá",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    await _roleRepositories.DeleteAsync(entity.RoleId);
                    LoadData();
                }
            }
        }

    }
    private async void SaveEditButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var entityName = txtName.Text;

        if (entityName is null)
        {
            MessageBox.Show("Phải nhập thông tin tên danh mục.");
            return;
        }

        try
        {
                var entity = new Role
                {
                    RoleId = int.Parse(txtID.Text),
                    RoleName = entityName,
                    Accounts = new List<Account>()
                };

                await _roleRepositories.UpdateAsync(entity);

                LoadData();
                EditForm.Visibility = System.Windows.Visibility.Collapsed;
                HContent.Visibility = System.Windows.Visibility.Visible;
            
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            Console.WriteLine(ex.Message);
        }
    }
    private void CancelEditButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        // Handle Cancel button click in Edit User Form
        EditForm.Visibility = System.Windows.Visibility.Collapsed;
        HContent.Visibility = System.Windows.Visibility.Visible;
    }
}
