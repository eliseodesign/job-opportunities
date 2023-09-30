using job_opportunities_asp_react.Models.Entities;
using job_opportunities_asp_react.Models.Repositories;
using job_opportunities_asp_react.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class JobOfferService : IJobOfferService
{
  private readonly IGenericRepository<JobOffer> JobOfferRepo;

  public JobOfferService(IGenericRepository<JobOffer> _JobOfferRepo){
    JobOfferRepo = _JobOfferRepo;
  }

    public Task<bool> Create(JobOffer model)
    {
      return JobOfferRepo.Create(model);
    }

    public Task<bool> Delete(int id)
    {
      return JobOfferRepo.Delete(id);
    }

    public Task<IQueryable<JobOffer>> GetAll()
    {
      return JobOfferRepo.GetAll();
    }

    public Task<JobOffer?> GetById(int id)
    {
      return JobOfferRepo.GetById(id);
    }

    public Task<bool> Update(JobOffer model)
    {
      return JobOfferRepo.Update(model);
    }
}
