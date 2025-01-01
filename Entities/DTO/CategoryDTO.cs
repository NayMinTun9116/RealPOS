namespace RealPOSApi.DTO
{
    public class CategoryDTO
    {        
        public required string Category { get; set; }        
        public int Exprired_day { get; set; }
    }
    public class UpdateCategoryRequestDTO
    {
        public int CategoryID { get; set; }
        public required string Category { get; set; }
        public int Exprired_day { get; set; }
    }

    public class CategoryRespondDTO
    {
        public string  Message{ get; set; }
        public string  Error{ get; set; }
        
    }

}