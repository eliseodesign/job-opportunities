using job_opportunities_asp_react.Models.Entities;
using job_opportunities_asp_react.Models.Repositories;
using job_opportunities_asp_react.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ApplicationService : IApplicationService
{
  private readonly IGenericRepository<Application> ApplicationRepo;

  public ApplicationService(IGenericRepository<Application> _ApplicationRepo){
    ApplicationRepo = _ApplicationRepo;
  }

    public Task<bool> Create(Application model)
    {
      return ApplicationRepo.Create(model);
    }

    public Task<bool> Delete(int id)
    {
      return ApplicationRepo.Delete(id);
    }

    public Task<IQueryable<Application>> GetAll()
    {
      return ApplicationRepo.GetAll();
    }

    public Task<Application?> GetById(int id)
    {
      return ApplicationRepo.GetById(id);
    }

    public Task<bool> Update(Application model)
    {
      return ApplicationRepo.Update(model);
    }
}
