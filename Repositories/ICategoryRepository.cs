using RealPOSApi.Model;

namespace RealPOSApi.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<Category?> OldCategory(int category_id, int customer_id);
        Task<bool> CheckDuplicate(string category);
        Task<int> MaxCategoryID(int customerId);
        Task<List<Category>> GetAllCategories(int customerId);
    }
}