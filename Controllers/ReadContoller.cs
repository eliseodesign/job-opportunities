using Microsoft.AspNetCore.Mvc;
using job_opportunities_asp_react.Models.DTOs;
using job_opportunities_asp_react.Services.Interfaces;
using job_opportunities_asp_react.Services.Utils;

namespace job_opportunities_asp_react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        private readonly IReadOnlyService ReadService;

        public ReadController(IReadOnlyService _ReadService)
        {
            ReadService = _ReadService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetInfo()
        {
            ReadInfoDTO result = await ReadService.getAllReadInfo();
            return Ok(Res.Provider(new {
                Countries = result.Countries.ToList(),
                EducationDegrees = result.EducationDegrees.ToList(),
                EducationLevels = result.EducationLevels.ToList(),
                EducationSubjects = result.EducationSubjects.ToList(),
                FieldSectors = result.FieldSectors.ToList(),
                Genders = result.Genders.ToList(),
                MaritalStatuses = result.MaritalStatuses.ToList()
            }, "Operación exitosa", true));
        }
    }
}
