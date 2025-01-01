namespace RealPOSApi.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<RT>> GetAll<RT>(string query, object parameters); // dapper 
        Task<int> EditData(string query, object parameters); // dapper
        Task<T?> FindByID(int id);
        Task Create(dynamic entity, bool flush = true);
        Task Update(dynamic entity, bool flush = true);
        Task Delete(dynamic entity, bool flush = true);
        Task<T?> FindByCompositeID(int id1, int id2);
    }
}