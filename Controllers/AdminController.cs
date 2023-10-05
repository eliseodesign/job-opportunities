using Microsoft.AspNetCore.Mvc;
using job_opportunities_asp_react.Models.Entities;
using job_opportunities_asp_react.Models.DTOs;
using job_opportunities_asp_react.Services;
using job_opportunities_asp_react.Services.Interfaces;
using job_opportunities_asp_react.Services.Utils;

namespace job_opportunities_asp_react.Controllers
{

  public class AdminController : Controller
  {

    private readonly IWebHostEnvironment _webHostEnvironment;
    public AdminController(IWebHostEnvironment webHostEnvironment)
    {
      _webHostEnvironment = webHostEnvironment;
    }

  }
}