using BusinessObject.Models;
using DataAccess.Repository.HRepositories;
using DataAccess.Repository.IRepositories;
using System.Windows;

namespace HShopAPP.View;

public partial class EditOrder : Window
{
    public Order SelectedOrder { get; set; }
    private readonly IOrderRepositories _repository;
    public EditOrder(Order order)
    {
        InitializeComponent();
        _repository = new OrderRepositories();
        SelectedOrder = order;
        DataContext = SelectedOrder;

    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        //OrderId
        //ProductID
        //Quantity
        //    OrderAddress
        //    OrderTotal
        //    Status
        

        var updateAddress = new Order
        {
            OrderId = SelectedOrder.OrderId,
            ProductID = SelectedOrder.ProductID,
            Quantity = SelectedOrder.Quantity,
            OrderAddress = txtAddress.Text,
            OrderTotal  = SelectedOrder.OrderTotal,
            Status = SelectedOrder.Status
        };
        await _repository.UpdateAsync(updateAddress);
        MessageBox.Show("Update successfully");
        this.Close();
    }

    private void RemoveOrder_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
