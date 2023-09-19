using Microsoft.AspNetCore.Mvc;
using job_opportunities_asp_react.Models.Repositories;
using job_opportunities_asp_react.Models.Entities;
using job_opportunities_asp_react.Models.DTOs;
using job_opportunities_asp_react.Services;
using job_opportunities_asp_react.Services.Utils;

namespace WebAppCorreo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IApplicantService _applicantService;
    private readonly IEmailService _emailService;
    public AuthController(ApplicantService applicantService, IWebHostEnvironment webHostEnvironment, IEmailService emailService)
    {
      _applicantService = applicantService;
      _webHostEnvironment = webHostEnvironment;
      _emailService = emailService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
      Applicant usuario = await _applicantService.Validate(request.Correo, UtilService.ConvertSHA256(request.Clave));

      if (usuario != null)
      {
        if (usuario.ConfirmAccount == false)
        {
          return BadRequest(Res.Provider($"Falta confirmar su cuenta. Se le envió un correo a {request.Correo}", "Error", false));
        }
        else if (usuario.RestartAccount == true)
        {
          return BadRequest(Res.Provider($"Se ha solicitado RestartAccount su cuenta, favor revise su bandeja del correo {request.Correo}", "Error", false));
        }
        else
        {
          // Aquí puedes devolver una respuesta de éxito personalizada si es necesario
          return Ok(Res.Provider("Login exitoso", "Operación exitosa", true));
        }
      }
      else
      {
        return NotFound(Res.Provider("No se encontraron coincidencias", "Error", false));
      }
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] Applicant usuario)
    {
      // if (usuario.Clave != usuario.ConfirmAccount)
      // {
      //     return BadRequest(Res.Provider("Las contraseñas no coinciden", "Error", false));
      // }

      if (_applicantService.GetByEmail(usuario.Email) == null)
      {
        usuario.Password = UtilService.ConvertSHA256(usuario.Password);
        usuario.Token = UtilService.GenerateToken();
        usuario.RestartAccount = false;
        usuario.ConfirmAccount = false;
        bool respuesta = await _applicantService.Create(usuario);

        if (respuesta)
        {
          string content = this.GetFileContent("Pages/Templates/VerifyEmail.html");
          string url = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, "/Inicio/Confirmar?token=" + usuario.Token);

          string htmlBody = string.Format(content, $"{usuario.FirstName} {usuario.LastName}", url);

          EmailDTO EmailDTO = new EmailDTO()
          {
            To = usuario.Email,
            Subject = "Correo confirmación",
            Content = htmlBody
          };

          bool enviado = _emailService.SendEmail(EmailDTO);
          return Ok(Res.Provider($"Su cuenta ha sido creada. Hemos enviado un mensaje al correo {usuario.Email} para confirmar su cuenta", "Operación exitosa", true));
        }
        else
        {
          return BadRequest(Res.Provider("No se pudo crear su cuenta", "Error", false));
        }
      }
      else
      {
        return BadRequest(Res.Provider("El correo ya se encuentra registrado", "Error", false));
      }
    }

    [HttpGet("Confirmar")]
    public IActionResult Confirmar(string token)
    {
      return Ok(Res.Provider(new { token = token }, "Operación exitosa", true));
    }

    [HttpGet("RestartAccount")]
    public IActionResult RestartAccount()
    {
      return Ok(Res.Provider("RestartAccount", "Operación exitosa", true));
    }

    [HttpPost("RestartAccount")]
    public async Task<IActionResult> RestartAccount([FromBody] RestartAccountRequest request)
    {
      Applicant usuario = await _applicantService.GetByEmail(request.Correo);
      if (usuario != null)
      {
        bool respuesta = await _applicantService.RestartAccount(true, usuario.Password, usuario.Token);

        if (respuesta)
        {

          string content = this.GetFileContent("Pages/Templates/ResetEmail.html");
          string url = string.Format("{0}://{1}{2}", Request.Scheme, Request.Headers["host"], "/Inicio/Actualizar?token=" + usuario.Token);

          string htmlBody = string.Format(content,$"{usuario.FirstName} {usuario.LastName}", url);

          EmailDTO emailDTO = new EmailDTO()
          {
            To = request.Correo,
            Subject = "RestartAccount cuenta",
            Content = htmlBody
          };

          bool enviado = _emailService.SendEmail(emailDTO);
          return Ok(Res.Provider("Restablecido", "Operación exitosa", true));
        }
        else
        {
          return BadRequest(Res.Provider("No se pudo RestartAccount la cuenta", "Error", false));
        }
      }
      else
      {
        return BadRequest(Res.Provider("No se encontraron coincidencias con el correo", "Error", false));
      }
    }

    [HttpGet("Actualizar")]
    public IActionResult Actualizar(string token)
    {
      return Ok(Res.Provider("Actualizar", "Operación exitosa", true));
    }

    [HttpPost("Actualizar")]
    public async Task<IActionResult> Actualizar([FromBody] ActualizarRequest request)
    {
      if (request.Clave != request.ConfirmAccount)
      {
        return BadRequest(Res.Provider("Las contraseñas no coinciden", "Error", false));
      }

      bool respuesta = await _applicantService.RestartAccount(false, UtilService.ConvertSHA256(request.Clave), request.Token);

      if (respuesta)
      {
        return Ok(Res.Provider("Restablecido", "Operación exitosa", true));
      }
      else
      {
        return BadRequest(Res.Provider("No se pudo actualizar", "Error", false));
      }
    }

    public class LoginRequest
    {
      public string Correo { get; set; }
      public string Clave { get; set; }
    }

    public class RestartAccountRequest
    {
      public string Correo { get; set; }
    }

    public class ActualizarRequest
    {
      public string Token { get; set; }
      public string Clave { get; set; }
      public string ConfirmAccount { get; set; }
    }

    private string GetFileContent(string filePath)
    {
      string basePath = _webHostEnvironment.ContentRootPath;
      string fullPath = Path.Combine(basePath, filePath);

      if (System.IO.File.Exists(fullPath))
      {
        return System.IO.File.ReadAllText(fullPath);
      }

      throw new FileNotFoundException("El archivo no existe", fullPath);
    }
  }
}
