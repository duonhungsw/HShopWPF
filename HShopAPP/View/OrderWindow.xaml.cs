using BusinessObject.Models;
using BusinessObject.ViewModel;
using DataAccess.Repository.HRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;

namespace HShopAPP.View
{
    public partial class OrderWindow : Window
    {
        public Product SelectedProduct { get; set; }
        private Account? loggedInCustomer;
        private readonly IOrderRepositories orderRepositories;

        public OrderWindow(Product product)
        {
            InitializeComponent();
            SelectedProduct = product;
            loggedInCustomer = AccountManager.LoggedInAccount;
            orderRepositories = new OrderRepositories();
            DataContext = SelectedProduct;
        }
        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            int quantity = int.Parse(QuantityTextBox.Text);
            QuantityTextBox.Text = (quantity + 1).ToString();
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            int quantity = int.Parse(QuantityTextBox.Text);
            if (quantity > 1)
            {
                QuantityTextBox.Text = (quantity - 1).ToString();
            }
        }
        private async void BuyButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (int.TryParse(QuantityTextBox.Text, out int quantity) && quantity > 0)
            {
                var order = new Order
                {
                    ProductID = SelectedProduct.ProductId,
                    AccountID = loggedInCustomer.AccountId,
                    Quantity = quantity,
                    OrderAddress = txtAddress.Text ?? "Null",
                    OrderTotal = quantity * SelectedProduct.Price,
                    Status = false
                };
                
                await orderRepositories.CreateAsync(order);
                MessageBox.Show($"Thank you for Order");
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.");
            }
        }
        private void RemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
