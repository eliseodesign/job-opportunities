using job_opportunities_asp_react.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace job_opportunities_asp_react.Models.Repositories
{
    public class ApplicationRepository : IGenericRepository<Application>
    {
        private readonly JobOpportunitiesContext db;
        public ApplicationRepository(JobOpportunitiesContext _db)
        {
            db = _db;
        }
        
        public async Task<bool> Create(Application model)
        {
            try
            {
                db.Applications.Add(model);
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
                Application Application = db.Applications.First(a => a.Id == id);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false; 
            }
        }
        public async Task<IQueryable<Application>> GetAll()
        {
            IQueryable<Application> query = db.Applications;
            return query;
        }
        public async Task<Application?> GetById(int id)
        {
            return await db.Applications.FindAsync(id);
        }
        public async Task<bool> Update(Application model)
        {
            try
            {
                db.Applications.Update(model);
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

