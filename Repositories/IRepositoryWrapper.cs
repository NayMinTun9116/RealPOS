namespace RealPOSApi.Repositories
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }
        ICustomerRepository Customer { get; }
    }
}