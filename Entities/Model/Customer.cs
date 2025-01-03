using System.ComponentModel.DataAnnotations;
namespace RealPOSApi.Model;
[System.ComponentModel.DataAnnotations.Schema.Table("tbcustomer")]
public class Customer : BaseModel
{
    [Key]
    public int customer_id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? name { get; set; }
    public string? url { get; set; }
}