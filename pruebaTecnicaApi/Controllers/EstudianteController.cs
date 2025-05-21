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
        public async Task<IActionResult> ObtenerDetalleMaterias(int idMateria,int idEstudiante)
        {
            var response = await _estudianteService.AsignarMateria(idEstudiante, idMateria);
            return Ok(response);
        }
    }
}
