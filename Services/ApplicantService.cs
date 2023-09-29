using job_opportunities_asp_react.Models.Entities;
using job_opportunities_asp_react.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace job_opportunities_asp_react.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IGenericRepository<Applicant> repo;
        public ApplicantService(IGenericRepository<Applicant> _repo)
        {
            repo = _repo;
        }

        public async Task<bool> Create(Applicant model) {
            return await repo.Create(model);
        }
        
        public Task<bool> Delete(int id) => repo.Delete(id);

        public Task<IQueryable<Applicant>> GetAll() => repo.GetAll();

        public async Task<Applicant?> GetById(int id) => await repo.GetById(id);

        public Task<bool> Update(Applicant model) => repo.Update(model);

        /// <sumary>
        /// Login de usuario
        /// </sumary>
        public async Task<Applicant?> Validate(string email, string password)
        {
            try
            {
                var applicants = await repo.GetAll();
                var appl =  await applicants.FirstAsync(a => a.Email == email && a.Password == password);
                return appl;
            }
            catch 
            {
                return null;
            }

        }

        /// <sumary>
        /// Login de usuario
        /// </sumary>
        public async Task<Applicant?> GetByEmail(string email)
        {
            try
            {
                var applicants = await repo.GetAll();
                var appl = await applicants.FirstAsync(a => a.Email == email);
                return appl;
            }
            catch
            {
                return null;
            }

        }

        /// <sumary>
        /// Restablecer contraseña
        /// </sumary>
        public async Task<bool> RestartAccount(bool restart, string password, string token)
        {
            try
            {
                var aplicants = await repo.GetAll();
                Applicant existingApplicant = await aplicants.FirstAsync(a => a.Token == token);

                existingApplicant.RestartAccount = restart;
                existingApplicant.Password = password;

                await repo.Update(existingApplicant);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <sumary>
        /// Restablecer contraseña
        /// </sumary>
        public async Task<bool> ConfirmarToken(string token)
        {
            try
            {
                var aplicants = await repo.GetAll();
                Applicant existingApplicant = await aplicants.FirstAsync(a => a.Token == token);

                existingApplicant.ConfirmAccount = true;

                await repo.Update(existingApplicant);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
