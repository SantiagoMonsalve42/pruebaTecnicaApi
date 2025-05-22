using DATA.ModelData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NEGOCIO.Implementations;
using NEGOCIO.Interfaces;

namespace pruebaTecnicaApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController: BaseController
    {
        private readonly IEstudianteService _estudianteService;
        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }
        [HttpPost("AsignarMateria/{idMateria}/idEstudiante/{idEstudiante}")]
        public async Task<IActionResult> AsignarMateria(int idMateria,int idEstudiante)
        {
            var response = await _estudianteService.AsignarMateria(idEstudiante, idMateria);
            return Ok(response);
        }
        [HttpPost("Detalle/{idEstudiante}")]
        public async Task<IActionResult> Detalle( int idEstudiante)
        {
            var response = await _estudianteService.ConsultarDetalle(idEstudiante);
            return Ok(response);
        }
        [HttpDelete("DesasignarMateria/{idMateria}/idEstudiante/{idEstudiante}")]
        public async Task<IActionResult> DesasignarMateria(int idMateria, int idEstudiante)
        {
            var response = await _estudianteService.DesasignarMateria(idEstudiante, idMateria);
            return Ok(response);
        }
    }
}
