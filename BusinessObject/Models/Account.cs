using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public class Account
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }
    [Required]
    public string? AccountName { get; set; }
    [Required]
    public string? AccountEmail { get; set; }
    [Required]
    public string? AccountPassword { get; set; }
    public string? AccountPhone { get; set; }
    public string? Gender { get; set; }
    public string? AccountAddress {  get; set; }
    [Required]
    public int RoleID {  get; set; }
    public  Role Role { get; set; }

}
