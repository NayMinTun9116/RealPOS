using Microsoft.EntityFrameworkCore;
using RealPOSApi.Model;
namespace RealPOSApi.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDb context) : base(context)
        {
        }

        public async Task<Customer?> OldCustomer(int customer_id)
        {
            return await RepositoryContext.Customer!.Where(u => u.customer_id == customer_id).FirstOrDefaultAsync() ?? null;
        }
        public async Task<bool> CheckDuplicate(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    return await RepositoryContext.Customer!.AnyAsync(u => u.url == url);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> MaxCategoryID()
        {
            int maxId = 0;
            try
            {
                var mainQuery = await (from main in RepositoryContext.Customer                                       
                                       select main.customer_id).ToListAsync();
                if (mainQuery.Count() > 0)
                {
                    maxId = mainQuery.Max();
                }
                maxId = maxId + 1;
            }
            catch (Exception ex)
            {

            }
            return maxId;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                customers = await (from main in RepositoryContext.Customer                                    
                                    select main).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return customers;
        }
    }
}
