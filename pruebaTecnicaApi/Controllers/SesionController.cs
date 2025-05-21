using DTO.Transport.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIO.Interfaces;

namespace pruebaTecnicaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : BaseController
    {
        private readonly ISesionService _sesionService;
        public SesionController(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _sesionService.Login(request.Username, request.Password);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost("Registro")]
        [AllowAnonymous]
        public async Task<IActionResult> Registro([FromBody] CrearEstudiante request)
        {
            var response = await _sesionService.Registro(request);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
