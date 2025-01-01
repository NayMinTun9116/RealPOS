using System.ComponentModel.DataAnnotations;
namespace RealPOSApi.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbcategory")]
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string category { get; set; }
        public int expired_day { get; set; }

    }
}
