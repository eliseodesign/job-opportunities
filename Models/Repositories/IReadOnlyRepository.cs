using job_opportunities_asp_react.Models.Entities;
namespace job_opportunities_asp_react;

/// <summary>
/// interface para repositorio de entidades solo delectura 
/// Country, EducationDegree, EducationLevel, EducationSubject, FieldSector, Gender and Marital Status
/// </summary>
public interface IReadOnlyRepository
{
  IQueryable<Country> getCountries();
  IQueryable<EducationDegree> getEduDegrees();
  IQueryable<EducationLevel> getEduLevels();
  IQueryable<EducationSubject> getEduSubjects();
  IQueryable<FieldSector> getSectors();
  IQueryable<Gender> getGenders();
  IQueryable<MaritalStatus> getMaritalStatus();
}
