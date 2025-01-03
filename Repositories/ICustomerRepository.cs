using RealPOSApi.Model;

namespace RealPOSApi.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<Customer?> OldCustomer(int customer_id);
        Task<bool> CheckDuplicate(string url);
        Task<int> MaxCategoryID();
        Task<List<Customer>> GetAllCustomers();
    }
}