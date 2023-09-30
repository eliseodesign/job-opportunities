using job_opportunities_asp_react.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace job_opportunities_asp_react.Models.Repositories
{
    public class EmployerRepository : IGenericRepository<Employer>
    {
        private readonly JobOpportunitiesContext db;
        public EmployerRepository(JobOpportunitiesContext _db)
        {
            db = _db;
        }
        
        public async Task<bool> Create(Employer model)
        {
            try
            {
                db.Employers.Add(model);
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
                Employer Employer = db.Employers.First(a => a.Id == id);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false; 
            }
        }
        public async Task<IQueryable<Employer>> GetAll()
        {
            IQueryable<Employer> query = db.Employers;
            return query;
        }
        public async Task<Employer?> GetById(int id)
        {
            return await db.Employers.FindAsync(id);
        }
        public async Task<bool> Update(Employer model)
        {
            try
            {
                db.Employers.Update(model);
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

