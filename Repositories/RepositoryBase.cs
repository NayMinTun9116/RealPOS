using RealPOSApi.Repositories;

namespace RealPOSApi.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDb RepositoryContext { get; set; }
        public RepositoryBase(AppDb repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<RT>> GetAll<RT>(string query, object
        parameters)
        {
            return await RepositoryContext.GetAll<RT>(query, parameters);
        }
        public async Task<int> EditData(string query, object parameters)
        {
            return await RepositoryContext.EditData(query, parameters);
        }
        public async Task<T?> FindByID(int id)
        {
            return await RepositoryContext.FindAsync<T>(id) ?? null;
        }
        public async Task<T?> FindByCompositeID(int id1, int id2)
        {
            T? obj;
            obj = await this.RepositoryContext.Set<T>().FindAsync(id1, id2) ?? null;
            return obj;
        }
        public async Task SaveAsync()
        {
            await this.RepositoryContext.SaveChangesAsync();
        }
        public async Task Create(dynamic entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            if (flush) await this.SaveAsync();
        }
        public async Task Update(dynamic entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            if (flush) await this.SaveAsync();

        }
        public async Task Delete(dynamic entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            if (flush) await this.SaveAsync();
        }
    }
}