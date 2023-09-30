using job_opportunities_asp_react.Models.Entities;

namespace job_opportunities_asp_react.Services.Interfaces
{
    public interface IJobOfferService
    {
        Task<bool> Create(JobOffer model);
        Task<bool> Update(JobOffer model);
        Task<bool> Delete(int id);
        Task<IQueryable<JobOffer>> GetAll();
        Task<JobOffer?> GetById(int id);
    }
}
