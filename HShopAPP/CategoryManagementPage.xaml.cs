using BusinessObject.Models;
using DataAccess.Repository.HRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;
using System.Windows.Controls;

namespace HShopAPP;

public partial class CategoryManagementPage : Page
{
    private readonly ICategoryRepositories categoryRepositories;
    public CategoryManagementPage()
    {
        InitializeComponent();
        categoryRepositories = new CategoryRepositories();
        LoadData();
    }
    private async void LoadData()
    {
        var list = await categoryRepositories.GetAllAsync();
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
                var Category = new Category
                {
                    CategoryName = txtAddName.Text,
                    Products = new List<Product>()
                };
                await categoryRepositories.CreateAsync(Category);
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
        if(DataGrid.SelectedItem is Category category)
        {
            txtID.Text = category.CategoryId.ToString();
            txtName.Text = category.CategoryName;

            HContent.Visibility = System.Windows.Visibility.Collapsed;
            EditForm.Visibility = System.Windows.Visibility.Visible;
        }
        // Populate other fields similarly
    }

    private async void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataGrid.SelectedItem is Category category)
        { 
            if(category.CategoryId is not 0) 
            {
                MessageBoxResult result = MessageBox.Show("Bạn thực sự muốn xoá không?",
                                             "Xác nhận xoá",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    await categoryRepositories.DeleteAsync(category.CategoryId);
                    LoadData();
                }
            }
        }
            
    }
    private async void SaveEditButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var categoryName = txtName.Text;

        if (categoryName is null)
        {
            MessageBox.Show("Phải nhập thông tin tên danh mục.");
            return;
        }

        try
        {
            var check = await  categoryRepositories.checkExistAsync(categoryName);

            if (check != null)
            {
                MessageBox.Show("Loại sản phẩm đã tồn tại!");
            }
            else
            {
                var cate = new Category
                {
                    CategoryId = int.Parse(txtID.Text),
                    CategoryName = categoryName,
                    Products = new List<Product>()
                };

                await categoryRepositories.UpdateAsync(cate);

                LoadData();
                EditForm.Visibility = System.Windows.Visibility.Collapsed;
                HContent.Visibility = System.Windows.Visibility.Visible;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
        }
    }
    private void CancelEditButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        // Handle Cancel button click in Edit User Form
        EditForm.Visibility = System.Windows.Visibility.Collapsed;
        HContent.Visibility = System.Windows.Visibility.Visible;
    }
}
