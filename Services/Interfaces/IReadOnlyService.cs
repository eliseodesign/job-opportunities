using job_opportunities_asp_react.Models.DTOs;
namespace job_opportunities_asp_react;

public interface IReadOnlyService
{
  public Task<ReadInfoDTO> getAllReadInfo();
}
