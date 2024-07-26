using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    public int ProductID { get; set; }
    public int AccountID { get; set; }
    [Required]
    public  Product Product { get; set; }
    [Required]
    public  Account Account { get; set; }

    [Required]
    public int Quantity { get; set; }
    [Required]
    public string? OrderAddress { get; set; }
    public decimal OrderTotal { get; set; }
    public bool? Status { get; set; }

}
