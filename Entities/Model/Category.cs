using System.ComponentModel.DataAnnotations;
namespace RealPOSApi.Model;
[System.ComponentModel.DataAnnotations.Schema.Table("tbcategory")]
public class Category : BaseModel
{
    [Key]
    public int category_id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? category { get; set; }
    public int expired_day { get; set; }
    public int customer_id { get; set; }

}