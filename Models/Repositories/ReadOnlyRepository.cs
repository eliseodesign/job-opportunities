using job_opportunities_asp_react.Models.Entities;

namespace job_opportunities_asp_react;

public class ReadOnlyRepository : IReadOnlyRepository
{
    private readonly JobOpportunitiesContext db;
    public ReadOnlyRepository(JobOpportunitiesContext _db){
        db = _db;
    }

    public IQueryable<Country> getCountries()
    {
        return db.Countries;
    }

    public IQueryable<EducationDegree> getEduDegrees()
    {
        return db.EducationDegrees;
    }

    public IQueryable<EducationLevel> getEduLevels()
    {
        return db.EducationLevels;
    }

    public IQueryable<EducationSubject> getEduSubjects()
    {
        return db.EducationSubjects;
    }

    public IQueryable<Gender> getGenders()
    {
        return db.Genders;
    }

    public IQueryable<MaritalStatus> getMaritalStatus()
    {
        return db.MaritalStatuses;
    }

    public IQueryable<FieldSector> getSectors()
    {
        return db.FieldSectors;
    }
}
