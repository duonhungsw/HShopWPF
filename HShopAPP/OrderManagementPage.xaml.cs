using BusinessObject.Models;
using DataAccess.Repository.HRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;
using System.Windows.Controls;

namespace HShopAPP;

public partial class OrderManagementPage : Page
{
    private readonly IOrderRepositories _orderRepositories;
    public OrderManagementPage()
    {
        InitializeComponent();
        _orderRepositories = new OrderRepositories();
        LoadData();
    }
    private async void LoadData()
    {
        var list = await _orderRepositories.GetAllAsync();
        DataGrid.ItemsSource = list;
    }
    private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGrid.SelectedItem is Order selected)
        {
            if (selected.Status is true)
            {
                MessageBox.Show("Đơn hàng đang được giao!");
            }
            else
            {
                var order = new Order
                {
                    OrderId = selected.OrderId,
                    Product = selected.Product,
                    Account = selected.Account,
                    OrderAddress = selected.OrderAddress,
                    OrderTotal = selected.OrderTotal,
                    Status = true,
                    Quantity = selected.Quantity
                };
                await _orderRepositories.UpdateAsync(order);
                MessageBox.Show("Xác nhận đơn hàng thành công:3");
                LoadData();
            }
            
        }
        else
        {
            MessageBox.Show("Error");
        }
    }
    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGrid.SelectedItem is Order entity)
        {
            if (entity.OrderId is not 0)
            {
                MessageBoxResult result = MessageBox.Show("Bạn thực sự muốn xoá không?",
                                             "Xác nhận xoá",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    await _orderRepositories.DeleteAsync(entity.OrderId);
                    LoadData();
                }
            }
        }
    }

}
