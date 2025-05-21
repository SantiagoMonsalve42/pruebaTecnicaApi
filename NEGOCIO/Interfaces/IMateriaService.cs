using DTO.Common;

namespace NEGOCIO.Interfaces
{
    public interface IMateriaService
    {
        Task<HttpResponseDto> ObtenerMaterias();
        Task<HttpResponseDto> ObtenerDetalleMaterias(int id);
    }
}
