using job_opportunities_asp_react.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace job_opportunities_asp_react.Models.Repositories
{
    public class JobOfferReppository : IGenericRepository<JobOffer>
    {
        private readonly JobOpportunitiesContext db;
        public JobOfferReppository(JobOpportunitiesContext _db)
        {
            db = _db;
        }
        
        public async Task<bool> Create(JobOffer model)
        {
            try
            {
                db.JobOffers.Add(model);
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
                JobOffer JobOffer = db.JobOffers.First(a => a.Id == id);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false; 
            }
        }
        public async Task<IQueryable<JobOffer>> GetAll()
        {
            IQueryable<JobOffer> query = db.JobOffers;
            return query;
        }
        public async Task<JobOffer?> GetById(int id)
        {
            return await db.JobOffers.FindAsync(id);
        }
        public async Task<bool> Update(JobOffer model)
        {
            try
            {
                db.JobOffers.Update(model);
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

