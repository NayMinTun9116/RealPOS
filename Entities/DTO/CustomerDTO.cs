namespace RealPOSApi.DTO
{
    public class CustomerDTO
    {        
        public required string Name { get; set; }        
        public required string url { get; set; }
    }
    public class UpdateCustomerRequestDTO
    {
        public int CustomerID { get; set; }
        public required string Name { get; set; }
        public string? url { get; set; }
    }

    public class CustomerRespondDTO
    {
        public string?  Message{ get; set; }
        public string? Error{ get; set; }
        
    }
}