using  job_opportunities_asp_react.Models.DTOs;

namespace job_opportunities_asp_react.Services.Utils;

public interface IEmailService
{
  bool SendEmail(EmailDTO emailDTO);
}
