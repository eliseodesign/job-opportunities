using job_opportunities_asp_react.Models.Entities;
namespace job_opportunities_asp_react;

/// <summary>
/// interface para repositorio de entidades solo delectura 
/// Country, EducationDegree, EducationLevel, EducationSubject, FieldSector, Gender and Marital Status
/// </summary>
public interface IReadOnlyRepository
{
  Task<IQueryable<Country>> getCountries();
  Task<IQueryable<EducationDegree>> getEduDegrees();
  Task<IQueryable<EducationLevel>> getEduLevels();
  Task<IQueryable<EducationSubject>> getEduSubjects();
  Task<IQueryable<FieldSector>> getSectors();
  Task<IQueryable<Gender>> getGenders();
  Task<IQueryable<MaritalStatus>> getMaritalStatus();
}
