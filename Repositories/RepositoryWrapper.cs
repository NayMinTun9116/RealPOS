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
        private ICustomerRepository? _customer;
        public ICustomerRepository Customer
        {
            get
            {
                _customer ??= new CustomerRepository(_context);
                return _customer;
            }
        }
        
    }
}