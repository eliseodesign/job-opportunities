using job_opportunities_asp_react.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace job_opportunities_asp_react.Models.Repositories
{
    public class ApplicantRepository : IGenericRepository<Applicant>
    {
        private readonly JobOpportunitiesContext db;
        public ApplicantRepository(JobOpportunitiesContext _db)
        {
            db = _db;
        }
        
        public async Task<bool> Create(Applicant model)
        {
            try
            {
                db.Applicants.Add(model);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Applicant applicant = db.Applicants.First(a => a.Id == id);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false; 
            }
        }
        public async Task<IQueryable<Applicant>> GetAll()
        {
            IQueryable<Applicant> query = db.Applicants;
            return query;
        }
        public async Task<Applicant> GetById(int id)
        {
            return await db.Applicants.FindAsync(id);
        }
        public async Task<bool> Update(Applicant model)
        {
            try
            {
                db.Applicants.Update(model);
                int affectedRows = await db.SaveChangesAsync();

                // Verificar si al menos una fila se actualizó
                return affectedRows > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}

