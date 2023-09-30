using job_opportunities_asp_react.Models.Entities;
namespace job_opportunities_asp_react;

/// <summary>
/// información de lectura enviada al frontend para crear registros
/// </summary>
public class ReadInfoDTO
{
  public IQueryable<Country> Countries;
  public IQueryable<EducationDegree> EducationDegrees;
  public IQueryable<EducationLevel> EducationLevels;
  public IQueryable<EducationSubject> EducationSubjects;
  public IQueryable<FieldSector> FieldSectors;
  public IQueryable<Gender> Genders;
  public IQueryable<MaritalStatus> MaritalStatuses;
}
