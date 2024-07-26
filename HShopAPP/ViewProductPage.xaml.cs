using BusinessObject.Models;
using DataAccess.Repository.HRepositories;
using DataAccess.Repository.IRepositories;
using HShopAPP.View;
using System.Windows;
using System.Windows.Controls;

namespace HShopAPP
{
    public partial class ViewProductPage : Page
    {
        public IEnumerable<Category> Categories { get; set; }
        private readonly ICategoryRepositories categoryRepositories;

        public ViewProductPage()
        {
            InitializeComponent();
            categoryRepositories = new CategoryRepositories();
            LoadData();
            DataContext = this;

        }

        private async void LoadData()
        {
             Categories = await categoryRepositories.GetAllAsync();
            CategoriesControl.ItemsSource = Categories;
            // Example categories and products data

        }

        private void OrderNowButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button?.DataContext as Product;
            if (product != null)
            {
                var orderWindow = new OrderWindow(product);
                orderWindow.ShowDialog();
            }
        }
    }
}
