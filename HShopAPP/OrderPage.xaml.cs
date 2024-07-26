using BusinessObject.Models;
using BusinessObject.ViewModel;
using DataAccess.Repository.HRepositories;
using DataAccess.Repository.IRepositories;
using HShopAPP.View;
using System.Windows;
using System.Windows.Controls;

namespace HShopAPP;


public partial class OrderPage : Page
{
    private Account loggedInCustomer;
    private readonly IOrderRepositories orderRepositories;
    public OrderPage()
    {
        InitializeComponent();
        loggedInCustomer = AccountManager.LoggedInAccount;
        orderRepositories = new OrderRepositories();
        LoadOrder();
        DataContext = this;
    }
    public async void LoadOrder()
    {
        try
        {
            var list = await orderRepositories.GetAllByIDAsync(loggedInCustomer.AccountId);
            
            RoomDataGrid.ItemsSource = list;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error load Orders");
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var order = button?.DataContext as Order;
        if (order != null)
        {
            var orderdetail = await orderRepositories.GetByIdAsync(order.OrderId);
            if (orderdetail.Status == false) {
                var orderWindow = new EditOrder(order);
                orderWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đơn hàng đang được giao tới bạn");
            }
           
        }
    }
    
}
