namespace job_opportunities_asp_react.Models.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Create(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(int id);
        Task<bool> Get();
        Task<bool> GetById(int id);
    }
}
