namespace RealPOSApi.Repositories
{
    public class RepositoryWrapper(AppDb context) : IRepositoryWrapper
    {        
        readonly AppDb _context = context;
        private ICategoryRepository? _category;
        public ICategoryRepository Category
        {
            get
            {
                _category ??= new CategoryRepository(_context);
                return _category;
            }
        }
        
    }
}