using job_opportunities_asp_react.Models.Entities;

namespace job_opportunities_asp_react;

public class ReadOnlyRepository : IReadOnlyRepository
{
    private readonly JobOpportunitiesContext db;
    public ReadOnlyRepository(JobOpportunitiesContext _db){
        db = _db;
    }

    public async Task<IQueryable<Country>> getCountries()
    {
        return db.Countries;
    }

    public async Task<IQueryable<EducationDegree>> getEduDegrees()
    {
        return db.EducationDegrees;
    }

    public async Task<IQueryable<EducationLevel>> getEduLevels()
    {
        return db.EducationLevels;
    }

    public async Task<IQueryable<EducationSubject>> getEduSubjects()
    {
        return db.EducationSubjects;
    }

    public async Task<IQueryable<Gender>> getGenders()
    {
        return db.Genders;
    }

    public async Task<IQueryable<MaritalStatus>> getMaritalStatus()
    {
        return db.MaritalStatuses;
    }

    public async Task<IQueryable<FieldSector>> getSectors()
    {
        return db.FieldSectors;
    }
}
