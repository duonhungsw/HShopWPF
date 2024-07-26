using BusinessObject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.ViewModel;

public class HomeModel
{
    
}
public static class AccountManager
{
    public static Account? LoggedInAccount { get; set; }
}
public class OrderDTO
{
    public int OrderId { get; set; }
    public Product? product { get; set; }
    public Account? account { get; set; }
    public int Quantity { get; set; }
    public string? OrderAddress { get; set; }
    public decimal OrderTotal { get; set; }
    public string? Status { get; set; }

}
