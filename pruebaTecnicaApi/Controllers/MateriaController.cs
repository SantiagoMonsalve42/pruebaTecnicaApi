using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIO.Interfaces;

namespace pruebaTecnicaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : BaseController
    {
        private readonly IMateriaService _materiaService;
        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }
        [HttpGet("ObtenerMaterias")]
        public async Task<IActionResult> ObtenerMaterias()
        {
            var response = await _materiaService.ObtenerMaterias();
            return Ok(response);
        }

        [HttpGet("ObtenerDetalleMaterias/{id}")]
        public async Task<IActionResult> ObtenerDetalleMaterias(int id)
        {
            var response = await _materiaService.ObtenerDetalleMaterias(id);
            return Ok(response);
        }
    }
}
