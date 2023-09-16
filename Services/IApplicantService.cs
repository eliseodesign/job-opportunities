using job_opportunities_asp_react.Models.Entities;

namespace job_opportunities_asp_react.Services
{
    public interface IApplicantService
    {
        Task<bool> Create(Applicant model);
        Task<bool> Update(Applicant model);
        Task<bool> Delete(int id);
        Task<IQueryable<Applicant>> GetAll();
        Task<Applicant> GetById(int id);
        Task<Applicant> Validate(string email, string password);
        Task<Applicant> GetByEmail(string email);
        Task<bool> RestartAccount(bool restart, string password, string token);
        Task<bool> ConfirmarToken(string token);
    }
}
