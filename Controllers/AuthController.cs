using Microsoft.AspNetCore.Mvc;
using job_opportunities_asp_react.Models.Entities;
using job_opportunities_asp_react.Models.DTOs;
using job_opportunities_asp_react.Services;
using job_opportunities_asp_react.Services.Utils;

namespace job_opportunities_asp_react.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IApplicantService _applicantService;
    private readonly IEmailService _emailService;
    public AuthController(IApplicantService applicantService, IWebHostEnvironment webHostEnvironment, IEmailService emailService)
    {
      _applicantService = applicantService;
      _webHostEnvironment = webHostEnvironment;
      _emailService = emailService;
    }


    [HttpPost]
    [Route("login")]
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

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Reg([FromBody] Applicant usuario)
    {
      // if (usuario.Clave != usuario.ConfirmAccount)
      // {
      //     return BadRequest(Res.Provider("Las contraseñas no coinciden", "Error", false));
      // }

      if (await _applicantService.GetByEmail(usuario.Email) == null)
      {
        usuario.Password = UtilService.ConvertSHA256(usuario.Password);
        usuario.Token = UtilService.GenerateToken();
        usuario.RestartAccount = false;
        usuario.ConfirmAccount = false;
        bool respuesta = await _applicantService.Create(usuario);

        if (respuesta)
        {
          string content = this.GetFileContent("Pages/Templates/VerifyEmail.html");
          string url = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, "/api/auth/verify?token=" + usuario.Token);

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
          return BadRequest(Res.Provider(new {}, "No se pudo crear su cuenta", false));
        }
      }
      else
      {
        return BadRequest(Res.Provider(new {}, $"Ya existe un usuario registrado con {usuario.Email}", false));
      }
    }

    [HttpGet]
    [Route("verify")]
    public async Task<IActionResult> Confirm(string token)
    {
      bool result = await _applicantService.ConfirmarToken(token);
      if(result == true)
      {
         return Ok(Res.Provider("Cuenta confirmada", "Ya puede aplicar a ofertas", true));
      }
      else
      {
         return BadRequest(Res.Provider("Error al confirmar cuenta", "Error", false));
      }
    }

    [HttpGet("RestartAccount")]
    public async Task<IActionResult> RestartAccount()
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

          string htmlBody = string.Format(content, $"{usuario.FirstName} {usuario.LastName}", url);

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

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] ActualizarRequest request)
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
