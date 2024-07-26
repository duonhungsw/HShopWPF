using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models;



public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Name Product is required")]
    [StringLength(500)]
    public string? ImagePath { get; set; }
    [Required(ErrorMessage = "Image Product is required")]
    [StringLength(500)]
    public string? ProductName { get; set; }
    [Required(ErrorMessage = "Price Product is required")]
    [StringLength(50)]
    public decimal Price { get; set; }
    public int CategoryID {  get; set; }
    public virtual Category? Category { get; set; }
}

