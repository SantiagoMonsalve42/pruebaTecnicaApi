using DTO.Common;
using DTO.Transport.Request;

namespace NEGOCIO.Interfaces
{
    public interface ISesionService
    {
        Task<HttpResponseDto> Login(string username, string password);
        Task<HttpResponseDto> Registro(CrearEstudiante request);
    }
}
