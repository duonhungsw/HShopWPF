using BusinessObject.Models;
using DataAccess.Repository.HRepositories;
using DataAccess.Repository.IRepositories;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HShopAPP;
public partial class ProductManagementPage : Page
{
    private string selectedImagePath;
    private readonly IProductRepositories productRepositories;
    private readonly ICategoryRepositories categoryRepositories;
    public ProductManagementPage()
    {
        InitializeComponent();
        productRepositories = new ProductRepositories();
        categoryRepositories = new CategoryRepositories();
        LoadDataCate();
        LoadData();
    }

    private async void LoadData()
    {
        var list = await productRepositories.GetAllAsync();
        DataGrid.ItemsSource = list;
    }
    private async void LoadDataCate()
    {
        var categories = await categoryRepositories.GetAllAsync();
        if (categories.Any())
        {
            AddCategoryComboBox.ItemsSource = categories;
            AddCategoryComboBox.DisplayMemberPath = "CategoryName";
            AddCategoryComboBox.SelectedValuePath = "CategoryId";

            CategoryComboBox.ItemsSource = categories;
            CategoryComboBox.DisplayMemberPath = "CategoryName";
            CategoryComboBox.SelectedValuePath = "CategoryId";
        }
    }

    private void SelectImage_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            selectedImagePath = openFileDialog.FileName;
            txtAddImage.Text = selectedImagePath;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(selectedImagePath);
            bitmap.EndInit();
            SelectedImage.Source = bitmap;
        }
    }
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        HContent.Visibility = Visibility.Collapsed;
        AddForm.Visibility = Visibility.Visible;
    }

    private async void SaveAddButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtAddName.Text) || string.IsNullOrEmpty(selectedImagePath) || string.IsNullOrEmpty(txtAddPrice.Text) || AddCategoryComboBox.SelectedItem == null)
        {
            MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm.");
            return;
        }

        string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        // Tạo thư mục nếu chưa tồn tại
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string fileName = System.IO.Path.GetFileName(selectedImagePath);
        string destinationPath = System.IO.Path.Combine(folderPath, fileName);

        // Copy file vào thư mục đích
        File.Copy(selectedImagePath, destinationPath, true);

        var selectedCategoryId = (int)AddCategoryComboBox.SelectedValue;
        var cate = await categoryRepositories.GetByIdAsync(selectedCategoryId);

        var Product = new Product();


        Product.ProductName = txtAddName.Text;
        Product.Price = decimal.Parse(txtAddPrice.Text);
        Product.ImagePath = destinationPath;
        Product.CategoryID = selectedCategoryId;


        await productRepositories.CreateAsync(Product);

        MessageBox.Show("Sản phẩm đã được lưu thành công.");
        LoadData();
        AddForm.Visibility = Visibility.Collapsed;
        HContent.Visibility = Visibility.Visible;
    }
    private void CancelAddButton_Click(object sender, RoutedEventArgs e)
    {
        AddForm.Visibility = System.Windows.Visibility.Collapsed;
        HContent.Visibility = System.Windows.Visibility.Visible;
    }

    private void EditButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataGrid.SelectedItem is Product entity)
        {
            txtID.Text = entity.ProductId.ToString();
            txtName.Text = entity.ProductName;
            txtPrice.Text = entity.Price.ToString();
            txtImage.Text = entity.ImagePath;
            CategoryComboBox.SelectedValue = entity.CategoryID;

            // Populate other fields similarly
            HContent.Visibility = System.Windows.Visibility.Collapsed;
            EditForm.Visibility = System.Windows.Visibility.Visible;
        }
        else
        {
            MessageBox.Show("Error load data");
        }

    }

    private async void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataGrid.SelectedItems is Product selected)
        {
            if (selected.ProductId != 0)
            {
                MessageBoxResult result = MessageBox.Show("Bạn thực sự muốn xoá không?",
                                             "Xác nhận xoá",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    await productRepositories.DeleteAsync(selected.ProductId);
                    MessageBox.Show("Xoá thành công");
                    LoadData();
                }
            }
        }
    }
    private async void SaveEditButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        try
        {
            string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = System.IO.Path.GetFileName(selectedImagePath);
            string destinationPath = System.IO.Path.Combine(folderPath, fileName);

            // Copy file vào thư mục đích
            File.Copy(selectedImagePath, destinationPath, true);

            var selectedCategoryId = (int)CategoryComboBox.SelectedValue;
            var product = new Product
            {
                ProductId = int.Parse(txtID.Text),
                ProductName = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                ImagePath = destinationPath,
                CategoryID = selectedCategoryId
            };
            await productRepositories.UpdateAsync(product);
            MessageBox.Show("Cập nhật thành công");
            LoadData();
        }
        catch (Exception ex)
        {
            //
        }

        EditForm.Visibility = System.Windows.Visibility.Collapsed;
        HContent.Visibility = System.Windows.Visibility.Visible;
    }

    private void CancelEditButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        // Handle Cancel button click in Edit User Form
        EditForm.Visibility = System.Windows.Visibility.Collapsed;
        HContent.Visibility = System.Windows.Visibility.Visible;
    }
}
