using job_opportunities_asp_react.Models.Entities;

namespace job_opportunities_asp_react.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<bool> Create(Application model);
        Task<bool> Update(Application model);
        Task<bool> Delete(int id);
        Task<IQueryable<Application>> GetAll();
        Task<Application?> GetById(int id);
    }
}
