using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealPOSApi.Model;
using RealPOSApi.Repositories;
namespace RealPOSApi.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDb context) : base(context)

        {
        }

        public async Task<Category?> OldCategory(int category_id, int customer_id)
        {
            return await RepositoryContext.Category.Where(u => u.category_id == category_id && u.customer_id == customer_id).FirstOrDefaultAsync() ?? null;
        }
        public async Task<bool> CheckDuplicate(string category)
        {
            try
            {
                if (!string.IsNullOrEmpty(category))
                {
                    return await RepositoryContext.Category.AnyAsync(u => u.category == category);
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

        public async Task<int> MaxCategoryID(int customerId)
        {
            int maxId = 0;
            try
            {
                var mainQuery = await (from main in RepositoryContext.Category
                                       where main.customer_id == customerId
                                       select main.category_id).ToListAsync();
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

        public async Task<List<Category>> GetAllCategories(int customerId)
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = await (from main in RepositoryContext.Category
                                    where main.customer_id == customerId
                                    select main).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return categories;
        }
    }
}
